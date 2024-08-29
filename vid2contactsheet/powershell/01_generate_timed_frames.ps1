param (
    [Parameter(Mandatory=$true)]
    [string]$videoFilePath,

    [Parameter(Mandatory=$true)]
    [string]$frameDirectory,

    [Parameter(Mandatory=$true)]
    [string]$annotatedFrameDirectory,

    [Parameter(Mandatory=$true)]
    [string]$ffmpegPath,

    [Parameter(Mandatory=$true)]
    [string]$imagemagickPath,

    [Parameter(Mandatory=$false)]
    [int]$frameCount
)

if(-not $frameCount)
{
    Write-Host "Warning: Frame Count not supplied, defaulting to 16." -ForegroundColor Yellow
    $frameCount = 16
}

# Add 2 additional frames because I've fucked up somewhere and it always generates 2 less.
$frameCount = $frameCount + 2;

# Create the output folder if it doesn't exist
if (-Not (Test-Path $frameDirectory)) {
    New-Item -ItemType Directory -Path $frameDirectory | Out-Null
}

# Get the video duration in seconds
$duration = & "$ffmpegPath" -i $videoFilePath 2>&1 | Select-String "Duration" | ForEach-Object { #-hide_banner -loglevel warning
    if ($_ -match "Duration: (\d+):(\d+):(\d+)\.(\d+)") {
        $hours = [int]$matches[1]
        $minutes = [int]$matches[2]
        $seconds = [int]$matches[3]
        $milliseconds = [int]$matches[4]
        ($hours * 3600) + ($minutes * 60) + $seconds + ($milliseconds / 100)
    }
}

# Calculate the interval between frames
$interval = $duration / ($frameCount - 1)

Write-Host "Interval between frames is $interval"

# Loop to extract frames
for ($i = 0; $i -lt $frameCount; $i++) {
    $timestamp = [math]::Round($i * $interval, 2)
    $formattedTime = [TimeSpan]::FromSeconds($timestamp).ToString("hh\:mm\:ss\.ff")
    $outputFile = Join-Path $frameDirectory ("frame_$timestamp.png")
    #Clear-Host
    Write-Host "Timestamp in Seconds: $timestamp"

    Write-Host "Generating frame with ffmpeg"
    & "$ffmpegPath" -ss $formattedTime -i $videoFilePath -frames:v 1 $outputFile -y #-hide_banner -loglevel warning

    Write-Host "Annotating image with timestamp using imagemagick"
    & "$imagemagickPath" $outputFile -gravity south -background black -splice 0x90 -pointsize 76 -fill white  -annotate +10+10 "$formattedTime" $annotatedFrameDirectory\annotated_$i.png
}

# delete empty frame
Remove-item -Path $frameDirectory\frame_0.png
Remove-item -Path $annotatedFrameDirectory\annotated_0.png

Write-Output "Extracted $frameCount frames to $frameDirectory"