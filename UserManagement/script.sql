create database usersdb;
USE usersdb;
CREATE TABLE Users 
(
  Id int NOT NULL,
  Name VARCHAR(30) NOT NULL,
  Age int NOT NULL,
  Email VARCHAR(40) NOT NULL,
);

INSERT INTO Users(Id,Name,Age,Email)VALUES(1,'Gurmeet',45,'gurmeet45@gmail.com');

INSERT INTO Users(Id,Name,Age,Email)VALUES(2,'Priyanka',28,'priyanka@yahoo.com');