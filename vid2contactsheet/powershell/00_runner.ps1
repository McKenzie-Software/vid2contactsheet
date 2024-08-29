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
    [string]$ffprobePath,

    [Parameter(Mandatory=$true)]
    [string]$outputDirectory,

    [Parameter(Mandatory=$true)]
    [int]$frameCount,

    [Parameter(Mandatory=$true)]
    [string]$imageMagickPath,

    [Parameter(Mandatory=$false)]
    [string]$contactSheetResolution
)

# Validate Paths
function Validate-Path {
    param (
        [string]$path
    )

    if (-not (Test-Path $path)) {
        Write-Host "Error: Path not found - $path" -ForegroundColor Red
        exit 1
    }
}

# Validate parameters
Validate-Path $frameDirectory
Validate-Path $annotatedFrameDirectory
Validate-Path $ffmpegPath
Validate-Path $ffprobePath
Validate-Path $outputDirectory
Validate-Path $imageMagickPath

# Define paths for metadata file
$metadataFilePath = Join-Path -Path $outputDirectory -ChildPath "metadata.txt"

# Bypass execution policy temporarily
Set-ExecutionPolicy Bypass -Scope Process

#$currentDirectory = (Get-Location).path

# Generate frames
Write-Host "Generating timed frames..."
try {
    #$currentDirectory\powershell
    & ".\powershell\01_generate_timed_frames.ps1" -videoFilePath $videoFilePath -frameDirectory $frameDirectory -annotatedFrameDirectory $annotatedFrameDirectory -ffmpegPath $ffmpegPath -imagemagickPath $imageMagickPath -frameCount $frameCount
} catch {
    Write-Host "Error during frame generation: $_" -ForegroundColor Red
    exit 1
}

Start-Sleep -Seconds 2

# Generate metadata
Write-Host "Generating metadata..."
try {
    & ".\powershell\02_generate_metadata.ps1" -videoFilePath $videoFilePath -outputDirectory $outputDirectory -ffprobePath $ffprobePath
} catch {
    Write-Host "Error during metadata generation: $_" -ForegroundColor Red
    exit 1
}

Start-Sleep -Seconds 2

# Generate contact sheet
Write-Host "Generating contact sheet..."
try {
    & ".\powershell\03_generate_contact_sheet.ps1" -metadataFilePath $metadataFilePath -annotatedFrameDirectory $annotatedFrameDirectory -outputDirectory $outputDirectory -imagemagickPath $imageMagickPath -resolution $contactSheetResolution
} catch {
    Write-Host "Error during contact sheet generation: $_" -ForegroundColor Red
    exit 1
}

Write-Host "Process completed successfully."