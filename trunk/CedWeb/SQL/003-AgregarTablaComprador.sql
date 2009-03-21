/****** Objeto:  Table [dbo].[Comprador]    Fecha de la secuencia de comandos: 03/06/2009 17:16:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Comprador](
	[IdCuenta] [varchar](50) NOT NULL,
	[RazonSocial] [varchar](50) NOT NULL,
	[Calle] [varchar](30) NOT NULL,
	[Nro] [varchar](6) NOT NULL,
	[Piso] [varchar](5) NOT NULL,
	[Depto] [varchar](5) NOT NULL,
	[Sector] [varchar](5) NOT NULL,
	[Torre] [varchar](5) NOT NULL,
	[Manzana] [varchar](5) NOT NULL,
	[Localidad] [varchar](25) NOT NULL,
	[IdProvincia] [varchar](2) NOT NULL,
	[DescrProvincia] [varchar](50) NOT NULL,
	[CodPost] [varchar](8) NOT NULL,
	[NombreContacto] [varchar](25) NOT NULL,
	[EmailContacto] [varchar](60) NOT NULL,
	[TelefonoContacto] [varchar](50) NOT NULL,
	[IdTipoDoc] [numeric](2, 0) NOT NULL,
	[DescrTipoDoc] [varchar](50) NOT NULL,
	[NroDoc] [numeric](11, 0) NOT NULL,
	[IdCondIVA] [numeric](2, 0) NOT NULL,
	[DescrCondIVA] [varchar](50) NOT NULL,
	[NroIngBrutos] [varchar](13) NOT NULL,
	[IdCondIngBrutos] [numeric](2, 0) NOT NULL,
	[DescrCondIngBrutos] [varchar](50) NOT NULL,
	[GLN] [numeric](13, 0) NOT NULL,
	[CodigoInterno] [varchar](20) NOT NULL,
	[FechaInicioActividades] [datetime] NOT NULL,
 CONSTRAINT [PK_Table_Comprador] PRIMARY KEY CLUSTERED 
(
	[IdCuenta] ASC, 
	[RazonSocial] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[Comprador]  WITH CHECK ADD  CONSTRAINT [FK_Comprador_Cuenta] FOREIGN KEY([IdCuenta])
REFERENCES [dbo].[Cuenta] ([IdCuenta])
GO
ALTER TABLE [dbo].[Comprador] CHECK CONSTRAINT [FK_Comprador_Cuenta]
GO
