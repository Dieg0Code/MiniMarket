-- mostra detalle venta
create proc spMostrar_DetalleVenta
as
select top 100 * from DETALLE_VENTA
order by ID_DET_VENTA desc
go

--Guardar detalle venta 
create proc spguardar_DetalleVenta
@ID_DET_VENTA int output,
@ID_VENTA int,
@ID_PRODUCTO int, 
@DET_VEN_CANTIDAD int,
as
insert into DETALLE_VENTA (ID_VENTA,
ID_PRODUCTO,
DET_VEN_CANTIDAD,
) values (@ID_VENTA, @ID_PRODUCTO, @DET_VEN_CANTIDAD)
go

-- Actualizar Detalle venta
create proc spguardar_DetalleVenta
@ID_DET_VENTA int,
@ID_VENTA int,
@ID_PRODUCTO int,
@DET_VEN_CANTIDAD int,
as
update DETALLE_VENTA set ID_VENTA = @ID_VENTA,
ID_PRODUCTO = @ID_PRODUCTO,
DET_VEN_CANTIDAD = @DET_VEN_CANTIDAD where ID_DET_VENTA = @ID_DET_VENTA 
go

-- eliminar detalle
create proc spdeliminar_DetalleVenta
@ID_DET_VENTA int
as
delete from DETALLE_VENTA where ID_DET_VENTA = @ID_DET_VENTA
go

