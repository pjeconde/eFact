alter table dbo.Cuenta add NroSerieDisco varchar(100) null
go
update Cuenta set NroSerieDisco=''
go
alter table dbo.Cuenta alter column NroSerieDisco varchar(100) not null
go
