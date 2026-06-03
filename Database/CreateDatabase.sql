CREATE DATABASE AdoNetModuleDb;
GO

USE AdoNetModuleDb;
GO

CREATE TABLE NetworkUser
(
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Login NVARCHAR(50) NOT NULL,
    Name NVARCHAR(100) NOT NULL,

    CONSTRAINT UQ_NetworkUser_Login UNIQUE(Login)
);
GO

INSERT INTO NetworkUser(Login, Name)
VALUES
('admin', N'Администратор'),
('test', N'Тест Тестович');
GO

