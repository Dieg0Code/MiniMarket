-- Mostrar Venta
create proc spmostrar_VENTA
as
select top 100 * from VENTA
order by ID_VENTA desc
go

-- Guardar Venta
create proc spguardar_VENTA
@ID_VENTA int output,
@ID_CLIENTE int,
@ID_USUARIO int,
@ID_TIPO_DOC int,
@ID_TIPO_PAGO int,
@VEN_FECHA datetime,
@VEN_NUM_VENTA int,
@VEN_TOTAL decimal(19,2)
as
inser into VENTA (
ID_CLIENTE,
ID_USUARIO,
ID_TIPO_DOC,
ID_TIPO_PAGO,
VEN_FECHA,
VEN_NUM_VENTA,
VEN_TOTAL
) values (
@ID_CLIENTE,
@ID_USUARIO,
@ID_TIPO_DOC,
@ID_TIPO_PAGO,
@VEN_FECHA,
@VEN_NUM_VENTA,
@VEN_TOTAL
)
go

-- Actualizar Venta
create proc spactualizar_VENTA
@ID_VENTA int,
@ID_CLIENTE int,
@ID_USUARIO int,
@ID_TIPO_DOC int,
@ID_TIPO_PAGO int,
@VEN_FECHA datetime,
@VEN_NUM_VENTA int,
@VEN_TOTAL decimal(19,2)
as
update VENTA set
ID_CLIENTE = @ID_CLIENTE,
ID_USUARIO = @ID_USUARIO,
ID_TIPO_DOC = @ID_TIPO_DOC,
ID_TIPO_PAGO = @ID_TIPO_PAGO,
VEN_FECHA = @VEN_FECHA,
VEN_NUM_VENTA = @VEN_NUM_VENTA,
VEN_TOTAL = @VEN_TOTAL
where ID_VENTA = @ID_VENTA
go

-- Eliminar Venta
create proc speliminar_VENTA
@ID_VENTA int
as
delete from VENTA
where ID_VENTA = @ID_VENTA
go