using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ADOX;
using System.IO;

namespace access_database_csharp_dotnet_framework
{
    class Program
    {
        static void Main(string[] args)
        {
            bool existsDatabase = File.Exists("file.accdb");
            File.Delete("file.accdb");
            ADOX.Catalog cat = new ADOX.Catalog();
            cat.Create("Provider = Microsoft.ACE.OLEDB.12.0; " + "Data Source = file.accdb;");
            ADOX.Table table = new ADOX.Table();
            table.Name = "Студенты";
            table.Columns.Append("Имя");
            table.Columns.Append("Номер группы", DataTypeEnum.adInteger);
            table.Columns.Append("Очное обучение", DataTypeEnum.adBoolean);
            cat.Tables.Append(table);
            table = new ADOX.Table();
            table.Name = "Преподаватели";
            table.Columns.Append("Имя");
            table.Columns.Append("Номер группы", DataTypeEnum.adInteger);
            table.Columns.Append("Дата приема на рабоут", DataTypeEnum.adDate);
            cat.Tables.Append(table);
            table = new ADOX.Table();
            table.Name = "Продукты";
            table.Columns.Append("Название");
            table.Columns.Append("Цена", DataTypeEnum.adInteger);
            table.Columns.Append("Срок годности", DataTypeEnum.adDate);
            cat.Tables.Append(table);
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
