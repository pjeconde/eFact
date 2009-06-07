/* la base de datos no debe existir en el motor y no se necesita definir un backup device */
USE master
GO
RESTORE DATABASE [CedWeb] 
	FROM  DISK = N'C:\Documents and Settings\Claudio\Mis documentos\Cedeira y Asoc. S.A\DBs\CedWeb\CedWeb.bak' 
	WITH  FILE = 1
GO

