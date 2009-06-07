/* es necesario ya tener creado el backup device (CedWebdumpDevice) */
USE master
GO
BACKUP DATABASE CedWeb TO CedWebDumpDevice WITH FORMAT;
GO
