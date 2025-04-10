# Wujin DianDian
This is a gift for my online friends playing the mobile game [Whiteout Survival](https://whiteoutsurvival.centurygames.com/)
It comes in handy in replacing manual clicks with automated clicks in some scenarios. 
This tool can only run on Windows PCs since it uses user32.dll to hook to mouse/keyboard events as well as to stimulate programmatic clicks.

## Background
In the game, there is league teamwork/support work in a way that repeatedly sends out requests and responses to friends' requests to speed up some process.
The most extreme case would be during a war this is needed to quickly cure the soldiers to continue the fight and sometimes this can go up to 4 hours.
So automatic clicking saves your fingers and helps to keep stress low.

Thus, the game company does check for clicking hacks. The tool offers multiple clicking frequency options to better fit into different scenarios and just to be safe.

## Features
For the time being, the UI is build with WinForms.

  ![UI Overview](/Assets/UI_Overview.PNG)

It has two sections that toggle between Quick Start Mode and Advanced Mode.	
Both modes share the Deadline Section(time picker) at the bottom which is necessary to set with a deadline in the future.
At the every end, the big textbox shows logging information like errors, point of mouse position, clicking intervals, etc.

### Quick Start Mode
Under this mode, the tool will click wherever the current mouse position is.
The radio buttons switch between the human-like clicking interval and the like-machine clicking interval.
The human-like clicking interval will be drawn randomly after each stimulated click from choices of 1, 0.3, and 0.5 sec.

![Demo of like-machine clicking:](/Assets/Demo_QuickStart_HumanLikeClicking.gif)

The machine-like clicking interval comes from the user setting. The demo shows stimulate 3, 5, and 10 clicks per second.* If 
If it's not in a hurry, the human-like mode is recommended to be safe while switching to the other if you want to speed things up.

![Demo of machine-like clicking:](/Assets/Demo_QuickStart_LikeMachineClicking.gif)

### Advanced Mode
The advanced mode allows 2 recordings and replays. Each records a series of mouse clicks and provides 4 clicking speeds in replay. The replay settings are independent so better fit into the user scenarios.
Speed options cover the like-human clicking mode and the like-machine clicking mode mentioned above.
On top of that, it supports replay according to the exact original recording as well as replay with fine random touch based on the original recording. 
The latter will randomly change the waiting time most realistically. After every stimulated click, it chooses a number between 90 and 100 to speed up (1-10% less waiting time) or between 110 and 140 to slow down (10-40% more waiting time).

![Demo of Advanced Mode:](/Assets/Demo_AdvancedMode.gif)
