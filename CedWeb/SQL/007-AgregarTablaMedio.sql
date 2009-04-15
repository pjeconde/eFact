SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Medio](
	[IdMedio] [varchar](15) NOT NULL,
	[DescrMedio] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Table_Medio] PRIMARY KEY CLUSTERED 
(
	[IdMedio] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
insert Medio values ('Internet', 'Internet')
go
insert Medio values ('Interfacturas', 'Recomendado por Interfacturas')
go
insert Medio values ('Conocido', 'Recomendado por un conocido')
go
insert Medio values ('Mail', 'Mail')
go
alter table dbo.Cuenta add IdMedio varchar(15) null
go
update Cuenta set IdMedio='Conocido' where IdTipoCuenta='Admin'
go
update Cuenta set IdMedio='Interfacturas' where IdTipoCuenta<>'Admin'
go
alter table dbo.Cuenta alter column IdMedio varchar(15) not null
go
ALTER TABLE [dbo].[Cuenta]  WITH CHECK ADD  CONSTRAINT [FK_Cuenta_Medio] FOREIGN KEY([IdMedio])
REFERENCES [dbo].[Medio] ([IdMedio])
GO
ALTER TABLE [dbo].[Cuenta] CHECK CONSTRAINT [FK_Cuenta_Medio]
GO