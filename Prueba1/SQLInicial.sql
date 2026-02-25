-- =============================================================
-- Creacion de la BD
-- =============================================================

-- Crear la base de datos
CREATE DATABASE TareasDB;
GO

-- Usar la base de datos
USE TareasDB;
GO

-- Crear tabla Tareas
CREATE TABLE Tareas (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Titulo NVARCHAR(200) NOT NULL,
    Descripcion NVARCHAR(1000) NULL,
    EstaCompletada BIT NOT NULL DEFAULT 0,
    FechaCreacion DATETIME2 NOT NULL DEFAULT GETDATE()
);
GO

INSERT INTO Tareas (Titulo, Descripcion, EstaCompletada)
VALUES 
('Tarea 1', 'Descripcion de la tarea 1', 0),
('Tarea 2', 'Descripcion de la tarea 2', 0),
('Tarea 3', 'Descripcion de la tarea 3', 0),
('Tarea 4', 'Descripcion de la tarea 4', 0),
('Tarea 5', 'Descripcion de la tarea 5', 0),
('Tarea 6', 'Descripcion de la tarea 6', 0),
('Tarea 7', 'Descripcion de la tarea 7', 0),
('Tarea 8', 'Descripcion de la tarea 8', 0),
('Tarea 9', 'Descripcion de la tarea 9', 0),
('Tarea 10', 'Descripcion de la tarea 10', 0);
GO


-- =============================================================
-- Creacion de usuario para la BD
-- =============================================================

USE master;
GO

-- Crear login a nivel de servidor (si no existe)
IF NOT EXISTS (SELECT 1 FROM sys.server_principals WHERE name = 'adminTareas')
BEGIN
    CREATE LOGIN adminTareas
    WITH PASSWORD = 'grupo1progra5uh',
         CHECK_POLICY = OFF,
         CHECK_EXPIRATION = OFF;
END
GO

USE TareasDB;
GO

-- Crear usuario en la base de datos (si no existe)
IF NOT EXISTS (SELECT 1 FROM sys.database_principals WHERE name = 'adminTareas')
BEGIN
    CREATE USER adminTareas FOR LOGIN adminTareas;
END
GO

-- Asignar rol de administrador de la base de datos
ALTER ROLE db_owner ADD MEMBER adminTareas;
GO

-- =============================================================
-- Usuario adminCitas creado con permisos de administrador
-- =============================================================
