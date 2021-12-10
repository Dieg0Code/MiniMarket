--Stored Procedure mostrar
-- creamos el procedimiento de mostrar ciudad, utilizando las siglas sp
create proc spmostrar_ciudad
as
--haremos un select tomando los primeros 100 registros de la tabla ciudad (todas las columnas)
select top 100 * from CIUDAD
-- los ordenara por su llave primaria de manera descendente
order by ID_CIUDAD desc
go

-- Stored Procedure Guardar
create proc spguardar_ciudad
@ID_CIUDAD int output,
@CIU_NOMBRE varchar(50)
as
insert into CIUDAD (CIU_NOMBRE) values (@CIU_NOMBRE)
go

-- Stored Procedure Actualizar
create proc spactualizar_ciudad
@ID_CIUDAD int,
@CIU_NOMBRE varchar(50)
as
update CIUDAD set CIU_NOMBRE = @CIU_NOMBRE where ID_CIUDAD = @ID_CIUDAD
go

-- Stored Procedure Eliminar
create proc speliminar_ciudad
@ID_CIUDAD int
as
delete from CIUDAD where ID_CIUDAD = @ID_CIUDAD
go