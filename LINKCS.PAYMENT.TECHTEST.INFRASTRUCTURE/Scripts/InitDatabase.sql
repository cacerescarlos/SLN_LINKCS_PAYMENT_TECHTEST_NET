-- Crear base de datos
IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = 'PaymentDb')
BEGIN
    CREATE DATABASE PaymentDb;
END
GO

USE PaymentDb;
GO

-- Crear tabla Payments
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Payments')
BEGIN
    CREATE TABLE Payments (
        PaymentId NVARCHAR(100) PRIMARY KEY,
        CustomerId NVARCHAR(100) NOT NULL,
        ServiceProvider NVARCHAR(200) NOT NULL,
        Amount DECIMAL(18, 2) NOT NULL,
        Status NVARCHAR(20) NOT NULL DEFAULT 'pendiente',
        CreatedAt DATETIME2 NOT NULL DEFAULT GETUTCDATE(),
        CONSTRAINT CK_Payments_Status CHECK (Status IN ('pendiente', 'confirmado', 'rechazado'))
    );
    
    PRINT 'Tabla Payments creada exitosamente.';
END
GO