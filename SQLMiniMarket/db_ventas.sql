/*==============================================================*/
/* DBMS name:      Microsoft SQL Server 2008                    */
/* Created on:     04-12-2021 16:34:51                          */
/*==============================================================*/


if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('CLIENTE') and o.name = 'FK_CLIENTE_REFERENCE_CIUDAD')
alter table CLIENTE
   drop constraint FK_CLIENTE_REFERENCE_CIUDAD
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('DETALLE_VENTA') and o.name = 'FK_DETALLE__REFERENCE_VENTA')
alter table DETALLE_VENTA
   drop constraint FK_DETALLE__REFERENCE_VENTA
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('DETALLE_VENTA') and o.name = 'FK_DETALLE__REFERENCE_PRODUCTO')
alter table DETALLE_VENTA
   drop constraint FK_DETALLE__REFERENCE_PRODUCTO
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('PRODUCTO') and o.name = 'FK_PRODUCTO_REFERENCE_CATEGORI')
alter table PRODUCTO
   drop constraint FK_PRODUCTO_REFERENCE_CATEGORI
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('USUARIO') and o.name = 'FK_USUARIO_REFERENCE_CIUDAD')
alter table USUARIO
   drop constraint FK_USUARIO_REFERENCE_CIUDAD
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('VENTA') and o.name = 'FK_VENTA_REFERENCE_CLIENTE')
alter table VENTA
   drop constraint FK_VENTA_REFERENCE_CLIENTE
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('VENTA') and o.name = 'FK_VENTA_REFERENCE_USUARIO')
alter table VENTA
   drop constraint FK_VENTA_REFERENCE_USUARIO
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('VENTA') and o.name = 'FK_VENTA_REFERENCE_TIPO_DOC')
alter table VENTA
   drop constraint FK_VENTA_REFERENCE_TIPO_DOC
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('VENTA') and o.name = 'FK_VENTA_REFERENCE_TIPO_PAG')
alter table VENTA
   drop constraint FK_VENTA_REFERENCE_TIPO_PAG
go

alter table CATEGORIA
   drop constraint PK_CATEGORIA
go

if exists (select 1
            from  sysobjects
           where  id = object_id('CATEGORIA')
            and   type = 'U')
   drop table CATEGORIA
go

alter table CIUDAD
   drop constraint PK_CIUDAD
go

if exists (select 1
            from  sysobjects
           where  id = object_id('CIUDAD')
            and   type = 'U')
   drop table CIUDAD
go

alter table CLIENTE
   drop constraint PK_CLIENTE
go

if exists (select 1
            from  sysobjects
           where  id = object_id('CLIENTE')
            and   type = 'U')
   drop table CLIENTE
go

alter table DETALLE_VENTA
   drop constraint PK_DETALLE_VENTA
go

if exists (select 1
            from  sysobjects
           where  id = object_id('DETALLE_VENTA')
            and   type = 'U')
   drop table DETALLE_VENTA
go

alter table PRODUCTO
   drop constraint PK_PRODUCTO
go

if exists (select 1
            from  sysobjects
           where  id = object_id('PRODUCTO')
            and   type = 'U')
   drop table PRODUCTO
go

alter table TIPO_DOCUMENTO
   drop constraint PK_TIPO_DOCUMENTO
go

if exists (select 1
            from  sysobjects
           where  id = object_id('TIPO_DOCUMENTO')
            and   type = 'U')
   drop table TIPO_DOCUMENTO
go

alter table TIPO_PAGO
   drop constraint PK_TIPO_PAGO
go

if exists (select 1
            from  sysobjects
           where  id = object_id('TIPO_PAGO')
            and   type = 'U')
   drop table TIPO_PAGO
go

alter table USUARIO
   drop constraint PK_USUARIO
go

if exists (select 1
            from  sysobjects
           where  id = object_id('USUARIO')
            and   type = 'U')
   drop table USUARIO
go

alter table VENTA
   drop constraint PK_VENTA
go

if exists (select 1
            from  sysobjects
           where  id = object_id('VENTA')
            and   type = 'U')
   drop table VENTA
go

/*==============================================================*/
/* Table: CATEGORIA                                             */
/*==============================================================*/
create table CATEGORIA (
   ID_CATEGORIA         int                  not null,
   CAT_NOMBRE           varchar(20)          not null
)
go

alter table CATEGORIA
   add constraint PK_CATEGORIA primary key (ID_CATEGORIA)
go

/*==============================================================*/
/* Table: CIUDAD                                                */
/*==============================================================*/
create table CIUDAD (
   ID_CIUDAD            int                  not null,
   CIU_NOMBRE           varchar(50)          not null
)
go

alter table CIUDAD
   add constraint PK_CIUDAD primary key (ID_CIUDAD)
go

/*==============================================================*/
/* Table: CLIENTE                                               */
/*==============================================================*/
create table CLIENTE (
   ID_CLIENTE           int                  not null,
   ID_CIUDAD            int                  null,
   CLI_RUT              varchar(10)          not null,
   CLI_NOMBRE           varchar(30)          not null,
   CLI_APELLIDOS        varchar(30)          not null,
   CLI_FECHA_NAC        datetime             not null,
   CLI_DIRECCION        varchar(80)          not null,
   CLI_TELEFONO         int                  not null,
   CLI_CORREO           varchar(50)          null
)
go

alter table CLIENTE
   add constraint PK_CLIENTE primary key (ID_CLIENTE)
go

/*==============================================================*/
/* Table: DETALLE_VENTA                                         */
/*==============================================================*/
create table DETALLE_VENTA (
   ID_DET_VENTA         int                  not null,
   ID_VENTA             int                  null,
   ID_PRODUCTO          int                  null,
   DET_VEN_CANTIDAD     int                  not null
)
go

alter table DETALLE_VENTA
   add constraint PK_DETALLE_VENTA primary key (ID_DET_VENTA)
go

/*==============================================================*/
/* Table: PRODUCTO                                              */
/*==============================================================*/
create table PRODUCTO (
   ID_PRODUCTO          int                  not null,
   ID_CATEGORIA         int                  null,
   PRO_CODIGO           varchar(10)          not null,
   PRO_NOMBRE           varchar(30)          not null,
   PRO_STOCK            int                  not null,
   PRO_PRECIO_UNITARIO  decimal(19,2)        not null
)
go

alter table PRODUCTO
   add constraint PK_PRODUCTO primary key (ID_PRODUCTO)
go

/*==============================================================*/
/* Table: TIPO_DOCUMENTO                                        */
/*==============================================================*/
create table TIPO_DOCUMENTO (
   ID_TIPO_DOC          int                  not null,
   TIPO_DOC_NOMBRE      varchar(20)          not null
)
go

alter table TIPO_DOCUMENTO
   add constraint PK_TIPO_DOCUMENTO primary key (ID_TIPO_DOC)
go

/*==============================================================*/
/* Table: TIPO_PAGO                                             */
/*==============================================================*/
create table TIPO_PAGO (
   ID_TIPO_PAGO         int                  not null,
   TIPO_PAGO_NOMBRE     varchar(15)          not null
)
go

alter table TIPO_PAGO
   add constraint PK_TIPO_PAGO primary key (ID_TIPO_PAGO)
go

/*==============================================================*/
/* Table: USUARIO                                               */
/*==============================================================*/
create table USUARIO (
   ID_USUARIO           int                  not null,
   ID_CIUDAD            int                  null,
   USU_RUT              varchar(10)          not null,
   USU_NOMBRE           varchar(20)          not null,
   USU_APELLIDOS        varchar(30)          not null,
   USU_FECHA_NAC        datetime             not null,
   USU_DIRECCION        varchar(80)          not null,
   USU_PASSWORD         varchar(15)          not null
)
go

alter table USUARIO
   add constraint PK_USUARIO primary key (ID_USUARIO)
go

/*==============================================================*/
/* Table: VENTA                                                 */
/*==============================================================*/
create table VENTA (
   ID_VENTA             int                  not null,
   ID_CLIENTE           int                  null,
   ID_USUARIO           int                  null,
   ID_TIPO_DOC          int                  null,
   ID_TIPO_PAGO         int                  null,
   VEN_FECHA            datetime             not null,
   VEN_NUM_VENTA        int                  not null,
   VEN_TOTAL            decimal(19,2)        not null
)
go

alter table VENTA
   add constraint PK_VENTA primary key (ID_VENTA)
go

alter table CLIENTE
   add constraint FK_CLIENTE_REFERENCE_CIUDAD foreign key (ID_CIUDAD)
      references CIUDAD (ID_CIUDAD)
go

alter table DETALLE_VENTA
   add constraint FK_DETALLE__REFERENCE_VENTA foreign key (ID_VENTA)
      references VENTA (ID_VENTA)
go

alter table DETALLE_VENTA
   add constraint FK_DETALLE__REFERENCE_PRODUCTO foreign key (ID_PRODUCTO)
      references PRODUCTO (ID_PRODUCTO)
go

alter table PRODUCTO
   add constraint FK_PRODUCTO_REFERENCE_CATEGORI foreign key (ID_CATEGORIA)
      references CATEGORIA (ID_CATEGORIA)
go

alter table USUARIO
   add constraint FK_USUARIO_REFERENCE_CIUDAD foreign key (ID_CIUDAD)
      references CIUDAD (ID_CIUDAD)
go

alter table VENTA
   add constraint FK_VENTA_REFERENCE_CLIENTE foreign key (ID_CLIENTE)
      references CLIENTE (ID_CLIENTE)
go

alter table VENTA
   add constraint FK_VENTA_REFERENCE_USUARIO foreign key (ID_USUARIO)
      references USUARIO (ID_USUARIO)
go

alter table VENTA
   add constraint FK_VENTA_REFERENCE_TIPO_DOC foreign key (ID_TIPO_DOC)
      references TIPO_DOCUMENTO (ID_TIPO_DOC)
go

alter table VENTA
   add constraint FK_VENTA_REFERENCE_TIPO_PAG foreign key (ID_TIPO_PAGO)
      references TIPO_PAGO (ID_TIPO_PAGO)
go

