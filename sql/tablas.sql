CREATE DATABASE Database_SexShop
GO
USE Database_SexShop

GO
CREATE TABLE Categorias(
ID INT PRIMARY KEY NOT NULL IDENTITY(1,1),
Descripcion VARCHAR(100) NOT NULL,
)

GO
CREATE TABLE SubCategorias(
ID INT PRIMARY KEY NOT NULL IDENTITY(1,1),
IDCategoria INT foreign key references Categorias(ID),
Descripcion VARCHAR(100) NOT NULL,
)

GO
CREATE TABLE Imagenes(
ID INT PRIMARY KEY NOT NULL IDENTITY(1,1),
IDProducto INT foreign key references Producto(ID),
Descripcion VARCHAR(100) NOT NULL,
)

GO
CREATE TABLE Marca(
ID INT PRIMARY KEY NOT NULL IDENTITY(1,1),
Descripcion VARCHAR(100) NOT NULL,

)


GO
CREATE TABLE Producto(
ID INT PRIMARY KEY NOT NULL IDENTITY(1,1),
Nombre varchar(50) not null,
IDCategoria INT not null foreign key  references Categorias(ID),
IDSubCategoria INT null foreign key  references SubCategorias(ID),
FechaCarga datetime not null default(GETDATE()),
Precio money not null,
Stock money not null default 0,
Descripcion varchar(1000) not null,
Marca int foreign key references Marca(ID),
Baja bit not null default(0)
)
GO
Create Table CostosDeEnvio(
ID INT PRIMARY KEY NOT NULL IDENTITY(1,1),
Zona INT NOT NULL,
Precio money not null,
Baja bit not null default(0)
)
GO
Create Table Provincias(
ID INT PRIMARY KEY NOT NULL IDENTITY(1,1),
IDCostoEnvio INT  not null foreign key  references CostosDeEnvio(ID),
Descripcion VARCHAR(100) NOT NULL,
Baja bit not null default(0)
)
GO
Create Table Ciudades(
ID INT PRIMARY KEY NOT NULL IDENTITY(1,1),
IDProvincia INT not  null foreign key  references Provincias(ID),
Descripcion VARCHAR(100) NOT NULL,
Baja bit not null default(0)
)
GO
Create Table Direcciones(
ID INT PRIMARY KEY NOT NULL IDENTITY(1,1),
IDCiudad INT not null foreign key  references Ciudades(ID),
IDProvincia INT not  null foreign key  references Provincias(ID),
Calle varchar(100) not null,
Numeracion int not null,
Depto varchar(10) null,
Piso varchar(10) null,
CP varchar(4) null,
Baja bit not null default(0)
)
GO
Create Table Permisos(
ID INT PRIMARY KEY NOT NULL IDENTITY(1,1),
Descripcion varchar(100) 
)
GO
Create Table Usuarios(
ID INT PRIMARY KEY NOT NULL IDENTITY(1,1),
Usuario varchar(12) not null unique,
Contraseña varchar(10) not null,
Nombre varchar(50) not null,
Apellido varchar(100) not null,
DNI INT NULL,
Email varchar(50) null,
Telefono varchar(50) null,
IDDireccion int foreign key references Direcciones(ID),
IDPermiso int foreign key references Permisos(ID) DEFAULT 2,
Baja bit not null default(0)
)
GO
Create Table Carrito(
ID INT PRIMARY KEY NOT NULL IDENTITY(1,1),
IDUsuario int  not null foreign key references Usuarios(ID),
SubTotalProductos money not null,
CostoDeEnvio money not null,
Total money not null,
Estado varchar(50)not null check(Estado='En Proceso' or Estado='Pagado' or Estado= 'Entregado' or Estado= 'Cancelado'),
FormaPago varchar(50) not null,
Fecha date not null default(GETDATE()),
FechaEntrega date check(FechaEntrega>=GETDATE())
)
GO
Create Table CarritoDet(
ID INT PRIMARY KEY NOT NULL IDENTITY(1,1),
IDProducto INT null foreign key  references Producto(ID),
Cantidad int not null,
PrecioxProducto money not null,
IDCarrito int not null foreign key references Carrito(ID)
)