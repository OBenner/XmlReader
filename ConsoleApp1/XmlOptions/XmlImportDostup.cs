using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace XmlReader.XmlOptions
{
   public class XmlImportDostup { 
    public const string sourcePath = "Dostup.xml";

    List<Dospup> dostup = new List<Dospup>();
    // класс схемы xml
    public class Dospup
        {
            public int nomer { get; set; }
            public int auto { get; set; }
            public String free { get; set; }
            public String dostup_auto { get; set; }
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
    public List<Dospup> ParceDostup()
    {
        XElement doc1 = XElement.Load("Dostup.xml");
        IEnumerable<XElement> elements = doc1.Elements();

        dostup.Clear();
        foreach (XElement el in elements)
        {
            Dospup d = new Dospup();

            IEnumerable<XElement> props = el.Elements();
            foreach (XElement p in props)
            {
                if (p.Name.ToString().ToLower() == "dostup_auto")
                {
                    d.dostup_auto = p.Value;
                }
                if (p.Name.ToString().ToLower() == "nomer")
                {
                    d.nomer = Convert.ToInt32(p.Value);
                }
                    if (p.Name.ToString().ToLower() == "auto")
                    {
                        d.auto = Convert.ToInt32(p.Value);
                    }
                    else if (p.Name.ToString().ToLower() == "free")
                {
                    d.free = p.Value;
                }
            }
            dostup.Add(d);
        }
        return dostup;
    }
    // Удаление
    public void DeleteDostup(Dospup a)
    {
        XElement doc = XElement.Load("Dostup.xml");
        IEnumerable<XElement> elements = doc.Elements();

        XElement update = null;
        dostup.Clear();
        foreach (XElement el in elements)
        {
            IEnumerable<XElement> props = el.Elements();
            foreach (XElement p in props)
            {

                if (p.Name.ToString().ToLower() == "free")
                {
                    var free = Convert.ToString(p.Value);
                    if (free == a.free)
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
    public void AddDostup()
    {
        var nomer = 1;
        Console.WriteLine("Введите номер автомобиля(id) ");
        var auto = Console.ReadLine();
        Console.WriteLine("Введите значение доступности автомобиля (да/нет)");
        var free = Console.ReadLine();
        XDocument xd = XDocument.Load(sourcePath);
        xd.Root.Add(
                       new XElement("dostup_auto",
                       new XElement("Nomer", nomer),
                       new XElement("Auto", auto),
                       new XElement("Free", free)));
        xd.Save(sourcePath);
            Console.WriteLine("Данные добавлены");
    }
    // изменение автомобиля 
    public void AutoUpdateDostup(Dospup a)
    {
        XElement doc = XElement.Load("Dostup.xml");
        IEnumerable<XElement> elements = doc.Elements();

        XElement update = null;
        dostup.Clear();
        foreach (XElement el in elements)
        {
            IEnumerable<XElement> props = el.Elements();
            foreach (XElement p in props)
            {

                if (p.Name.ToString().ToLower() == "free")
                {
                    var free = Convert.ToString(p.Value);
                    if (free == a.free)
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

    // изменение доступности автомобиля
    public void FreeUpdateDostup(Dospup a)
    {
        XElement doc = XElement.Load("Dostup.xml");
        IEnumerable<XElement> elements = doc.Elements();

        XElement update = null;
        dostup.Clear();
        foreach (XElement el in elements)
        {
            IEnumerable<XElement> props = el.Elements();
            foreach (XElement p in props)
            {

                if (p.Name.ToString().ToLower() == "auto")
                {
                    var auto = Convert.ToInt16(p.Value);
                    if (auto == a.auto)
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
    

