SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PaginaDefault](
	[IdPaginaDefault] [varchar](15) NOT NULL,
	[DescrPaginaDefault] [varchar](50) NOT NULL,
	[URL] [varchar](255) NOT NULL,
 CONSTRAINT [PK_Table_PaginaDefault] PRIMARY KEY CLUSTERED 
(
	[IdPaginaDefault] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
CREATE TABLE [dbo].[PaginaDefaultXTipoCuenta](
	[IdTipoCuenta] [varchar](15) NOT NULL,
	[IdPaginaDefault] [varchar](15) NOT NULL,
	[Predeterminada] bit NOT NULL,
 CONSTRAINT [PK_Table_PaginaDefaultXTipoCuenta] PRIMARY KEY CLUSTERED 
(
	[IdTipoCuenta] ASC, 
	[IdPaginaDefault] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
insert PaginaDefault values ('Inicio', 'Inicio', 'Inicio')
go
insert PaginaDefault values ('eFactWeb', 'Factura Electrónica (servicio web)', 'FacturaElectronica')
go
insert PaginaDefault values ('eFactWeb-Ingr', 'Ingreso de Factura Electrónica', 'FacturaElectronicaXML')
go
insert PaginaDefault values ('Admin', 'Administración', 'Administracion')
go
insert PaginaDefaultXTipoCuenta values ('Admin', 'Inicio', 0)
go
insert PaginaDefaultXTipoCuenta values ('Admin', 'eFactWeb', 0)
go
insert PaginaDefaultXTipoCuenta values ('Admin', 'eFactWeb-Ingr', 0)
go
insert PaginaDefaultXTipoCuenta values ('Admin', 'Admin', 1)
go
insert PaginaDefaultXTipoCuenta values ('Free', 'Inicio', 0)
go
insert PaginaDefaultXTipoCuenta values ('Free', 'eFactWeb', 1)
go
insert PaginaDefaultXTipoCuenta values ('Free', 'eFactWeb-Ingr', 0)
go
insert PaginaDefaultXTipoCuenta values ('Prem', 'Inicio', 0)
go
insert PaginaDefaultXTipoCuenta values ('Prem', 'eFactWeb', 1)
go
insert PaginaDefaultXTipoCuenta values ('Prem', 'eFactWeb-Ingr', 0)
go
alter table dbo.Cuenta add IdPaginaDefault varchar(15) null
go
update Cuenta set Cuenta.IdPaginaDefault=PaginaDefaultXTipoCuenta.IdPaginaDefault from Cuenta, PaginaDefaultXTipoCuenta where Cuenta.IdTipoCuenta=PaginaDefaultXTipoCuenta.IdTipoCuenta and PaginaDefaultXTipoCuenta.Predeterminada=1
go
alter table dbo.Cuenta alter column IdPaginaDefault varchar(15) not null
go
ALTER TABLE [dbo].[Cuenta]  WITH CHECK ADD  CONSTRAINT [FK_Cuenta_PaginaDefault] FOREIGN KEY([IdPaginaDefault]) REFERENCES [dbo].[PaginaDefault] ([IdPaginaDefault])
GO
ALTER TABLE [dbo].[Cuenta] CHECK CONSTRAINT [FK_Cuenta_PaginaDefault]
GO
ALTER TABLE [dbo].[PaginaDefaultXTipoCuenta]  WITH CHECK ADD  CONSTRAINT [FK_PaginaDefaultXTipoCuenta_PaginaDefault] FOREIGN KEY([IdPaginaDefault]) REFERENCES [dbo].[PaginaDefault] ([IdPaginaDefault])
GO
ALTER TABLE [dbo].[PaginaDefaultXTipoCuenta] CHECK CONSTRAINT [FK_PaginaDefaultXTipoCuenta_PaginaDefault]
GO
ALTER TABLE [dbo].[PaginaDefaultXTipoCuenta]  WITH CHECK ADD  CONSTRAINT [FK_PaginaDefaultXTipoCuenta_TipoCuenta] FOREIGN KEY([IdTipoCuenta]) REFERENCES [dbo].[TipoCuenta] ([IdTipoCuenta])
GO
ALTER TABLE [dbo].[PaginaDefaultXTipoCuenta] CHECK CONSTRAINT [FK_PaginaDefaultXTipoCuenta_TipoCuenta]
GO
