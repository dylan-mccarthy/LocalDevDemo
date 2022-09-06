
CREATE Database NightSkyDB;
USE NightSkyDB;

CREATE TABLE Galaxies (
	Id	int NOT NULL,
	Name varchar(255) NOT NULL,
	Type varchar(255) NOT NULL,
	DistanceFromSolarSystem	int NOT NULL,
	PRIMARY KEY(Id)
);

CREATE TABLE Planets (
	Id	int NOT NULL,
	Name	varchar(255) NOT NULL,
	HasLife	int NOT NULL,
	DistanceFromSun	int NOT NULL,
	PRIMARY KEY(Id)
);

INSERT into Galaxies (Id, Name, Type, DistanceFromSolarSystem) VALUES (1, 'M32 Andromeda', 'Spiral', 752);

INSERT into Galaxies (Id, Name, Type, DistanceFromSolarSystem) VALUES (2, 'LMC Large Magellanic Cloud', 'Magellanic Spiral', 50);

INSERT into Galaxies (Id, Name, Type, DistanceFromSolarSystem) VALUES (3, 'M33 Triangulum', 'Spiral', 970);

INSERT into Planets (Id, Name, HasLife, DistanceFromSun) VALUES (1, 'Mercury', 0, 58);

INSERT into Planets (Id, Name, HasLife, DistanceFromSun) VALUES (2, 'Venus', 0, 108);

INSERT into Planets (Id, Name, HasLife, DistanceFromSun) VALUES (3, 'Earth', 1, 150);

INSERT into Planets (Id, Name, HasLife, DistanceFromSun) VALUES (4, 'Mars', 0, 228);

INSERT into Planets (Id, Name, HasLife, DistanceFromSun)VALUES (5, 'Jupiter', 0, 778);

INSERT into Planets (Id, Name, HasLife, DistanceFromSun) VALUES (6, 'Saturn', 0, 1427);

INSERT into Planets (Id, Name, HasLife, DistanceFromSun) VALUES (7, 'Uranus', 0, 2871);

INSERT into Planets (Id, Name, HasLife, DistanceFromSun) VALUES (8, 'Neptune', 0, 4497);