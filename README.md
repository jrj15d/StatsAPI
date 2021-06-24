StatsAPI
========

StatsAPI interfaces with an sqllite database and delivers data relating to MLB statistics.
The data is from the baseballdatabank repository: https://github.com/chadwickbureau/baseballdatabank
----------------------------------------------------------------------------------------------------


Layers
======

Application Layer
-----------------
* Controllers
	- PlayersController
		- api/players
			- provides list of general data for all players in the database
		- api/players/{playerid}
			- serves general player data for a specific player, identified by player-id
		- api/players/active
			- provides list of all currently active players
		- api/players/batting/{playerid}
			- provides year-by-year batting statistics for a player, identified by player-id

Data Layer
----------
* Models
	- Player
		- represents basic data for a player (name, height, weight, birthdate, etc.)
	- Batting
		- represents a season's worth of batting statistics for a given player

Services Layer
--------------
* BaseballDB
	- initializes sqllite database using baseballdatabank data
