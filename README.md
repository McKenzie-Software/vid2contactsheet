# vid2contactsheet
Generate Contact Sheets and more in a friendly GUI using ffmpeg, ffprobe and ImageMagick

## Output
Video file used [Steamboat Willie (1928) by Walt Disney](https://commons.wikimedia.org/wiki/File:Steamboat_Willie_(1928)_by_Walt_Disney.webm)

### Contact Sheet
![final_contact_sheet](https://github.com/user-attachments/assets/37635195-c1be-4aab-b14f-0a64535e10ec)

### GIF
![generated_preview](https://github.com/user-attachments/assets/98171984-09ac-4d4b-a820-38255049bfa1)

# Usage
Open `vid2contactsheet.exe` 

You will be asked if you want to download the required executables or do it [manually]()

Select your video file and click start.  You can modify frame count and contact sheet resolution on the Configuration tab.

Go through each tab and generate what you want.

# Build from Source

Debug Build:
`dotnet build vid2contactsheet.sln -c Debug /p:Version=1.0.0 /p:Authors="McKenzie Software & Contributors" /p:Copyright="McKenzie Software (c) 2024"`

Release Build:
`dotnet build vid2contactsheet.sln -c Debug /p:Version=1.0.0 /p:Authors="McKenzie Software & Contributors" /p:Copyright="McKenzie Software (c) 2024"`