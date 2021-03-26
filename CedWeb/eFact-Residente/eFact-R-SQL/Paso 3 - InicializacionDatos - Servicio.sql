USE [eFact-R];
GO
SET DATEFORMAT ymd
GO
BEGIN TRANSACTION
INSERT INTO [WCTbGrupos] ( [IdGrupo], [Descr], [IdTGrupo]) VALUES ( 'FactOperServ', 'Facturación servicio (rol)', 'ROL')
IF @@ERROR <> 0
ROLLBACK TRAN
ELSE
COMMIT TRANSACTION
GO


USE [eFact-R];
GO
SET DATEFORMAT ymd
GO
BEGIN TRANSACTION
INSERT INTO [WCGrupos] ( [IdGrupo], [IdUsuario], [Supervisor], [SupervisorNivel]) VALUES ( 'FactOperServ', 'usr_eFact', 1, 0)
IF @@ERROR <> 0
ROLLBACK TRAN
ELSE
COMMIT TRANSACTION
GO


USE [eFact-R];
GO
SET DATEFORMAT ymd
GO
BEGIN TRANSACTION
INSERT INTO [WF_Acceso] ( [IdAcceso], [DescrAcceso], [AssemblyVersion]) VALUES ( 'Servicio', 'Servicio eFact', '1.6')
IF @@ERROR <> 0
ROLLBACK TRAN
ELSE
COMMIT TRANSACTION
GO


USE [eFact-R];
GO
SET DATEFORMAT ymd
GO
BEGIN TRANSACTION
INSERT INTO [WF_PermisoGrupoXAcceso] ( [IdGrupo], [IdAcceso], [Permiso]) VALUES ( 'FactOperServ', 'Servicio', 1)
IF @@ERROR <> 0
ROLLBACK TRAN
ELSE
COMMIT TRANSACTION
GO


USE [eFact-R];
GO
SET DATEFORMAT ymd
GO
BEGIN TRANSACTION
INSERT INTO [WF_Circuito] ( [IdCircuito], [DescrCircuito])
VALUES ( 'FactServ', 'Facturacion Servicio')
IF @@ERROR <> 0
ROLLBACK TRAN
ELSE
COMMIT TRANSACTION
GO


USE [eFact-R];
GO
SET DATEFORMAT ymd
GO
BEGIN TRANSACTION
USE [eFact-R]
GO
insert into [dbo].[WF_EsquemaSeg]([IdFlow],[IdCircuito],[IdNivSeg],[IdEvento],[IdGrupo],[DebeSerSP],[SupervisorNivelDsd],[SupervisorNivelHst],[CantInterv]) values ('eFact','FactServ',0,'AnularCancel','FactOperServ','NA',0,255,1)
insert into [dbo].[WF_EsquemaSeg]([IdFlow],[IdCircuito],[IdNivSeg],[IdEvento],[IdGrupo],[DebeSerSP],[SupervisorNivelDsd],[SupervisorNivelHst],[CantInterv]) values ('eFact','FactServ',0,'AnularRechIF','FactOperServ','NA',0,255,1)
insert into [dbo].[WF_EsquemaSeg]([IdFlow],[IdCircuito],[IdNivSeg],[IdEvento],[IdGrupo],[DebeSerSP],[SupervisorNivelDsd],[SupervisorNivelHst],[CantInterv]) values ('eFact','FactServ',0,'EnvBandSalida','FactOperServ','NA',0,255,1)
insert into [dbo].[WF_EsquemaSeg]([IdFlow],[IdCircuito],[IdNivSeg],[IdEvento],[IdGrupo],[DebeSerSP],[SupervisorNivelDsd],[SupervisorNivelHst],[CantInterv]) values ('eFact','FactServ',0,'EnviarAIF','FactOperServ','NA',0,255,1)
insert into [dbo].[WF_EsquemaSeg]([IdFlow],[IdCircuito],[IdNivSeg],[IdEvento],[IdGrupo],[DebeSerSP],[SupervisorNivelDsd],[SupervisorNivelHst],[CantInterv]) values ('eFact','FactServ',0,'RegAceptAFIP','FactOperServ','NA',0,255,1)
insert into [dbo].[WF_EsquemaSeg]([IdFlow],[IdCircuito],[IdNivSeg],[IdEvento],[IdGrupo],[DebeSerSP],[SupervisorNivelDsd],[SupervisorNivelHst],[CantInterv]) values ('eFact','FactServ',0,'RegAceptAFIPO','FactOperServ','NA',0,255,1)
insert into [dbo].[WF_EsquemaSeg]([IdFlow],[IdCircuito],[IdNivSeg],[IdEvento],[IdGrupo],[DebeSerSP],[SupervisorNivelDsd],[SupervisorNivelHst],[CantInterv]) values ('eFact','FactServ',0,'RegAceptAFIPP','FactOperServ','NA',0,255,1)
insert into [dbo].[WF_EsquemaSeg]([IdFlow],[IdCircuito],[IdNivSeg],[IdEvento],[IdGrupo],[DebeSerSP],[SupervisorNivelDsd],[SupervisorNivelHst],[CantInterv]) values ('eFact','FactServ',0,'RegAceptIF','FactOperServ','NA',0,255,1)
insert into [dbo].[WF_EsquemaSeg]([IdFlow],[IdCircuito],[IdNivSeg],[IdEvento],[IdGrupo],[DebeSerSP],[SupervisorNivelDsd],[SupervisorNivelHst],[CantInterv]) values ('eFact','FactServ',0,'RegRechAFIP','FactOperServ','NA',0,255,1)
insert into [dbo].[WF_EsquemaSeg]([IdFlow],[IdCircuito],[IdNivSeg],[IdEvento],[IdGrupo],[DebeSerSP],[SupervisorNivelDsd],[SupervisorNivelHst],[CantInterv]) values ('eFact','FactServ',0,'RegRechIF','FactOperServ','NA',0,255,1)
insert into [dbo].[WF_EsquemaSeg]([IdFlow],[IdCircuito],[IdNivSeg],[IdEvento],[IdGrupo],[DebeSerSP],[SupervisorNivelDsd],[SupervisorNivelHst],[CantInterv]) values ('eFact','FactServ',0,'AnularPteRIF','FactOperServ','NA',0,255,1)
IF @@ERROR <> 0
ROLLBACK TRAN
ELSE
COMMIT TRANSACTION
GO


USE [eFact-R];
GO
SET DATEFORMAT ymd
GO
BEGIN TRANSACTION
USE [eFact-R]
GO
insert into [dbo].[WF_EsquemaSeg]([IdFlow],[IdCircuito],[IdNivSeg],[IdEvento],[IdGrupo],[DebeSerSP],[SupervisorNivelDsd],[SupervisorNivelHst],[CantInterv]) values ('eFact','FactServ',0,'RegActAFIPO','FactOperServ','NA',0,255,1)
insert into [dbo].[WF_EsquemaSeg]([IdFlow],[IdCircuito],[IdNivSeg],[IdEvento],[IdGrupo],[DebeSerSP],[SupervisorNivelDsd],[SupervisorNivelHst],[CantInterv]) values ('eFact','FactServ',0,'RegActAFIPP','FactOperServ','NA',0,255,1)
insert into [dbo].[WF_EsquemaSeg]([IdFlow],[IdCircuito],[IdNivSeg],[IdEvento],[IdGrupo],[DebeSerSP],[SupervisorNivelDsd],[SupervisorNivelHst],[CantInterv]) values ('eFact','FactServ',0,'RegActAFIP','FactOperServ','NA',0,255,1)
insert into [dbo].[WF_EsquemaSeg]([IdFlow],[IdCircuito],[IdNivSeg],[IdEvento],[IdGrupo],[DebeSerSP],[SupervisorNivelDsd],[SupervisorNivelHst],[CantInterv]) values ('eFact','FactServ',0,'RegContAFIP','FactOperServ','NA',0,255,1)
insert into [dbo].[WF_EsquemaSeg]([IdFlow],[IdCircuito],[IdNivSeg],[IdEvento],[IdGrupo],[DebeSerSP],[SupervisorNivelDsd],[SupervisorNivelHst],[CantInterv]) values ('eFact','FactServ',0,'RegContAFIPO','FactOperServ','NA',0,255,1)
insert into [dbo].[WF_EsquemaSeg]([IdFlow],[IdCircuito],[IdNivSeg],[IdEvento],[IdGrupo],[DebeSerSP],[SupervisorNivelDsd],[SupervisorNivelHst],[CantInterv]) values ('eFact','FactServ',0,'RegContAFIPP','FactOperServ','NA',0,255,1)
IF @@ERROR <> 0
ROLLBACK TRAN
ELSE
COMMIT TRANSACTION
GO


USE [eFact-R];
GO
SET DATEFORMAT ymd
GO
BEGIN TRANSACTION
USE [eFact-R]
GO
insert into [dbo].[WF_EsquemaSeg]([IdFlow],[IdCircuito],[IdNivSeg],[IdEvento],[IdGrupo],[DebeSerSP],[SupervisorNivelDsd],[SupervisorNivelHst],[CantInterv]) values ('eFact','FactServ',0,'RevertirRechIFA','FactOperServ','NA',0,255,1)
IF @@ERROR <> 0
ROLLBACK TRAN
ELSE
COMMIT TRANSACTION
GO
