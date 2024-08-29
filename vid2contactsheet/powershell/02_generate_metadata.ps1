param (
    [Parameter(Mandatory=$true)]
    [string]$videoFilePath,

    [Parameter(Mandatory=$true)]
    [string]$outputDirectory,
    
    [Parameter(Mandatory=$true)]
    [string]$ffprobePath
)

# Function to run ffprobe and handle errors
function Get-VideoMetadata {
    param (
        [string]$ffprobePath,
        [string]$videoFilePath
    )

    try {
        # Run ffprobe to get the video metadata in JSON format
        $jsonOutput = & "$ffprobePath" -v quiet -print_format json -show_format -show_streams "$videoFilePath"
        
        if ($LASTEXITCODE -ne 0) {
            throw "ffprobe failed with exit code $LASTEXITCODE. Please check the file path or ffprobe installation."
        }

        # Convert the JSON output to a PowerShell object
        return $jsonOutput | ConvertFrom-Json
    }
    catch {
        Write-Host "Error: $_" -ForegroundColor Red
        exit 1
    }
}

# Function to safely parse bitrate
function Safe-ParseBitrate {
    param (
        [string]$bitrateString
    )
    
    if ([string]::IsNullOrWhiteSpace($bitrateString)) {
        return 0
    }
    
    try {
        return [math]::round([double]::Parse($bitrateString) / 1000)
    }
    catch {
        Write-Host "Error parsing bitrate: $bitrateString" -ForegroundColor Red
        return 0
    }
}

# Get metadata
$metadata = Get-VideoMetadata -ffprobePath $ffprobePath -videoFilePath $VideoFilePath

# Extract the filename, size, duration, and bitrate
$filename = Split-Path $metadata.format.filename -leaf
$filesize = [double]::Parse($metadata.format.size)
$duration = [math]::round([double]::Parse($metadata.format.duration))
$bitrate = [math]::round([double]::Parse($metadata.format.bit_rate) / 1000)

# Convert duration to HH:mm:ss format
$timespan = New-TimeSpan -Seconds $duration
$formattedDuration = $timespan.ToString("hh\:mm\:ss")

# Determine file size display format (GiB or MiB)
if ($filesize -ge 1GB) {
    $formattedSize = "{0:N2} GiB" -f ($filesize / 1GB)
} else {
    $formattedSize = "{0:N2} MiB" -f ($filesize / 1MB)
}

# Prepare output
$output = @()
$output += "File: $filename"
$output += "Size: $filesize bytes ($formattedSize), Duration: $formattedDuration, Avg Bitrate: $bitrate kb/s"

# Loop through each stream and prepare audio and video information
foreach ($stream in $metadata.streams) {
    if ($stream.codec_type -eq "video") {
        $videoCodec = $stream.codec_name
        $videoFormat = $stream.pix_fmt
        $resolution = "$($stream.width)x$($stream.height)"
        $videoBitrate = Safe-ParseBitrate -bitrateString $stream.bit_rate
        $frameRate = try {
            [math]::round([double]::Parse($stream.avg_frame_rate.Split("/")[0]) / [double]::Parse($stream.avg_frame_rate.Split("/")[1]), 2)
        }
        catch {
            Write-Host "Error calculating frame rate: $($_.Exception.Message)" -ForegroundColor Red
            0
        }
        $output += "Video: $videoCodec, $videoFormat, $resolution, $videoBitrate kb/s, ${frameRate}fps(r) ($($stream.tags.language))"
    }
    elseif ($stream.codec_type -eq "audio") {
        $audioCodec = $stream.codec_name
        $sampleRate = $stream.sample_rate
        $channels = $stream.channels
        $audioBitrate = Safe-ParseBitrate -bitrateString $stream.bit_rate
        $output += "Audio: $audioCodec, $sampleRate Hz, $channels channels, s16, $audioBitrate kb/s ($($stream.tags.language))"
    }
}

# add note of where this app comes from to the script
$output += "Made with vid2contactsheet v1.0 @ github.com/mckenzie-software/vid2contactsheet"

# Save output to file
$outputDirectory = "$outputDirectory\metadata.txt"
$output | Out-File -FilePath $outputDirectory -Encoding utf8

# Inform the user
Write-Host "Metadata has been saved to $outputDirectory" -ForegroundColor Green