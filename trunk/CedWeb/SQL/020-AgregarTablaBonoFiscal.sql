CREATE TABLE [dbo].[BonoFiscal](
	[CUIT] [numeric](11, 0) NOT NULL,
	[PuntoDeVentaHabilitado] [numeric](4) NOT NULL,
 CONSTRAINT [PK_BonoFiscal] PRIMARY KEY CLUSTERED 
(
	[CUIT] ASC,
	[PuntoDeVentaHabilitado] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
go
