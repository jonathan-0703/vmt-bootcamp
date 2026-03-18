CREATE DATABASE leaderBoard
GO
USE leaderBoard
GO

-- DDL
CREATE TABLE UsuarioTipos(
	UsuarioTipoId INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	Description NVARCHAR(255),
	CreatedAT DATETIME2 NOT NULL DEFAULT SYSUTCDATETIME()
);
GO


CREATE TABLE ModuloTipos(
	ModuloTipoId INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	Especialidad VARCHAR(100) NOT NULL,
	Tecnologia VARCHAR(100) NOT NULL,
	CreatedAT DATETIME2 NOT NULL DEFAULT SYSUTCDATETIME(),
);

GO
CREATE TABLE Usuarios(
	UsuarioId UNIQUEIDENTIFIER NOT NULL DEFAULT NEWID() PRIMARY KEY,
	UsuarioTipoId INT NOT NULL,
	Nombre VARCHAR(150) NOT NULL,
	Edad INT NOT NULL,
	Correo VARCHAR(150) NOT NULL,
	Cedula VARCHAR(10) NOT NULL,
	NumeroDeTelefono  VARCHAR(32) NOT NULL, 
	CreatedAT DATETIME2 NOT NULL DEFAULT SYSUTCDATETIME(),

	CONSTRAINT FK_UsuarioTipoId FOREIGN KEY (UsuarioTipoId) REFERENCES UsuarioTipos(UsuarioTipoId)
);
GO
CREATE TABLE Modulo(
	ModuloId INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	ModuloTipoId INT NOT NULL,
	Profesor UNIQUEIDENTIFIER NOT NULL,
	Nombre VARCHAR(150) NOT NULL,
	CreatedAT DATETIME2 NOT NULL DEFAULT SYSUTCDATETIME(),
	CONSTRAINT FK_ModuloTipo FOREIGN KEY (ModuloId) REFERENCES Modulo(ModuloId)
);
GO
CREATE TABLE Participaciones(
	ParticipacionId INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	UsuarioId UNIQUEIDENTIFIER NOT NULL,
	ModuloId INT NOT NULL,
	Punto DECIMAL NOT NULL DEFAULT 0,
	FechaParticipacion DATETIME2 NOT NULL DEFAULT SYSUTCDATETIME(),
	CreatedAT DATETIME2 NOT NULL DEFAULT SYSUTCDATETIME(),

	CONSTRAINT FK_UsuarioId FOREIGN KEY (UsuarioId) REFERENCES Usuarios(UsuarioId),
	CONSTRAINT FK_ModuloId FOREIGN KEY (ModuloId) REFERENCES Modulo(ModuloId)
);
GO

--DML
INSERT INTO UsuarioTipos(Description) 
VALUES ('Profesor'),('Estudiante');

INSERT INTO ModuloTipos(Especialidad,Tecnologia)
VALUES ('Motor de base de datos','SQL Server'),
('FrameWork','.Net'),
('FrameWork','Angular'),
('FrameWork','.NET'),
('Entornor de ejecucion','Node.js');

DECLARE @JohnDoUserId UNIQUEIDENTIFIER= NEWID();
DECLARE @JohnDoUserSegundoUserId UNIQUEIDENTIFIER= NEWID();
DECLARE @JohnDoUsersTerceroUserId UNIQUEIDENTIFIER= NEWID();


INSERT INTO Usuarios (UsuarioId ,UsuarioTipoId, Nombre, Edad, Correo, NumeroDeTelefono, Cedula)
VALUES
(@JohnDoUserId, 1, 'John Doe', 'om@doe.com', '0123123230923', '0123456789'),
(@JohnDoUserSegundoUserId, 1, 'John Doe', 'om22@doe.com', '01231874787778', '0123456789'),
(@JohnDoUsersTerceroUserId, 1, 'John Doe', 'om33@doe.com', '4234287372377', '0123456789');

DECLARE @SQLServerModuloTipo INT =(SELECT ModuloTipoId FROM ModuloTipos WHERE Tecnologia='SQL Server' )
DECLARE @AngularModuloTipo INT =(SELECT ModuloTipoId FROM ModuloTipos WHERE Tecnologia='Angular' )
DECLARE @DotNetModuloTipo INT =(SELECT ModuloTipoId FROM ModuloTipos WHERE Tecnologia='.NET' )


INSERT INTO Modulo(ModuloTipoId,Profesor) VALUES
(@SQLServerModuloTipo,@JohnDoUserId)

INSERT INTO Modulo(ModuloTipoId,Profesor) VALUES
(@AngularModuloTipo,@JohnDoUserSegundoUserId)

INSERT INTO Modulo(ModuloTipoId,Profesor) VALUES
(@DotNetModuloTipo,@JohnDoUsersTerceroUserId)


ALTER TABLE Usuarios ADD CONSTRAINT UQ_UsuarioCorreoElectronico UNIQUE(Correo)
ALTER TABLE Usuarios ADD CONSTRAINT UQ_UsuarioCorreoCedula UNIQUE(Cedula)
ALTER TABLE Usuarios ADD CONSTRAINT UQ_UsuarioCorreoNumeroDeTelefono UNIQUE(NumeroDeTelefono)

