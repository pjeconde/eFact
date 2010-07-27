BEGIN TRANSACTION
USE [eFact-R]
GO
alter table Comprobantes add ImporteMonedaOrigen decimal(18, 2) null
alter table Comprobantes add TipoCambio decimal(18, 6) null
IF @@ERROR <> 0
ROLLBACK TRAN
ELSE
COMMIT TRANSACTION
GO

