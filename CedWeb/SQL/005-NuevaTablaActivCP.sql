CREATE TABLE dbo.ActivCP(
	IdCuenta varchar(50) NOT NULL,
	Fecha datetime NOT NULL,
	NroSerieDisco varchar(100) NOT NULL,
 CONSTRAINT PK_Table_ActivCP PRIMARY KEY CLUSTERED 
(
	IdCuenta ASC,
	Fecha ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
go
ALTER TABLE dbo.ActivCP WITH CHECK ADD  CONSTRAINT FK_ActivCP_Cuenta FOREIGN KEY(IdCuenta)
REFERENCES dbo.Cuenta (IdCuenta)
go
ALTER TABLE dbo.ActivCP CHECK CONSTRAINT FK_ActivCP_Cuenta
go
CREATE TABLE dbo.ActivCPDepurado(
	IdCuenta varchar(50) NOT NULL,
	Fecha datetime NOT NULL,
	NroSerieDisco varchar(100) NOT NULL
)
go
insert ActivCP select IdCuenta, getdate(), NroSerieDisco from Cuenta where NroSerieDisco<>''
go
/* Ajuste Cuenta */
alter table dbo.Cuenta add CantidadActivacionesCPs int null
go
update Cuenta set CantidadActivacionesCPs=1 where ActivCP=1
go
update Cuenta set CantidadActivacionesCPs=0 where ActivCP=0
go
alter table dbo.Cuenta alter column CantidadActivacionesCPs int not null
go
alter table dbo.Cuenta drop column ActivCP
go
alter table dbo.Cuenta drop column NroSerieDisco
go
/* Ajuste Cuenta Depurada */
alter table dbo.CuentaDepurada add CantidadActivacionesCPs int null
go
update CuentaDepurada set CantidadActivacionesCPs=1 where ActivCP=1
go
update CuentaDepurada set CantidadActivacionesCPs=0 where ActivCP=0
go
alter table dbo.CuentaDepurada alter column CantidadActivacionesCPs int not null
go
alter table dbo.CuentaDepurada drop column ActivCP
go
alter table dbo.CuentaDepurada drop column NroSerieDisco
go
