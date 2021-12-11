-- Mostrar Producto
create proc spmostrar_PRODUCTO
as
select top 100 * from PRODUCTO
order by ID_PRODUCTO desc
go

-- Guardar Producto
create proc spguardar_PRODUCTO
@ID_PRODUCTO int output,
@ID_CATEGORIA int,
@PRO_CODIGO varchar(10),
@PRO_NOMBRE varchar(30),
@PRO_STOCK int,
@PRO_PRECIO_UNITARIO decimal(19,2)
as
insert into PRODUCTO (
ID_CATEGORIA,
PRO_CODIGO,
PRO_NOMBRE,
PRO_STOCK,
PRO_PRECIO_UNITARIO
) values (
@ID_CATEGORIA,
@PRO_CODIGO,
@PRO_NOMBRE,
@PRO_STOCK,
@PRO_PRECIO_UNITARIO
)
go

-- Actualizar Producto
create proc spactualizar_PRODUCTO
@ID_PRODUCTO int,
@ID_CATEGORIA int,
@PRO_CODIGO varchar(10),
@PRO_NOMBRE varchar(30),
@PRO_STOCK int,
@PRO_PRECIO_UNITARIO decimal(19,2)
as
update PRODUCTO set
ID_CATEGORIA = @ID_CATEGORIA,
PRO_CODIGO = @PRO_CODIGO,
PRO_NOMBRE = @PRO_NOMBRE,
PRO_STOCK = @PRO_STOCK,
PRO_PRECIO_UNITARIO = @PRO_PRECIO_UNITARIO
where ID_PRODUCTO = @ID_PRODUCTO
go

-- Eliminar Producto
create proc speliminar_PRODUCTO
@ID_PRODUCTO int
as
delete from PRODUCTO
where ID_PRODUCTO = @ID_PRODUCTO
go