(Project originally hosted on [Codeplex](https://gwapinet.codeplex.com/) and last updated September 15, 2013)

**Project Description**
This library hopes to provide an minimal abstraction from the Guild Wars 2 API using a Caching scheme to reduce network traffic and allow persistent data.

# New Updates
* 2013 - 09 - 15: Beta release - Fix to ItemDetailsEntry parsing, Added async api calls.
	* Added updated ResponseCache.bin; contains nearly all available items, recipes and item images
* 2013 - 09 - 13: New Response Cache download added
* 2013 - 09 - 06: New Release - Added language parameter to various api calls
* 2013 - 09 - 04: New Release
* 2013 - 09 - 01: Huge update to [Getting Started](https://github.com/prbarcelon/GwApiNET/wiki/Getting-Started) - contains a bunch of examples, check it out.
* 2013 - 08 - 28: Planned release coming soon; Includes a logging framework and code cleanup.
* 2013 - 08 - 24: New Release posted.  Fixes a few API calls.
* 2013 - 08 - 22: Added API Documentation generated using Doxygen. Available in html or chm format.
	* [GwApiNETDoc.chm](https://github.com/prbarcelon/GwApiNET/blob/master/wiki/Home_GwApiNETDoc.chm) (may need to Right Click > Properties and unlock if on Windows 8)
	* [GwApiNETDoc.7z](https://github.com/prbarcelon/GwApiNET/blob/master/wiki/Home_GwApiNETDoc.7z)



**Purpose Statement**
This library is an attempt to provide a low level abstraction.  This project could be used as a DataProvider for a higher level library providing complete objects containing  all related data.  Another use could be a desktop resource application providing real time insight into Guild Wars 2 information such as Event, Item Details, Crafting Recipes and more.

# Project Features:

## Api Implementation - 100% Complete as of 2013-08-20
* Dynamic Events API – BETA - **100% Completed **
	* https://api.guildwars2.com/v1/events.json - **Completed **
	* https://api.guildwars2.com/v1/event_names.json - **Completed **
	* https://api.guildwars2.com/v1/map_names.json - **Completed **
	* https://api.guildwars2.com/v1/world_names.json - **Completed **
	* https://api.guildwars2.com/v1/event_details.json - **Completed **
* WvW API – BETA - **100% Completed **
	* https://api.guildwars2.com/v1/wvw/matches.json - **Completed **
	* https://api.guildwars2.com/v1/wvw/match_details.json - **Completed **
	* https://api.guildwars2.com/v1/wvw/objective_names.json - **Completed **
* Item and Recipe Database API – BETA - **100% Completed **
	* https://api.guildwars2.com/v1/items.json - **Completed **
	* https://api.guildwars2.com/v1/item_details.json - **Complete**
	* https://api.guildwars2.com/v1/recipes.json - **Completed **
	* https://api.guildwars2.com/v1/recipe_details.json - **Completed **
* Guild API – BETA - **100% Completed **
	* https://api.guildwars2.com/v1/guild_details.json - **Completed **
* Map API – BETA - **100% Completed **
	* https://api.guildwars2.com/v1/continents.json - **Completed **
	* https://api.guildwars2.com/v1/maps.json - **Completed **
	* https://api.guildwars2.com/v1/map_floor.json - **Completed **
* Miscellaneous APIs – BETA - **100% Completed **
	* https://api.guildwars2.com/v1/build.json - **Completed **
	* https://api.guildwars2.com/v1/colors.json - **Completed **
	* https://api.guildwars2.com/v1/files.json - **Completed**
* Render Service - **100% Completed**

## World Map Tile Utilities - **100%**

## Object Mapping - 100% Complete
* 1 to 1 GW2 Object Mapping
## Data Caching - 100% Complete
* Data caching of GW2 objects 
	* Custom caching scheme allows full control of what data is cached and when data is refreshed (Need to implement proper caching for Custom Collections)
## Gw2Stats.net Api - 100% Complete
* [Gw2Stats](http://gw2stats.net) Api implementation
## Gw2PositionReader Api - 100% Complete as of 2013-08-25
* [Read Mumble Link](http://mumble.sourceforge.net/Link) data including:
	* Version
	* Tick
	* Player Position and Orientation
	* Camera Position and Orientation
	* Player Name
	* Player Profession
	* Team Color ID
	* Commander Status
	* Server Address
	* [Map ID](http://wiki.guildwars2.com/wiki/API:1/maps)
	* Map Type
	* [Shard/World ID](http://wiki.guildwars2.com/wiki/API:1/world_names)
	* Instance
	* [Build](http://wiki.guildwars2.com/wiki/API:1/build)

## Library settings persistence
* Allows for persistent library settings via Constants.Save(...) and Constants.Load(...)
* persistent library settings allows for saving or changing library constants to an xml file. 

# Planned Features:
* Logging - Implemented
* World Map Tile Service utilities - Implemented
* Async api call option.
* middle layer objects that will contain all relevant data for a given object. (e.g. A recipe will contain ingredients which will be item objects, without the need to manually link them with two separate api calls.)  The middle layer objects will take advantage of Caching.
I may change the caching feature to allow custom caching strategies.  Currently caching is done via binary serialization of ResponseObjects.  I would like to allow caching via other methods such as a database.

# References
* [https://forum-en.guildwars2.com/forum/community/api](https://forum-en.guildwars2.com/forum/community/api)
* [http://wiki.guildwars2.com/wiki/API:Main](http://wiki.guildwars2.com/wiki/API:Main)