ALTER TABLE dbo.Cuenta ADD
	NroSerieCertificado varchar(50) NULL
GO

UPDATE dbo.Cuenta SET NroSerieCertificado=''
 GO

ALTER TABLE dbo.Cuenta ALTER COLUMN
	NroSerieCertificado varchar(50) NOT NULL
GO

ALTER TABLE dbo.CuentaDepurada ADD
	NroSerieCertificado varchar(50) NULL
GO

UPDATE dbo.CuentaDepurada SET NroSerieCertificado=''
 GO

ALTER TABLE dbo.CuentaDepurada ALTER COLUMN
	NroSerieCertificado varchar(50) NOT NULL
GO
