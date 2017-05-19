using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static XmlReader.XmlOptions.XmlImportDostup;

namespace XmlReader.MenuAll
{
    class MenuDostup
    {

        public static void MDostup()
        {
            bool show = true;
            XmlOptions.XmlImportDostup dos = new XmlOptions.XmlImportDostup();
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

                            dos.ReadFile();
                            break;
                        case 2:
                            dos.AddDostup();
                            break;
                        case 3:
                            Dospup a = null;
                            var list = dos.ParceDostup();
                            while (true)
                            {
                                for (int i = 0; i < list.Count; i++)
                                {
                                    Console.WriteLine("№ {0} : \n id автомобиля : {1}  доступность автомобиля: {2}  ", i + 1, list[i].auto, list[i].free);
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
                            Console.WriteLine("Вы выбрали: \n id автомобиля : {0}  доступность автомобиля: {1} ", a.auto, a.free);
                            //

                            bool mUp = true;
                            while (mUp)
                            {

                                Console.WriteLine();
                                Console.WriteLine("Выберите действия с объектом: ");
                                Console.WriteLine("1.посмотреть выбранный объект");
                                Console.WriteLine("2.обновить id автомбиля");
                                Console.WriteLine("3.обновить доступность автомобиля (да/нет)");
                                Console.WriteLine("4. удалить запись");
                                Console.WriteLine("5. Назад");
                                Console.WriteLine();
                                string x = Console.ReadLine();
                                int y = int.Parse(x);
                                switch (y)
                                {

                                    case 1:
                                        Console.WriteLine("Вы выбрали: \n id автомобиля : {0}  доступность автомобиля: {1} ", a.auto, a.free);
                                        break;

                                    case 2:
                                        Console.WriteLine("Введите новый id автомбиля ");
                                        string _id = Console.ReadLine();
                                        int resultid;
                                        try
                                        {

                                            if (!int.TryParse(_id, out resultid))
                                            {
                                                Console.WriteLine("Не корректные данные");

                                            }
                                            else
                                            {
                                                a.auto = resultid;
                                                dos.AutoUpdateDostup(a);
                                            }
                                        }
                                        catch (Exception e)
                                        {
                                            Console.WriteLine("Не корректные данные, попробуйте еще раз!");
                                            Console.WriteLine();
                                        }
                                        break;

                                    case 3:
                                        Console.WriteLine("Введите новые данные по доступности автомобиля (да/нет)");
                                        string _fr = Console.ReadLine();
                                        try
                                        {
                                            a.free = _fr;
                                            dos.FreeUpdateDostup(a);
                                        }
                                        catch (Exception e)
                                        {
                                            Console.WriteLine("Не корректные данные, попробуйте еще раз!");
                                          //  Console.WriteLine(e.StackTrace);
                                        }
                                        break;
                                    case 4:
                                        dos.DeleteDostup(a);
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
                  //  Console.WriteLine(e.StackTrace);
                    Console.WriteLine("Некорректно введенные данные!");
                }

            }
        }
    }
}

   