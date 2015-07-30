SET ANSI_NULLS ON;
GO
SET QUOTED_IDENTIFIER ON;
GO
CREATE TABLE dbo.ComprobantesC (
IdLote int NOT NULL,
PuntoVenta varchar(4) COLLATE Modern_Spanish_CI_AS NOT NULL,
IdTipoComprobante varchar(2) COLLATE Modern_Spanish_CI_AS NOT NULL,
NumeroComprobante varchar(8) COLLATE Modern_Spanish_CI_AS NOT NULL,
TipoDocVendedor varchar(3) COLLATE Modern_Spanish_CI_AS NOT NULL,
NroDocVendedor varchar(11) COLLATE Modern_Spanish_CI_AS NOT NULL,
NombreVendedor varchar(60) COLLATE Modern_Spanish_CI_AS NOT NULL,
Fecha datetime NOT NULL,
IdMoneda varchar(3) COLLATE Modern_Spanish_CI_AS NOT NULL,
Importe decimal(18, 2) NOT NULL,
CONSTRAINT PK_ComprobantesC
PRIMARY KEY CLUSTERED (IdLote ASC, TipoDocVendedor ASC, NroDocVendedor ASC, PuntoVenta ASC, IdTipoComprobante ASC, NumeroComprobante ASC)
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


SET ANSI_NULLS ON;
GO
SET QUOTED_IDENTIFIER ON;
GO
CREATE TABLE dbo.ComprobantesD (
IdLote int NOT NULL,
IdTipoComprobante varchar(2) COLLATE Modern_Spanish_CI_AS NOT NULL,
NumeroDespacho varchar(16) COLLATE Modern_Spanish_CI_AS NOT NULL,
TipoDocVendedor varchar(3) COLLATE Modern_Spanish_CI_AS NOT NULL,
NroDocVendedor varchar(11) COLLATE Modern_Spanish_CI_AS NOT NULL,
NombreVendedor varchar(60) COLLATE Modern_Spanish_CI_AS NOT NULL,
Fecha datetime NOT NULL,
IdMoneda varchar(3) COLLATE Modern_Spanish_CI_AS NOT NULL,
Importe decimal(18, 2) NOT NULL,
CONSTRAINT PK_ComprobantesD
PRIMARY KEY CLUSTERED (IdLote ASC, TipoDocVendedor ASC, NroDocVendedor ASC, IdTipoComprobante ASC, IdDespacho ASC)
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


alter table ComprobantesC add ImporteMonedaOrigen decimal(18, 2) null
alter table ComprobantesC add TipoCambio decimal(18, 6) null
GO


alter table Lotes add IdNaturalezaLote varchar(15) not null default('')
GO


update dbo.WF_Acceso set AssemblyVersion='2.0'
GO


GRANT INSERT, DELETE, UPDATE, SELECT, REFERENCES ON dbo.ComprobantesC TO ce_update
GO
GRANT INSERT, DELETE, UPDATE, SELECT, REFERENCES ON dbo.ComprobantesD TO ce_update
GO


INSERT INTO dbo.WF_Estado (IdEstado, DescrEstado, Virtual) VALUES ('Vigente', 'Vigente', 0)
GO
INSERT INTO dbo.WF_Estado (IdEstado, DescrEstado, Virtual) VALUES ('DeBaja', 'De Baja', 0)
GO

INSERT INTO dbo.WF_EstadoXFlow (IdFlow, IdEstado, EstadoFinal) VALUES ('eFact', 'Vigente', 1)
GO
INSERT INTO dbo.WF_EstadoXFlow (IdFlow, IdEstado, EstadoFinal) VALUES ('eFact', 'DeBaja', 1)
GO


insert into dbo.WF_Evento (IdFlow, IdEvento, DescrEvento, TextoAccion, IdEstadoDsd, IdEstadoHst, Automatico, CXO, XLote) values ('eFact', 'BajaVigente', 'Dar de Baja lote vigente', 'Dar de Baja lote vigente', 'Vigente', 'DeBaja', 0, 0, 1)
GO
insert into dbo.WF_Evento (IdFlow, IdEvento, DescrEvento, TextoAccion, IdEstadoDsd, IdEstadoHst, Automatico, CXO, XLote) values ('eFact', 'EnvBandSalidaV', 'Enviar a la Bandeja de Salida Vigente', 'Enviar a Bandeja de Salida Vigente', null, 'Vigente', 0, 0, 0)
GO

insert into dbo.WF_EsquemaSeg(IdFlow, IdCircuito, IdNivSeg, IdEvento, IdGrupo, DebeSerSP, SupervisorNivelDsd, SupervisorNivelHst, CantInterv) values ('eFact', 'Fact', 0, 'BajaVigente', 'FactOper', 'NA', 0, 255, 1)
GO
insert into dbo.WF_EsquemaSeg( IdFlow, IdCircuito, IdNivSeg, IdEvento, IdGrupo, DebeSerSP, SupervisorNivelDsd, SupervisorNivelHst, CantInterv) values ('eFact', 'Fact', 0, 'EnvBandSalidaV', 'FactOper', 'NA', 0, 255, 1)
GO
