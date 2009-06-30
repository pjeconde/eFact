CREATE TABLE [dbo].[Contacto](
	[IdContacto] [varchar](60) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Calle] [varchar](30) NOT NULL,
	[Nro] [varchar](6) NOT NULL,
	[Piso] [varchar](5) NOT NULL,
	[Depto] [varchar](5) NOT NULL,
	[Localidad] [varchar](25) NOT NULL,
	[IdProvincia] [varchar](2) NOT NULL,
	[DescrProvincia] [varchar](50) NOT NULL,
	[CodPost] [varchar](8) NOT NULL,
	[Telefono] [varchar](50) NOT NULL,
	[Tratamiento] [varchar](50) NOT NULL,
	[Organizacion] [varchar](50) NOT NULL,
	[Observacion] [varchar](50) NOT NULL,
	[IdEstadoContacto] [varchar](15) NOT NULL,
 CONSTRAINT [PK_Table_Contacto] PRIMARY KEY CLUSTERED 
(
	[IdContacto] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
go

CREATE TABLE [dbo].[Atributo](
	[IdAtributo] [varchar](15) NOT NULL,
	[DescrAtributo] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Atributo] PRIMARY KEY CLUSTERED 
(
	[IdAtributo] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
go

CREATE TABLE [dbo].[AtributoXContacto](
	[IdContacto] [varchar](60) NOT NULL,
	[IdAtributo] [varchar](15) NOT NULL,
 CONSTRAINT [PK_Table_AtributoXContacto] PRIMARY KEY CLUSTERED 
(
	[IdContacto] ASC,
	[IdAtributo] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
go
ALTER TABLE [dbo].[AtributoXContacto]  WITH CHECK ADD  CONSTRAINT [FK_AtributoXContacto_Contacto] FOREIGN KEY([IdContacto])
REFERENCES [dbo].[Contacto] ([IdContacto])
go
ALTER TABLE [dbo].[AtributoXContacto] CHECK CONSTRAINT [FK_AtributoXContacto_Contacto]
go
ALTER TABLE [dbo].[AtributoXContacto]  WITH CHECK ADD  CONSTRAINT [FK_AtributoXContacto_Atributo] FOREIGN KEY([IdAtributo])
REFERENCES [dbo].[Atributo] ([IdAtributo])
go
ALTER TABLE [dbo].[AtributoXContacto] CHECK CONSTRAINT [FK_AtributoXContacto_Atributo]
go

CREATE TABLE [dbo].[Publicacion](
	[IdPublicacion] [int] IDENTITY(1,1) NOT NULL,
	[DescrPublicacion] [varchar](255) NOT NULL,
	[Asunto] [varchar](255) NOT NULL,
	[URL] [varchar](255) NOT NULL,
 CONSTRAINT [PK_Table_Publicacion] PRIMARY KEY CLUSTERED 
(
	[IdPublicacion] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
go

CREATE TABLE [dbo].[AtributoXPublicacion](
	[IdPublicacion] [int] NOT NULL,
	[IdAtributo] [varchar](15) NOT NULL,
 CONSTRAINT [PK_Table_AtributoXPublicacion] PRIMARY KEY CLUSTERED 
(
	[IdPublicacion] ASC,
	[IdAtributo] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
go
ALTER TABLE [dbo].[AtributoXPublicacion]  WITH CHECK ADD  CONSTRAINT [FK_AtributoXPublicacion_Publicacion] FOREIGN KEY([IdPublicacion])
REFERENCES [dbo].[Publicacion] ([IdPublicacion])
go
ALTER TABLE [dbo].[AtributoXPublicacion] CHECK CONSTRAINT [FK_AtributoXPublicacion_Publicacion]
go
ALTER TABLE [dbo].[AtributoXPublicacion]  WITH CHECK ADD  CONSTRAINT [FK_AtributoXPublicacion_Atributo] FOREIGN KEY([IdAtributo])
REFERENCES [dbo].[Atributo] ([IdAtributo])
go
ALTER TABLE [dbo].[AtributoXPublicacion] CHECK CONSTRAINT [FK_AtributoXPublicacion_Atributo]
go

CREATE TABLE [dbo].[PublicacionLog](
	[IdPublicacion] [int] NOT NULL,
	[IdContacto] [varchar](60) NOT NULL,
	[Fecha] [datetime] NOT NULL,
 CONSTRAINT [PK_Table_PublicacionLog] PRIMARY KEY CLUSTERED 
(
	[IdPublicacion] ASC,
	[IdContacto] ASC,
	[Fecha] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
go
ALTER TABLE [dbo].[PublicacionLog]  WITH CHECK ADD  CONSTRAINT [FK_PublicacionLog_Publicacion] FOREIGN KEY([IdPublicacion])
REFERENCES [dbo].[Publicacion] ([IdPublicacion])
go
ALTER TABLE [dbo].[PublicacionLog] CHECK CONSTRAINT [FK_PublicacionLog_Publicacion]
go
ALTER TABLE [dbo].[PublicacionLog]  WITH CHECK ADD  CONSTRAINT [FK_PublicacionLog_Contacto] FOREIGN KEY([IdContacto])
REFERENCES [dbo].[Contacto] ([IdContacto])
go
ALTER TABLE [dbo].[PublicacionLog] CHECK CONSTRAINT [FK_PublicacionLog_Contacto]
go
