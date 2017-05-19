using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace XmlReader.XmlOptions
{
   
        public class XmlImportClients
        {
            public const string sourcePath = "Clients.xml";

            List<Clients> clients = new List<Clients>();
            // класс схемы xml
            public class Clients
            {
            public int id_client { get; set; }
            public String fio { get; set; }
            public String document { get; set; }
            public String client { get; set; }
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
            public List<Clients> ParceClients()
            {
                XElement doc1 = XElement.Load("Clients.xml");
                IEnumerable<XElement> elements = doc1.Elements();

                clients.Clear();
                foreach (XElement el in elements)
                {
                    Clients c = new Clients();

                    IEnumerable<XElement> props = el.Elements();
                    foreach (XElement p in props)
                    {
                        if (p.Name.ToString().ToLower() == "client")
                        {
                        c.client = p.Value;
                        }
                        if (p.Name.ToString().ToLower() == "id_client")
                        {
                        c.id_client = Convert.ToInt32(p.Value);
                        }
                        if (p.Name.ToString().ToLower() == "fio")
                        {
                            c.fio = p.Value;
                        }
                        else if (p.Name.ToString().ToLower() == "document")
                        {
                            c.document = p.Value;
                        }                   
                    }
                    clients.Add(c);
                }
                return clients;
            }
            // Удаление
            public void DeleteClient(Clients a)
            {
                XElement doc = XElement.Load("Clients.xml");
                IEnumerable<XElement> elements = doc.Elements();

                XElement update = null;
                clients.Clear();
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


            // Добавление нового
            public void AddAuto()
            {
            var id_client = 1;
                Console.WriteLine("Введите ФИО клиента");            
                var fio = Console.ReadLine();
                Console.WriteLine("Введите дату выпуска автомобиля");
                var docum = Console.ReadLine();
                XDocument xd = XDocument.Load(sourcePath);
                xd.Root.Add(
                               new XElement("client",
                               new XElement("id_client", id_client),
                               new XElement("FIO", fio),
                               new XElement("Document", docum)));
                xd.Save(sourcePath);
            }
            // изменение цены 
            public void FioUpdateClient(Clients a)
            {
                XElement doc = XElement.Load("Clients.xml");
                IEnumerable<XElement> elements = doc.Elements();

                XElement update = null;
                clients.Clear();
                foreach (XElement el in elements)
                {
                    IEnumerable<XElement> props = el.Elements();
                    foreach (XElement p in props)
                    {

                        if (p.Name.ToString().ToLower() == "document")
                        {
                            var document = Convert.ToString(p.Value);
                            if (document == a.document)
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

            // изменение модели
            public void DocUpdateClient(Clients a)
            {
                XElement doc = XElement.Load("Clients.xml");
                IEnumerable<XElement> elements = doc.Elements();

                XElement update = null;
                clients.Clear();
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

                    if (item.Name.LocalName.ToLower() == "document")
                    {
                        item.SetValue(a.document);
                        Console.WriteLine("ok");

                    }
                    doc.Save(sourcePath);
                }
            }

           
            }
        }
    



