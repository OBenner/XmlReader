using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static XmlReader.XmlOptions.XmlImportClients;

namespace XmlReader.MenuAll
{
    class MenuClients
    {

        public static void MClient()
        {
            bool show = true;
            XmlOptions.XmlImportClients cl = new XmlOptions.XmlImportClients();
            while (show)
            {
                Console.WriteLine();
                Console.WriteLine("Выберите действия с объектов: ");
                Console.WriteLine("1. Получить список объектов");
                Console.WriteLine("2. Добавить объект");
                Console.WriteLine("3. Изменить объект");
                Console.WriteLine("4. Назад");

                try
                {
                    string answer = Console.ReadLine();
                    int resultOut;

                    if (!int.TryParse(answer, out resultOut))
                        throw new Exception("Не корректные данные");

                    switch (resultOut)
                    {
                        case 1:

                            cl.ReadFile();
                            break;
                        case 2:
                            cl.AddAuto();
                            break;
                        case 3:
                            Clients a = null;
                            var list = cl.ParceClients();
                            while (true)
                            {
                                for (int i = 0; i < list.Count; i++)
                                {
                                    Console.WriteLine("№ {0} : \n ФИО: {1}  Документ: {2}  ", i + 1, list[i].fio, list[i].document);
                                }
                                answer = Console.ReadLine();

                                if (!int.TryParse(answer, out resultOut))
                                {
                                    Console.WriteLine("Не корректные данные");
                                    continue;
                                }
                                if (resultOut <= 0 || resultOut > list.Count)
                                {
                                    Console.WriteLine("Повторить ввод");
                                    continue;
                                }
                                a = list[resultOut - 1];
                                break;
                            }
                            Console.WriteLine("Вы выбрали: \n ФИО: {0}  Документ: {1} ", a.fio, a.document);
                            //

                            bool mUp = true;
                            while (mUp)
                            {

                                Console.WriteLine();
                                Console.WriteLine("Выберите действия с объектом: ");
                                Console.WriteLine("1.посмотреть выбранный объект");
                                Console.WriteLine("2.обновить ФИО");
                                Console.WriteLine("3.обновить предъявленный документ");
                                Console.WriteLine("4. удалить запись");
                                Console.WriteLine("5. Назад");
                                Console.WriteLine();
                                string x = Console.ReadLine();
                                int y = int.Parse(x);
                                switch (y)
                                {

                                    case 1:

                                        Console.WriteLine("Вы выбрали: \n ФИО: {0}  Документ: {1} ", a.fio, a.document);
                                        break;
                                    
                                    case 2:
                                        Console.WriteLine("Введите новые ФИО ");
                                        string fio = Console.ReadLine();
                                        try
                                        {
                                            a.fio = fio;
                                            cl.FioUpdateClient(a);
                                        }
                                        catch (Exception e)
                                        {
                                            Console.WriteLine("Не корректные данные, попробуйте еще раз!");
                                            Console.WriteLine();
                                        }
                                        break;

                                    case 3:
                                        Console.WriteLine("Введите новые данные предъявленного документа ");
                                        string _doc = Console.ReadLine();
                                        try
                                        {
                                            a.document = _doc;
                                            cl.DocUpdateClient(a);
                                        }
                                        catch (Exception e)
                                        {
                                            Console.WriteLine("Не корректные данные, попробуйте еще раз!");
                                            Console.WriteLine();
                                        }
                                        break;

                                   

                                    case 4:
                                        cl.DeleteClient(a);
                                        break;
                                    case 5:
                                        mUp = false;
                                        break;

                                    default:
                                        throw new Exception("Некорректное число, попробуйте еще раз!");
                                }
                            }
                            break;

                        case 4:
                            show = false;
                            break;
                        default:
                            throw new Exception("Некорректное число");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Некорректно введенные данные!");
                }

            }
        }
    }
}
