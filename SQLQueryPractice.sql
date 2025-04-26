CREATE DATABASE PRACTICE_LISAV;

USE PRACTICE_LISAV;

CREATE TABLE UserInfo(
    UserId INT IDENTITY(1,1) PRIMARY KEY,
    UserName NVARCHAR(128),
    UserLogin NVARCHAR(128),
    UserEmail NVARCHAR(128),
    UserPassword NVARCHAR(128)
);

CREATE TABLE UserRequisites(
    RequisitId INT IDENTITY(1,1) PRIMARY KEY,
    RequisitName NVARCHAR(128),
    UserID INT FOREIGN KEY REFERENCES UserInfo(UserId)
);

CREATE TABLE UserCostumes(
    CostumeId INT IDENTITY(1,1) PRIMARY KEY,
    CostumeName NVARCHAR(128),
    UserID INT FOREIGN KEY REFERENCES UserInfo(UserId)
);

CREATE TABLE UseRequisitiesCostumes(
    id INT IDENTITY(1,1) PRIMARY KEY,
    RequsitId INT FOREIGN KEY REFERENCES UserRequisites(RequisitId),
    CostumeId INT FOREIGN KEY REFERENCES UserCostumes(CostumeId),
    UserId INT FOREIGN KEY REFERENCES UserInfo(UserId)
);

INSERT INTO UserInfo (UserName, UserLogin, UserEmail, UserPassword)
VALUES 
('Alice', 'alice_login', 'alice@example.com', 'password123'),
('Bob', 'bob_login', 'bob@example.com', 'securepass'),
('Admin', 'admin', 'admin@example.com', 'admin123');

INSERT INTO UserRequisites (RequisitName, UserID)
VALUES 
('Sword', 1),
('Shield', 1),
('Bow', 2),
('Helmet', 2);

INSERT INTO UserCostumes (CostumeName, UserID)
VALUES 
('Knight Armor', 1),
('Wizard Robe', 1),
('Archer Outfit', 2),
('Ninja Suit', 2);

INSERT INTO [UseRequisitiesCostumes](RequsitId, CostumeId, UserId)
VALUES 
(1, 1, 1),
(2, 1, 1),
(3, 3, 2),
(4, 4, 2);