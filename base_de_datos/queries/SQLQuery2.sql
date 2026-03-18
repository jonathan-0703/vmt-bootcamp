Create database Prueba;
GO

USE Prueba
GO


CREATE TABLE Roles (
	RoleId INT IDENTITY(1,1) NOT NULL,
	Code NVARCHAR (10) NOT NULL,
	ShowName NVARCHAR(100) NOT NULL,
	CreatedAT DATETIME2 NOT NULL DEFAULT SYSUTCDATETIME()
);
GO

CREATE TABLE UserStatus(
	UserStatusId INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	Code NVARCHAR(10) NOT NULL,
	ShowName NVARCHAR(11) NOT NULL,
	CreatedAt DATETIME2 NOT NULL DEFAULT SYSUTCDATETIME()
);
GO

INSERT INTO UserStatus(Code, ShowName) 
VALUES
('online',		'En línea'),
('not_disturb',	'No molestar'),
('idle',		'Ausente'),
('ghost',		'Invisible')

GO
CREATE TABLE Users(
	UserId UNIQUEIDENTIFIER NOT NULL DEFAULT NEWID(),
	Username NVARCHAR(32) NOT NULL,
	DisplayName NVARCHAR(100) NOT NULL,
	Description NVARCHAR (100) NOT NULL,
	StatusType INT NOT NULL REFERENCES UserStatusType(UserStatusId) DEFAULT(1) , --Online
	StatusContent NVARCHAR(50) NULL DEFAULT ('HI, there!'),
	StatusTime INT,
	AvatarURL NVARCHAR(255),
	BannerURL NVARCHAR(255),
	--RoleId INT NOT NULL REFERENCES Roles(RoleId),
	CreatedAT DATETIME2 NOT NULL DEFAULT SYSUTCDATETIME()
	--CONSTRAINT FK_Roles_RoleId FOREIGN KEY (RoleId) REFERENCES Roles(RoleId)
);
GO


/*CREATE TABLE UserRoles(
	 UserId UNIQUEIDENTIFIER NOT NULL,
	 RoleId INT NOT NULL,
	 CONSTRAINT PK_UserRoles_UserId_RoleId PRIMARY KEY (UserId, RoleId)

);*/

CREATE TABLE Collections(
	CollectionId UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT NEWID(),
	Name NVARCHAR(50) NOT NULL,
	Description NVARCHAR(200) NOT NULL DEFAULT('This is my Collec,tion!'),
	CreatedAt DATETIME2 NOT NULL DEFAULT SYSUTCDATETIME(),
	DeletedAt DATETIME2

);

GO

CREATE TABLE Items(
	ItemId INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	Name NVARCHAR(50)NOT NULL UNIQUE,
	CreatedAt DATETIME2 NOT NULL DEFAULT SYSUTCDATETIME()
);

GO

INSERT INTO Items(Name)
VALUES 
('Hollow Knight'), -- Me pago $10
('osul') --Este tambien me pago $10

GO
CREATE TABLE CollectionsItem(
	CollectionId UNIQUEIDENTIFIER NOT NULL REFERENCES Collections (CollectionId),
	ItemId INT NOT NULL REFERENCES Items(ItemId) ON DELETE CASCADE,
	CONSTRAINT PK_CollectionsiTEMS_CollectionId_ItemId  PRIMARY KEY (CollectionId,ItemId)
)

INSERT INTO Collections (Name, Description) VALUES
('Mis Juegos','Juegos')


DECLARE @CollectionID UNIQUEIDENTIFIER='41B47698-0C7A-480E-B7E7-BEFCE1175FF8'
DECLARE @ItemHollowKnightId INT = (SELECT ItemId from Items WHERE ItemId =1);
DECLARE @ItemOsuID INT =(SELECT ItemId from Items WHERE ItemId =2);

INSERT INTO CollectionsItem(CollectionId,ItemId)
VALUES (@CollectionID, @ItemOsuID );


select * from Collections


CREATE INDEX IX_Items_Name ON Items(Name)