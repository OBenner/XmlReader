using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ConsoleApp1.XmlOptions
{
    class XmlExporttAuto
    {

        public const string sourcePath = "correctOperations.XML";                       // Маршрут экспорта

        /// <summary>
        /// Экспорт операций
        /// </summary>
        public static void ExportData()
        {

            XElement sourceFile = new XElement("ExportData");
            XElement operationNode = new XElement("Operations");

            operationNode.Add(InsertOperations());
            operationNode.Add(UpdateOperations());
            operationNode.Add(DeleteOperations());

            sourceFile.Add(operationNode);

            using (StreamWriter sw = new StreamWriter(sourcePath, false, System.Text.Encoding.Default))
            {
                sw.WriteLine(sourceFile);
                sw.Close();
            }

        }
        /// <summary>
        /// Экспорт операций вставки
        /// </summary>
        /// <returns></returns>
        public static XElement InsertOperations()
        {
            XElement operType = new XElement("Insert");

            foreach (var objectOneName in DbElement.insertOper.Keys)
            {
                foreach (var oper in DbElement.insertOper[objectOneName])
                {
                    XElement objectOne = new XElement(objectOneName);

                    Dictionary<string, string> optionList = DbElement.option[objectOneName];

                    foreach (var oneOpt in optionList.Keys)
                    {
                        try
                        {
                            XElement operOne = new XElement(oneOpt);
                            operOne.SetValue(oper.optionsValue[oneOpt]);
                            objectOne.Add(operOne);
                        }
                        catch { }
                    }
                    operType.Add(objectOne);
                }

            }
            return operType;
        }

        /// <summary>
        /// Экспорт операций Обновления
        /// </summary>
        /// <returns></returns>
        public static XElement UpdateOperations()
        {
            XElement operType = new XElement("Update");

            foreach (var objectOneName in DbElement.updateOper.Keys)
            {
                foreach (var oper in DbElement.updateOper[objectOneName])
                {
                    XElement objectOne = new XElement(objectOneName);

                    Dictionary<string, string> optionList = DbElement.option[objectOneName];

                    foreach (var oneOpt in optionList.Keys)
                    {
                        try
                        {
                            XElement operOne = new XElement(oneOpt);
                            operOne.SetValue(oper.optionsValue[oneOpt]);
                            objectOne.Add(operOne);
                        }
                        catch { }
                    }
                    operType.Add(objectOne);
                }

            }
            return operType;
        }
        /// <summary>
        /// Экспорт операций удаления
        /// </summary>
        /// <returns></returns>
        public static XElement DeleteOperations()
        {
            XElement operType = new XElement("Delete");

            foreach (var objectOneName in DbElement.deleteOper.Keys)
            {
                XElement objectOne = new XElement(objectOneName);
                foreach (var oper in DbElement.deleteOper[objectOneName])
                {
                    XElement operOne = new XElement("id");
                    operOne.SetValue(oper.optionsValue["id"]);
                    objectOne.Add(operOne);
                }

                operType.Add(objectOne);
            }
            return operType;
        }

    
}
}
