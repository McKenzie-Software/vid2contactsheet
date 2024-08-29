param (
    [Parameter(Mandatory=$true)]
    [string]$videoFilePath,

    [Parameter(Mandatory=$true)]
    [string]$outputDirectory,
    
    [Parameter(Mandatory=$true)]
    [string]$ffprobePath,

    [Parameter(Mandatory=$true)]
    [string]$ffmpegPath,

    [Parameter(Mandatory=$true)]
    [int]$length
)

# Get the duration of the video using ffprobe
$duration = & $ffprobePath -v error -show_entries format=duration -of default=noprint_wrappers=1:nokey=1 $videoFilePath -hide_banner -loglevel warning

# Calculate the start time (halfway point)
$halfwayPoint = [math]::Round([double]$duration / 2, 2)

# Set the output file name
$outputFilePath = Join-Path $outputDirectory "generated_preview.gif" #change .gif to webm if wanting to generate a webm instead

# Run ffmpeg to create the GIF
& $ffmpegPath -ss $halfwayPoint -i $videoFilePath -t $length -vf "fps=10,scale=540:-1:flags=lanczos,setsar=1:1" $outputFilePath -hide_banner -loglevel warning
## change the above code to this:
# & $ffmpegPath -ss $halfwayPoint -i $videoFilePath -t $length -c:v libvpx-vp9 -b:v 1M -vf "scale=540:-1:flags=lanczos" $outputFilePath
# if you want to generate a webm instead

Write-Host "GIF has been generated and saved to: $outputFilePath"