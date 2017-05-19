using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Linq;
//using XmlReader.Action;

namespace XmlReader.XmlOptions
{
    public class XmlImportAuto
    {
        public const string sourcePath = "Auto.xml";

        List<Auto> autos = new List<Auto>();
        // класс схемы xml
        public class Auto
        {
            public int id_auto { get; set; }
            public String model { get; set; }
            public String dataV { get; set; }
            public String color { get; set; }
            public int probeg { get; set; }
            public int price { get; set; }
            public String auto { get; set; }
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
        public List<Auto> ParceAuto()
        {
            XElement doc = XElement.Load("Auto.xml");
            IEnumerable<XElement> elements = doc.Elements();

            autos.Clear();
            foreach (XElement el in elements)
            {
                Auto auto = new Auto();

                IEnumerable<XElement> props = el.Elements();
                foreach (XElement p in props)
                {
                    if (p.Name.ToString().ToLower() == "auto")
                    {
                        auto.auto = p.Value;
                    }
                    if (p.Name.ToString().ToLower() == "id_auto")
                    {
                        auto.id_auto = Convert.ToInt32(p.Value);
                    }
                    if (p.Name.ToString().ToLower() == "model")
                    {
                        auto.model = p.Value;
                    }
                    else if (p.Name.ToString().ToLower() == "data_vipuska")
                    {
                        auto.dataV = p.Value;
                    }
                    else if (p.Name.ToString().ToLower() == "color")
                    {
                        auto.color = p.Value;
                    }
                    else if (p.Name.ToString().ToLower() == "probeg")
                    {
                        auto.probeg = Convert.ToInt32(p.Value);
                    }
                    else if (p.Name.ToString().ToLower() == "price")
                    {
                        auto.price = Convert.ToInt32(p.Value);
                    }
                }
                autos.Add(auto);
            }
            return autos;
        }
        // Удаление
        public void DeleteAuto(Auto a)
        {
            XElement doc = XElement.Load("Auto.xml");
            IEnumerable<XElement> elements = doc.Elements();

            XElement update = null;
            autos.Clear();
            foreach (XElement el in elements)
            {
                IEnumerable<XElement> props = el.Elements();
                foreach (XElement p in props)
                {

                    if (p.Name.ToString().ToLower() == "model")
                    {
                        var model = Convert.ToString(p.Value);
                        if (model == a.model)
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

            Console.WriteLine("Введите модель автомобиля");
            var id_auto = 1;
            var model = Console.ReadLine();
            Console.WriteLine("Введите дату выпуска автомобиля");
            var dataV = Console.ReadLine();
            Console.WriteLine("Введите цвет автомобиля");
            var color = Console.ReadLine();
            Console.WriteLine("Введите пробег автомобиля");
            var probeg = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите цену автомобиля");
            var price = int.Parse(Console.ReadLine());
            XDocument xd = XDocument.Load(sourcePath);
            xd.Root.Add(
                           new XElement("auto",
                           new XElement("id_auto", id_auto),
                           new XElement("Model", model),
                           new XElement("Data_vipuska", dataV),
                           new XElement("Color", color),
                           new XElement("Probeg", probeg),
                           new XElement("Price", price)));
            xd.Save(sourcePath);
        }
        // изменение цены 
        public void PriceUpdateAuto(Auto a)
        {
            XElement doc = XElement.Load("Auto.xml");
            IEnumerable<XElement> elements = doc.Elements();

            XElement update = null;
            autos.Clear();
            foreach (XElement el in elements)
            {
                IEnumerable<XElement> props = el.Elements();
                foreach (XElement p in props)
                {

                    if (p.Name.ToString().ToLower() == "model")
                    {
                        var model = Convert.ToString(p.Value);
                        if (model == a.model)
                        {
                            update = el;
                            break;
                        }
                    }

                }
            }
            foreach (var item in update.Elements())
            {

                if (item.Name.LocalName.ToLower() == "price")
                {
                    item.SetValue(a.price);
                    Console.WriteLine("ok");

                }
                doc.Save(sourcePath);
                }
            }
        
        // изменение модели
    public void ModelUpdateAuto(Auto a)
    {
        XElement doc = XElement.Load("Auto.xml");
        IEnumerable<XElement> elements = doc.Elements();

        XElement update = null;
        autos.Clear();
        foreach (XElement el in elements)
        {
            IEnumerable<XElement> props = el.Elements();
            foreach (XElement p in props)
            {

                if (p.Name.ToString().ToLower() == "color")
                {
                    var color = Convert.ToString(p.Value);
                    if (color == a.color)
                    {
                        update = el;
                        break;
                    }
                }

            }
        }
        foreach (var item in update.Elements())
        {

            if (item.Name.LocalName.ToLower() == "model")
            {
                item.SetValue(a.model);
                Console.WriteLine("ok");

            }
            doc.Save(sourcePath);
        }
    }

        public void ColorUpdateAuto(Auto a)
        {
            XElement doc = XElement.Load("Auto.xml");
            IEnumerable<XElement> elements = doc.Elements();

            XElement update = null;
            autos.Clear();
            foreach (XElement el in elements)
            {
                IEnumerable<XElement> props = el.Elements();
                foreach (XElement p in props)
                {

                    if (p.Name.ToString().ToLower() == "model")
                    {
                        var model = Convert.ToString(p.Value);
                        if (model == a.model)
                        {
                            update = el;
                            break;
                        }
                    }

                }
            }
            foreach (var item in update.Elements())
            {

                if (item.Name.LocalName.ToLower() == "color")
                {
                    item.SetValue(a.color);
                    Console.WriteLine("ok");

                }
                doc.Save(sourcePath);
            }
        }


        public void dataUpdateAuto(Auto a)
        {
            XElement doc = XElement.Load("Auto.xml");
            IEnumerable<XElement> elements = doc.Elements();

            XElement update = null;
            autos.Clear();
            foreach (XElement el in elements)
            {
                IEnumerable<XElement> props = el.Elements();
                foreach (XElement p in props)
                {

                    if (p.Name.ToString().ToLower() == "model")
                    {
                        var model = Convert.ToString(p.Value);
                        if (model == a.model)
                        {
                            update = el;
                            break;
                        }
                    }

                }
            }
            foreach (var item in update.Elements())
            {

                if (item.Name.LocalName.ToLower() == "data_vipuska")
                {
                    item.SetValue(a.dataV);
                    Console.WriteLine("ok");

                }
                doc.Save(sourcePath);
            }
        }

        public void ProbegUpdateAuto(Auto a)
        {
            XElement doc = XElement.Load("Auto.xml");
            IEnumerable<XElement> elements = doc.Elements();

            XElement update = null;
            autos.Clear();
            foreach (XElement el in elements)
            {
                IEnumerable<XElement> props = el.Elements();
                foreach (XElement p in props)
                {

                    if (p.Name.ToString().ToLower() == "model")
                    {
                        var model = Convert.ToString(p.Value);
                        if (model == a.model)
                        {
                            update = el;
                            break;
                        }
                    }

                }
            }
            foreach (var item in update.Elements())
            {

                if (item.Name.LocalName.ToLower() == "probeg")
                {
                    item.SetValue(a.probeg);
                    Console.WriteLine("ok");

                }
                doc.Save(sourcePath);
            }
        }
    }
}





