
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XmlReader.MenuAll;


namespace XmlReader

{
    class main
    {
        static void Main(string[] args)
        {
             
        bool menu = true;
            while (menu)
            {
                Console.WriteLine();
                Console.WriteLine("Выберите соответствующую таблицу: ");
                Console.WriteLine("1. Автомобили");
                Console.WriteLine("2. Клиенты");
                Console.WriteLine("3. Сотрудники");
                Console.WriteLine("4. Сделки");
                Console.WriteLine("5. Доступность автомобилей");
                Console.WriteLine();
                try
                {
                    string answer = Console.ReadLine();
                    int resultOut;

                    if (!int.TryParse(answer, out resultOut))
                        throw new Exception("Не корректные данные, попробуйте еще раз!");
                        Console.WriteLine();

                    switch (resultOut)
                    {
                        case 1:
                            MenuAuto.MAuto();
                            break;
                        case 2:
                            MenuClients.MClient();
                            break;
                        case 3:
                            MenuSotrudniki.MSotrudnik();
                            break;
                        case 4:
                            MenuSdelki.MSdelki();
                            break;
                        case 5:
                            MenuDostup.MDostup();
                            break;
                        default:
                            throw new Exception("Некорректное число, попробуйте еще раз!");
                           
                    }

                }
                catch (Exception e)
                {
                    Console.WriteLine("Не корректные данные, попробуйте еще раз!");
                    Console.WriteLine();
                }


            }

            

           

        }
    }
}

