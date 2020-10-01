# LR Debug

With this plugin you can debug and extract different values from the game.

**Attention!** For this plugin to work correctly, you must enable the console in the bepinex configurator.

## Install
* Install Bepinex;
* Copy .dll file in bepinex plugins directory.

## Description

### Info
<span style="color:gray">Shortcut: NUMPAD_1</span>

This sub-plugin shows (in console) the current game mode and cursor position.

### Dump
<span style="color:gray">Shortcut: NUMPAD_2</span>

This sub-plugin dumps the game resource files into the data directory.

Files:
* *scenarioInfoData.json - scenario info data;*
* *charaData.json - characters data;*
* *eventData_{GAME_ID}.json - event script data;*
* *eventMessageData_{GAME_ID}.json - message data;*
* *scenarioUnitList_{GAME_ID}.json - unit info;*
* *classTree.json - class tree data;*
* *classData.json - unit class data;*
* *itemData.json - item data;*
* *weaponData.json - weapon data;*
* *skillData.json - unit skill data;*
* *magicData.json - unit magic data;*
* *levelUpPattern.json - level up data;*
* *impactAreaData.json - impact area data;*
* *unitAnimationList.json - unit animation data;*
* *bgmData.json - bgm sound data.*

After the changes, you can use the **LR DataLoader** plugin to have the game apply your modified files.

### Change Scenario
<span style="color:gray">Shortcut: NUMPAD_3</span>

This sub-plugin allows you to go to any scenario specified in the plugin settings **(F1)** right during the game.

**Attention!** You need to be either in the scenario itself or in preparation for the battle.

**Attention!!!!!** UI elements may crash.