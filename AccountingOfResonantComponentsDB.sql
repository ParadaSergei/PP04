
--CREATE DATABASE YchotRemontnihKomplektuishuh

USE YchotRemontnihKomplektuishuh
GO 

CREATE TABLE Account_Data (
    id INT PRIMARY KEY IDENTITY,
    Name VARCHAR(255),
	Familia VARCHAR(255),
    Device_Remont_type VARCHAR(255),
    Raspisanie_work VARCHAR(255),
    Zarplata DECIMAL(10, 2)
);

CREATE TABLE Account (
    id INT PRIMARY KEY IDENTITY,
    Login VARCHAR(255),
    Password VARCHAR(255),
	Id_Account_data int,
    Privilege_account VARCHAR(255),
    Date_Created DATETIME
	FOREIGN KEY(Id_Account_data) REFERENCES Account_data,
);
CREATE TABLE Sclad (
    id INT PRIMARY KEY IDENTITY,
    Device_type VARCHAR(255),
    Detali VARCHAR(255),
    Kolichestvo INT,
    Pribitie_time DATETIME
);
CREATE TABLE Remont (
    id INT PRIMARY KEY IDENTITY,
    Name VARCHAR(255),
    Id_Account_Data INT,
    Id_Detail INT,
    Type_neispravnosti VARCHAR(255),
    Device_names VARCHAR(255),
    Price DECIMAL(10, 2),
    Start_remonta_po_time DATETIME,
    End_remonta_po_time DATETIME
	FOREIGN KEY(Id_Account_data) REFERENCES Account_data,
	FOREIGN KEY([Id_Detail]) REFERENCES Sclad,
);

