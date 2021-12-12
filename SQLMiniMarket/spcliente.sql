--mostrar Cliente
create proc spMOstrar_Cliente
as
select top 100 * from CLIENTE
order by ID_CLIENTE desc 
go

--Guardar Cliente
create proc spguardar_Cliente 
@ID_CLIENTE int output,
@ID_CIUDAD int,
@CLI_RUT varchar(10),
@CLI_NOMBRE varchar(30),
@CLI_APELLIDOS varchar(30),
@CLI_FECHA_NAC datetime,
@CLI_DIRECCION varchar(80),
@CLI_TELEFONO int,
@CLI_CORREO varchar(50),
as
insert into CLIENTE(ID_CLIENTE,
ID_CIUDAD,
CLI_RUT,
CLI_NOMBRE,
CLI_APELLIDOS,
CLI_FECHA_NAC,
CLI_DIRECCION,
CLI_TELEFONO,
CLI_CORREO,
) values (@ID_CLIENTE,@ID_CIUDAD,@CLIENTE)
go

--Actualizar Cliente
create proc spguardar_Cliente
@ID_CLIENTE int,
@ID_CIUDAD int,
@CLI_RUT varchar(10),
@CLI_NOMBRE varchar(30),
@CLI_APELLIDOS varchar(30),
@CLI_FECHA_NAC datetime,
@CLI_DIRECCION  varchar(80),
@CLI_TELEFONO int,
@CLI_CORREO varchar(50),
as
update CLIENTE  set ID_CLIENTE = @ID_CLIENTE,
ID_CLIENTE = @ID_CLIENTE,
CLIENTE = @CLIENTE where ID_CLIENTE = @ID_CLIENTE
go

--eliminar Cliente
create proc spdeliminar_Cliente
@ID_CLIENTE int 
as
delete from CLIENTE where ID_CLIENTE = @ID_CLIENTE
go