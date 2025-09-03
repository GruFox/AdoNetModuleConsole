using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdoNetLib;

namespace AdoNetModuleConsole;

public class Manager
{
    private MainConnector connector;
    private DbExecutor dbExecutor;
    private Table userTable;
    public Manager()
    {
        connector = new MainConnector();

        userTable = new Table();
        userTable.Name = "NetworkUser";
        userTable.ImportantField = "Login";
        userTable.Fields.Add("Id");
        userTable.Fields.Add("Login");
        userTable.Fields.Add("Name");
    }

    public async Task Connect()
    {
        bool isConnected = await connector.ConnectAsync();

        if (isConnected)
        {
            Console.WriteLine("Подключено успешно!");

            dbExecutor = new DbExecutor(connector);
        }
        else
        {
            Console.WriteLine("Ошибка подключения!");
        }
    }

    public async Task Disconnect()
    {
        Console.WriteLine("Отключаем БД!");
        await connector.DisconnectAsync();
    }

    public void ShowData()
    {
        Console.WriteLine("Получаем данные таблицы " + userTable.Name);

        dbExecutor.ShowRowCount(userTable.Name);

        var reader = dbExecutor.SelectAllCommandReader(userTable.Name);

        var columnList = new List<string>();

        for (int i = 0; i < reader.FieldCount; i++)
        {
            var name = reader.GetName(i);
            columnList.Add(name);
        }

        for (int i = 0; i < columnList.Count; i++)
        {
            Console.Write($"{columnList[i]}\t");
        }
        Console.WriteLine();

        while (reader.Read())
        {
            for (int i = 0; i < columnList.Count; i++)
            {
                var value = reader[columnList[i]];
                Console.Write($"{value}\t");
            }

            Console.WriteLine();
        }

        Console.WriteLine();

        reader.Close();
    }

    public int DeleteUserByLogin(string value)
    {
        return dbExecutor.DeleteByColumn(userTable.Name, userTable.ImportantField, value);
    }

    public void AddUser(string name, string login)
    {
        dbExecutor.ExecProcedureAdding(name, login);
    }

    public int UpdateUserByLogin(string valuecheck, string valueupdate)
    {
        return dbExecutor.UpdateByColumn(userTable.Name, userTable.Fields[2], valueupdate, userTable.ImportantField, valuecheck);
    }
}