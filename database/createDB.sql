CREATE DATABASE pizzitas;
--DROP database pizzitas;

/* Catalogos */
CREATE TABLE Municipio (
	idMunicipio SERIAL,
	name TEXT,
	PRIMARY KEY (idMunicipio)
);


CREATE TABLE Ciudad (
	idCiudad SERIAL,
	NombreCiudad TEXT,
	PRIMARY KEY (idCiudad)
);

CREATE TABLE Estado (
	idEstado SERIAL,
	NombreEstado TEXT,
	PRIMARY KEY (idEstado)
);

CREATE TABLE Cargo (
	idCargo SERIAL,
	name VARCHAR(64),
	PRIMARY KEY (idCargo)
);



--drop table cliente;
/* Relaciones */
CREATE TABLE Cliente(
	idCliente SERIAL,
	name VARCHAR(64),
	lastName VARCHAR(64),
	phone TEXT,
	calle VARCHAR(256) ,
	colonia VARCHAR(256),
	nInterior  SMALLINT,
	nExterior SMALLINT,
	cp VARCHAR(10),
	referencias TEXT,
	idMunicipio INT,
	idCiudad INT,
	idEstado INT,
	PRIMARY KEY (IdCliente),
	FOREIGN KEY (idMunicipio) REFERENCES Municipio (idMunicipio),
	FOREIGN KEY (idCiudad) REFERENCES Ciudad(idCiudad),
	FOREIGN KEY (idEstado) REFERENCES Estado (idEstado)
);

--drop table empleado;
/* creacion del tipo dirección */
CREATE TABLE Empleado (
	idEmpleado SERIAL,
	name VARCHAR(64),
	lastName VARCHAR(64),
	celular VARCHAR(16),
	idCargo INT,
	PRIMARY KEY (idEmpleado),
	FOREIGN KEY (idCargo) REFERENCES Cargo (idCargo)
);

--drop table producto;
CREATE TABLE Producto (
	idProducto SERIAL,
	name VARCHAR(64),
	descripcion VARCHAR(64),
	precio DECIMAL(5,2),
	quantity INT,
	PRIMARY KEY (IdProducto)
);


CREATE TABLE Sucursal (
	idSucursal SERIAL,
	name VARCHAR(64),
	calle VARCHAR(256) ,
	colonia VARCHAR(256),
	nInterior  SMALLINT,
	nExterior SMALLINT,
	cp VARCHAR(10),
	idMunicipio INT,
	idCiudad INT,
	idEstado INT,
	PRIMARY KEY (IdSucursal),
	FOREIGN KEY (idMunicipio) REFERENCES Municipio (idMunicipio),
	FOREIGN KEY (idCiudad) REFERENCES Ciudad(idCiudad),
	FOREIGN KEY (idEstado) REFERENCES Estado (idEstado)	
);

/* Relación 1:N entre sucursal y empleados */
--drop table SucursalEmpleado;
CREATE TABLE SucursalEmpleado (	
	idSucursal INT,
	idEmpleado INT,
	FOREIGN KEY (idSucursal) REFERENCES Sucursal (IdSucursal),
	FOREIGN KEY (idEmpleado) REFERENCES Empleado (IdEmpleado)
);

--drop table Orden;
CREATE TABLE Orden (
	idOrden SERIAL,
	idCliente INT,
	idSucursal INT,
	fecha TIMESTAMP,
	PRIMARY KEY (IdOrden),
	FOREIGN KEY (idCliente) REFERENCES Cliente(idCliente),
	FOREIGN KEY (idSucursal) REFERENCES Sucursal (idSucursal)
);

--drop table DetallesOrden;
CREATE TABLE DetallesOrden (
	idDetalles SERIAL,
	idOrden INT,
	idProducto INT,
	quantity INT,
	FOREIGN KEY (idOrden) REFERENCES Orden (idOrden),
	FOREIGN KEY (idProducto) REFERENCES Producto (idProducto)
);