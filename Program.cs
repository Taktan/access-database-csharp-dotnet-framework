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
            int answer = 0;
            bool exit = false;
            bool existsDatabase = File.Exists("file.accdb");

            ADOX.Catalog cat = new ADOX.Catalog();
            ADOX.Table table = new ADOX.Table();

            //Create the table and it's fields. 
            table.Name = "Table1";
            table.Columns.Append("Field1");
            table.Columns.Append("Field2");

            do
            {
                if (existsDatabase) Console.WriteLine("База данных найдена");
                else Console.WriteLine("База данных ненайдена");

                Console.WriteLine("Выберите функцию:");

                if (existsDatabase) {
                    Console.WriteLine("1. Удалить базу данных.");
                    Console.WriteLine("2. Редактировать базу данных.");
                    Console.WriteLine("3. Сделать запрос в БД");
                }else {
                    Console.WriteLine("1. Создать базу данных.");;
                }
                
                Console.WriteLine("0. Выйти");
                answer = Convert.ToInt32(Console.ReadLine());

                switch (answer) {
                    case 1:
                        if (existsDatabase)
                        {
                            File.Delete("file.accdb");
                            Console.WriteLine("База данных успешно удалена");
                            existsDatabase = false;
                        }
                        else {
                            cat.Create("Provider = Microsoft.ACE.OLEDB.12.0; " + "Data Source = file.accdb;");
                            Console.WriteLine("База данных успешно создана");
                            existsDatabase = true;
                        }
                        break;
                    case 2:
                        if (existsDatabase) {
                            bool exitStage = false;
                            do
                            {
                                Console.WriteLine("1. Добавить таблицу.");
                                Console.WriteLine("2. Выбрать таблицу");
                                Console.WriteLine("0. Выйти");
                                answer = Convert.ToInt32(Console.ReadLine());
                                switch (answer)
                                {
                                    case 1:
                                        break;
                                    case 2:
                                        break;
                                    case 0:
                                        exitStage = true;
                                        break;
                                }
                            } while (!exitStage);
                        }
                        break;
                    case 0:
                        exit = true;
                        break;
                }
            } while (!exit);
            

            Console.WriteLine("Bye bye");
            Console.ReadKey();
        }
    }
}
