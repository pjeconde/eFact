SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TipoPuntoDeVenta](
	[IdTipoPuntoDeVenta] [varchar](15) COLLATE Modern_Spanish_CI_AS NOT NULL,
	[DescrTipoPuntoDeVenta] [varchar](50) COLLATE Modern_Spanish_CI_AS NOT NULL,
 CONSTRAINT [PK_TipoPuntoDeVenta] PRIMARY KEY CLUSTERED 
(
	[IdTipoPuntoDeVenta] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
insert TipoPuntoDeVenta values ('BFiscal', 'Bono Fiscal')
GO
insert TipoPuntoDeVenta values ('Export', 'Exportacion')
GO
insert TipoPuntoDeVenta values ('Comun', 'Comun')
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PuntoDeVenta](
	[CUIT] [numeric](11, 0) NOT NULL,
	[IdPuntoDeVenta] [numeric](4, 0) NOT NULL,
	[IdTipoPuntoDeVenta] [varchar](15) COLLATE Modern_Spanish_CI_AS NOT NULL,
	[Calle] [varchar](30) COLLATE Modern_Spanish_CI_AS NOT NULL,
	[Nro] [varchar](6) COLLATE Modern_Spanish_CI_AS NOT NULL,
	[Piso] [varchar](5) COLLATE Modern_Spanish_CI_AS NOT NULL,
	[Depto] [varchar](5) COLLATE Modern_Spanish_CI_AS NOT NULL,
	[Sector] [varchar](5) COLLATE Modern_Spanish_CI_AS NOT NULL,
	[Torre] [varchar](5) COLLATE Modern_Spanish_CI_AS NOT NULL,
	[Manzana] [varchar](5) COLLATE Modern_Spanish_CI_AS NOT NULL,
	[Localidad] [varchar](25) COLLATE Modern_Spanish_CI_AS NOT NULL,
	[IdProvincia] [varchar](2) COLLATE Modern_Spanish_CI_AS NOT NULL,
	[DescrProvincia] [varchar](50) COLLATE Modern_Spanish_CI_AS NOT NULL,
	[CodPost] [varchar](8) COLLATE Modern_Spanish_CI_AS NOT NULL,
 CONSTRAINT [PK_PuntoDeVenta] PRIMARY KEY CLUSTERED 
(
	[CUIT] ASC,
	[IdPuntoDeVenta] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[PuntoDeVenta]  WITH CHECK ADD  CONSTRAINT [FK_PuntoDeVenta_TipoPuntoDeVenta] FOREIGN KEY([IdTipoPuntoDeVenta])
REFERENCES [dbo].[TipoPuntoDeVenta] ([IdTipoPuntoDeVenta])
GO
ALTER TABLE [dbo].[PuntoDeVenta] CHECK CONSTRAINT [FK_PuntoDeVenta_TipoPuntoDeVenta]
GO
select * into PuntoDeVentaDepurado from PuntoDeVenta where 1=2
go
insert PuntoDeVenta select CUIT, PuntoDeVentaHabilitado, 'BFiscal', '', '', '', '', '', '', '', '', '', '', '' from BonoFiscal
go
insert PuntoDeVentaDepurado select CUIT, PuntoDeVentaHabilitado, 'BFiscal', '', '', '', '', '', '', '', '', '', '', '' from BonoFiscalDepurado
go
drop table dbo.BonoFiscal
go
drop table dbo.BonoFiscalDepurado
go
