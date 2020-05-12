using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ADOX;
using System.IO;
using System.Data.OleDb;

namespace access_database_csharp_dotnet_framework
{
    class Program
    {
        static void Main(string[] args)
        {
            string stringConnection = "Provider = Microsoft.ACE.OLEDB.12.0; " + "Data Source = file.accdb;";

            File.Delete("file.accdb");
            ADOX.Catalog cat = new ADOX.Catalog();
            cat.Create(stringConnection);
            ADOX.Table table = new ADOX.Table();
            table.Name = "Студенты";
            table.Columns.Append("Имя");
            table.Columns.Append("Группа", DataTypeEnum.adInteger);
            table.Columns.Append("Очное обучение", DataTypeEnum.adBoolean);
            cat.Tables.Append(table);
            table = new ADOX.Table();
            table.Name = "Преподаватели";
            table.Columns.Append("Имя");
            table.Columns.Append("Группа", DataTypeEnum.adInteger);
            table.Columns.Append("Дата приема на работу", DataTypeEnum.adDate);
            cat.Tables.Append(table);
            table = new ADOX.Table();
            table.Name = "Продукты";
            table.Columns.Append("Название");
            table.Columns.Append("Цена", DataTypeEnum.adInteger);
            table.Columns.Append("Срок годности", DataTypeEnum.adDate);
            cat.Tables.Append(table);

            OleDbConnection connection = new OleDbConnection(stringConnection);
            connection.Open();
            OleDbCommand command = null;
            OleDbDataReader reader = null;
            string answer = "";
            command = new OleDbCommand("INSERT INTO [Студенты] VALUES ('Бубулюка', 171, 0);", connection);
            command.ExecuteNonQuery();
            command = new OleDbCommand("INSERT INTO [Студенты] VALUES ('Булкин', 181, -1);", connection);
            command.ExecuteNonQuery();
            command = new OleDbCommand("INSERT INTO [Студенты] VALUES ('Порошков', 181, 0);", connection);
            command.ExecuteNonQuery();
            command = new OleDbCommand("INSERT INTO [Преподаватели] VALUES ('Иванов', 171, '01.01.2001');", connection);
            command.ExecuteNonQuery();
            command = new OleDbCommand("INSERT INTO [Преподаватели] VALUES ('Петрова', 171, '01.05.2010');", connection);
            command.ExecuteNonQuery();
            command = new OleDbCommand("INSERT INTO [Преподаватели] VALUES ('Литров', 181, '01.01.2015');", connection);
            command.ExecuteNonQuery();
            command = new OleDbCommand("INSERT INTO [Продукты] VALUES ('Сникерс', 70, '01.01.2020');", connection);
            command.ExecuteNonQuery();
            command = new OleDbCommand("INSERT INTO [Продукты] VALUES ('Кола', 45, '01.01.2020');", connection);
            command.ExecuteNonQuery();
            command = new OleDbCommand("INSERT INTO [Продукты] VALUES ('Макарошки', 40, '01.01.2020');", connection);
            command.ExecuteNonQuery();

            command = new OleDbCommand("SELECT Sum([Цена]) AS [Сумма] FROM [Продукты]", connection);
            Console.WriteLine($"Стоимость всех продуктов {command.ExecuteScalar().ToString()} бубликов");

            command = new OleDbCommand("SELECT Имя FROM [Студенты] WHERE Группа =181;", connection);
            reader = command.ExecuteReader();
            
            while (reader.Read())
            {
                answer += reader[0].ToString() + " ";
            }
            Console.WriteLine($"Студенты 181 группы: {answer}");

            command = new OleDbCommand("SELECT Имя FROM[Преподаватели] WHERE [Дата приема на работу] = (SELECT max([Дата приема на работу]) FROM[Преподаватели]);", connection);
            reader = command.ExecuteReader();
            answer = "";
            while (reader.Read())
            {
                answer += reader[0].ToString() + " ";
            }
            Console.WriteLine($"Самый молодой преподаватель - {answer}");


            connection.Close();


            //do
            //{
            //    if (existsDatabase) Console.WriteLine("База данных найдена");
            //    else Console.WriteLine("База данных ненайдена");

            //    Console.WriteLine("Выберите функцию:");

            //    if (existsDatabase) {
            //        Console.WriteLine("1. Удалить базу данных.");
            //        Console.WriteLine("2. Редактировать базу данных.");
            //        Console.WriteLine("3. Сделать запрос в БД");
            //    }else {
            //        Console.WriteLine("1. Создать базу данных.");;
            //    }

            //    Console.WriteLine("0. Выйти");
            //    answer = Convert.ToInt32(Console.ReadLine());

            //    switch (answer) {
            //        case 1:
            //            if (existsDatabase)
            //            {
            //                File.Delete("file.accdb");
            //                Console.WriteLine("База данных успешно удалена");
            //                existsDatabase = false;
            //            }
            //            else {
            //                cat.Create("Provider = Microsoft.ACE.OLEDB.12.0; " + "Data Source = file.accdb;");
            //                Console.WriteLine("База данных успешно создана");
            //                existsDatabase = true;
            //            }
            //            break;
            //        case 2:
            //            if (existsDatabase) {
            //                bool exitStage = false;
            //                do
            //                {
            //                    Console.WriteLine("Кол-во таблиц:" + cat.Tables.Count);
            //                    Console.WriteLine("1. Добавить таблицу.");
            //                    Console.WriteLine("2. Выбрать таблицу");
            //                    Console.WriteLine("0. Выйти");
            //                    answer = Convert.ToInt32(Console.ReadLine());
            //                    switch (answer)
            //                    {
            //                        case 1:
            //                            Console.WriteLine("Введите название таблицы:");
            //                            string name = Console.ReadLine();
            //                            ADOX.Table table = new ADOX.Table();
            //                            table.Name = name;
            //                            cat.Tables.Append(table);
            //                            break;
            //                        case 2:
            //                            break;
            //                        case 0:
            //                            exitStage = true;
            //                            break;
            //                    }
            //                } while (!exitStage);
            //            }
            //            break;
            //        case 0:
            //            exit = true;
            //            break;
            //    }
            //} while (!exit);


            Console.WriteLine("Bye bye");
            Console.ReadKey();
        }
    }
}
