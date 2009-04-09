alter table dbo.Cuenta add FechaAlta datetime null
go
alter table dbo.Cuenta add CantidadEnviosMail int null
go
alter table dbo.Cuenta add FechaUltimoReenvioMail datetime null
go
update Cuenta set FechaAlta='20090301 12:00:00', CantidadEnviosMail=1, FechaUltimoReenvioMail='20090301 12:00:00' where IdEstadoCuenta<>'PteConf'
go
update Cuenta set FechaAlta='20090301 12:00:00', CantidadEnviosMail=2, FechaUltimoReenvioMail=getdate() where IdEstadoCuenta='PteConf'
go
alter table dbo.Cuenta alter column FechaAlta datetime not null
go
alter table dbo.Cuenta alter column CantidadEnviosMail int not null
go
alter table dbo.Cuenta alter column FechaUltimoReenvioMail datetime not null
go
