USE [eFact-R];
GO
SET DATEFORMAT ymd
GO
BEGIN TRANSACTION
insert into [dbo].[Vendedores]([CuitVendedor],[Nombre],[NumeroSerieCertificado],[Codigo],[CondicionIVA],[CondicionIB],[NroIB],[InicioActividades],[Contacto],[DomicilioCalle],[DomicilioNumero],[DomicilioPiso],[DomicilioDepto],[DomicilioSector],[DomicilioTorre],[DomicilioManzana],[Localidad],[Provincia],[CP],[EMail],[Telefono]) 
values ('30710015062','','','',0,0,'','99981231','','','','','','','','','','0','','','')
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
INSERT INTO [WCTbGrupos] ( [IdGrupo], [Descr], [IdTGrupo]) VALUES ( 'Fact', 'Facturación (sector)', 'SEC')
INSERT INTO [WCTbGrupos] ( [IdGrupo], [Descr], [IdTGrupo]) VALUES ( 'FactOper', 'Facturación (rol)', 'ROL')
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
INSERT INTO [WCUsuarios] ( [IdUsuario], [Nombre], [Activo], [Alias], [FecAlta], [FecBaja], [RequierePassword], [Email]) VALUES ( 'usr_eFact', 'Usuario eFact', 1, NULL, '2009-01-01 00:00:00', '2064-12-31 00:00:00', 1, NULL)
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
INSERT INTO [WCGrupos] ( [IdGrupo], [IdUsuario], [Supervisor], [SupervisorNivel]) VALUES ( 'FactOper', 'usr_eFact', 1, 0)
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
INSERT INTO [WF_Acceso] ( [IdAcceso], [DescrAcceso], [AssemblyVersion]) VALUES ( 'FrontEnd', 'FrontEnd eFact', '1.6')
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
VALUES ( 'Fact', 'Facturacion')
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
INSERT INTO [WF_Estado] ( [IdEstado], [DescrEstado], [Virtual]) VALUES ( 'AceptadoAFIP', 'Aceptado AFIP', 0)
INSERT INTO [WF_Estado] ( [IdEstado], [DescrEstado], [Virtual]) VALUES ( 'Anulado', 'Anulado', 0)
INSERT INTO [WF_Estado] ( [IdEstado], [DescrEstado], [Virtual]) VALUES ( 'Cancelado', 'Cancelado', 0)
INSERT INTO [WF_Estado] ( [IdEstado], [DescrEstado], [Virtual]) VALUES ( 'PteEnvio', 'Pendiente de Envio', 0)
INSERT INTO [WF_Estado] ( [IdEstado], [DescrEstado], [Virtual]) VALUES ( 'PteRespAFIP', 'Pendiente de Respuesta AFIP', 0)
INSERT INTO [WF_Estado] ( [IdEstado], [DescrEstado], [Virtual]) VALUES ( 'PteRespIF', 'Pendiente de Respuesta IF', 0)
INSERT INTO [WF_Estado] ( [IdEstado], [DescrEstado], [Virtual]) VALUES ( 'RechazadoAFIP', 'Rechazado AFIP', 0)
INSERT INTO [WF_Estado] ( [IdEstado], [DescrEstado], [Virtual]) VALUES ( 'RechazadoIF', 'Rechazado IF', 0)
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
INSERT INTO [WF_Flow] ( [IdFlow], [DescrFlow])
VALUES ( 'eFact', 'Factutación Electrónica')
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
INSERT INTO [WF_EstadoXFlow] ( [IdFlow], [IdEstado], [EstadoFinal]) VALUES ( 'eFact', 'AceptadoAFIP', 1)
INSERT INTO [WF_EstadoXFlow] ( [IdFlow], [IdEstado], [EstadoFinal]) VALUES ( 'eFact', 'Cancelado', 0)
INSERT INTO [WF_EstadoXFlow] ( [IdFlow], [IdEstado], [EstadoFinal]) VALUES ( 'eFact', 'PteEnvio', 0)
INSERT INTO [WF_EstadoXFlow] ( [IdFlow], [IdEstado], [EstadoFinal]) VALUES ( 'eFact', 'PteRespAFIP', 0)
INSERT INTO [WF_EstadoXFlow] ( [IdFlow], [IdEstado], [EstadoFinal]) VALUES ( 'eFact', 'PteRespIF', 0)
INSERT INTO [WF_EstadoXFlow] ( [IdFlow], [IdEstado], [EstadoFinal]) VALUES ( 'eFact', 'RechazadoAFIP', 1)
INSERT INTO [WF_EstadoXFlow] ( [IdFlow], [IdEstado], [EstadoFinal]) VALUES ( 'eFact', 'RechazadoIF', 1)
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
INSERT INTO [WF_NivSeg] ( [IdNivSeg], [DescrNivSeg]) VALUES ( 0, 'No aplica')
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
INSERT INTO [WF_Parm] ( [IdParm], [ValorInt], [ValorStr]) VALUES ( 'CXO', 0, '1-Si 0-No')
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
INSERT INTO [WF_PermisoGrupoXAcceso] ( [IdGrupo], [IdAcceso], [Permiso]) VALUES ( 'FactOper', 'FrontEnd', 1)
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
insert into [dbo].[WF_Evento]([IdFlow],[IdEvento],[DescrEvento],[TextoAccion],[IdEstadoDsd],[IdEstadoHst],[Automatico],[CXO],[XLote]) values ('eFact','AnularCancel','Anular el lote por envio posterior','Anular el lote por envio posterior','Cancelado','Anulado',1,0,0)
insert into [dbo].[WF_Evento]([IdFlow],[IdEvento],[DescrEvento],[TextoAccion],[IdEstadoDsd],[IdEstadoHst],[Automatico],[CXO],[XLote]) values ('eFact','AnularRechIF','Anular el lote por envio posterior','Anular el lote por envio posterior','RechazadoIF','Anulado',1,0,0)
insert into [dbo].[WF_Evento]([IdFlow],[IdEvento],[DescrEvento],[TextoAccion],[IdEstadoDsd],[IdEstadoHst],[Automatico],[CXO],[XLote]) values ('eFact','Cancelar','Cancelar el envio del lote','Cancelar','PteEnvio','Cancelado',0,0,1)
insert into [dbo].[WF_Evento]([IdFlow],[IdEvento],[DescrEvento],[TextoAccion],[IdEstadoDsd],[IdEstadoHst],[Automatico],[CXO],[XLote]) values ('eFact','EnvBandSalida','Enviar a la Bandeja de Salida','Enviar a Bandeja de Salida',null,'PteEnvio',0,0,0)
insert into [dbo].[WF_Evento]([IdFlow],[IdEvento],[DescrEvento],[TextoAccion],[IdEstadoDsd],[IdEstadoHst],[Automatico],[CXO],[XLote]) values ('eFact','EnviarAIF','Enviar a Interfacturas','Enviar a Interfacturas','PteEnvio','PteRespIF',0,0,1)
insert into [dbo].[WF_Evento]([IdFlow],[IdEvento],[DescrEvento],[TextoAccion],[IdEstadoDsd],[IdEstadoHst],[Automatico],[CXO],[XLote]) values ('eFact','RegAceptAFIP','Registrar la aceptación del AFIP','Registrar Aceptación AFIP','PteRespAFIP','AceptadoAFIP',1,0,0)
insert into [dbo].[WF_Evento]([IdFlow],[IdEvento],[DescrEvento],[TextoAccion],[IdEstadoDsd],[IdEstadoHst],[Automatico],[CXO],[XLote]) values ('eFact','RegAceptIF','Registrar la aceptación de Interfacturas','Registrar Aceptación IF','PteRespIF','PteRespAFIP',1,0,0)
insert into [dbo].[WF_Evento]([IdFlow],[IdEvento],[DescrEvento],[TextoAccion],[IdEstadoDsd],[IdEstadoHst],[Automatico],[CXO],[XLote]) values ('eFact','RegAceptIFM','Registrar la aceptación de Interfacturas (manual)','Registrar Aceptación IF (M)','PteRespIF','PteRespAFIP',0,0,0)
insert into [dbo].[WF_Evento]([IdFlow],[IdEvento],[DescrEvento],[TextoAccion],[IdEstadoDsd],[IdEstadoHst],[Automatico],[CXO],[XLote]) values ('eFact','RegRechAFIP','Registrar el rechazo del AFIP','Registrar Rechazo AFIP','PteRespAFIP','RechazadoAFIP',1,0,0)
insert into [dbo].[WF_Evento]([IdFlow],[IdEvento],[DescrEvento],[TextoAccion],[IdEstadoDsd],[IdEstadoHst],[Automatico],[CXO],[XLote]) values ('eFact','RegRechIF','Registrar el rechazo de Interfacturas','Registrar Aceptación IF','PteRespIF','RechazadoIF',1,0,0)
insert into [dbo].[WF_Evento]([IdFlow],[IdEvento],[DescrEvento],[TextoAccion],[IdEstadoDsd],[IdEstadoHst],[Automatico],[CXO],[XLote]) values ('eFact','RegRechIFM','Registrar el rechazo de IF (manual)','Registrar Rechazo IF (M)','PteRespIF','RechazadoIF',0,0,0)
insert into [dbo].[WF_Evento]([IdFlow],[IdEvento],[DescrEvento],[TextoAccion],[IdEstadoDsd],[IdEstadoHst],[Automatico],[CXO],[XLote]) values ('eFact','RevertirCancel','Revertir la cancelación','Revertir Cancelación','Cancelado','PteEnvio',0,0,1)
insert into [dbo].[WF_Evento]([IdFlow],[IdEvento],[DescrEvento],[TextoAccion],[IdEstadoDsd],[IdEstadoHst],[Automatico],[CXO],[XLote]) values ('eFact','RevertirRechIF','Revertir el rechazo de IF','Revertir el rechazo de IF','RechazadoIF','PteEnvio',0,0,1)
insert into [dbo].[WF_Evento]([IdFlow],[IdEvento],[DescrEvento],[TextoAccion],[IdEstadoDsd],[IdEstadoHst],[Automatico],[CXO],[XLote]) values ('eFact','AnularPteRIF','Anular el lote por envio posterior','Anular el lote por envio posterior','PteRespIF','Anulado',1,0,0)
insert into [dbo].[WF_Evento]([IdFlow],[IdEvento],[DescrEvento],[TextoAccion],[IdEstadoDsd],[IdEstadoHst],[Automatico],[CXO],[XLote]) values ('eFact','CancelarPteRIF','Cancelar lote pendiente de respuesta IF','Cancelar lote pendiente de respuesta IF','PteRespIF','Cancelado',0,0,1)
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
insert into [dbo].[WF_EsquemaSeg]([IdFlow],[IdCircuito],[IdNivSeg],[IdEvento],[IdGrupo],[DebeSerSP],[SupervisorNivelDsd],[SupervisorNivelHst],[CantInterv]) values ('eFact','Fact',0,'AnularCancel','FactOper','NA',0,255,1)
insert into [dbo].[WF_EsquemaSeg]([IdFlow],[IdCircuito],[IdNivSeg],[IdEvento],[IdGrupo],[DebeSerSP],[SupervisorNivelDsd],[SupervisorNivelHst],[CantInterv]) values ('eFact','Fact',0,'AnularRechIF','FactOper','NA',0,255,1)
insert into [dbo].[WF_EsquemaSeg]([IdFlow],[IdCircuito],[IdNivSeg],[IdEvento],[IdGrupo],[DebeSerSP],[SupervisorNivelDsd],[SupervisorNivelHst],[CantInterv]) values ('eFact','Fact',0,'Cancelar','FactOper','NA',0,255,1)
insert into [dbo].[WF_EsquemaSeg]([IdFlow],[IdCircuito],[IdNivSeg],[IdEvento],[IdGrupo],[DebeSerSP],[SupervisorNivelDsd],[SupervisorNivelHst],[CantInterv]) values ('eFact','Fact',0,'EnvBandSalida','FactOper','NA',0,255,1)
insert into [dbo].[WF_EsquemaSeg]([IdFlow],[IdCircuito],[IdNivSeg],[IdEvento],[IdGrupo],[DebeSerSP],[SupervisorNivelDsd],[SupervisorNivelHst],[CantInterv]) values ('eFact','Fact',0,'EnviarAIF','FactOper','NA',0,255,1)
insert into [dbo].[WF_EsquemaSeg]([IdFlow],[IdCircuito],[IdNivSeg],[IdEvento],[IdGrupo],[DebeSerSP],[SupervisorNivelDsd],[SupervisorNivelHst],[CantInterv]) values ('eFact','Fact',0,'RegAceptAFIP','FactOper','NA',0,255,1)
insert into [dbo].[WF_EsquemaSeg]([IdFlow],[IdCircuito],[IdNivSeg],[IdEvento],[IdGrupo],[DebeSerSP],[SupervisorNivelDsd],[SupervisorNivelHst],[CantInterv]) values ('eFact','Fact',0,'RegAceptIF','FactOper','NA',0,255,1)
insert into [dbo].[WF_EsquemaSeg]([IdFlow],[IdCircuito],[IdNivSeg],[IdEvento],[IdGrupo],[DebeSerSP],[SupervisorNivelDsd],[SupervisorNivelHst],[CantInterv]) values ('eFact','Fact',0,'RegAceptIFM','FactOper','NA',0,255,1)
insert into [dbo].[WF_EsquemaSeg]([IdFlow],[IdCircuito],[IdNivSeg],[IdEvento],[IdGrupo],[DebeSerSP],[SupervisorNivelDsd],[SupervisorNivelHst],[CantInterv]) values ('eFact','Fact',0,'RegRechAFIP','FactOper','NA',0,255,1)
insert into [dbo].[WF_EsquemaSeg]([IdFlow],[IdCircuito],[IdNivSeg],[IdEvento],[IdGrupo],[DebeSerSP],[SupervisorNivelDsd],[SupervisorNivelHst],[CantInterv]) values ('eFact','Fact',0,'RegRechIF','FactOper','NA',0,255,1)
insert into [dbo].[WF_EsquemaSeg]([IdFlow],[IdCircuito],[IdNivSeg],[IdEvento],[IdGrupo],[DebeSerSP],[SupervisorNivelDsd],[SupervisorNivelHst],[CantInterv]) values ('eFact','Fact',0,'RegRechIFM','FactOper','NA',0,255,1)
insert into [dbo].[WF_EsquemaSeg]([IdFlow],[IdCircuito],[IdNivSeg],[IdEvento],[IdGrupo],[DebeSerSP],[SupervisorNivelDsd],[SupervisorNivelHst],[CantInterv]) values ('eFact','Fact',0,'RevertirCancel','FactOper','NA',0,255,1)
insert into [dbo].[WF_EsquemaSeg]([IdFlow],[IdCircuito],[IdNivSeg],[IdEvento],[IdGrupo],[DebeSerSP],[SupervisorNivelDsd],[SupervisorNivelHst],[CantInterv]) values ('eFact','Fact',0,'RevertirRechIF','FactOper','NA',0,255,1)
insert into [dbo].[WF_EsquemaSeg]([IdFlow],[IdCircuito],[IdNivSeg],[IdEvento],[IdGrupo],[DebeSerSP],[SupervisorNivelDsd],[SupervisorNivelHst],[CantInterv]) values ('eFact','Fact',0,'AnularPteRIF','FactOper','NA',0,255,1)
insert into [dbo].[WF_EsquemaSeg]([IdFlow],[IdCircuito],[IdNivSeg],[IdEvento],[IdGrupo],[DebeSerSP],[SupervisorNivelDsd],[SupervisorNivelHst],[CantInterv]) values ('eFact','Fact',0,'CancelarPteRIF','FactOper','NA',0,255,1)

IF @@ERROR <> 0
ROLLBACK TRAN
ELSE
COMMIT TRANSACTION
GO



/*-- Actualización Version 1.6.22 --*/ 
USE [eFact-R];
GO
SET DATEFORMAT ymd
GO
BEGIN TRANSACTION
INSERT INTO [WF_Estado] ( [IdEstado], [DescrEstado], [Virtual]) VALUES ('AceptadoAFIPO', 'Aceptado AFIP Observado', 0)
INSERT INTO [WF_Estado] ( [IdEstado], [DescrEstado], [Virtual]) VALUES ('AceptadoAFIPP', 'Aceptado AFIP Parcial', 0)
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
INSERT INTO [WF_EstadoXFlow] ( [IdFlow], [IdEstado], [EstadoFinal]) VALUES ( 'eFact', 'AceptadoAFIPO', 1)
INSERT INTO [WF_EstadoXFlow] ( [IdFlow], [IdEstado], [EstadoFinal]) VALUES ( 'eFact', 'AceptadoAFIPP', 1)
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
insert into [dbo].[WF_Evento]([IdFlow],[IdEvento],[DescrEvento],[TextoAccion],[IdEstadoDsd],[IdEstadoHst],[Automatico],[CXO],[XLote]) values ('eFact','RegAceptAFIPO','Registrar la aceptación del AFIP Observado','Registrar Aceptación AFIP Observado','PteRespAFIP','AceptadoAFIPO',1,0,0)
insert into [dbo].[WF_Evento]([IdFlow],[IdEvento],[DescrEvento],[TextoAccion],[IdEstadoDsd],[IdEstadoHst],[Automatico],[CXO],[XLote]) values ('eFact','RegAceptAFIPP','Registrar la aceptación del AFIP Parcial','Registrar Aceptación AFIP Parcial','PteRespAFIP','AceptadoAFIPP',1,0,0)
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
insert into [dbo].[WF_EsquemaSeg]([IdFlow],[IdCircuito],[IdNivSeg],[IdEvento],[IdGrupo],[DebeSerSP],[SupervisorNivelDsd],[SupervisorNivelHst],[CantInterv]) values ('eFact','Fact',0,'RegAceptAFIPO','FactOper','NA',0,255,1)
insert into [dbo].[WF_EsquemaSeg]([IdFlow],[IdCircuito],[IdNivSeg],[IdEvento],[IdGrupo],[DebeSerSP],[SupervisorNivelDsd],[SupervisorNivelHst],[CantInterv]) values ('eFact','Fact',0,'RegAceptAFIPP','FactOper','NA',0,255,1)
IF @@ERROR <> 0
ROLLBACK TRAN
ELSE
COMMIT TRANSACTION
GO



/*-- Actualización Version 1.6.30 --*/ 
USE [eFact-R];
GO
SET DATEFORMAT ymd
GO
BEGIN TRANSACTION
insert into [dbo].[WF_Evento]([IdFlow],[IdEvento],[DescrEvento],[TextoAccion],[IdEstadoDsd],[IdEstadoHst],[Automatico],[CXO],[XLote]) values ('eFact','RegActAFIPO','Registrar la actualización de AFIP Observado','Registrar actualización AFIP Observado','AceptadoAFIPO','AceptadoAFIPO',0,0,0)
insert into [dbo].[WF_Evento]([IdFlow],[IdEvento],[DescrEvento],[TextoAccion],[IdEstadoDsd],[IdEstadoHst],[Automatico],[CXO],[XLote]) values ('eFact','RegActAFIPP','Registrar la actualización de AFIP Parcial','Registrar actualización AFIP Parcial','AceptadoAFIPP','AceptadoAFIPP',0,0,0)
insert into [dbo].[WF_Evento]([IdFlow],[IdEvento],[DescrEvento],[TextoAccion],[IdEstadoDsd],[IdEstadoHst],[Automatico],[CXO],[XLote]) values ('eFact','RegActAFIP','Registrar la actualización de AFIP','Registrar actualización AFIP','AceptadoAFIP','AceptadoAFIP',0,0,0)
insert into [dbo].[WF_Evento]([IdFlow],[IdEvento],[DescrEvento],[TextoAccion],[IdEstadoDsd],[IdEstadoHst],[Automatico],[CXO],[XLote]) values ('eFact','RegContAFIP','Registrar la aceptación de AFIP (C)','Registrar aceptación AFIP (C)',NULL,'AceptadoAFIP',0,0,0)
insert into [dbo].[WF_Evento]([IdFlow],[IdEvento],[DescrEvento],[TextoAccion],[IdEstadoDsd],[IdEstadoHst],[Automatico],[CXO],[XLote]) values ('eFact','RegContAFIPO','Registrar la aceptación de AFIP Observado (C)','Registrar aceptación AFIP Observado (C)',NULL,'AceptadoAFIPO',0,0,0)
insert into [dbo].[WF_Evento]([IdFlow],[IdEvento],[DescrEvento],[TextoAccion],[IdEstadoDsd],[IdEstadoHst],[Automatico],[CXO],[XLote]) values ('eFact','RegContAFIPP','Registrar la aceptación de AFIP Parcial (C)','Registrar aceptación AFIP Parcial (C)',NULL,'AceptadoAFIPP',0,0,0)
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
insert into [dbo].[WF_EsquemaSeg]([IdFlow],[IdCircuito],[IdNivSeg],[IdEvento],[IdGrupo],[DebeSerSP],[SupervisorNivelDsd],[SupervisorNivelHst],[CantInterv]) values ('eFact','Fact',0,'RegActAFIPO','FactOper','NA',0,255,1)
insert into [dbo].[WF_EsquemaSeg]([IdFlow],[IdCircuito],[IdNivSeg],[IdEvento],[IdGrupo],[DebeSerSP],[SupervisorNivelDsd],[SupervisorNivelHst],[CantInterv]) values ('eFact','Fact',0,'RegActAFIPP','FactOper','NA',0,255,1)
insert into [dbo].[WF_EsquemaSeg]([IdFlow],[IdCircuito],[IdNivSeg],[IdEvento],[IdGrupo],[DebeSerSP],[SupervisorNivelDsd],[SupervisorNivelHst],[CantInterv]) values ('eFact','Fact',0,'RegActAFIP','FactOper','NA',0,255,1)
insert into [dbo].[WF_EsquemaSeg]([IdFlow],[IdCircuito],[IdNivSeg],[IdEvento],[IdGrupo],[DebeSerSP],[SupervisorNivelDsd],[SupervisorNivelHst],[CantInterv]) values ('eFact','Fact',0,'RegContAFIP','FactOper','NA',0,255,1)
insert into [dbo].[WF_EsquemaSeg]([IdFlow],[IdCircuito],[IdNivSeg],[IdEvento],[IdGrupo],[DebeSerSP],[SupervisorNivelDsd],[SupervisorNivelHst],[CantInterv]) values ('eFact','Fact',0,'RegContAFIPO','FactOper','NA',0,255,1)
insert into [dbo].[WF_EsquemaSeg]([IdFlow],[IdCircuito],[IdNivSeg],[IdEvento],[IdGrupo],[DebeSerSP],[SupervisorNivelDsd],[SupervisorNivelHst],[CantInterv]) values ('eFact','Fact',0,'RegContAFIPP','FactOper','NA',0,255,1)
IF @@ERROR <> 0
ROLLBACK TRAN
ELSE
COMMIT TRANSACTION
GO




/*-- Actualización Version 1.6.31 --*/ 
USE [eFact-R];
GO
SET DATEFORMAT ymd
GO
BEGIN TRANSACTION
insert into [dbo].[WF_Evento]([IdFlow],[IdEvento],[DescrEvento],[TextoAccion],[IdEstadoDsd],[IdEstadoHst],[Automatico],[CXO],[XLote]) values ('eFact','RevertirRechIFA','Revertir el rechazo de IF (A)','Revertir el rechazo de IF (A)','RechazadoIF','PteEnvio',1,0,0)
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
insert into [dbo].[WF_EsquemaSeg]([IdFlow],[IdCircuito],[IdNivSeg],[IdEvento],[IdGrupo],[DebeSerSP],[SupervisorNivelDsd],[SupervisorNivelHst],[CantInterv]) values ('eFact','Fact',0,'RevertirRechIFA','FactOper','NA',0,255,1)
IF @@ERROR <> 0
ROLLBACK TRAN
ELSE
COMMIT TRANSACTION
GO
