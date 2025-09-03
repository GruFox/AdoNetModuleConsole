using System.Data;
using Microsoft.Data.SqlClient;

namespace AdoNetLib;

public class MainConnector
{
    private SqlConnection? connection;

    public async Task<bool> ConnectAsync()
    {
        try
        {
            connection = new SqlConnection(ConnectionString.MsSqlConnection);
            await connection.OpenAsync();
            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine("Ошибка: " + ex.Message);
            return false;
        }
    }

    public async Task DisconnectAsync()
    {
        if (connection != null && connection.State == ConnectionState.Open)
        {
            await connection.CloseAsync();
            Console.WriteLine("Соединение закрыто.");
        }
    }
    public SqlConnection GetConnection()
    {
        if (connection.State == ConnectionState.Open)
        {
            return connection;
        }
        else
        {
            throw new Exception("Подключение уже закрыто!");
        }
    }
}