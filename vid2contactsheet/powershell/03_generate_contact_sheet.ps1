param (
    [Parameter(Mandatory=$true)]
    [string]$metadataFilePath,

    [Parameter(Mandatory=$true)]
    [string]$annotatedFrameDirectory,

    [Parameter(Mandatory=$true)]
    [string]$outputDirectory,

    [Parameter(Mandatory=$true)]
    [string]$imagemagickPath,

    [Parameter(Mandatory=$false)]
    [string]$resolution
)

# Load the .NET assembly for image handling
Add-Type -AssemblyName System.Drawing

# Read metadata from the file
$metadataText = Get-Content -Path $metadataFilePath -Raw

if (-not $imagemagickPath) {
    Write-Error "Error: Imagemagick path is required." -ForegroundColor Red
    exit 1
}

# List and sort images numerically based on the suffix
$annotatedFiles = Get-ChildItem -Path $annotatedFrameDirectory -Filter "annotated_*.png" | Sort-Object { [int]($_.BaseName -replace 'annotated_', '') }

# Create a list of image paths
$imagePaths = $annotatedFiles | ForEach-Object { $_.FullName }

# Generate the contact sheet with sorted images
$contactSheetPath = "$outputDirectory\contact_sheet.png"
& "$imagemagickPath" montage @($imagePaths) -tile 4x -geometry +0+0 $contactSheetPath

# Load contact sheet dimensions
$contactSheetFromSystem = [System.Drawing.Image]::FromFile($contactSheetPath)
$contactSheetWidth = $contactSheetFromSystem.Width
$contactSheetHeight = $contactSheetFromSystem.Height
$contactSheetFromSystem.Dispose()

# Define dimensions for the black box
$blackBoxHeight = 280
$blackBoxWidth = $contactSheetWidth

# Create the black box with text
$blackBoxPath = "$outputDirectory\black_box.png"
& "$imagemagickPath" -size ${blackBoxWidth}x$blackBoxHeight xc:black -font Arial -pointsize 46 -fill white -gravity NorthWest -annotate +10+10 "$metadataText" $blackBoxPath

# Create a new blank image with additional height (only top space)
$newImagePath = "$outputDirectory\new_image_with_contact_sheet.png"
& "$imagemagickPath" -size ${contactSheetWidth}x$($blackBoxHeight + $contactSheetHeight) xc:black $newImagePath

# Composite the black box and contact sheet into the new image
$finalSheetPath = "$outputDirectory\final_contact_sheet.png"
& "$imagemagickPath" $newImagePath $blackBoxPath -geometry +0+0 -composite $contactSheetPath -geometry +0+$blackBoxHeight -colorspace sRGB -composite $finalSheetPath 

# Compress and overwrite the final contact sheet if resolution is specified
if (-not [string]::IsNullOrEmpty($resolution)) {
    & "$imagemagickPath" $finalSheetPath -resize $resolution -quality 85 $finalSheetPath
}

# Remove left overs
Remove-Item $contactSheetPath 
Remove-Item $blackBoxPath 
Remove-Item $newImagePath 