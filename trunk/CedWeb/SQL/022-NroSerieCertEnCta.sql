ALTER TABLE dbo.Cuenta ADD
	NroSerieCertificado varchar(50) NULL
GO

UPDATE dbo.Cuenta SET NroSerieCertificado=''
 GO

ALTER TABLE dbo.Cuenta ALTER COLUMN
	NroSerieCertificado varchar(50) NOT NULL
GO
