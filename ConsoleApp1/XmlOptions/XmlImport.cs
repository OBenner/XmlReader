using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ConsoleApp1.XmlOptions
{
    class XmlImportAuto
    {
        public const string sourcePath = "Auto.xml";


        // Чтение файла
        public static void ReadFile()
        {
            StreamReader sr = new StreamReader(sourcePath);
            string sourceXml = sr.ReadToEnd();
            sr.Close();


            XElement sourceFile = XElement.Parse(sourceXml);
            foreach (XElement one in sourceFile.Elements())
            {
                if (one.Name.LocalName.Contains("_root"))
                    ParceElementList(one);
            }
            //foreach (var elem in DbElement.option.Keys) {
            //	foreach (var key in DbElement.option[elem].Keys) {
            //		Console.WriteLine(key + " : " + DbElement.option[elem][key]);
            //	}
            //}

        }
        // Парсинг элементов
        public static void ParceElementList(XElement rootElement)
        {
            foreach (XElement oneElement in rootElement.Elements())
            {
                string objectName = oneElement.Name.LocalName;

                if (objectName.Contains("_struct"))
                {

                    Dictionary<string, string> obj = new Dictionary<string, string>();

                    foreach (XElement propertie in oneElement.Elements())
                    {
                        obj.Add(propertie.Name.LocalName, propertie.Attribute("type").Value.ToString());
                    }

                    DbElement.option.Add(objectName.Replace("_struct", ""), obj);

                    continue;
                }


                DbElement dbElement = new DbElement();

                foreach (XElement propertie in oneElement.Elements())
                {
                    dbElement.optionsValue.Add(propertie.Name.LocalName, propertie.Value.ToString());
                }

                if (!DbElement.instanceList.ContainsKey(objectName))
                    DbElement.instanceList.Add(objectName, new List<DbElement>());

                DbElement.instanceList[objectName].Add(dbElement);

            }
        }
    }
}
