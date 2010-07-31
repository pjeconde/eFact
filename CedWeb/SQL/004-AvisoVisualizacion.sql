alter table dbo.Comprador add EmailAvisoVisualizacion varchar(128) NULL
GO
alter table dbo.Comprador add PasswordAvisoVisualizacion varchar(50) NULL
GO
update Comprador set EmailAvisoVisualizacion='', PasswordAvisoVisualizacion=''
GO
alter table dbo.Comprador alter column EmailAvisoVisualizacion varchar(128) NOT NULL
GO
alter table dbo.Comprador alter column PasswordAvisoVisualizacion varchar(50) NOT NULL
GO
alter table dbo.CompradorDepurado add EmailAvisoVisualizacion varchar(128) NULL
GO
alter table dbo.CompradorDepurado add PasswordAvisoVisualizacion varchar(50) NULL
GO
update CompradorDepurado set EmailAvisoVisualizacion='', PasswordAvisoVisualizacion=''
GO
alter table dbo.CompradorDepurado alter column EmailAvisoVisualizacion varchar(128) NOT NULL
GO
alter table dbo.CompradorDepurado alter column PasswordAvisoVisualizacion varchar(50) NOT NULL
GO
