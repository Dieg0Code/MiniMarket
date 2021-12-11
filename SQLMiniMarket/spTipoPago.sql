-- Mostrar Tipo Pago
create proc spmostrar_tipoPago
as
select top 100 * from TIPO_PAGO
order by ID_TIPO_PAGO desc
go

-- Guardar Tipo Pago
create proc spguardar_tipoPago
@ID_TIPO_PAGO int output,
@TIPO_PAGO_NOMBRE varchar(15)
as
insert into TIPO_PAGO (TIPO_PAGO_NOMBRE) values (@TIPO_PAGO_NOMBRE)
go

-- Actualizar Tipo Pago
create proc spactualizar_tipo_pago
@ID_TIPO_PAGO int,
@TIPO_PAGO_NOMBRE varchar(15)
as
update TIPO_PAGO set TIPO_PAGO_NOMBRE = @TIPO_PAGO_NOMBRE where ID_TIPO_PAGO = @ID_TIPO_PAGO
go

-- Eliminar Tipo Pago
create proc speliminar_tipoPago
@ID_TIPO_PAGO int
as
delete from TIPO_PAGO where ID_TIPO_PAGO = @ID_TIPO_PAGO
go