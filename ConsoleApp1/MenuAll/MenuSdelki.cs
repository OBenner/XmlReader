using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static XmlReader.XmlOptions.XmlImportSdelki;

namespace XmlReader.MenuAll
{
    class MenuSdelki
    {
        public static void MSdelki()
        {
            bool show = true;
            XmlOptions.XmlImportSdelki sd = new XmlOptions.XmlImportSdelki();
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

                            sd.ReadFile();
                            break;
                        case 2:
                            sd.AddAuto();
                            break;
                        case 3:
                            Sdelki a = null;
                            var list = sd.ParceSdelki();
                            while (true)
                            {
                                for (int i = 0; i < list.Count; i++)
                                {
                                    Console.WriteLine("№ {0} : \n Дата выдачи : {1} Дата сдачи : {2} id используемого автомобиля: {3} id клиента использующего: {4} Доступность автомобиля:{5} ",
                                        i + 1, list[i].data_vidachi, list[i].data_sdachi, list[i].auto, list[i].client, list[i].free);
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
                            Console.WriteLine("Вы выбрали: \n Дата выдачи : {0} Дата сдачи : {1} id используемого автомобиля: {2} id клиента использующего: {3} Доступность автомобиля:{4}", 
                                        a.data_vidachi, a.data_sdachi, a.auto, a.client, a.free);
                            //

                            bool mUp = true;
                            while (mUp)
                            {

                                Console.WriteLine();
                                Console.WriteLine("Выберите действия с объектом: ");
                                Console.WriteLine("1.посмотреть выбранный объект");
                                Console.WriteLine("2.обновить дату выдачи автомобиля");
                                Console.WriteLine("3.обновить дату сдачи автомобиля");
                                Console.WriteLine("4.обновить id используемого автомобиля");
                                Console.WriteLine("5.обновить id клиента, используещего автомобиль");
                                Console.WriteLine("6.обновить доступность автомобиля");
                                Console.WriteLine("7. удалить запись");
                                Console.WriteLine("8. Назад");
                                Console.WriteLine();
                                string x = Console.ReadLine();
                                int y = int.Parse(x);
                                switch (y)
                                {

                                    case 1:

                                        Console.WriteLine("Вы выбрали: \n Дата выдачи : {0} Дата сдачи : {1} id используемого автомобиля: {2} id клиента использующего автомобиль: {3} Доступность автомобиля:{4}",
                                        a.data_vidachi, a.data_sdachi, a.auto, a.client, a.free);
                                        //
                                        break;
                                    case 2:
                                        Console.WriteLine("Введите новую дату выдачи автомобиля автомобиля ");
                                        string dd = Console.ReadLine();
                                        
                                        try
                                        {
                                            a.data_vidachi = dd;
                                            sd.DataVUpdateSdelki(a);
                                        }
                                        catch (Exception e)
                                        {
                                            Console.WriteLine("Не корректные данные, попробуйте еще раз!");
                                            Console.WriteLine();
                                        }
                                        break;

                                    case 3:
                                        Console.WriteLine("Введите новую дату сдачи автомобиля ");
                                        string dds = Console.ReadLine();
                                        try
                                        {
                                            a.data_sdachi = dds;
                                            sd.DataSUpdateSdelki(a);
                                        }
                                        catch (Exception e)
                                        {
                                            Console.WriteLine("Не корректные данные, попробуйте еще раз!");
                                            Console.WriteLine();
                                        }
                                        break;

                                    case 4:
                                       
                                        Console.WriteLine("Введите новый id используемого автомобиля ");
                                        string _id = Console.ReadLine();
                                        int resultProbeg;
                                        try
                                        {

                                            if (!int.TryParse(_id, out resultProbeg))
                                            {
                                                Console.WriteLine("Не корректные данные");

                                            }
                                            else
                                            {
                                                a.auto = resultProbeg;
                                                sd.AutoUpdateSdelki(a);
                                            }
                                        }
                                        catch (Exception e)
                                        {
                                            Console.WriteLine("Не корректные данные, попробуйте еще раз!");
                                            Console.WriteLine();
                                        }
                                        break;
                                    case 5:
                                        Console.WriteLine("Введите новый id клиента использующего автомобиль");
                                        string ic = Console.ReadLine();
                                        int res;
                                        try
                                        {

                                            if (!int.TryParse(ic, out res))
                                            {
                                                Console.WriteLine("Не корректные данные");

                                            }
                                            else
                                            {
                                                a.client = res;
                                                sd.ClientlUpdateSdelki(a);
                                            }
                                        }
                                        catch (Exception e)
                                        {
                                            Console.WriteLine("Не корректные данные, попробуйте еще раз!");
                                            Console.WriteLine();
                                        }
                                        break;
                                    case 6:
                                        Console.WriteLine("Введите сведение о доступности автомобиля (да/нет) ");
                                        string ds = Console.ReadLine();

                                        a.free = ds;
                                        sd.FreeUpdateAuto(a);

                                        break;

                                   

                                    case 7:
                                        sd.DeleteSdelka(a);
                                        break;
                                    case 8:
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

 