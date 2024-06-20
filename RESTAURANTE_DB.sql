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

INSERT INTO Platos VALUES ('Fideos al tuco','Plato principal',5000,'50% de descuento',1),('Flan de vainilla','Postre',500,'10% de descuento',1), ('Manaos','Bebida',1000,null,1)



GO
CREATE TABLE Clientes(
    Documento INT NOT NULL PRIMARY KEY,
    NumeroCliente INT NOT NULL UNIQUE IDENTITY(1,1) ,
    Nombre VARCHAR (60) NOT NULL,
    /*Apellido VARCHAR (60) NOT NULL,
    Sexo VARCHAR(1) NOT NULL CHECK(Sexo='M' OR Sexo='F'),
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
CREATE TABLE Mozos(
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
    Activo BIT CHECK(Activo IN (0,1))
    --VentasUltimoMes TINYINT NULL, CALCULABLE
)
GO
CREATE TABLE Sucursales(     /*Esta bien el nombre de Sucursales? Una cadena puede tener varias Sucursales,Ver*/
    Id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    Nombre VARCHAR(80) NULL,
    -- Numero INT NOT NULL UNIQUE, /*Numero de sucursal, sirve para que el dueño identifique el locan dentro de su cadena*/
    -- Duenio INT NULL FOREIGN KEY Usuarios(Id)/* Ver. Tambien podria haber una base de datos de Duenios*/
    -- Cadena INT NULL FOREIGN KEY REFERENCES Cadenas(Id), /*Si la sucursal pertenece a una cadena de restaurantes*/
    -- Direccion VARCHAR(50) NULL,
    -- Piso VARCHAR(3) NULL,
    -- CodigoPostal INT NULL,
    -- Localidad VARCHAR(40) NULL,
    -- Provincia VARCHAR(40) NULL,
    -- CantidadCocinas INT NOT NULL CHECK(CantidadCocinas >=0),
    CantidadPisos INT NOT NULL CHECK(CantidadPisos >=0)
)
GO
CREATE TABLE EstadoMesa(  /* puede ser: 1-mesa libre, 2-mesa ocupada, 3-en proceso de pago*/
    Id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    Estado VARCHAR(50) NOT NULL,
)
GO
INSERT INTO EstadoMesa VALUES ('libre') /*1*/
INSERT INTO EstadoMesa VALUES ('ocupada') /*2*/
INSERT INTO EstadoMesa VALUES ('en proceso de pago') /*3*/


GO
CREATE TABLE Mesas(
    Id INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
    Numero INT NOT NULL CHECK( Numero >= 0),
    Sucursal INT NOT NULL FOREIGN KEY REFERENCES Sucursales(Id), 
    Personas INT NULL CHECK( Personas >= 0),
    Cliente INT NULL FOREIGN KEY REFERENCES Clientes(Documento),
    Mozo INT NULL FOREIGN KEY REFERENCES Mozos(Documento),
    Comentario VARCHAR(200) NULL,
    IdEstadoMesa INT NOT NULL FOREIGN KEY REFERENCES EstadoMesa(Id),
    UNIQUE (Numero, Sucursal)
)

GO

INSERT INTO Clientes VALUES (38547785,'Juan',1)

INSERT INTO Mozos VALUES (39789545,'Jorge',1)

INSERT INTO Sucursales VALUES ('El Chirimbolo',3)
INSERT INTO Sucursales VALUES ('El Chirimbolo2',2)





INSERT INTO Mesas VALUES (11,1,3,null,39789545,'atencion urgente',2)

INSERT INTO Mesas VALUES (12,1,1,38547785,39789545,'atencion urgente',1)

INSERT INTO Mesas VALUES (12,2,1,38547785,39789545,'atencion urgente',1)
