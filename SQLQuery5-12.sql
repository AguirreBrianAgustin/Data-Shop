create database DataShop
ON
( NAME = prods2_dat,
 FILENAME = 'C:\SQL Laboratorio de computacion III\DataShop.mdf' )
GO 

use DataShop
go

---------------------------------------------------------------------------------------------
---------------------------CREACION DE TABLAS------------------------------------------------
create table GENEROS(
id_genero int NOT NULL,
descripcion text null
CONSTRAINT PK_generos PRIMARY KEY (id_genero)
)
go

create table MARCAS(
id_marca int not null,
nombre text null,
CONSTRAINT PK_marcas PRIMARY KEY (id_marca)
)
go

create table PRODUCTOS(
id_producto int not NULL,
nombre text null,
id_marca int not null,
id_genero int not null,
id_pegi int not null,
stock int null, 
portada image null, 
Descripcion text null,
precio_de_unidad float null,
CONSTRAINT PK_producto PRIMARY KEY (id_producto),
)

go

create table CLIENTES(
id_cliente int NOT NULL,
dni int null,
Nombre text null,
Direccion text null,
Telefono text null,
CONSTRAINT PK_cliente PRIMARY KEY (id_cliente),
)
go



create table PROVEEDORES(
id_proveedor int NOT NULL,
id_producto int not null,
Nombre text null,
Dirección text null,
Telefono text null,
Localidad text null,
CONSTRAINT PK_proveedor PRIMARY KEY (id_proveedor)
)
go



create table VENTAS(
id_venta int identity (1,1)not null,
id_cliente int not null,
dni_cliente int null,
telefono int null,
fecha DATE default getdate() NULL,
total float null,
CONSTRAINT pk_venta primary key (id_venta)
)

GO

create table PEGI(
id_pegi int not null,
descripcion text null,
constraint pk_pegi primary key (id_pegi)
)
go

create table USUARIOS(
id_usuario int identity (1,1)not null,
nombre_usuario char(15) null,
contraseña_usuario char(15) null,
permiso bit null
CONSTRAINT pk_usuario primary key (id_usuario)
)
go


create table DETALLE_VENTAS(
id_Detalle_Venta int identity (1,1)not null,
id_venta int not null,
id_producto int not null,
cantidad int null,
precio_unitario float null,
CONSTRAINT PK_id_Detalle_Venta PRIMARY KEY (id_Detalle_Venta)
)
go




----------------------------CREACION DE TABLAS-------------------------------------------
-----------------------------------------------------------------------------------------


-----------------------------------------------------------------------------------------
---------------------------------ENLACES-------------------------------------------------

 -- clave foranea del lado de muchos !!!

alter table PRODUCTOS
ADD CONSTRAINT FK_marca FOREIGN KEY (id_marca) REFERENCES MARCAS(id_marca)

alter table PRODUCTOS
ADD CONSTRAINT FK_pegi FOREIGN KEY (id_pegi) REFERENCES PEGI (id_pegi)

alter table PRODUCTOS
ADD CONSTRAINT FK_genero FOREIGN KEY (id_genero) REFERENCES GENEROS (id_genero)

alter table PROVEEDORES
ADD CONSTRAINT FK_producto foreign key (id_producto) REFERENCES PRODUCTOS (id_producto)

alter table DETALLE_VENTAS
ADD CONSTRAINT FK_id_venta FOREIGN KEY (id_venta) REFERENCES VENTAS (id_venta)

alter table VENTAS
ADD CONSTRAINT FK_cliente FOREIGN KEY (id_cliente) REFERENCES CLIENTES (id_cliente)

alter table DETALLE_VENTAS
ADD CONSTRAINT FK_detalle_venta_producto FOREIGN KEY (id_producto) REFERENCES PRODUCTOS (id_producto)




-------------------------ENLACES-----------------------------------------------------------
-------------------------------------------------------------------------------------------


-------------------------------------------------------------------------------------------
--------------------------Insercion de datos-----------------------------------------------

INSERT into USUARIOS ( nombre_usuario, contraseña_usuario, permiso)
SELECT 'admin', 'admin', 'true' UNION
SELECT 'juan',  '1234' , 'false' UNION
select 'maria', '1111' , 'false'
go

INSERT into GENEROS (id_genero, descripcion)
SELECT 1,'Rol Playing game' UNION
SELECT 2,'First Person Shooter' UNION
SELECT 3,'Side scrolling'
go

INSERT into PEGI (id_pegi, descripcion)
SELECT 1, '3' UNION
SELECT 2, '7' UNION
SELECT 3, '12' UNION
SELECT 4, '16' UNION
SELECT 5, '18' 
go

INSERT INTO MARCAS (id_marca, nombre)
SELECT 1, 'Capcom' UNION
SELECT 2, 'Konami' UNION
SELECT 3, 'Squresoft' UNION
SELECT 4, 'Epic' UNION
SELECT 5, 'Enix' UNION
SELECT 6, 'Bandai' UNION
SELECT 7, 'Banpresto' UNION
SELECT 8, 'From Software' UNION
SELECT 9, 'Nintendo'
go
***********************************************************************************************
create procedure SP_Actualizar_Proveedores(
@id_proveedor int,
@id_producto int,
@Nombre text,
@Direccion text,
@Telefono text,
@Localidad text)
as
begin
update PROVEEDORES
set 
id_proveedor =@id_proveedor,
id_producto=@id_producto,
Nombre = @Nombre,
Dirección = @Direccion,
Telefono = @Telefono,
Localidad = @Localidad
where id_proveedor = @id_proveedor
end
go

***********************************************************************************************

INSERT CLIENTES (id_cliente, dni, Nombre, Direccion, Telefono)
SELECT 1, 111,'Carlos' ,'Pichincha 220','47494336' UNION
SELECT 2, 222, 'Veronica' ,'calle falsa 123','63724453' UNION
SELECT 3, 333, 'José' ,'3 de febrero','44327418' UNION
SELECT 4, 444, 'Mauro Gonzales' , 'Santa María 330','1532469788'UNION
SELECT 5, 555, 'Lucía Rodriguez' ,'Larralde 500','20871884'

go

INSERT INTO PRODUCTOS (Id_producto, Nombre, id_marca, id_genero, stock, id_pegi, portada, descripcion, precio_de_unidad)
SELECT 1,'Dragon quest III'      ,1,1,20,1,  'imagen','Descripcion',50 UNION
SELECT 2,'Final fantasy VII'     ,4,1,19,2,  'imagen','Descripcion',40 UNION
SELECT 3,'Unreal Tournament 2004',2,2,50,3,  'imagen','Descripcion',40 UNION
SELECT 4,'Castlevania SOTN'      ,3,3,13,1,  'imagen','Descripcion',45 UNION
SELECT 5,'Playstation 2'         ,1,1,20,2,  'imagen','Descripcion',600
go

INSERT into PROVEEDORES (id_proveedor, id_producto, Nombre, Dirección, Telefono, Localidad)
SELECT 1,1,'Electronica Pacheco' ,'xxxx'   ,'23424435','Pacheco' UNION
SELECT 2,2,'Compu data'    ,'xxxx'   ,'32425542','Vicente Lopez'UNION
SELECT 3,3,'All Hardware'    ,'Florida 123' ,'87575273','Capital'
go

INSERT into VENTAS (id_cliente, dni_cliente, telefono,fecha,total)
SELECT 1,111,47494336,'2018-12-23',200 UNION
SELECT 2,222,47494336,'2018-12-23',300 UNION
SELECT 2,222,63724453,'2018-11-15',400
go

INSERT into DETALLE_VENTAS(id_venta, id_producto, cantidad,precio_unitario)
SELECT 1,1,1,20 UNION
SELECT 2,2,2,20 UNION
SELECT 2,2,1,30
go

CREATE PROCEDURE SP_Venta_Producto(
@idProducto int, @cant_ven int)
as
begin
if(select stock from PRODUCTOS WHERE id_producto=@idProducto)>=@cant_ven
update PRODUCTOS set stock = stock - @cant_ven
where id_producto =@idProducto
end
go

create procedure SP_Eliminar_Producto(
@id_producto int)
as
begin
delete from PROVEEDORES where id_producto=@id_producto
delete from PRODUCTOS where id_producto =@id_producto
end
go

create procedure SP_Eliminar_Cliente(
@id_cliente int)
as
begin
delete from CLIENTES where id_cliente =@id_cliente
end
go

create procedure SP_Eliminar_Proveedor(
@id_Proveedor int)
as
begin
delete from PROVEEDORES where id_proveedor = @id_Proveedor
end
go

create procedure SP_Eliminar_Marcas(
@id_Marcas int)
as
begin
delete from MARCAS where id_marca = @id_Marcas
end
go


create procedure SP_Eliminar_Generos(
@id_generos int)
as
begin
delete from GENEROS where id_genero = @id_generos
end
go

create procedure SP_Actualizar_Proveedores(
@id_proveedor int,
@id_producto int,
@Nombre text,
@Direccion text,
@Telefono text,
@Localidad text)
as
begin
update PROVEEDORES
set 
id_proveedor =@id_proveedor,
id_producto=@id_producto,
Nombre = @Nombre,
Dirección = @Direccion,
Telefono = @Telefono,
Localidad = @Localidad
where id_proveedor = @id_proveedor
end
go

create procedure SP_actualizar_marcas(
@id_marca int,
@nombre text)
as 
begin
update MARCAS
set
id_marca = @id_marca,
nombre = @nombre
where id_marca=@id_marca
end
go

create procedure SP_actualizar_generos(
@id_genero int,
@nombre text)
as 
begin
update GENEROS
set
id_genero = @id_genero,
descripcion = @nombre
where id_genero=@id_genero
end
go

create procedure sp_actualizar_Producto(
@id_producto int,
@nombre text,
@id_marca int,
@id_genero int,
@stock int,
@pegi int,
@portada image,
@descripcion text,
@preciounidad float
)
as
begin
update PRODUCTOS
set 
id_producto=@id_producto,
nombre=@nombre,
id_marca=@id_marca,
id_genero=@id_genero,
stock=@stock,
id_pegi=@pegi,
portada=@portada,
Descripcion=@descripcion,
precio_de_unidad=@preciounidad
where id_producto=@id_producto
end
go

create procedure SP_actualizar_clientes(
@id_cliente int,
@dni int,
@Nombre text,
@Direccion text,
@Telefono text)
as 
begin
update clientes
set
id_cliente=@id_cliente,
dni=@dni,
Nombre=@Nombre,
Direccion=@Direccion,
Telefono=@Telefono

where id_cliente=@id_cliente
end
go

create procedure sp_actualizar_Producto_sin_portada(
@id_producto int,
@nombre text,
@id_marca int,
@id_genero int,
@stock int,
@pegi int,
@descripcion text,
@preciounidad float
)
as
begin
update PRODUCTOS
set 
id_producto=@id_producto,
nombre=@nombre,
id_marca=@id_marca,
id_genero=@id_genero,
stock=@stock,
id_pegi=@pegi,
Descripcion=@descripcion,
precio_de_unidad=@preciounidad
where id_producto=@id_producto
end
go

CREATE Procedure venta_Insertar
(
 @id_cliente int,
 @dni_cliente int,
 @telefono int,
 @total float
)
as
begin
 insert into VENTAS (id_cliente, dni_cliente, telefono, total ) 
 select @id_cliente,@dni_cliente,@telefono,@total
end
GO

CREATE Procedure DetalleDeVenta_Insertar
(
 @id_venta int,
 @id_producto int,
 @cantidad int,
 @precio float
)
as
begin
 insert into DETALLE_VENTAS (id_venta, id_producto, cantidad, precio_unitario ) 
 select @id_venta, @id_producto,@cantidad,@precio
end
GO

create procedure SP_Eliminar_Detalle_de_Venta(
@id_producto int)
as
begin
delete from DETALLE_VENTAS where id_producto =@id_producto
end
go


--- COMPILACIÓN OK 30/01/2019 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
--->>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
--->>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
--->>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
--->>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
--->>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
--->>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
--->>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
--->>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
--->>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
--->>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
--->>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
--->>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
--->>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
--->>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
--->>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
--->>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
--->>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
--->>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
--->>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
--->>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
--->>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
--->>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
--->>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>

exec venta_Insertar 1,1,1,1.23
select * from VENTAS

select * from VENTAS


exec DetalleDeVenta_Insertar 1,1,1,1.23
select * from DETALLE_VENTAS
select * from ventas
select precio_de_unidad from PRODUCTOS where id_producto = 1
select count(id_venta) from ventas



SELECT * FROM PRODUCTOS
--estadisticas para el entraga con otro formulario
select max(stock)as stock_Hoy, id_producto from PRODUCTOS group by id_producto 
select sum (total)as Totalvendido_hoy from VENTAS where GETDATE()= GETDATE() -- aca estaria el campo de la fechab actual

select top 5 Nombre from CLIENTES --para los clientes mas compraron
go
--------------------------------------Consultas
------------------------------
select * from PRODUCTOS
go

select *from PEGI
go

select * from GENEROS
go

select * from MARCAS
go

select * from PROVEEDORES
go

select * from CLIENTES
go

select * from USUARIOS
go

SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE='BASE TABLE'
go

select PRODUCTOS.nombre from PRODUCTOS
where PRODUCTOS.id_producto = '2'
go

select GENEROS.descripcion from GENEROS
where GENEROS.descripcion LIKE 's%'
go

select MARCAS.nombre from MARCAS
where MARCAS.nombre LIKE '%o'
go

select CLIENTES.Nombre from CLIENTES
where CLIENTES.id_cliente > 3
go

select (productos.id_producto)as ID_Producto,(productos.nombre)as Nombre,(productos.id_marca)as ID_Marca,(productos.id_genero)as ID_Genero,(productos.id_pegi)as ID_Pegi,(productos.stock)as Stock,productos.Descripcion,(productos.precio_de_unidad)as Precio_X_Unidad 
from PRODUCTOS 
INNER JOIN MARCAS ON PRODUCTOS.id_marca = MARCAS.id_marca 
INNER JOIN GENEROS on PRODUCTOS.id_genero = GENEROS.id_genero 
INNER JOIN PEGI on PRODUCTOS.id_pegi = PEGI.id_pegi
go
------consultas
----------------------------------------



---Mes y año
SELECT 
       MONTH(01) as SalesMonth,
       SUM(total) AS TotalSales
FROM VENTAS
go

SELECT MONTH(01) as SalesMonth, SUM(total) AS TotalSales FROM VENTAS
go

--- Año
SELECT YEAR(fecha) as SalesYear,
       MONTH(fecha) as SalesMonth,
       SUM(total) AS TotalSales
FROM VENTAS
GROUP BY YEAR(fecha), MONTH(fecha)
ORDER BY YEAR(fecha), MONTH(fecha)
go

---
SELECT DATEPART(month, fecha) as mes, SUM(total) as total
FROM VENTAS
GROUP BY DATEPART(month, fecha)
go

SELECT DATEPART(month, fecha) as mes, SUM(total) as total FROM VENTAS WHERE fecha ='20190131 00:00:00' GROUP BY DATEPART(month, fecha)
go


---

SELECT DATEPART(month, 2019-02-02) as mes, SUM(total) as total
FROM VENTAS
go
select GETDATE()
go



---ESTE para mes
select sum (total)as Totalvendido_mes from VENTAS WHERE MONTH(fecha) like ('2')
go

select sum (total)as Totalvendido_mes from VENTAS WHERE MONTH(fecha) = '1'
go
---ESTE para mes

---ESTE PARA AÑO
select sum (total)as Totalvendido_anio from VENTAS WHERE YEAR(fecha) = '2018'
go
---ESTE PARA AÑO

--- ESTE PARA RANGO ENTE MESES
select sum (total)as Totalvendido_rangoMes from VENTAS WHERE month(fecha) between '01' and '01'
go
--- ESTE PARA RANGO ENTE MESES



SELECT month('2019-03-01') as mes, SUM(total) as total
FROM VENTAS
GROUP BY YEAR(fecha), MONTH(fecha)


SELECT month(fecha) AS Month, sum(total)as total
FROM VENTAS
WHERE MONTH(fecha) like ('1')
GROUP BY fecha 