using System.Data;
using AdoNetLib;
using Microsoft.Data.SqlClient;

namespace AdoNetModuleConsole;

internal class Program
{
    static Manager manager = new Manager();
    static async Task Main(string[] args)
    {
        await manager.Connect();

        Console.WriteLine("Список команд для работы консоли:");
        Console.WriteLine(Commands.stop + ": прекращение работы");
        Console.WriteLine(Commands.add + ": добавление данных");
        Console.WriteLine(Commands.delete + ": удаление данных");
        Console.WriteLine(Commands.update + ": обновление данных");
        Console.WriteLine(Commands.show + ": просмотр данных");

        string command;
        do
        {
            Console.WriteLine("\nВведите команду:");
            command = Console.ReadLine();
            Console.WriteLine();

            switch (command)
            {
                case nameof(Commands.add):
                    {
                        Add();
                        break;
                    }
                case nameof(Commands.delete):
                    {
                        Delete();
                        break;
                    }
                case nameof(Commands.update):
                    {
                        Update();
                        break;
                    }
                case nameof(Commands.show):
                    {
                        manager.ShowData();
                        break;
                    }
                break;
            }
        }
        while (command != nameof(Commands.stop));

        await manager.Disconnect();

        static void Add()
        {
            Console.WriteLine("Введите логин для добавления:");

            var login = Console.ReadLine();

            Console.WriteLine("Введите имя для добавления:");
            var name = Console.ReadLine();

            manager.AddUser(name, login);

            manager.ShowData();
        }

        static void Delete()
        {
            Console.WriteLine("Введите логин для удаления:");

            var count = manager.DeleteUserByLogin(Console.ReadLine());

            Console.WriteLine("Количество удаленных строк " + count);

            manager.ShowData();
        }

        static void Update()
        {
            Console.WriteLine("Введите логин для обновления:");

            var login = Console.ReadLine();

            Console.WriteLine("Введите имя для обновления:");
            var name = Console.ReadLine();

            var count = manager.UpdateUserByLogin(login, name);

            Console.WriteLine("Строк обновлено" + count);

            manager.ShowData();
        }
    }

    public enum Commands
    {
        stop,
        add,
        delete,
        update,
        show
    }




    //var connector = new MainConnector();

    ////Отсоединенная модель

    //var data = new DataTable();

    //bool isConnected = await connector.ConnectAsync();

    //if (isConnected)
    //{
    //    Console.WriteLine("Подключено успешно!");
    //}
    //else
    //{
    //    Console.WriteLine("Ошибка подключения!");
    //}

    //var db = new DbExecutor(connector);

    //var tablename = "NetworkUser";

    //Console.WriteLine("Получаем данные таблицы " + tablename);

    //data = db.SelectAll(tablename);

    //Console.WriteLine("Количество строк в " + tablename + ": " + data.Rows.Count);

    //Console.WriteLine("Отключаем БД!");

    //await connector.DisconnectAsync();

    //Console.WriteLine("Данные из отсоединенной модели:");
    //Console.WriteLine();

    //foreach (DataColumn column in data.Columns)
    //{
    //    Console.Write($"{column.ColumnName}\t");
    //}

    //Console.WriteLine();

    //foreach (DataRow row in data.Rows)
    //{
    //    //Console.Write($"{row[data.Columns[0]]}\t");
    //    //Console.Write($"{row[data.Columns[1]]}\t");
    //    //Console.Write($"{row[data.Columns[2]]}\t");

    //    var cells = row.ItemArray;
    //    foreach (var cell in cells)
    //    {
    //        Console.Write($"{cell}\t");
    //    }
    //    Console.WriteLine();
    //}

    //Console.WriteLine();





    //присоединенная модель

    //bool isConnected = await connector.ConnectAsync();

    //if (isConnected)
    //{
    //    Console.WriteLine("Подключено успешно!");
    //}
    //else
    //{
    //    Console.WriteLine("Ошибка подключения!");
    //}

    //Console.WriteLine("Данные из присоединенной модели:");
    //Console.WriteLine();

    //var db = new DbExecutor(connector);

    //var tablename = "NetworkUser";

    //var reader = db.SelectAllCommandReader(tablename);

    //var columnList = new List<string>();

    //for (int i = 0; i < reader.FieldCount; i++)
    //{
    //    var name = reader.GetName(i);
    //    columnList.Add(name);
    //}

    //for (int i = 0; i < columnList.Count; i++)
    //{
    //    Console.Write($"{columnList[i]}\t");
    //}
    //Console.WriteLine();

    //while (reader.Read())
    //{
    //    for (int i = 0; i < columnList.Count; i++)
    //    {
    //        var value = reader[columnList[i]];
    //        Console.Write($"{value}\t");
    //    }

    //    Console.WriteLine();
    //}

}