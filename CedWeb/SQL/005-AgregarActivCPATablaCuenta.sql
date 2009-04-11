alter table dbo.Cuenta add ActivCP bit null
go
update Cuenta set ActivCP=0
go
alter table dbo.Cuenta alter column ActivCP bit not null
go