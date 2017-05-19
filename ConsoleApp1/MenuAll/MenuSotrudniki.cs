using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static XmlReader.XmlOptions.XmlImportSotrudniki;

namespace XmlReader.MenuAll
{
    class MenuSotrudniki
    {

        public static void MSotrudnik()
        {
            bool show = true;
            XmlOptions.XmlImportSotrudniki sot = new XmlOptions.XmlImportSotrudniki();
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

                            sot.ReadFile();
                            break;
                        case 2:
                            sot.AddSotrudnik();
                            break;
                        case 3:
                            Sotrudniki a = null;
                            var list = sot.ParceSotrudniki();
                            while (true)
                            {
                                for (int i = 0; i < list.Count; i++)
                                {
                                    Console.WriteLine("№ {0} : \n ФИО: {1}  Должность: {2}  Дата приема на работу: {3} ", i + 1, list[i].fio, list[i].doljnost, list[i].data_priema);
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
                            Console.WriteLine("Вы выбрали: \n ФИО: {0}  Должность: {1}  Дата приема на работу: {2}", a.fio, a.doljnost,a.data_priema);
                            //

                            bool mUp = true;
                            while (mUp)
                            {

                                Console.WriteLine();
                                Console.WriteLine("Выберите действия с объектом: ");
                                Console.WriteLine("1. посмотреть выбранный объект");
                                Console.WriteLine("2. обновить ФИО");
                                Console.WriteLine("3. обновить должность сотрудника ");
                                Console.WriteLine("4. обновить дату приема сотрудника на работу ");
                                Console.WriteLine("5. удалить запись");
                                Console.WriteLine("6. Назад");
                                Console.WriteLine();
                                string x = Console.ReadLine();
                                int y = int.Parse(x);
                                switch (y)
                                {

                                    case 1:

                                        Console.WriteLine("Вы выбрали: \n ФИО: {0}  Должность: {1}  Дата приема на работу: {2}", a.fio, a.doljnost, a.data_priema);
                                        break;

                                    case 2:
                                        Console.WriteLine();
                                        Console.WriteLine("Введите новые ФИО ");
                                        string fio = Console.ReadLine();
                                        try
                                        {
                                            a.fio = fio;
                                            sot.FioUpdateSotrudnik(a);
                                        }
                                        catch (Exception e)
                                        {
                                            Console.WriteLine("Не корректные данные, попробуйте еще раз!");
                                            Console.WriteLine();
                                        }
                                        break;

                                    case 3:
                                        Console.WriteLine();
                                        Console.WriteLine("Введите новую должность сотрудника: ");
                                        Console.WriteLine();
                                        string _dol = Console.ReadLine();
                                        try
                                        {
                                            a.doljnost = _dol;
                                            sot.DoljnostUpdateSotrudnik(a);
                                        }
                                        catch (Exception e)
                                        {
                                            Console.WriteLine("Не корректные данные, попробуйте еще раз!");
                                            Console.WriteLine();
                                        }
                                        break;


                                    case 4:
                                        Console.WriteLine();
                                        Console.WriteLine("Введите новую дату приема сотрудника на работу сотрудника: ");
                                        Console.WriteLine();
                                        string dat = Console.ReadLine();
                                        try
                                        {
                                            a.data_priema = dat;
                                            sot.DatalUpdateSotrudnik(a);
                                        }
                                        catch (Exception e)
                                        {
                                            Console.WriteLine("Не корректные данные, попробуйте еще раз!");
                                            Console.WriteLine();
                                        }
                                        break;

                                    case 5:
                                        sot.DeleteSotrudnik(a);
                                        break;
                                    case 6:
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

 