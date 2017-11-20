--create database Muzyka
IF OBJECT_ID('Zespoly', 'U') IS NOT NULL 
	DROP TABLE Zespoly;
IF OBJECT_ID('Wytwornie', 'U') IS NOT NULL 
	DROP TABLE Wytwornie;
IF OBJECT_ID('Albumy', 'U') IS NOT NULL 
	DROP TABLE Albumy;
IF OBJECT_ID('Adresy', 'U') IS NOT NULL 
	DROP TABLE Adresy;
IF OBJECT_ID('Czlonkowie', 'U') IS NOT NULL 
	DROP TABLE Czlonkowie;

create table Zespoly
(
	id_zespolu int identity(1,1) ,
	nazwa_zespolu varchar(30) primary key,
	data_zalozenia datetime not null,
);

create table Wytwornie
(
	id_wytworni int identity(1,1),
	nazwa_wytworni varchar(30) primary key,
);

create table Albumy
(
	id_album int identity(1,1) primary key,
	nazwa_albumu varchar(30) not null,
	wykonawca varchar(30) references Zespoly(nazwa_zespolu),
	wytwornia varchar(30) references Wytwornie(nazwa_wytworni),
	gatunek varchar(20),
	data_wydania datetime not null
);

Create table Adresy
(
	id_adresow int primary key,
	naz_wyt varchar(30) references Wytwornie(nazwa_wytworni),
	miasto varchar(20)
);
create table Czlonkowie
(
	id_czlonkow int primary key,
	liczba_czlonkow int,
	nazw_zesp varchar(30) references Zespoly(nazwa_zespolu)
);

Insert into Zespoly values ('Metallica','01-09-1980');
INsert into Zespoly values ('Megadeth' ,'01-10-1980');
insert into Wytwornie values ('SCRD');
insert into Wytwornie values ('Records Mania');
insert into Albumy values ('Load', 'Metallica', 'Records Mania', 'metal','01-11-1980');
insert into Albumy values ('Rust in Peace', 'Megadeth', 'SCRD', 'metal','01-12-1980');
insert into Adresy values (1,'SCRD','Warszawa');
insert into Adresy values (2,'Records Mania','New York');
insert into Czlonkowie values (1,4,'Metallica');
insert into Czlonkowie values (2,5,'Megadeth');
Select * FROM Albumy