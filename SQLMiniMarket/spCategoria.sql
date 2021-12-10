
-- Mostrar Categoria
create proc spmostrar_categoria
as
select top 100 * from CATEGORIA
order by ID_CATEGORIA desc
go

-- Guardar Categoria
create proc spguardar_categoria
@ID_CATEGORIA int output,
@CAT_NOMBRE varchar(20)
as
insert into CATEGORIA (CAT_NOMBRE) values (@CAT_NOMBRE)
go

-- Actualizar Categoria
create proc spactualizar_categoria
@ID_CATEGORIA int output,
@CAT_NOMBRE varchar(20)
as
update CATEGORIA set CAT_NOMBRE = @CAT_NOMBRE where ID_CATEGORIA = @ID_CATEGORIA
go

-- Eliminar Categoria
create proc speliminar_categoria
@ID_CATEGORIA int 
as
delete from CATEGORIA where ID_CATEGORIA = @ID_CATEGORIA
go

