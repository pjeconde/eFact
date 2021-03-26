CREATE DATABASE [eFact-R] 
GO
CREATE LOGIN usr_eFact WITH PASSWORD = '123456', DEFAULT_DATABASE=[eFact-R]
GO
USE [eFact-R]
GO
create role ce_update
GO
CREATE USER usr_eFact FOR LOGIN usr_eFact
GO
EXEC sp_addrolemember 'ce_update', 'usr_eFact'
GO

USE [eFact-R];
GO
SET ANSI_NULLS ON;
GO
SET QUOTED_IDENTIFIER ON;
GO
CREATE TABLE [dbo].[Archivos] (
[IdArchivo] int IDENTITY(1, 1) NOT NULL,
[Nombre] varchar(255) COLLATE Modern_Spanish_CI_AS NOT NULL,
[Tipo] varchar(10) COLLATE Modern_Spanish_CI_AS NOT NULL,
[Path] varchar(255) COLLATE Modern_Spanish_CI_AS NOT NULL,
[FechaCreacion] datetime NOT NULL,
[FechaModificacion] datetime NOT NULL,
[Tamaño] int NOT NULL,
[TamañoUMedida] varchar(10) COLLATE Modern_Spanish_CI_AS NOT NULL,
[Comentario] text COLLATE Modern_Spanish_CI_AS NULL,
[FechaProceso] datetime NOT NULL,
[NombreProcesado] text COLLATE Modern_Spanish_CI_AS NOT NULL,
[IdUsuario] varchar(15) COLLATE Modern_Spanish_CI_AS NOT NULL,
[IdLote] int NULL)
ON [PRIMARY]
TEXTIMAGE_ON [PRIMARY];
GO

GRANT SELECT ON [dbo].[Archivos] TO [ce_update];
GO
GRANT UPDATE ON [dbo].[Archivos] TO [ce_update];
GO
GRANT REFERENCES ON [dbo].[Archivos] TO [ce_update];
GO
GRANT INSERT ON [dbo].[Archivos] TO [ce_update];
GO
GRANT DELETE ON [dbo].[Archivos] TO [ce_update];
GO

/****** Object: Table [dbo].[Comprobantes]   Script Date: 15/02/2010 11:31:08 ******/
USE [eFact-R];
GO
SET ANSI_NULLS ON;
GO
SET QUOTED_IDENTIFIER ON;
GO
CREATE TABLE [dbo].[Comprobantes] (
[IdLote] int NOT NULL,
[IdTipoComprobante] varchar(2) COLLATE Modern_Spanish_CI_AS NOT NULL,
[NumeroComprobante] varchar(8) COLLATE Modern_Spanish_CI_AS NOT NULL,
[TipoDocComprador] varchar(3) COLLATE Modern_Spanish_CI_AS NOT NULL,
[NroDocComprador] varchar(11) COLLATE Modern_Spanish_CI_AS NOT NULL,
[NombreComprador] varchar(60) COLLATE Modern_Spanish_CI_AS NOT NULL,
[Fecha] datetime NOT NULL,
[IdMoneda] varchar(3) COLLATE Modern_Spanish_CI_AS NOT NULL,
[Importe] decimal(18, 2) NOT NULL,
[NumeroCAE] varchar(14) COLLATE Modern_Spanish_CI_AS NULL,
[FechaCAE] datetime NULL,
[FechaVtoCAE] datetime NULL,
CONSTRAINT [PK_Comprobantes]
PRIMARY KEY CLUSTERED ([IdLote] ASC, [IdTipoComprobante] ASC, [NumeroComprobante] ASC)
WITH ( PAD_INDEX = OFF,
FILLFACTOR = 100,
IGNORE_DUP_KEY = OFF,
STATISTICS_NORECOMPUTE = OFF,
ALLOW_ROW_LOCKS = ON,
ALLOW_PAGE_LOCKS = ON )
 ON [PRIMARY]
)
ON [PRIMARY];
GO

GRANT SELECT ON [dbo].[Comprobantes] TO [ce_update];
GO
GRANT UPDATE ON [dbo].[Comprobantes] TO [ce_update];
GO
GRANT REFERENCES ON [dbo].[Comprobantes] TO [ce_update];
GO
GRANT INSERT ON [dbo].[Comprobantes] TO [ce_update];
GO
GRANT DELETE ON [dbo].[Comprobantes] TO [ce_update];
GO

/****** Object: Table [dbo].[Lotes]   Script Date: 15/02/2010 11:31:09 ******/
USE [eFact-R];
GO
SET ANSI_NULLS ON;
GO
SET QUOTED_IDENTIFIER ON;
GO
CREATE TABLE [dbo].[Lotes] (
[IdLote] int IDENTITY(1, 1) NOT NULL,
[CuitVendedor] varchar(11) COLLATE Modern_Spanish_CI_AS NOT NULL,
[NumeroLote] varchar(20) COLLATE Modern_Spanish_CI_AS NOT NULL,
[PuntoVenta] varchar(4) COLLATE Modern_Spanish_CI_AS NOT NULL,
[NumeroEnvio] int NOT NULL,
[IdOp] int NOT NULL,
[FechaAlta] datetime NOT NULL,
[FechaEnvio] datetime NULL,
[CantidadRegistros] int NOT NULL,
[NombreArch] varchar(255) COLLATE Modern_Spanish_CI_AS NOT NULL,
[LoteXML] text COLLATE Modern_Spanish_CI_AS NOT NULL,
[LoteXMLIF] text COLLATE Modern_Spanish_CI_AS NOT NULL,
CONSTRAINT [PK_Lotes]
PRIMARY KEY CLUSTERED ([IdLote] ASC, [NumeroLote] ASC, [PuntoVenta] ASC, [NumeroEnvio] ASC)
WITH ( PAD_INDEX = OFF,
FILLFACTOR = 100,
IGNORE_DUP_KEY = OFF,
STATISTICS_NORECOMPUTE = OFF,
ALLOW_ROW_LOCKS = ON,
ALLOW_PAGE_LOCKS = ON )
 ON [PRIMARY]
)
ON [PRIMARY]
TEXTIMAGE_ON [PRIMARY];
GO

GRANT SELECT ON [dbo].[Lotes] TO [ce_update];
GO
GRANT UPDATE ON [dbo].[Lotes] TO [ce_update];
GO
GRANT REFERENCES ON [dbo].[Lotes] TO [ce_update];
GO
GRANT INSERT ON [dbo].[Lotes] TO [ce_update];
GO
GRANT DELETE ON [dbo].[Lotes] TO [ce_update];
GO


/****** Object: Table [dbo].[Vendedores]   Script Date: 15/02/2010 11:31:09 ******/
USE [eFact-R];
GO
SET ANSI_NULLS ON;
GO
SET QUOTED_IDENTIFIER ON;
GO
CREATE TABLE [dbo].[Vendedores] (
[CuitVendedor] varchar(11) COLLATE Modern_Spanish_CI_AS NOT NULL,
[Nombre] varchar(255) COLLATE Modern_Spanish_CI_AS NULL,
[NumeroSerieCertificado] varchar(255) COLLATE Modern_Spanish_CI_AS NOT NULL,
[Logo] image NULL,
[Codigo] varchar(255) COLLATE Modern_Spanish_CI_AS NULL,
[CondicionIVA] int NULL,
[CondicionIB] int NULL,
[NroIB] varchar(13) COLLATE Modern_Spanish_CI_AS NULL,
[InicioActividades] datetime NULL,
[Contacto] varchar(25) COLLATE Modern_Spanish_CI_AS NULL,
[DomicilioCalle] varchar(30) COLLATE Modern_Spanish_CI_AS NULL,
[DomicilioNumero] varchar(6) COLLATE Modern_Spanish_CI_AS NULL,
[DomicilioPiso] varchar(5) COLLATE Modern_Spanish_CI_AS NULL,
[DomicilioDepto] varchar(5) COLLATE Modern_Spanish_CI_AS NULL,
[DomicilioSector] varchar(5) COLLATE Modern_Spanish_CI_AS NULL,
[DomicilioTorre] varchar(5) COLLATE Modern_Spanish_CI_AS NULL,
[DomicilioManzana] varchar(5) COLLATE Modern_Spanish_CI_AS NULL,
[Localidad] varchar(25) COLLATE Modern_Spanish_CI_AS NULL,
[Provincia] varchar(2) COLLATE Modern_Spanish_CI_AS NULL,
[CP] varchar(8) COLLATE Modern_Spanish_CI_AS NULL,
[EMail] varchar(60) COLLATE Modern_Spanish_CI_AS NULL,
[Telefono] varchar(15) COLLATE Modern_Spanish_CI_AS NULL,
CONSTRAINT [PK_Vendedores]
PRIMARY KEY CLUSTERED ([CuitVendedor] ASC)
WITH ( PAD_INDEX = OFF,
FILLFACTOR = 100,
IGNORE_DUP_KEY = OFF,
STATISTICS_NORECOMPUTE = OFF,
ALLOW_ROW_LOCKS = ON,
ALLOW_PAGE_LOCKS = ON )
 ON [PRIMARY]
)
ON [PRIMARY]
TEXTIMAGE_ON [PRIMARY];
GO

GRANT SELECT ON [dbo].[Vendedores] TO [ce_update];
GO
GRANT UPDATE ON [dbo].[Vendedores] TO [ce_update];
GO
GRANT REFERENCES ON [dbo].[Vendedores] TO [ce_update];
GO
GRANT INSERT ON [dbo].[Vendedores] TO [ce_update];
GO
GRANT DELETE ON [dbo].[Vendedores] TO [ce_update];
GO


/****** Object: Table [dbo].[WCTbGrupos]   Script Date: 15/02/2010 11:31:10 ******/
USE [eFact-R];
GO
SET ANSI_NULLS ON;
GO
SET QUOTED_IDENTIFIER ON;
GO
CREATE TABLE [dbo].[WCTbGrupos] (
[IdGrupo] varchar(15) COLLATE Modern_Spanish_CI_AS NOT NULL,
[Descr] varchar(40) COLLATE Modern_Spanish_CI_AS NULL,
[IdTGrupo] char(3) COLLATE Modern_Spanish_CI_AS NULL,
CONSTRAINT [XPKWCTbGrupos]
PRIMARY KEY CLUSTERED ([IdGrupo] ASC)
WITH ( PAD_INDEX = OFF,
FILLFACTOR = 100,
IGNORE_DUP_KEY = OFF,
STATISTICS_NORECOMPUTE = OFF,
ALLOW_ROW_LOCKS = ON,
ALLOW_PAGE_LOCKS = ON )
 ON [PRIMARY]
)
ON [PRIMARY];
GO

GRANT SELECT ON [dbo].[WCTbGrupos] TO [ce_update];
GO
GRANT UPDATE ON [dbo].[WCTbGrupos] TO [ce_update];
GO
GRANT REFERENCES ON [dbo].[WCTbGrupos] TO [ce_update];
GO
GRANT INSERT ON [dbo].[WCTbGrupos] TO [ce_update];
GO
GRANT DELETE ON [dbo].[WCTbGrupos] TO [ce_update];
GO


/****** Object: Table [dbo].[WCUsuarios]   Script Date: 15/02/2010 11:31:10 ******/
USE [eFact-R];
GO
SET ANSI_NULLS ON;
GO
SET QUOTED_IDENTIFIER ON;
GO
CREATE TABLE [dbo].[WCUsuarios] (
[IdUsuario] varchar(15) COLLATE Modern_Spanish_CI_AS NOT NULL,
[Nombre] varchar(40) COLLATE Modern_Spanish_CI_AS NULL,
[Activo] bit NULL,
[Alias] varchar(30) COLLATE Modern_Spanish_CI_AS NULL,
[FecAlta] smalldatetime NOT NULL,
[FecBaja] smalldatetime NOT NULL,
[RequierePassword] bit NULL,
[Email] varchar(255) COLLATE Modern_Spanish_CI_AS NULL,
CONSTRAINT [XPKWCUsuarios]
PRIMARY KEY CLUSTERED ([IdUsuario] ASC)
WITH ( PAD_INDEX = OFF,
FILLFACTOR = 100,
IGNORE_DUP_KEY = OFF,
STATISTICS_NORECOMPUTE = OFF,
ALLOW_ROW_LOCKS = ON,
ALLOW_PAGE_LOCKS = ON )
 ON [PRIMARY]
)
ON [PRIMARY];
GO

GRANT SELECT ON [dbo].[WCUsuarios] TO [ce_update];
GO
GRANT UPDATE ON [dbo].[WCUsuarios] TO [ce_update];
GO
GRANT REFERENCES ON [dbo].[WCUsuarios] TO [ce_update];
GO
GRANT INSERT ON [dbo].[WCUsuarios] TO [ce_update];
GO
GRANT DELETE ON [dbo].[WCUsuarios] TO [ce_update];
GO


/****** Object: Table [dbo].[WCGrupos]   Script Date: 15/02/2010 11:31:10 ******/
USE [eFact-R];
GO
SET ANSI_NULLS ON;
GO
SET QUOTED_IDENTIFIER ON;
GO
CREATE TABLE [dbo].[WCGrupos] (
[IdGrupo] varchar(15) COLLATE Modern_Spanish_CI_AS NOT NULL,
[IdUsuario] varchar(15) COLLATE Modern_Spanish_CI_AS NOT NULL,
[Supervisor] bit NULL,
[SupervisorNivel] tinyint NOT NULL,
CONSTRAINT [XPKWCGrupos]
PRIMARY KEY CLUSTERED ([IdGrupo] ASC, [IdUsuario] ASC)
WITH ( PAD_INDEX = OFF,
FILLFACTOR = 100,
IGNORE_DUP_KEY = OFF,
STATISTICS_NORECOMPUTE = OFF,
ALLOW_ROW_LOCKS = ON,
ALLOW_PAGE_LOCKS = ON )
 ON [PRIMARY],
CONSTRAINT [FK_WCTbGrupos_WCGrupos]
FOREIGN KEY ([IdGrupo])
REFERENCES [dbo].[WCTbGrupos] ( [IdGrupo] ),
CONSTRAINT [FK_WCUsuarios_WCGrupos]
FOREIGN KEY ([IdUsuario])
REFERENCES [dbo].[WCUsuarios] ( [IdUsuario] )
)
ON [PRIMARY];
GO

GRANT SELECT ON [dbo].[WCGrupos] TO [ce_update];
GO
GRANT UPDATE ON [dbo].[WCGrupos] TO [ce_update];
GO
GRANT REFERENCES ON [dbo].[WCGrupos] TO [ce_update];
GO
GRANT INSERT ON [dbo].[WCGrupos] TO [ce_update];
GO
GRANT DELETE ON [dbo].[WCGrupos] TO [ce_update];
GO


/****** Object: Table [dbo].[WF_Acceso]   Script Date: 15/02/2010 11:31:10 ******/
USE [eFact-R];
GO
SET ANSI_NULLS ON;
GO
SET QUOTED_IDENTIFIER ON;
GO
CREATE TABLE [dbo].[WF_Acceso] (
[IdAcceso] varchar(15) COLLATE Modern_Spanish_CI_AS NOT NULL,
[DescrAcceso] varchar(50) COLLATE Modern_Spanish_CI_AS NOT NULL,
[AssemblyVersion] varchar(50) COLLATE Modern_Spanish_CI_AS NULL DEFAULT (''),
CONSTRAINT [PK_WF_Acceso]
PRIMARY KEY CLUSTERED ([IdAcceso] ASC)
WITH ( PAD_INDEX = OFF,
FILLFACTOR = 100,
IGNORE_DUP_KEY = OFF,
STATISTICS_NORECOMPUTE = OFF,
ALLOW_ROW_LOCKS = ON,
ALLOW_PAGE_LOCKS = ON )
 ON [PRIMARY]
)
ON [PRIMARY];
GO

GRANT SELECT ON [dbo].[WF_Acceso] TO [ce_update];
GO
GRANT UPDATE ON [dbo].[WF_Acceso] TO [ce_update];
GO
GRANT REFERENCES ON [dbo].[WF_Acceso] TO [ce_update];
GO
GRANT INSERT ON [dbo].[WF_Acceso] TO [ce_update];
GO
GRANT DELETE ON [dbo].[WF_Acceso] TO [ce_update];
GO



/****** Object: Table [dbo].[WF_Circuito]   Script Date: 15/02/2010 11:31:11 ******/
USE [eFact-R];
GO
SET ANSI_NULLS ON;
GO
SET QUOTED_IDENTIFIER ON;
GO
CREATE TABLE [dbo].[WF_Circuito] (
[IdCircuito] varchar(15) COLLATE Modern_Spanish_CI_AS NOT NULL,
[DescrCircuito] varchar(50) COLLATE Modern_Spanish_CI_AS NOT NULL,
CONSTRAINT [PK_WF_Circuito]
PRIMARY KEY CLUSTERED ([IdCircuito] ASC)
WITH ( PAD_INDEX = OFF,
FILLFACTOR = 100,
IGNORE_DUP_KEY = OFF,
STATISTICS_NORECOMPUTE = OFF,
ALLOW_ROW_LOCKS = ON,
ALLOW_PAGE_LOCKS = ON )
 ON [PRIMARY]
)
ON [PRIMARY];
GO

GRANT SELECT ON [dbo].[WF_Circuito] TO [ce_update];
GO
GRANT UPDATE ON [dbo].[WF_Circuito] TO [ce_update];
GO
GRANT REFERENCES ON [dbo].[WF_Circuito] TO [ce_update];
GO
GRANT INSERT ON [dbo].[WF_Circuito] TO [ce_update];
GO
GRANT DELETE ON [dbo].[WF_Circuito] TO [ce_update];
GO


/****** Object: Table [dbo].[WF_Estado]   Script Date: 15/02/2010 11:31:12 ******/
USE [eFact-R];
GO
SET ANSI_NULLS ON;
GO
SET QUOTED_IDENTIFIER ON;
GO
CREATE TABLE [dbo].[WF_Estado] (
[IdEstado] varchar(15) COLLATE Modern_Spanish_CI_AS NOT NULL,
[DescrEstado] varchar(50) COLLATE Modern_Spanish_CI_AS NOT NULL,
[Virtual] bit NOT NULL DEFAULT ((0)),
CONSTRAINT [PK_WF_Estado]
PRIMARY KEY CLUSTERED ([IdEstado] ASC)
WITH ( PAD_INDEX = OFF,
FILLFACTOR = 100,
IGNORE_DUP_KEY = OFF,
STATISTICS_NORECOMPUTE = OFF,
ALLOW_ROW_LOCKS = ON,
ALLOW_PAGE_LOCKS = ON )
 ON [PRIMARY]
)
ON [PRIMARY];
GO

GRANT SELECT ON [dbo].[WF_Estado] TO [ce_update];
GO
GRANT UPDATE ON [dbo].[WF_Estado] TO [ce_update];
GO
GRANT REFERENCES ON [dbo].[WF_Estado] TO [ce_update];
GO
GRANT INSERT ON [dbo].[WF_Estado] TO [ce_update];
GO
GRANT DELETE ON [dbo].[WF_Estado] TO [ce_update];
GO


/****** Object: Table [dbo].[WF_Flow]   Script Date: 15/02/2010 11:31:13 ******/
USE [eFact-R];
GO
SET ANSI_NULLS ON;
GO
SET QUOTED_IDENTIFIER ON;
GO
CREATE TABLE [dbo].[WF_Flow] (
[IdFlow] varchar(10) COLLATE Modern_Spanish_CI_AS NOT NULL,
[DescrFlow] varchar(50) COLLATE Modern_Spanish_CI_AS NOT NULL,
CONSTRAINT [PK_WF_Flow]
PRIMARY KEY CLUSTERED ([IdFlow] ASC)
WITH ( PAD_INDEX = OFF,
FILLFACTOR = 100,
IGNORE_DUP_KEY = OFF,
STATISTICS_NORECOMPUTE = OFF,
ALLOW_ROW_LOCKS = ON,
ALLOW_PAGE_LOCKS = ON )
 ON [PRIMARY]
)
ON [PRIMARY];
GO

GRANT SELECT ON [dbo].[WF_Flow] TO [ce_update];
GO
GRANT UPDATE ON [dbo].[WF_Flow] TO [ce_update];
GO
GRANT REFERENCES ON [dbo].[WF_Flow] TO [ce_update];
GO
GRANT INSERT ON [dbo].[WF_Flow] TO [ce_update];
GO
GRANT DELETE ON [dbo].[WF_Flow] TO [ce_update];
GO


/****** Object: Table [dbo].[WF_NivSeg]   Script Date: 15/02/2010 11:31:14 ******/
USE [eFact-R];
GO
SET ANSI_NULLS ON;
GO
SET QUOTED_IDENTIFIER ON;
GO
CREATE TABLE [dbo].[WF_NivSeg] (
[IdNivSeg] int NOT NULL,
[DescrNivSeg] varchar(50) COLLATE Modern_Spanish_CI_AS NOT NULL,
CONSTRAINT [PK_WF_NivSeg]
PRIMARY KEY CLUSTERED ([IdNivSeg] ASC)
WITH ( PAD_INDEX = OFF,
FILLFACTOR = 100,
IGNORE_DUP_KEY = OFF,
STATISTICS_NORECOMPUTE = OFF,
ALLOW_ROW_LOCKS = ON,
ALLOW_PAGE_LOCKS = ON )
 ON [PRIMARY]
)
ON [PRIMARY];
GO

GRANT SELECT ON [dbo].[WF_NivSeg] TO [ce_update];
GO
GRANT UPDATE ON [dbo].[WF_NivSeg] TO [ce_update];
GO
GRANT REFERENCES ON [dbo].[WF_NivSeg] TO [ce_update];
GO
GRANT INSERT ON [dbo].[WF_NivSeg] TO [ce_update];
GO
GRANT DELETE ON [dbo].[WF_NivSeg] TO [ce_update];
GO


/****** Object: Table [dbo].[WF_Op]   Script Date: 15/02/2010 11:31:14 ******/
USE [eFact-R];
GO
SET ANSI_NULLS ON;
GO
SET QUOTED_IDENTIFIER ON;
GO
CREATE TABLE [dbo].[WF_Op] (
[IdOp] int IDENTITY(1, 1) NOT NULL,
[IdFlow] varchar(10) COLLATE Modern_Spanish_CI_AS NOT NULL,
[IdCircuito] varchar(15) COLLATE Modern_Spanish_CI_AS NOT NULL,
[IdNivSeg] int NOT NULL,
[IdEstado] varchar(15) COLLATE Modern_Spanish_CI_AS NOT NULL,
[DescrOp] varchar(255) COLLATE Modern_Spanish_CI_AS NOT NULL,
[UltActualiz] timestamp NOT NULL,
CONSTRAINT [PK_WF_Op]
PRIMARY KEY CLUSTERED ([IdOp] ASC)
WITH ( PAD_INDEX = OFF,
FILLFACTOR = 100,
IGNORE_DUP_KEY = OFF,
STATISTICS_NORECOMPUTE = OFF,
ALLOW_ROW_LOCKS = ON,
ALLOW_PAGE_LOCKS = ON )
 ON [PRIMARY],
CONSTRAINT [FK_WF_Op_WF_Flow]
FOREIGN KEY ([IdFlow])
REFERENCES [dbo].[WF_Flow] ( [IdFlow] ),
CONSTRAINT [FK_WF_Op_WF_Circuito]
FOREIGN KEY ([IdCircuito])
REFERENCES [dbo].[WF_Circuito] ( [IdCircuito] ),
CONSTRAINT [FK_WF_Op_WF_Estado]
FOREIGN KEY ([IdEstado])
REFERENCES [dbo].[WF_Estado] ( [IdEstado] ),
CONSTRAINT [FK_WF_Op_WF_NivSeg]
FOREIGN KEY ([IdNivSeg])
REFERENCES [dbo].[WF_NivSeg] ( [IdNivSeg] )
)
ON [PRIMARY];
GO

GRANT SELECT ON [dbo].[WF_Op] TO [ce_update];
GO
GRANT UPDATE ON [dbo].[WF_Op] TO [ce_update];
GO
GRANT REFERENCES ON [dbo].[WF_Op] TO [ce_update];
GO
GRANT INSERT ON [dbo].[WF_Op] TO [ce_update];
GO
GRANT DELETE ON [dbo].[WF_Op] TO [ce_update];
GO


/****** Object: Table [dbo].[WF_Log]   Script Date: 15/02/2010 11:31:14 ******/
USE [eFact-R];
GO
SET ANSI_NULLS ON;
GO
SET QUOTED_IDENTIFIER ON;
GO
CREATE TABLE [dbo].[WF_Log] (
[IdLog] int IDENTITY(1, 1) NOT NULL,
[IdOp] int NOT NULL,
[IdUsuario] varchar(15) COLLATE Modern_Spanish_CI_AS NOT NULL,
[IdFlow] varchar(10) COLLATE Modern_Spanish_CI_AS NOT NULL,
[IdCircuito] varchar(15) COLLATE Modern_Spanish_CI_AS NOT NULL,
[IdNivSeg] int NOT NULL,
[IdEvento] varchar(15) COLLATE Modern_Spanish_CI_AS NOT NULL,
[Fecha] datetime NOT NULL,
[Comentario] text COLLATE Modern_Spanish_CI_AS NOT NULL,
[IdEstado] varchar(15) COLLATE Modern_Spanish_CI_AS NOT NULL,
[IdGrupo] varchar(15) COLLATE Modern_Spanish_CI_AS NOT NULL,
[Supervisor] bit NOT NULL,
[SupervisorNivel] tinyint NOT NULL,
CONSTRAINT [PK_WF_Log]
PRIMARY KEY CLUSTERED ([IdLog] ASC)
WITH ( PAD_INDEX = OFF,
FILLFACTOR = 100,
IGNORE_DUP_KEY = OFF,
STATISTICS_NORECOMPUTE = OFF,
ALLOW_ROW_LOCKS = ON,
ALLOW_PAGE_LOCKS = ON )
 ON [PRIMARY],
CONSTRAINT [FK_WF_Log_WCTbGrupos]
FOREIGN KEY ([IdGrupo])
REFERENCES [dbo].[WCTbGrupos] ( [IdGrupo] ),
CONSTRAINT [FK_WF_Log_WCUsuarios]
FOREIGN KEY ([IdUsuario])
REFERENCES [dbo].[WCUsuarios] ( [IdUsuario] ),
CONSTRAINT [FK_WF_Log_WF_Estado]
FOREIGN KEY ([IdEstado])
REFERENCES [dbo].[WF_Estado] ( [IdEstado] ),
CONSTRAINT [FK_WF_Log_WF_Op]
FOREIGN KEY ([IdOp])
REFERENCES [dbo].[WF_Op] ( [IdOp] )
)
ON [PRIMARY]
TEXTIMAGE_ON [PRIMARY];
GO

GRANT SELECT ON [dbo].[WF_Log] TO [ce_update];
GO
GRANT UPDATE ON [dbo].[WF_Log] TO [ce_update];
GO
GRANT REFERENCES ON [dbo].[WF_Log] TO [ce_update];
GO
GRANT INSERT ON [dbo].[WF_Log] TO [ce_update];
GO
GRANT DELETE ON [dbo].[WF_Log] TO [ce_update];
GO


/****** Object: Table [dbo].[WF_Parm]   Script Date: 15/02/2010 11:31:15 ******/
USE [eFact-R];
GO
SET ANSI_NULLS ON;
GO
SET QUOTED_IDENTIFIER ON;
GO
CREATE TABLE [dbo].[WF_Parm] (
[IdParm] varchar(30) COLLATE Modern_Spanish_CI_AS NOT NULL,
[ValorInt] int NOT NULL,
[ValorStr] varchar(200) COLLATE Modern_Spanish_CI_AS NOT NULL DEFAULT (''),
CONSTRAINT [PK_WF_Parm]
PRIMARY KEY CLUSTERED ([IdParm] ASC)
WITH ( PAD_INDEX = OFF,
FILLFACTOR = 100,
IGNORE_DUP_KEY = OFF,
STATISTICS_NORECOMPUTE = OFF,
ALLOW_ROW_LOCKS = ON,
ALLOW_PAGE_LOCKS = ON )
 ON [PRIMARY]
)
ON [PRIMARY];
GO

GRANT SELECT ON [dbo].[WF_Parm] TO [ce_update];
GO
GRANT UPDATE ON [dbo].[WF_Parm] TO [ce_update];
GO
GRANT REFERENCES ON [dbo].[WF_Parm] TO [ce_update];
GO
GRANT INSERT ON [dbo].[WF_Parm] TO [ce_update];
GO
GRANT DELETE ON [dbo].[WF_Parm] TO [ce_update];
GO


/****** Object: Table [dbo].[WF_PermisoGrupoXAcceso]   Script Date: 15/02/2010 11:31:15 ******/
USE [eFact-R];
GO
SET ANSI_NULLS ON;
GO
SET QUOTED_IDENTIFIER ON;
GO
CREATE TABLE [dbo].[WF_PermisoGrupoXAcceso] (
[IdGrupo] varchar(15) COLLATE Modern_Spanish_CI_AS NOT NULL,
[IdAcceso] varchar(15) COLLATE Modern_Spanish_CI_AS NOT NULL,
[Permiso] bit NOT NULL,
CONSTRAINT [PK_WF_PermisoGrupoXAcceso]
PRIMARY KEY CLUSTERED ([IdGrupo] ASC, [IdAcceso] ASC)
WITH ( PAD_INDEX = OFF,
FILLFACTOR = 100,
IGNORE_DUP_KEY = OFF,
STATISTICS_NORECOMPUTE = OFF,
ALLOW_ROW_LOCKS = ON,
ALLOW_PAGE_LOCKS = ON )
 ON [PRIMARY],
CONSTRAINT [FK_WF_PermisoGrupoXAcceso_WCTbGrupos]
FOREIGN KEY ([IdGrupo])
REFERENCES [dbo].[WCTbGrupos] ( [IdGrupo] ),
CONSTRAINT [FK_WF_PermisoGrupoXAcceso_WF_Acceso]
FOREIGN KEY ([IdAcceso])
REFERENCES [dbo].[WF_Acceso] ( [IdAcceso] )
)
ON [PRIMARY];
GO

GRANT SELECT ON [dbo].[WF_PermisoGrupoXAcceso] TO [ce_update];
GO
GRANT UPDATE ON [dbo].[WF_PermisoGrupoXAcceso] TO [ce_update];
GO
GRANT REFERENCES ON [dbo].[WF_PermisoGrupoXAcceso] TO [ce_update];
GO
GRANT INSERT ON [dbo].[WF_PermisoGrupoXAcceso] TO [ce_update];
GO
GRANT DELETE ON [dbo].[WF_PermisoGrupoXAcceso] TO [ce_update];
GO


/****** Object: Table [dbo].[WF_Evento]   Script Date: 15/02/2010 11:31:13 ******/
USE [eFact-R];
GO
SET ANSI_NULLS ON;
GO
SET QUOTED_IDENTIFIER ON;
GO
CREATE TABLE [dbo].[WF_Evento] (
[IdFlow] varchar(10) COLLATE Modern_Spanish_CI_AS NOT NULL,
[IdEvento] varchar(15) COLLATE Modern_Spanish_CI_AS NOT NULL,
[DescrEvento] varchar(50) COLLATE Modern_Spanish_CI_AS NOT NULL,
[TextoAccion] varchar(40) COLLATE Modern_Spanish_CI_AS NOT NULL,
[IdEstadoDsd] varchar(15) COLLATE Modern_Spanish_CI_AS NULL,
[IdEstadoHst] varchar(15) COLLATE Modern_Spanish_CI_AS NULL,
[Automatico] bit NULL,
[CXO] bit NOT NULL,
[XLote] bit NOT NULL DEFAULT ((0)),
CONSTRAINT [PK_WF_Evento]
PRIMARY KEY CLUSTERED ([IdFlow] ASC, [IdEvento] ASC)
WITH ( PAD_INDEX = OFF,
FILLFACTOR = 100,
IGNORE_DUP_KEY = OFF,
STATISTICS_NORECOMPUTE = OFF,
ALLOW_ROW_LOCKS = ON,
ALLOW_PAGE_LOCKS = ON )
 ON [PRIMARY],
CONSTRAINT [FK_WF_Evento_WF_Flow]
FOREIGN KEY ([IdFlow])
REFERENCES [dbo].[WF_Flow] ( [IdFlow] )
)
ON [PRIMARY];
GO

GRANT SELECT ON [dbo].[WF_Evento] TO [ce_update];
GO
GRANT UPDATE ON [dbo].[WF_Evento] TO [ce_update];
GO
GRANT REFERENCES ON [dbo].[WF_Evento] TO [ce_update];
GO
GRANT INSERT ON [dbo].[WF_Evento] TO [ce_update];
GO
GRANT DELETE ON [dbo].[WF_Evento] TO [ce_update];
GO


/****** Object: Table [dbo].[WF_EstadoXFlow]   Script Date: 15/02/2010 11:31:12 ******/
USE [eFact-R];
GO
SET ANSI_NULLS ON;
GO
SET QUOTED_IDENTIFIER ON;
GO
CREATE TABLE [dbo].[WF_EstadoXFlow] (
[IdFlow] varchar(10) COLLATE Modern_Spanish_CI_AS NOT NULL,
[IdEstado] varchar(15) COLLATE Modern_Spanish_CI_AS NOT NULL,
[EstadoFinal] bit NOT NULL,
CONSTRAINT [PK_WF_EstadoXFlow]
PRIMARY KEY CLUSTERED ([IdFlow] ASC, [IdEstado] ASC)
WITH ( PAD_INDEX = OFF,
FILLFACTOR = 100,
IGNORE_DUP_KEY = OFF,
STATISTICS_NORECOMPUTE = OFF,
ALLOW_ROW_LOCKS = ON,
ALLOW_PAGE_LOCKS = ON )
 ON [PRIMARY],
CONSTRAINT [FK_WF_EstadoXFlow_WF_Estado]
FOREIGN KEY ([IdEstado])
REFERENCES [dbo].[WF_Estado] ( [IdEstado] ),
CONSTRAINT [FK_WF_EstadoXFlow_WF_Flow]
FOREIGN KEY ([IdFlow])
REFERENCES [dbo].[WF_Flow] ( [IdFlow] )
)
ON [PRIMARY];
GO

GRANT SELECT ON [dbo].[WF_EstadoXFlow] TO [ce_update];
GO
GRANT UPDATE ON [dbo].[WF_EstadoXFlow] TO [ce_update];
GO
GRANT REFERENCES ON [dbo].[WF_EstadoXFlow] TO [ce_update];
GO
GRANT INSERT ON [dbo].[WF_EstadoXFlow] TO [ce_update];
GO
GRANT DELETE ON [dbo].[WF_EstadoXFlow] TO [ce_update];
GO


/****** Object: Table [dbo].[WF_EsquemaSeg]   Script Date: 15/02/2010 11:31:12 ******/
USE [eFact-R];
GO
SET ANSI_NULLS ON;
GO
SET QUOTED_IDENTIFIER ON;
GO
CREATE TABLE [dbo].[WF_EsquemaSeg] (
[IdFlow] varchar(10) COLLATE Modern_Spanish_CI_AS NOT NULL,
[IdCircuito] varchar(15) COLLATE Modern_Spanish_CI_AS NOT NULL,
[IdNivSeg] int NOT NULL,
[IdEvento] varchar(15) COLLATE Modern_Spanish_CI_AS NOT NULL,
[IdGrupo] varchar(15) COLLATE Modern_Spanish_CI_AS NOT NULL,
[DebeSerSP] varchar(2) COLLATE Modern_Spanish_CI_AS NOT NULL,
[SupervisorNivelDsd] tinyint NOT NULL,
[SupervisorNivelHst] tinyint NOT NULL,
[CantInterv] int NOT NULL,
CONSTRAINT [PK_WF_EsquemaSeg]
PRIMARY KEY CLUSTERED ([IdFlow] ASC, [IdCircuito] ASC, [IdNivSeg] ASC, [IdEvento] ASC, [IdGrupo] ASC, [DebeSerSP] ASC, [SupervisorNivelDsd] ASC, [SupervisorNivelHst] ASC)
WITH ( PAD_INDEX = OFF,
FILLFACTOR = 100,
IGNORE_DUP_KEY = OFF,
STATISTICS_NORECOMPUTE = OFF,
ALLOW_ROW_LOCKS = ON,
ALLOW_PAGE_LOCKS = ON )
 ON [PRIMARY],
CONSTRAINT [FK_WF_EsquemaSeg_WF_Evento]
FOREIGN KEY ([IdFlow], [IdEvento])
REFERENCES [dbo].[WF_Evento] ( [IdFlow], [IdEvento] ),
CONSTRAINT [FK_WF_EventoSeg_WCTbGrupos]
FOREIGN KEY ([IdGrupo])
REFERENCES [dbo].[WCTbGrupos] ( [IdGrupo] ),
CONSTRAINT [FK_WF_EventoSeg_WF_Circuito]
FOREIGN KEY ([IdCircuito])
REFERENCES [dbo].[WF_Circuito] ( [IdCircuito] ),
CONSTRAINT [FK_WF_EventoSeg_WF_NivSeg]
FOREIGN KEY ([IdNivSeg])
REFERENCES [dbo].[WF_NivSeg] ( [IdNivSeg] )
)
ON [PRIMARY];
GO

GRANT SELECT ON [dbo].[WF_EsquemaSeg] TO [ce_update];
GO
GRANT UPDATE ON [dbo].[WF_EsquemaSeg] TO [ce_update];
GO
GRANT REFERENCES ON [dbo].[WF_EsquemaSeg] TO [ce_update];
GO
GRANT INSERT ON [dbo].[WF_EsquemaSeg] TO [ce_update];
GO
GRANT DELETE ON [dbo].[WF_EsquemaSeg] TO [ce_update];
GO

/*-- Actualización Version 1.6.10 --*/ 
alter table Comprobantes add ImporteMonedaOrigen decimal(18, 2) null
alter table Comprobantes add TipoCambio decimal(18, 6) null
GO

/*-- Actualización Version 1.6.22 --*/ 
alter table Comprobantes add EstadoIFoAFIP varchar(15) null
alter table Comprobantes add ComentarioIFoAFIP varchar(8000) null
GO