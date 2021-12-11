-- Mostrar Usuario
create proc spmostrar_USUARIO
as
select top 100 * from USUARIO
order by ID_USUARIO desc
go

-- Guardar Usuario
create proc spguardar_USUARIO
@ID_USUARIO int output,
@ID_CIUDAD int,
@USU_RUT varchar(10),
@USU_NOMBRE varchar(20),
@USU_APELLIDOS varchar(30),
@USU_FECHA_NAC datetime,
@USU_DIRECCION varchar(80),
@USU_PASSWORD varchar(15)
as
insert into USUARIO (
ID_CIUDAD,
USU_RUT,
USU_NOMBRE,
USU_APELLIDOS,
USU_FECHA_NAC,
USU_DIRECCION,
USU_PASSWORD
) values (
@ID_CIUDAD,
@USU_RUT,
@USU_NOMBRE,
@USU_APELLIDOS,
@USU_FECHA_NAC,
@USU_DIRECCION,
@USU_PASSWORD
)
go

-- Actualizar Usuario
create proc spactualizar_USUARIO
@ID_USUARIO int,
@ID_CIUDAD int,
@USU_RUT varchar(10),
@USU_NOMBRE varchar(20),
@USU_APELLIDOS varchar(30),
@USU_FECHA_NAC datetime,
@USU_DIRECCION varchar(80),
@USU_PASSWORD varchar(15)
as
update USUARIO set
ID_CIUDAD = @ID_CIUDAD,
USU_RUT = @USU_RUT,
USU_NOMBRE = @USU_NOMBRE,
USU_APELLIDOS = @USU_APELLIDOS,
USU_FECHA_NAC = @USU_FECHA_NAC,
USU_DIRECCION = @USU_DIRECCION,
USU_PASSWORD = @USU_PASSWORD
where ID_USUARIO = @ID_USUARIO
go

-- Eliminar Usuario
create proc speliminar_USUARIO
@ID_USUARIO int
as
delete from USUARIO
where ID_USUARIO = @ID_USUARIO
go