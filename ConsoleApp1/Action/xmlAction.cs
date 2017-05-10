using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Action
{
    class xmlAction
    {
        /// <summary>
        /// Родитель для используемых элементов
        /// </summary>
        public class DbElement
        {

            public static Dictionary<string, List<DbElement>> instanceList = new Dictionary<string, List<DbElement>>();                   // Список загруженных элементов
            public static Dictionary<string, Dictionary<string, string>> option = new Dictionary<string, Dictionary<string, string>>();   // Набор свойств объекта

            public Dictionary<string, string> optionsValue = new Dictionary<string, string>();        // Значение параметров

            // списки операций
            public static Dictionary<string, List<DbElement>> insertOper = new Dictionary<string, List<DbElement>>();
            public static Dictionary<string, List<DbElement>> updateOper = new Dictionary<string, List<DbElement>>();
            public static Dictionary<string, List<DbElement>> deleteOper = new Dictionary<string, List<DbElement>>();

            /// <summary>
            /// Печать объекта
            /// </summary>
            public void Print()
            {
                string info = "";
                foreach (var elem in optionsValue.Keys)
                {
                    info += elem + ": " + optionsValue[elem] + " ";
                }
                Console.WriteLine(info);
            }

            string typeObject;                                                          // Название объекта

            public bool isInsert;                           // Флаг добавления
            public bool isUpdate;                           // Флаг обновления
            public bool isDelete;                           // Флаг удаления

            /// <summary>
            /// Меню работы с объектом
            /// </summary>
            /// <param name="typeObject">Название объекта</param>
            public void Menu(string typeObject)
            {
                this.typeObject = typeObject;
                bool show = true;
                while (show)
                {
                    Console.WriteLine("Выберите действия с объектов: ");
                    Console.WriteLine("1. Получить список объектов");
                    Console.WriteLine("2. Добавить объект");
                    Console.WriteLine("3. Изменить объект");
                    Console.WriteLine("4. Удалить объект");
                    Console.WriteLine("5. Назад");

                    try
                    {
                        string answer = Console.ReadLine();
                        int resultOut;

                        if (!int.TryParse(answer, out resultOut))
                            throw new Exception("Не корректные данные");

                        switch (resultOut)
                        {
                            case 1:
                                ShowAll();
                                break;
                            case 2:
                                InsertMenu();
                                break;
                            case 3:
                                UpdateMenu();
                                break;
                            case 4:
                                DeleteMenu();
                                break;
                            case 5:
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
            /// <summary>
            /// Вывод всех данных по объекту
            /// </summary>
            public void ShowAll()
            {
                List<DbElement> elementList = instanceList[this.typeObject];

                foreach (var elem in elementList)
                {
                    elem.Print();
                }

            }
            /// <summary>
            /// Меню обновления записи
            /// </summary>
            public void UpdateMenu()
            {
                bool show = true;
                while (show)
                {
                    Console.WriteLine("Введите номер элемента для изменения или введите (назад) для возврата в предыдущее меню:");

                    try
                    {
                        string answer = Console.ReadLine();
                        int resultOut;

                        if (answer.Contains("назад"))
                        {
                            show = false;
                            break;
                        }

                        if (!int.TryParse(answer, out resultOut))
                            throw new Exception("Не корректные данные");

                        DbElement useElement = DbElement.instanceList[typeObject].Find(x => x.optionsValue["id"] == resultOut.ToString());

                        InsertMenu(useElement);

                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Некорректно введенные данные!");
                    }
                }

            }
            /// <summary>
            /// Меню удаления записи
            /// </summary>
            public void DeleteMenu()
            {
                bool show = true;
                while (show)
                {
                    Console.WriteLine("Введите номер элемента для удаления или введите (назад) для возврата в предыдущее меню:");

                    try
                    {
                        string answer = Console.ReadLine();
                        int resultOut;

                        if (answer.Contains("назад"))
                        {
                            show = false;
                            break;
                        }

                        if (!int.TryParse(answer, out resultOut))
                            throw new Exception("Не корректные данные");

                        if (!deleteOper.ContainsKey(typeObject))
                            deleteOper.Add(typeObject, new List<DbElement>());

                        deleteOper[typeObject].Add(DbElement.instanceList[this.typeObject].Find(x => x.optionsValue.ContainsKey("id") && x.optionsValue["id"] == resultOut.ToString()));
                        DeleteElement(resultOut);

                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Некорректно введенные данные!");
                    }
                }

            }
            /// <summary>
            /// Операция добавления / удаления
            /// </summary>
            /// <param name="activeElementEdit"></param>
            public void InsertMenu(DbElement activeElementEdit = null)
            {

                if (activeElementEdit == null)
                    activeElementEdit = new DbElement();

                bool isInsert = activeElementEdit.optionsValue.Count == 0;

                if (isInsert)
                {
                    Console.WriteLine("Создание новой должности");
                }
                else
                {
                    Console.WriteLine("Изменение элемента");
                }

                Dictionary<string, string> optionList = DbElement.option[typeObject];

                foreach (var oneElement in optionList.Keys)
                {

                    if (oneElement == "id") continue;

                    Console.WriteLine(String.Format("Введите значение поля {0} типа {1} {2}", oneElement, optionList[oneElement], (!isInsert ? "старое значение " + activeElementEdit.optionsValue[oneElement].ToString() : "")));

                    string answer = Console.ReadLine();
                    if (answer.Length == 0) continue;

                    if (activeElementEdit.optionsValue.ContainsKey(oneElement))
                        activeElementEdit.optionsValue.Remove(oneElement);

                    activeElementEdit.optionsValue.Add(oneElement, answer);

                }

                if (isInsert)
                {
                    if (!insertOper.ContainsKey(typeObject))
                        insertOper.Add(typeObject, new List<DbElement>());

                    insertOper[typeObject].Add(activeElementEdit);
                    DbElement.instanceList[typeObject].Add(activeElementEdit);
                }
                else
                {
                    if (!updateOper.ContainsKey(typeObject))
                        updateOper.Add(typeObject, new List<DbElement>());

                    if (!updateOper[typeObject].Contains(activeElementEdit))
                        updateOper[typeObject].Add(activeElementEdit);
                }

            }
            /// <summary>
            /// Удание элемента
            /// </summary>
            /// <param name="number">Номер элемента</param>
            private void DeleteElement(int number)
            {
                DbElement.instanceList[this.typeObject].RemoveAll(x => x.optionsValue.ContainsKey("id") && x.optionsValue["id"] == number.ToString());
            }
            /// <summary>
            /// Удание элемента
            /// </summary>
            /// <param name="number">Номер элемента</param>
            private void DeleteElement(string number)
            {
                DbElement.instanceList[this.typeObject].RemoveAll(x => x.optionsValue.ContainsKey("id") && x.optionsValue["id"] == number);
            }

        }

    }
}
