param (
    [Parameter(Mandatory=$true)]
    [string]$ffmpegPath,

    [Parameter(Mandatory=$true)]
    [string]$ffprobePath,

    [Parameter(Mandatory=$true)]
    [string]$videoFilePath,

    [Parameter(Mandatory=$true)]
    [string]$outputDirectory
)

# Ensure the output folder exists
if (-not (Test-Path -Path $outputDirectory)) {
    New-Item -ItemType Directory -Path $outputDirectory
}

# Get the duration of the video in seconds using ffprobe
$duration = & $ffprobePath -v error -show_entries format=duration -of default=noprint_wrappers=1:nokey=1 $videoFilePath -hide_banner -loglevel warning
$duration = [math]::Round([double]$duration)

# Calculate timestamps
$timestamp1 = 60                            # 10 seconds
$timestamp2 = [math]::Round($duration / 2)  # Halfway point
$timestamp3 = $duration - 120               # 2 minutes before the end

# Function to generate snapshot for a keyframe only
function Generate-KeyframeSnapshot {
    param ($ffmpegPath, $videoFilePath, $timestamp, $outputFile)
    & $ffmpegPath -skip_frame nokey -ss $timestamp -i $videoFilePath -frames:v 1 $outputFile -hide_banner -loglevel warning
}

# Generate snapshots for keyframes
Generate-KeyframeSnapshot -ffmpegPath $ffmpegPath -videoFilePath $videoFilePath -timestamp $timestamp1 -outputFile "$outputDirectory\preview1.png" -hide_banner -loglevel warning
Generate-KeyframeSnapshot -ffmpegPath $ffmpegPath -videoFilePath $videoFilePath -timestamp $timestamp2 -outputFile "$outputDirectory\preview2.png" -hide_banner -loglevel warning
Generate-KeyframeSnapshot -ffmpegPath $ffmpegPath -videoFilePath $videoFilePath -timestamp $timestamp3 -outputFile "$outputDirectory\preview3.png" -hide_banner -loglevel warning

Write-Output "Keyframe snapshots have been saved to $outputDirectory"
