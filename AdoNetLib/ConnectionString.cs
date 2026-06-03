namespace AdoNetLib;

public static class ConnectionString
{
    public static string MsSqlConnection =>
        @"Server=.\SQLEXPRESS;Database=AdoNetModuleDb;Trusted_Connection=True;TrustServerCertificate=True;";
}