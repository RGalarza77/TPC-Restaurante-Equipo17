use master
GO
CREATE DATABASE RESTAURANTE_DB;
GO
USE RESTAURANTE_DB;
GO
CREATE TABLE Ingredientes(
    Id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    Nombre VARCHAR(50) NOT NULL,
    FechaVencimiento DATE NULL,
    Cantidad INT NULL CHECK(Cantidad >=0),
    Precio MONEY NULL CHECK(Precio >=0),
)
GO
CREATE TABLE ImagenesIngredientes(
	Id INT IDENTITY(1,1) NOT NULL,
	IdIngrediente INT NOT NULL FOREIGN KEY REFERENCES Ingredientes(Id),
	ImagenUrl VARCHAR(1000) NOT NULL,
)
GO
CREATE TABLE platos (
    id INT PRIMARY KEY IDENTITY(1,1),
    codigo VARCHAR(50) NOT NULL,
    nombre VARCHAR(100) NOT NULL,
    descripcion varchar(200),
    precio DECIMAL(10, 2) NOT NULL
);


INSERT INTO Ingredientes VALUES ('tomate','2024-01-10',10,50),('lechuga','2024-10-11',12,15), ('milanesa','2024-01-10',1000,5)

INSERT INTO Platos VALUES ('ft','Fideos al tuco','fideos con salsa a eleccion', 1200)
GO
CREATE TABLE Clientes(
    Documento INT NOT NULL PRIMARY KEY,
    NumeroCliente INT NOT NULL UNIQUE IDENTITY(1,1) ,
    Nombre VARCHAR (60) NOT NULL,
    Apellido VARCHAR (60) NULL,
    /*Sexo VARCHAR(1) NOT NULL CHECK(Sexo='M' OR Sexo='F'),
    Email VARCHAR(60) NULL,
    Telefono VARCHAR (15) NULL,
    FechaAlta DATE NOT NULL,
    Direccion VARCHAR (50) NULL, /*Calle y el numero*/
    Piso VARCHAR(3) NULL,
    CodigoPostal INT NULL,
    Localidad VARCHAR(40) NULL,
    Provincia VARCHAR(40) NULL,*/
    Activo BIT CHECK(Activo IN (0,1))
)
GO
INSERT INTO Clientes VALUES (23556455,'Esteban','Nogues',1)
INSERT INTO Clientes VALUES (38547785,'Juan','Alvarez',1)

GO
CREATE TABLE Puestos(
    Id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    Nombre VARCHAR(80) NOT NULL UNIQUE,
    -- Sector VARCHAR(80) NULL,  
)
GO
INSERT INTO Puestos VALUES ('Mozo')
INSERT INTO Puestos VALUES ('Cocinero')

GO
CREATE TABLE Empleados(
    Documento INT NOT NULL PRIMARY KEY,
    Legajo INT NOT NULL UNIQUE IDENTITY(2000,1),
    Nombre VARCHAR(50) NOT NULL,
    /*Apellido VARCHAR(50) NOT NULL,
    Sexo VARCHAR(1) NOT NULL CHECK(Sexo='M' OR Sexo='F'),
    FechaNacimiento DATE NOT NULL, 
    Email VARCHAR(60) NULL,
    Telefono VARCHAR(15) NULL,
    FechaIngreso DATE NOT NULL,
    Direccion VARCHAR(50) NULL,
    Piso VARCHAR(3) NULL,
    CodigoPostal INT NULL,
    Localidad VARCHAR(40) NULL,
    Provincia VARCHAR(40) NULL,
    Sueldo MONEY NULL CHECK(Sueldo >= 0),*/
    IdPuesto INT NULL FOREIGN KEY REFERENCES Puestos(Id),
    Activo BIT CHECK(Activo IN (0,1))
    --VentasUltimoMes TINYINT NULL, CALCULABLE
)
GO
INSERT INTO Empleados VALUES (39789545,'Jorge',1,1) 
INSERT INTO Empleados VALUES (77777777,'Sebastian',1,1) 

GO
CREATE TABLE Salas(
    Id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    Nombre VARCHAR(70) NOT NULL,
    Mesas INT NULL CHECK(Mesas >= 0),
)
GO
INSERT INTO Salas VALUES ('Piso 1',10)
INSERT INTO Salas VALUES ('Terraza',5)

GO
CREATE TABLE Mesas(
    Id INT NOT NULL PRIMARY KEY IDENTITY (1,1),
    Numero INT NOT NULL ,
    IdSala INT NOT NULL FOREIGN KEY REFERENCES Salas(Id), 
    UNIQUE (Numero, IdSala)
)
