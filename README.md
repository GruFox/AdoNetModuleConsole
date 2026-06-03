# AdoNetModuleConsole

Учебный проект по изучению ADO.NET и SQL Server.

## Требования

- .NET 8
- SQL Server Express
- SQL Server Management Studio

## Настройка базы данных

1. Open SQL Server Management Studio.
2. Execute Database/CreateDatabase.sql.
3. Update the connection string if needed.

## Строка подключения

Используется локальный SQL Server:

```csharp
Server=localhost\SQLEXPRESS;
Database=AdoNetModuleDb;
Trusted_Connection=True;
TrustServerCertificate=True;
```

## Запуск

Запустить проект AdoNetModuleConsole.