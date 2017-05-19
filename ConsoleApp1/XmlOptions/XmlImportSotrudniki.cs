using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace XmlReader.XmlOptions
{
    class XmlImportSotrudniki
    {
        public const string sourcePath = "Sotrudniki.xml";

        List<Sotrudniki> sotrudniki = new List<Sotrudniki>();
        // класс схемы xml
        public class Sotrudniki
        {
            public int id_sotr { get; set; }
            public String fio { get; set; }
            public String data_priema { get; set; }
            public String doljnost { get; set; }
            public String sotrudnik { get; set; }
        }



        // Чтение файла
        public void ReadFile()
        {

            XDocument doc = XDocument.Load(sourcePath);
            foreach (XElement el in doc.Root.Elements())
            {
                foreach (XElement element in el.Elements())
                    Console.WriteLine("    {0}: {1} ", element.Name, element.Value);
            }
        }
        //метод разбора файл и сохранения в  List<Sotrudniki> sotrudniki
        public List<Sotrudniki> ParceSotrudniki()
        {
            XElement doc1 = XElement.Load("Sotrudniki.xml");
            IEnumerable<XElement> elements = doc1.Elements();

            sotrudniki.Clear();
            foreach (XElement el in elements)
            {
                Sotrudniki s = new Sotrudniki();

                IEnumerable<XElement> props = el.Elements();
                foreach (XElement p in props)
                {
                    if (p.Name.ToString().ToLower() == "sotrudnik")
                    {
                        s.sotrudnik = p.Value;
                    }
                    else if (p.Name.ToString().ToLower() == "id_sotr")
                    {
                        s.id_sotr = Convert.ToInt32(p.Value);
                    }
                   else if (p.Name.ToString().ToLower() == "fio")
                    {
                        s.fio = p.Value;
                    }
                    else if (p.Name.ToString().ToLower() == "data_priema")
                    {
                        s.data_priema = p.Value;
                    }
                    else if (p.Name.ToString().ToLower() == "doljnost")
                    {
                        s.doljnost = p.Value;
                    }
                }
                sotrudniki.Add(s);
            }
            return sotrudniki;
        }


        // Удаление сотрудника
        public void DeleteSotrudnik(Sotrudniki a)
        {
            XElement doc = XElement.Load("Sotrudniki.xml");
            IEnumerable<XElement> elements = doc.Elements();

            XElement update = null;
            sotrudniki.Clear();
            foreach (XElement el in elements)
            {
                IEnumerable<XElement> props = el.Elements();
                foreach (XElement p in props)
                {

                    if (p.Name.ToString().ToLower() == "fio")
                    {
                        var fio = Convert.ToString(p.Value);
                        if (fio == a.fio)
                        {
                            update = el;
                            break;

                        }
                    }

                }
            }
            update.Remove();
            Console.WriteLine("Элемент удален.");
            doc.Save(sourcePath);
        }


        // Добавление нового сотрудника
        public void AddSotrudnik()
        {
            var id_sotr = 1;
            Console.WriteLine("Введите ФИО сотрудника");
            var fio = Console.ReadLine();
            Console.WriteLine("Введите дату приема сотрудника");
            var data_priema = Console.ReadLine();
            Console.WriteLine("Введите должность сотрудника");
            var doljnost = Console.ReadLine();
            XDocument xd = XDocument.Load(sourcePath);
            xd.Root.Add(
                           new XElement("sotrudnik",
                           new XElement("id_sotr", id_sotr),
                           new XElement("FIO", fio),
                           new XElement("Data_priema", data_priema),
                           new XElement("Doljnost", doljnost)));
            xd.Save(sourcePath);
        }


        // изменение ФИО  сотрудника
        public void FioUpdateSotrudnik(Sotrudniki a)
        {
            XElement doc = XElement.Load("Sotrudniki.xml");
            IEnumerable<XElement> elements = doc.Elements();

            XElement update = null;
            sotrudniki.Clear();
            foreach (XElement el in elements)
            {
                IEnumerable<XElement> props = el.Elements();
                foreach (XElement p in props)
                {

                    if (p.Name.ToString().ToLower() == "doljnost")
                    {
                        var doljnost = Convert.ToString(p.Value);
                        if (doljnost == a.doljnost)
                        {
                            update = el;
                            break;
                        }
                    }

                }
            }
            foreach (var item in update.Elements())
            {

                if (item.Name.LocalName.ToLower() == "fio")
                {
                    item.SetValue(a.fio);
                    Console.WriteLine("ok");

                }
                doc.Save(sourcePath);
            }
        }


        // изменение Даты приема сотрудника
        public void DatalUpdateSotrudnik(Sotrudniki a)
        {
            XElement doc = XElement.Load("Sotrudniki.xml");
            IEnumerable<XElement> elements = doc.Elements();

            XElement update = null;
            sotrudniki.Clear();
            foreach (XElement el in elements)
            {
                IEnumerable<XElement> props = el.Elements();
                foreach (XElement p in props)
                {

                    if (p.Name.ToString().ToLower() == "fio")
                    {
                        var fio = Convert.ToString(p.Value);
                        if (fio == a.fio)
                        {
                            update = el;
                            break;
                        }
                    }

                }
            }
            foreach (var item in update.Elements())
            {

                if (item.Name.LocalName.ToLower() == "data_priema")
                {
                    item.SetValue(a.data_priema);
                    Console.WriteLine("ok");

                }
                doc.Save(sourcePath);
            }
        }


        // изменение Должности  сотрудника
        public void DoljnostUpdateSotrudnik(Sotrudniki a)
        {
            XElement doc = XElement.Load("Sotrudniki.xml");
            IEnumerable<XElement> elements = doc.Elements();

            XElement update = null;
            sotrudniki.Clear();
            foreach (XElement el in elements)
            {
                IEnumerable<XElement> props = el.Elements();
                foreach (XElement p in props)
                {

                    if (p.Name.ToString().ToLower() == "fio")
                    {
                        var fio = Convert.ToString(p.Value);
                        if (fio == a.fio)
                        {
                            update = el;
                            break;
                        }
                    }

                }
            }
            foreach (var item in update.Elements())
            {

                if (item.Name.LocalName.ToLower() == "doljnost")
                {
                    item.SetValue(a.doljnost);
                    Console.WriteLine("ok");

                }
                doc.Save(sourcePath);
            }
        }



    }
}
    

    