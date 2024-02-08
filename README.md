# NCAA-DB-Editor
DB/Save Editor for NCAA Football series on PS2/Xbox/PSP/GC Consoles

This editor was designed using original source code from Madden Xtreme DB Editor (elguapo) and MaddenAMP (Colin Goudie/stringray68) and uses tdbaccess library from Artem Khassanov of NHLView.


# History

Feb 07, 2024
This version has a lot of experimental features in it! 
* Re-wrote a lot of the code for optimization
* Improved Off-Season save handling
* Added Randomization of Recruits and Walk-Ons in Dynasty Save files (Off-Season)
* Added ability to modify number of "interested teams" in recruiting phase (Off-Season)
* Added tools to mess around with recruiting point distribution (Off-Season)
* Added Coaching Budget randomization feature (Reg Season)
* Added QB Tendancies Re-Calculation (Reg. Season)

All of the Off-Season modules allow users to custom tweak the amount of chaos you want to add to your dynasty.

Feb 05, 2024
* FIXED loading in-season saves and non-dynasty files (like strmdata.db and league.dat)
* Does not allow IMPORTING in Dynasty/TEAM table. (this will crash your dynasty)
* Added ability to open off-season database table! (See below for info!)
* Added QB Tendency re-calculator to add more scrambling QB types
* Tweaks for efficiency
* Auto-Deletes temporary *.db files after closing
* Fixed bugs when opening up non-dynasty files
* PSU/Action Replay MAX save compatibility is improved BUT DO NOT WORK with off-season saves. Only in-season dynasties will work!

This can now view off-season saves! To do this, click OPTIONS, ENABLE Off-Season Save. Then load a save file from the offseason! I recommend checking it out after PLAYERS LEAVING and BEFORE Recruiting. This will let you see and edit the Recruits Database! There is also a WALKONs Database you can edit at anytime prior to them being added to rosters later on, among other things that I have not fully determine the meanings of yet! Happy discoveries!

Feb 01, 2024
* Fixed saving PSU files
* Fixed saving off-season save files
* Added Confirmation Boxes
* Added List of Medical Redshirts & Coach Prestige Changes 
* UI Updates and Icons :slight_smile:
* New Folder Structure
* Dumps an off-season DB save file for your viewing pleasure
* Disabled Player/Team Tab for now as they don't serve any real purpose yet