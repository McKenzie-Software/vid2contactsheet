## Powershell Details

00_runner.ps1 runs the following scripts:
- 01_generate_timed_frames
- 02_generate_metadata
- 03_generate_contact_sheet
- 
04_generate_snapshot_previews.ps1 is ran by itself and is used for generating the previews in tab Previews

05_generate_gif.ps1 is ran by itself and is used for generating the gif.

## Execution Policy
00_runner.ps1 has the following in it to set execution policy per process basis, meaning the execution policy is not changed for the whole system.

`Set-ExecutionPolicy Bypass -Scope Process`

You can comment this out of 00_runner.ps1 but note that the execution policy of the machine will need to be manually modified to allow the scripts to run.