/****** Objeto:  Table [dbo].[TipoCuenta]    Fecha de la secuencia de comandos: 03/06/2009 17:12:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TipoCuenta](
	[IdTipoCuenta] [varchar](15) COLLATE Modern_Spanish_CI_AS NOT NULL,
	[DescrTipoCuenta] [varchar](50) COLLATE Modern_Spanish_CI_AS NOT NULL,
 CONSTRAINT [PK_TipoCuenta] PRIMARY KEY CLUSTERED 
(
	[IdTipoCuenta] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO

/****** Objeto:  Table [dbo].[EstadoCuenta]    Fecha de la secuencia de comandos: 03/06/2009 17:14:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[EstadoCuenta](
	[IdEstadoCuenta] [varchar](15) COLLATE Modern_Spanish_CI_AS NOT NULL,
	[DescrEstadoCuenta] [varchar](50) COLLATE Modern_Spanish_CI_AS NOT NULL,
 CONSTRAINT [PK_EstadoCuenta] PRIMARY KEY CLUSTERED 
(
	[IdEstadoCuenta] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO

/****** Objeto:  Table [dbo].[Cuenta]    Fecha de la secuencia de comandos: 03/06/2009 17:14:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Cuenta](
	[IdCuenta] [varchar](50) COLLATE Modern_Spanish_CI_AS NOT NULL,
	[Nombre] [varchar](50) COLLATE Modern_Spanish_CI_AS NOT NULL,
	[Telefono] [varchar](50) COLLATE Modern_Spanish_CI_AS NOT NULL,
	[Email] [varchar](128) COLLATE Modern_Spanish_CI_AS NOT NULL,
	[Password] [varchar](50) COLLATE Modern_Spanish_CI_AS NOT NULL,
	[Pregunta] [varchar](256) COLLATE Modern_Spanish_CI_AS NOT NULL,
	[Respuesta] [varchar](256) COLLATE Modern_Spanish_CI_AS NOT NULL,
	[IdTipoCuenta] [varchar](15) COLLATE Modern_Spanish_CI_AS NOT NULL,
	[IdEstadoCuenta] [varchar](15) COLLATE Modern_Spanish_CI_AS NOT NULL,
 CONSTRAINT [PK_Table_Cuenta] PRIMARY KEY CLUSTERED 
(
	[IdCuenta] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[Cuenta]  WITH CHECK ADD  CONSTRAINT [FK_Cuenta_EstadoCuenta] FOREIGN KEY([IdEstadoCuenta])
REFERENCES [dbo].[EstadoCuenta] ([IdEstadoCuenta])
GO
ALTER TABLE [dbo].[Cuenta] CHECK CONSTRAINT [FK_Cuenta_EstadoCuenta]
GO
ALTER TABLE [dbo].[Cuenta]  WITH CHECK ADD  CONSTRAINT [FK_Cuenta_TipoCuenta] FOREIGN KEY([IdTipoCuenta])
REFERENCES [dbo].[TipoCuenta] ([IdTipoCuenta])
GO
ALTER TABLE [dbo].[Cuenta] CHECK CONSTRAINT [FK_Cuenta_TipoCuenta]
GO

/****** Objeto:  Table [dbo].[Texto]    Fecha de la secuencia de comandos: 03/06/2009 17:15:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Texto](
	[IdTexto] [varchar](50) COLLATE Modern_Spanish_CI_AS NOT NULL,
	[DescrTexto] [text] COLLATE Modern_Spanish_CI_AS NOT NULL,
 CONSTRAINT [PK_Texto] PRIMARY KEY CLUSTERED 
(
	[IdTexto] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Objeto:  Table [dbo].[Vendedor]    Fecha de la secuencia de comandos: 03/06/2009 17:16:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Vendedor](
	[IdCuenta] [varchar](50) COLLATE Modern_Spanish_CI_AS NOT NULL,
	[RazonSocial] [varchar](50) COLLATE Modern_Spanish_CI_AS NOT NULL,
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
	[NombreContacto] [varchar](25) COLLATE Modern_Spanish_CI_AS NOT NULL,
	[EmailContacto] [varchar](60) COLLATE Modern_Spanish_CI_AS NOT NULL,
	[TelefonoContacto] [numeric](15, 0) NOT NULL,
	[CUIT] [numeric](11, 0) NOT NULL,
	[IdCondIVA] [numeric](2, 0) NOT NULL,
	[DescrCondIVA] [varchar](50) COLLATE Modern_Spanish_CI_AS NOT NULL,
	[NroIngBrutos] [varchar](13) COLLATE Modern_Spanish_CI_AS NOT NULL,
	[IdCondIngBrutos] [numeric](2, 0) NOT NULL,
	[DescrCondIngBrutos] [varchar](50) COLLATE Modern_Spanish_CI_AS NOT NULL,
	[GLN] [numeric](13, 0) NOT NULL,
	[CodigoInterno] [varchar](20) COLLATE Modern_Spanish_CI_AS NOT NULL,
	[FechaInicioActividades] [datetime] NOT NULL,
 CONSTRAINT [PK_Table_Vendedor] PRIMARY KEY CLUSTERED 
(
	[IdCuenta] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[Vendedor]  WITH CHECK ADD  CONSTRAINT [FK_Vendedor_Cuenta] FOREIGN KEY([IdCuenta])
REFERENCES [dbo].[Cuenta] ([IdCuenta])
GO
ALTER TABLE [dbo].[Vendedor] CHECK CONSTRAINT [FK_Vendedor_Cuenta]
GO

insert Texto values ('eFact-TerminosyCondiciones', 'Los siguientes términos y condiciones generales regularán expresamente las relaciones surgidas entre este Portal www.cedeira.com.ar de Cedeira Software Factory S.R.L ( en adelante "NUESTRA EMPRESA" ) y Usted (en adelante el "USUARIO o USUARIOS") en virtud de las cuales NUESTRA EMPRESA le brinda servicios de gratuito de generación de comprobantes electrónicos en un archivo de formato XML, ya sea que se trate de nuevos USUARIOS o aquellos vinculados a través de cualquier acuerdo previo que pudiera existir entre las partes. Este acuerdo sustituye cualquier otra comunicación previa oral o de otro tipo, que haya habido entre las partes.'+char(13)+'La utilización del Portal www.cedeira.com.ar atribuye la condición de USUARIO del Portal, sea persona física o jurídica, e implica la aceptación plena y sin reservas de todas y cada una de las disposiciones incluidas en estos terminos y condiciones que se detallan a contituación.'+char(13)+''+char(13)+'NUESTRA EMPRESA:'+char(13)+''+char(13)+'1.No asume ninguna responsabilidad por la utilización de los presentes modelos de carga de comprobantes, ya que sólo los ofrece en forma gratuita a modo de simplificar las tareas en la carga de la información del comprobante electrónico que solicita InterFacturas.'+char(13)+''+char(13)+'2.No asume responsabilidad alguna sobre los datos de los comprobantes que usted envíe a Interfacturas. La información generada desde este sitio web, puede ser modificada por usted.'+char(13)+''+char(13)+'3.Se reserva el derecho unilateral de suspender temporalmente o de terminar definitivamente la prestación del servicios a través del Portal.'+char(13)+''+char(13)+'4.Se reserva el derecho de modificar unilateralmente y en cualquier momento el sistema de acceso al servicio.'+char(13)+''+char(13)+'5.No garantiza que el sitio web vaya a funcionar en forma constante, fiable y correctamente, sin retrasos o interrupciones, por lo que no se hace responsable de los daños y prejuicios que puedan derivarse de los posibles fallos en disponibilidad y continuidad técnica del sitio web.'+char(13)+''+char(13)+'6.No presenta ninguna garantía, explicita o implícitamente, acerca de la utilización de este servicio gratuito.'+char(13)+''+char(13)+'7.No será responsable por cualquier daño y/o perjuicio y/o beneficio dejado de obtener por el usuario o cualquier otro tercero causados directa o indirectamente por la conexión y/o utilización y/o acceso al sitio web www.cedeira.com.ar o a páginas enlazadas a él.'+char(13)+''+char(13)+'Ley aplicable y jurisdicción competente'+char(13)+'El USUARIO acepta que la legislación aplicable al funcionamiento de este servicio es la Argentina y se somete a la jurisdicción de los juzgados y tribunales de la Ciudad Autónoma de Buenos Aires para la resolución de las devergencias que se deriven de la interpretación o aplicación de este clausulado.')
go

insert TipoCuenta values ('Free', 'Servicio gratuito')
insert TipoCuenta values ('Prem', 'Servicio premium')
insert TipoCuenta values ('Admin', 'Administrador')
go

insert EstadoCuenta values ('PteConf', 'Pendiente de confirmación')
insert EstadoCuenta values ('Vigente', 'Vigente')
insert EstadoCuenta values ('Baja', 'De baja')
insert EstadoCuenta values ('Suspend', 'Suspendida')
go

insert Cuenta values ('claudio.cedeira', 'Claudio A. Cedeira', '', 'claudio.cedeira@cedeira.com.ar', 'cedeira123', 'Cual es la sigla de mi escuela secundaria', 'encjm', 'Admin', 'Vigente')
insert Cuenta values ('lucascolino', 'Lucas Colino', '', 'lucascolino@gmail.com', 'cedeira123', 'Cual es mi apellido materno', 'Del Hoyo', 'Admin', 'Vigente')
insert Cuenta values ('carlosdeluxe83', 'Carlos Glorioso', '', 'carlosdeluxe83@gmail.com', 'cedeira123', 'Cual es mi apellido materno', 'Saunero', 'Admin', 'Vigente')
insert Cuenta values ('lucas.legaspi', 'Lucas Legaspi', '', 'lucas.legaspi@gmail.com', 'cedeira123', 'Cual es mi apellido materno', 'Henderson', 'Admin', 'Vigente')
insert Cuenta values ('fcedeira', 'Fernando J. Cedeira', '', 'fcedeira@gmail.com', 'cedeira123', 'Cual es mi apellido materno', 'Cuello', 'Admin', 'Vigente')
insert Cuenta values ('marce.cdr', 'Marcela Crespi', '', 'marce.cdr@gmail.com', 'cedeira123', 'Cual es mi apellido materno', 'Rodriguez', 'Admin', 'Vigente')
insert Cuenta values ('pjeconde', 'Pablo J.E.Conde', '', 'pjeconde@gmail.com', 'cedeira123', 'Cual es mi apellido materno', 'Cedeira', 'Admin', 'Vigente')
go

