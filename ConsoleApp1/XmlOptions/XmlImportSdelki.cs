using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ConsoleApp1.XmlOptions
{
    class XmlImportSdelki
    {

        public const string sourcePath = "Sdelki.xml";

        List<Sdelki> sdelki = new List<Sdelki>();
        // класс схемы xml
        public class Sdelki
        {
            public int nomer { get; set; }
            public String data_vidachi { get; set; }
            public String data_sdachi { get; set; }
            public int client { get; set; }
            public int auto { get; set; }
            public int vidal { get; set; }
            public String free { get; set; }
            public String sdelka { get; set; }
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
        //метод разбора файл и сохранения в  List<Auto> autos
        public List<Sdelki> ParceSdelki()
        {
            XElement doc = XElement.Load("Sdelki.xml");
            IEnumerable<XElement> elements = doc.Elements();

            sdelki.Clear();
            foreach (XElement el in elements)
            {
                Sdelki s = new Sdelki();

                IEnumerable<XElement> props = el.Elements();
                foreach (XElement p in props)
                {
                    if (p.Name.ToString().ToLower() == "sdelka")
                    {
                        s.sdelka = p.Value;
                    }
                    if (p.Name.ToString().ToLower() == "nomer")
                    {
                        s.nomer = Convert.ToInt32(p.Value);
                    }
                    if (p.Name.ToString().ToLower() == "data_vidachi")
                    {
                        s.data_vidachi = p.Value;
                    }
                    else if (p.Name.ToString().ToLower() == "data_sdachi")
                    {
                        s.data_sdachi = p.Value;
                    }
                    else if (p.Name.ToString().ToLower() == "client")
                    {
                        s.client = Convert.ToInt32(p.Value);
                    }
                    else if (p.Name.ToString().ToLower() == "auto")
                    {
                        s.auto = Convert.ToInt32(p.Value);
                    }         
                    else if (p.Name.ToString().ToLower() == "vidal")
                    {
                        s.vidal = Convert.ToInt32(p.Value);
                    }
                    else if (p.Name.ToString().ToLower() == "free")
                    {
                        s.free = p.Value;
                    }
                }
                sdelki.Add(s);
            }
            return sdelki;
        }
        // Удаление
        public void DeleteSdelka(Sdelki a)
        {
            XElement doc = XElement.Load("Sdelki.xml");
            IEnumerable<XElement> elements = doc.Elements();

            XElement update = null;
            sdelki.Clear();
            foreach (XElement el in elements)
            {
                IEnumerable<XElement> props = el.Elements();
                foreach (XElement p in props)
                {

                    if (p.Name.ToString().ToLower() == "data_vidachi")
                    {
                        var data_vidachi = Convert.ToString(p.Value);
                        if (data_vidachi == a.data_vidachi)
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


        // Добавление нового
        public void AddAuto()
        {
            var nomer = 1;
            Console.WriteLine("Введите дату выдачи автомобиля");
            var data_vidachi = Console.ReadLine();
            Console.WriteLine("Введите дату сдачи автомобиля");
            var data_sdachi = Console.ReadLine();
            Console.WriteLine("Введите номер(id) клиента автомобиля");
            var client = Console.ReadLine();
            Console.WriteLine("Введите номер(id) автомобиля");
            var auto = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите номер(id) менеджера, выдавшего автомобиль");
            var vidal = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите даступность (да/нет) автомобиля");
            var free = Console.ReadLine();
            XDocument xd = XDocument.Load(sourcePath);
            xd.Root.Add(
                           new XElement("sdelka",
                           new XElement("nomer", nomer),
                           new XElement("data_vidachi", data_vidachi),
                           new XElement("data_sdachi", data_sdachi),
                           new XElement("client", client),
                           new XElement("auto", auto),
                           new XElement("vidal", vidal),
                           new XElement("free", free)));
            xd.Save(sourcePath);
        }
        // изменение даты выдачи автомобиля 
        public void DataVUpdateSdelki(Sdelki a)
        {
            XElement doc = XElement.Load("Sdelki.xml");
            IEnumerable<XElement> elements = doc.Elements();

            XElement update = null;
            sdelki.Clear();
            foreach (XElement el in elements)
            {
                IEnumerable<XElement> props = el.Elements();
                foreach (XElement p in props)
                {

                    if (p.Name.ToString().ToLower() == "data_sdachi")
                    {
                        var data_sdachi = Convert.ToString(p.Value);
                        if (data_sdachi == a.data_sdachi)
                        {
                            update = el;
                            break;
                        }
                    }

                }
            }
            foreach (var item in update.Elements())
            {

                if (item.Name.LocalName.ToLower() == "data_vidachi")
                {
                    item.SetValue(a.data_vidachi);
                    Console.WriteLine("ok");

                }
                doc.Save(sourcePath);
            }
        }


        // изменение даты сдачи автомобиля 
        public void DataSUpdateSdelki(Sdelki a)
        {
            XElement doc = XElement.Load("Sdelki.xml");
            IEnumerable<XElement> elements = doc.Elements();

            XElement update = null;
            sdelki.Clear();
            foreach (XElement el in elements)
            {
                IEnumerable<XElement> props = el.Elements();
                foreach (XElement p in props)
                {

                    if (p.Name.ToString().ToLower() == "data_vidachi")
                    {
                        var data_vidachi = Convert.ToString(p.Value);
                        if (data_vidachi == a.data_vidachi)
                        {
                            update = el;
                            break;
                        }
                    }

                }
            }
            foreach (var item in update.Elements())
            {

                if (item.Name.LocalName.ToLower() == "data_sdachi")
                {
                    item.SetValue(a.data_sdachi);
                    Console.WriteLine("ok");

                }
                doc.Save(sourcePath);
            }
        }


        // изменение клиента автомобиля 
        public void ClientlUpdateSdelki(Sdelki a)
        {
            XElement doc = XElement.Load("Sdelki.xml");
            IEnumerable<XElement> elements = doc.Elements();

            XElement update = null;
            sdelki.Clear();
            foreach (XElement el in elements)
            {
                IEnumerable<XElement> props = el.Elements();
                foreach (XElement p in props)
                {

                    if (p.Name.ToString().ToLower() == "data_vidachi")
                    {
                        var data_vidachi = Convert.ToString(p.Value);
                        if (data_vidachi == a.data_vidachi)
                        {
                            update = el;
                            break;
                        }
                    }

                }
            }
            foreach (var item in update.Elements())
            {

                if (item.Name.LocalName.ToLower() == "client")
                {
                    item.SetValue(a.client);
                    Console.WriteLine("ok");

                }
                doc.Save(sourcePath);
            }
        }


        // изменение  автомобиля в сделке 
        public void AutoUpdateSdelki(Sdelki a)
        {
            XElement doc = XElement.Load("Sdelki.xml");
            IEnumerable<XElement> elements = doc.Elements();

            XElement update = null;
            sdelki.Clear();
            foreach (XElement el in elements)
            {
                IEnumerable<XElement> props = el.Elements();
                foreach (XElement p in props)
                {

                    if (p.Name.ToString().ToLower() == "data_vidachi")
                    {
                        var data_vidachi = Convert.ToString(p.Value);
                        if (data_vidachi == a.data_vidachi)
                        {
                            update = el;
                            break;
                        }
                    }

                }
            }
            foreach (var item in update.Elements())
            {

                if (item.Name.LocalName.ToLower() == "auto")
                {
                    item.SetValue(a.auto);
                    Console.WriteLine("ok");

                }
                doc.Save(sourcePath);
            }
        }


        // изменение менеджера, выдавшего автомобиль 
        public void VidalUpdateAuto(Sdelki a)
        {
            XElement doc = XElement.Load("Sdelki.xml");
            IEnumerable<XElement> elements = doc.Elements();

            XElement update = null;
            sdelki.Clear();
            foreach (XElement el in elements)
            {
                IEnumerable<XElement> props = el.Elements();
                foreach (XElement p in props)
                {

                    if (p.Name.ToString().ToLower() == "data_vidachi")
                    {
                        var data_vidachi = Convert.ToString(p.Value);
                        if (data_vidachi == a.data_vidachi)
                        {
                            update = el;
                            break;
                        }
                    }

                }
            }
            foreach (var item in update.Elements())
            {

                if (item.Name.LocalName.ToLower() == "vidal")
                {
                    item.SetValue(a.vidal);
                    Console.WriteLine("ok");

                }
                doc.Save(sourcePath);
            }
        }


        // изменение доступности автомобиля 
        public void FreeUpdateAuto(Sdelki a)
        {
            XElement doc = XElement.Load("Sdelki.xml");
            IEnumerable<XElement> elements = doc.Elements();

            XElement update = null;
            sdelki.Clear();
            foreach (XElement el in elements)
            {
                IEnumerable<XElement> props = el.Elements();
                foreach (XElement p in props)
                {

                    if (p.Name.ToString().ToLower() == "data_vidachi")
                    {
                        var data_vidachi = Convert.ToString(p.Value);
                        if (data_vidachi == a.data_vidachi)
                        {
                            update = el;
                            break;
                        }
                    }

                }
            }
            foreach (var item in update.Elements())
            {

                if (item.Name.LocalName.ToLower() == "free")
                {
                    item.SetValue(a.free);
                    Console.WriteLine("ok");

                }
                doc.Save(sourcePath);
            }
        }
    }
}


 