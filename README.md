# NCAA Database Editor
DB/Save Editor for NCAA Football series on PS2/Xbox/PSP/GC Consoles

This editor was designed using original source code from Madden Xtreme DB Editor (elguapo) and MaddenAMP (Colin Goudie/stringray68) and uses tdbaccess library from Artem Khassanov of NHLView.


## Deployment

Publish the application using the modern tooling with:

```bash
dotnet publish NCAA_XDBE/NCAA_XDBE.csproj -c Release
```

The ClickOnce package is created in the `publish/` directory.

# New Features
* Added better compatibility with NCAA PS2 Games and PS2 in general as well as PS3/360 game titles that use TDB
* Ability to view, edit and save NCAA off-season save files  (click Options, Load Off-Season Save, Reload save file)
* Faster, more optimized database editing, loading, saving, etc.
* Added DB Tools & Modules

# Available Modules

League Editor
* Fully Customize Conference, Team, Bowl and Schedules in your own League Setup
* Ability to edit Dynasties or default League.DAT data to create your own game
* Requires modding files from game and creating a new game iso rom
* https://www.ncaanext.com/p/ncaa-db-editor-league-creator.html

Team Editor
* Fully working Team Editor tab
* Change College Names
* Change Prestige Ratings
* Update NCAA Investigation & Sanctions
* Stadium Updater
* Head Coach Editor
* Playbook and Strategy Editor
* FIRE COACH button
* Change User Coach/Team
* Select Team Captains
* Select 4 Impact Players
* Change Team Colors
* Generate Fantasy Roster per Team
* Apply DEATH PENALTY

Player Editor
* Edit Player Names & Attributes
* Edit Player Gear
* Force Players to Graduate/Go Pro or Transfer
* Automatically updates Overall Ratings

Coach Editor
* Edit Coach names and attributes
* Change Coach Strategies and Playbooks
* View Coaching Stats
* Auto-Adjust Coaching Budgets
* Coach Prestige Progression
* Randomize Free Agent Coaches
* Change Coach Performance

Conference Editor
* Swap teams between conferences
* Add/Remove FBS and FCS teams
* Reschedules as needed
* Creates fantasy rosters for FCS teams automatically

Schedule Viewer
* Full Schedule Viewer
* Team Comparison Chart
* OOC Re-Scheduler

Stat Viewr
* Ranking Lists
* Top Players

Stadium Editor
* Stadium Editor
* Realistic Weather Importer

Recruit Editor
* Edit Recruits
* Change Interested Teams
* Change Athletes

Recruiting Tools
* Team Points Editor
* Global Interested Teams Editor
* Randomize Recruits & Walk-Ons
* Randomize Names
* Randomize Faces
* Polynesian Generator
* Determine Best Athletes
* Update Recruit Rankings

Transfer Portal
* Adds a full transfer Portal to DB Editor

Coaching Carousel
* Adds a full coaching carousel
* Generate new coaches from existing players

Depth Chart Editor
* Full Depth Chart Editor

Bowl Editor
* Edit Bowl Names and matchups

DB Tools
* Fantasy Roster Generator
* Depth Chart Automatated Setter
* Team Rating Calculation
* Roster Filler
* Body Size Fixer
* Speed Enhancer
* QB Tendency Fixer
* Randomize Player Potential
* Randomize Face/Hair/Head
* Global Ratings Editor

Dynasty Tools (In-Season)
* Add Pre-Season Injuries with Player Regression
* Medical Redshirting with Player Regression
* Coaching Progression/Re-Rating for CPU
* Coaching Carousel + Coach Leaving Transfer Portal
* Randomize Coaching Budgets
* Auto Conference Realignment
* Transfer Chaos Mode
* Players -> Coaches
* Randomize "Free Agent" Coach Prestige

Recruiting Tools (DB2 save!)
* Redistribute Recruiting Point Minimum
* Remove Interested Teams from Recruits
* Randomize Recruits
* Randomize Walk-Ons

STRMDATA Tools
* Body Shape Fixer for RCAT Recruiting Database
* Uniform Editor

Playbook AI Editor
* Edit AI play calling for each playbook


## Notes
Users can fully customize files in RESOURCES folder to meet the mods they are using! 

## Help

[NCAA Database Editor Manual.docx](https://github.com/user-attachments/files/17964514/NCAA.Database.Editor.Manual.docx)


League Editor Instructions: https://www.ncaanext.com/p/ncaa-db-editor-league-creator.html
