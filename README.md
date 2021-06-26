StatsAPI
========

StatsAPI interfaces with an sqllite database and delivers data relating to MLB statistics.
The data is from the baseballdatabank repository: https://github.com/chadwickbureau/baseballdatabank
----------------------------------------------------------------------------------------------------

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
	- BattingController
		- api/batting
			- provides batting stats for all players
		- api/batting/{playerid}
			- provides year-by-year batting statistics for a player, identified by player-id
		- api/batting/active
			- provides batting stats for all currently active players
	- PitchingController
		- api/pitching
			- provides pitching stats for all players
		- api/pitching/{playerid}
			- provides year-by-year pitching statistics for a player, identified by player-id
		- api/pitching/active
			- provides pitching stats for all currently active players

Data Layer
----------
* Models
	- Player
		- represents basic data for a player (name, height, weight, birthdate, etc.)
	- Batting
		- represents a season's worth of batting statistics for a given player
	- Pitching
		- represents a season's worth of pitching statistics for a given player

Services Layer
--------------
* BaseballDB
	- initializes SQLite database using baseballdatabank data
