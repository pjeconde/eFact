alter table dbo.Cuenta add CantidadComprobantes int null
go
alter table dbo.Cuenta add FechaUltimoComprobante datetime null
go
alter table dbo.Cuenta add FechaVtoPremium datetime null
go
update Cuenta set CantidadComprobantes=0
go
update Cuenta set CantidadComprobantes=UltimoNroLote where IdTipoCuenta<>'Admin' and IdCuenta<>'Prueba' and UltimoNroLote<>0
go
update Cuenta set FechaUltimoComprobante='20000101'
go
update Cuenta set FechaVtoPremium='99991231'
go
alter table dbo.Cuenta alter column CantidadComprobantes int not null
go
alter table dbo.Cuenta alter column FechaUltimoComprobante datetime not null
go
alter table dbo.Cuenta alter column FechaVtoPremium datetime not null
go
