CREATE TABLE Kunde
(
    kunde_id INT PRIMARY KEY IDENTITY (1000, 1) NOT NULL,
	navn VARCHAR(50),
    tlf INT,
	email VARCHAR(50),
	adresse VARCHAR(50)
);
CREATE TABLE Medarbejder 
(
    med_id INT PRIMARY KEY IDENTITY (1000, 1) NOT NULL,
	navn VARCHAR(50),
    tlf INT,
	email VARCHAR(50),
	timepris float
);
CREATE TABLE Specialiseringer
(
	med_id INT FOREIGN KEY REFERENCES Medarbejder(med_id),
	speciale VARCHAR(50),
);
CREATE TABLE Materialer 
(
    mat_id INT PRIMARY KEY IDENTITY (1000, 1) NOT NULL,
	navn VARCHAR(50),
	indkøbspris FLOAT,
	salgspris FLOAT
);
CREATE TABLE Biler 
(
    bil_id INT PRIMARY KEY IDENTITY (1000, 1) NOT NULL,
	reg_nr INT,
	km_pris FLOAT,
	dags_pris FLOAT
);
CREATE TABLE Tilbud 
(
    tilbud_id INT PRIMARY KEY IDENTITY (1000, 1) NOT NULL,
	kunde_id INT FOREIGN KEY REFERENCES Kunde(kunde_id),
	title VARCHAR(50),
	beskrivelse VARCHAR(50),
	type VARCHAR(50),
	start_dato VARCHAR(50),
	slut_dato VARCHAR(50),
	rabat FLOAT,
	pris FLOAT,
	projekt_ansvarlig INT
);
CREATE TABLE Tilbud_materialer 
(
    tilbud_id INT FOREIGN KEY REFERENCES Tilbud(tilbud_id),
	mat_id INT FOREIGN KEY REFERENCES Materialer(mat_id),
	antal INT,
	brugt INT,
	rabat FLOAT
);
CREATE TABLE Tilbud_håndværkstimer
(
    tilbud_id INT FOREIGN KEY REFERENCES Tilbud(tilbud_id),
	med_id INT FOREIGN KEY REFERENCES Medarbejder(med_id),
	antal INT,
	brugt INT,
	rabat FLOAT
);
CREATE TABLE Tilbud_kørsel 
(
    tilbud_id INT FOREIGN KEY REFERENCES Tilbud(tilbud_id),
	bil_id INT FOREIGN KEY REFERENCES Biler(bil_id),
	type VARCHAR(50),
	antal INT,
	brugt INT,
);