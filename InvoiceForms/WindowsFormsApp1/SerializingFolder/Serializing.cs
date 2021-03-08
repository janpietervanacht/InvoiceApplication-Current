using InvoiceForms.ConstantsAndEnums;
using InvoiceForms.ExportModels;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Xml.Serialization;

namespace InvoiceForms.SerializingFolder
{
    public static class Serializing
    {
        // Best practice: Gebruik bij een generic bijna altijd een Where, en maak T zo specifiek mogelijk
        // Daarmee voorkomt je dat deze generic misbruikt wordt voor andere classes dan Client.
        public static void SerializeToClientFile<T>
                            ( this ExportClientList<T> exportClientList,
                                TypeOfExport typeOfExport,
                                string fullFileName,
                                IConfiguration config
                            )  where T: BaseClient, IExportClient
        {
            // T is een BigClient of een SmallClient

            StreamWriter file;
            string jsonString;

            switch (typeOfExport)
            {
                case TypeOfExport.XML:
                    using (file = new StreamWriter(fullFileName))
                    {
                        var xmlWriter = new XmlSerializer(exportClientList.GetType());
                        xmlWriter.Serialize(file, exportClientList);   // schrijf naar txt file  
                    }
                    break;
                case TypeOfExport.JSON:
                    using (file = new StreamWriter(fullFileName))
                    {
                        jsonString = JsonSerializer.Serialize(exportClientList);
                        file.WriteLine(jsonString); 
                    }
                    break;
                default:
                    throw new InvalidEnumArgumentException(); 
            }
        }
    }
}
