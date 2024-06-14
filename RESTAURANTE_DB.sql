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
CREATE TABLE Platos(
    Id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    Nombre VARCHAR(50) NOT NULL,
    Categoria VARCHAR(50) NOT NULL,
    Precio MONEY NULL CHECK(Precio >=0),
    CuponDescuento VARCHAR(50) NULL,
    Disponible BIT CHECK(Disponible IN (0,1)),
)


INSERT INTO Ingredientes VALUES ('tomate','2024-01-10',10,50),('lechuga','2024-10-11',12,15), ('milanesa','2024-01-10',1000,5)

INSERT INTO Platos VALUES ('Fideos al tuco','Plato principal',5000,'50% de descuento',1),('Flan de vainilla','Postre',500,'10% de descuento',1), ('Manaos','Bebida',1000,null,1)