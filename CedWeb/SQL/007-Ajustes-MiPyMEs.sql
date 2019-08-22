alter table Lotes add IdNaturalezaLote varchar(15) not null default('')
GO

update dbo.WF_Acceso set AssemblyVersion='2.0'
GO

alter table Comprobantes alter column IdTipoComprobante varchar(3) not null
GO