using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XmlReader

{
    class main
    {
        static void Main(string[] args)
        {

            Xml.XmlImport.ReadFile();

            if (DbElement.instanceList.Keys.Count <= 0)
            {
                Console.WriteLine("Нет файла импорта");
                return;
            }

            Menu();
        }

        // Меню 
        public static void Menu()
        {

            bool show = true;

            while (show)
            {
                Console.WriteLine("***Меню***");
                Console.WriteLine("Выберите действие:");
                int i = 0;

                foreach (var elem in DbElement.instanceList.Keys)
                {
                    i++;
                    Console.WriteLine(i + ". " + elem);
                }

                i++;
                Console.WriteLine(i + ". Export");
                i++;
                Console.WriteLine(i + ". Exit");

                try
                {
                    string answer = Console.ReadLine();

                    int resultOut;

                    if (!int.TryParse(answer, out resultOut))
                        throw new Exception("Не корректные данные");

                    DbElement menu = new DbElement();

                    int x = 0;

                    foreach (var elem in DbElement.instanceList.Keys)
                    {
                        x++;
                        if (x == resultOut)
                            menu.Menu(elem);
                    }

                    x++;
                    if (x == resultOut) Xml.XmlExport.ExportData();
                    x++;
                    if (x == resultOut) show = false;



                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }

        }


    }
}

        }
    }
}
