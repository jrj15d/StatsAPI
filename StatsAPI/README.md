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
	- PlayerDictionaryController

Data Layer
----------
* Models
	- Player
	- PlayerDictionary
* DTOs
	- PlayerDTO
	- PlayerDictionaryDTO

Services Layer
--------------
* BaseballDB
	- initializes sqllite database using baseballdatabank data