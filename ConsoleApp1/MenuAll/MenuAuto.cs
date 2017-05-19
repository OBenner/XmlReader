using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static XmlReader.XmlOptions.XmlImportAuto;

namespace XmlReader.MenuAll
{
    class MenuAuto
    {
        public static void MAuto()
        {
            bool show = true;
            XmlOptions.XmlImportAuto autom = new XmlOptions.XmlImportAuto();
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

                            autom.ReadFile();
                            break;
                        case 2:
                            autom.AddAuto();
                            break;
                        case 3:
                            Auto a = null;
                            var list = autom.ParceAuto();
                            while (true)
                            {
                                for (int i = 0; i < list.Count; i++)
                                {
                                    Console.WriteLine("№ {0} : \n Модель: {1} Цена: {2} Цвет: {3} Дата Выпуска: {4} Пробег:{5} ", i + 1, list[i].model, list[i].price, list[i].color, list[i].dataV, list[i].probeg);
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
                            Console.WriteLine("Вы выбрали: \n Модель: {0}  Цена: {1}  Цвет: {2}  Дата выпуска: {3}   Пробег: {4}", a.model, a.price, a.color, a.dataV, a.probeg);
                            //

                            bool mUp = true;
                            while (mUp)
                            {

                                Console.WriteLine();
                                Console.WriteLine("Выберите действия с объектом: ");
                                Console.WriteLine("1.посмотреть выбранный объект");
                                Console.WriteLine("2.обновить цену");
                                Console.WriteLine("3.обновить модель автомобиля");
                                Console.WriteLine("4.обновить цвет автомобиля");
                                Console.WriteLine("5.обновить дату выпуска");
                                Console.WriteLine("6.обновить пробег");
                                Console.WriteLine("7. удалить запись");
                                Console.WriteLine("8. Назад");
                                Console.WriteLine();
                                    string x = Console.ReadLine();
                                    int  y = int.Parse(x)  ;     
                                    switch (y)
                                    {

                                    case 1:

                                        Console.WriteLine("Вы выбрали: \n Модель: {0}  Цена: {1}  Цвет: {2}  Дата выпуска: {3}   Пробег: {4}", a.model, a.price, a.color, a.dataV, a.probeg);
                                        break;
                                    case  2:
                                            Console.WriteLine("Введите новую цену автомобиля ");
                                            string _price = Console.ReadLine();
                                            int result;
                                            try
                                            {

                                                if (!int.TryParse(_price, out result))
                                                {
                                                    Console.WriteLine("Не корректные данные");

                                                }
                                        else { 
                                                a.price = result;
                                                autom.PriceUpdateAuto(a);
                                        }
                                    }
                                            catch (Exception e)
                                            {
                                                Console.WriteLine("Не корректные данные, попробуйте еще раз!");
                                                Console.WriteLine();
                                            }
                                            break;

                                        case 3:
                                            Console.WriteLine("Введите новую модель автомобиля ");
                                            string model = Console.ReadLine();
                                            try
                                            {
                                                a.model = model;
                                                autom.ModelUpdateAuto(a);
                                            }
                                            catch (Exception e)
                                            {
                                                Console.WriteLine("Не корректные данные, попробуйте еще раз!");
                                                Console.WriteLine();
                                            }
                                            break;

                                        case 4:
                                            Console.WriteLine("Введите новый цвет автомобиля ");
                                            string _color = Console.ReadLine();
                                            try
                                            {
                                                a.color = _color;
                                                autom.ColorUpdateAuto(a);
                                            }
                                            catch (Exception e)
                                            {
                                                Console.WriteLine("Не корректные данные, попробуйте еще раз!");
                                                Console.WriteLine();
                                            }
                                            break;

                                        case 5:
                                            Console.WriteLine("Введите новую дату выпуска автомобиля ");
                                            string _dataV = Console.ReadLine();
                                            
                                                a.dataV = _dataV;
                                                autom.dataUpdateAuto(a);
                                            
                                            break;
                                           
                                        case 6:
                                            Console.WriteLine("Введите новый пробег автомобиля ");
                                            string _probeg = Console.ReadLine();
                                            int resultProbeg;
                                            try
                                            {

                                                if (!int.TryParse(_probeg, out resultProbeg))
                                                {
                                                    Console.WriteLine("Не корректные данные");

                                                }
                                        else { 
                                                a.probeg = resultProbeg;
                                                autom.ProbegUpdateAuto(a);
                                            }
                                    }
                                    catch (Exception e)
                                            {
                                                Console.WriteLine("Не корректные данные, попробуйте еще раз!");
                                                Console.WriteLine();
                                            }
                                            break;

                                        case 7:
                                            autom.DeleteAuto(a);
                                            break;
                                        case 8:
                                          mUp=false;
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
