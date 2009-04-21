alter table dbo.Cuenta add EmailSMS varchar(50) null
go
alter table dbo.Cuenta add RecibeAvisoAltaCuenta bit null
go
update Cuenta set EmailSMS=''
go
update Cuenta set RecibeAvisoAltaCuenta=0
go
alter table dbo.Cuenta alter column EmailSMS varchar(50) not null
go
alter table dbo.Cuenta alter column RecibeAvisoAltaCuenta bit not null
go
