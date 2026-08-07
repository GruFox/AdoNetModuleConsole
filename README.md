# AdoNetModuleConsole

Study project on studying ADO.NET и SQL Server.

## Requirements

- .NET 8
- SQL Server Express
- SQL Server Management Studio

## Database setup

1. Open SQL Server Management Studio.
2. Execute Database/CreateDatabase.sql.
3. Update the connection string if needed.

## Connection string

Local SQL Server is used:

```csharp
Server=localhost\SQLEXPRESS;
Database=AdoNetModuleDb;
Trusted_Connection=True;
TrustServerCertificate=True;
```

## Launch

Launch a project AdoNetModuleConsole.
