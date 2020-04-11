create database userservice;
USE userservice;
CREATE TABLE IF NOT EXISTS Users (
  Id INT NOT NULL AUTO_INCREMENT,
  Name VARCHAR(30) NOT NULL,
  Age INT NOT NULL,
  Email VARCHAR(40) NOT NULL,
  PRIMARY KEY (Id)
);

INSERT INTO Users (Name,Age,Email)
VALUES ('Gurmeet',45,'gurmeet45@gmail.com');

INSERT INTO Users (Name,Age,Email)
VALUES ('Priyanka',28,'priyanka@yahoo.com');