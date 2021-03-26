USE [eFact-R]
GO
/****** Objeto:  Table [dbo].[Novedades]    Fecha de la secuencia de comandos: 09/12/2011 16:47:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Novedades](
	[CuitVendedor] [varchar](11) COLLATE Modern_Spanish_CI_AS NOT NULL,
	[IdLote] [int] NOT NULL,
	[NumeroEnvio] [int] NOT NULL,
	[PuntoVenta] [int] NOT NULL,
	[IdLog] [int] NOT NULL,
	[IdOp] [int] NOT NULL,
	[NumeroLote] [varchar](20) COLLATE Modern_Spanish_CI_AS NOT NULL,
	[IdEstado] [varchar](15) COLLATE Modern_Spanish_CI_AS NULL,
	[Comentario] [text] COLLATE Modern_Spanish_CI_AS NULL,
	[FechaAlta] [datetime] NOT NULL,
	[CantidadRegistros] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[CuitVendedor] ASC,
	[IdLote] ASC,
	[NumeroEnvio] ASC,
	[PuntoVenta] ASC,
	[IdLog] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF, FILLFACTOR = 100) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF



GRANT SELECT ON [dbo].[Novedades] TO [ce_update];
GO
GRANT UPDATE ON [dbo].[Novedades] TO [ce_update];
GO
GRANT REFERENCES ON [dbo].[Novedades] TO [ce_update];
GO
GRANT INSERT ON [dbo].[Novedades] TO [ce_update];
GO
GRANT DELETE ON [dbo].[Novedades] TO [ce_update];
GO