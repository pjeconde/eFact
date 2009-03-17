alter table dbo.Cuenta add UltimoNroLote numeric(14) null
go
update Cuenta set UltimoNroLote=0
go
alter table dbo.Cuenta alter column UltimoNroLote numeric(14) not null
go
