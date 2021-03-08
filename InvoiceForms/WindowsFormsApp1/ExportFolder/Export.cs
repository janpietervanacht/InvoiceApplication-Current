using InvoiceForms.ConstantsAndEnums;
using InvoiceForms.ExportModels;
using InvoiceForms.SerializingFolder;
using Microsoft.Extensions.Configuration;
using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace InvoiceForms.ExportFolder
{
    // Let op new() (**)
    public static class Export<T> where T :   BaseClient, IExportClient, new() // **
    {
        public static void ExportClientToXML(List<Client> listClients, string fullFileName, IConfiguration config)
        {
            var exportClientList = CreateExportClientList(listClients);
            Serializing.SerializeToClientFile<T>(exportClientList, TypeOfExport.XML, fullFileName, config);
        }

        public static void ExportClientToJSON(List<Client> listClients, string fullFileName, IConfiguration config)
        {
            var exportClientList = CreateExportClientList(listClients);
            Serializing.SerializeToClientFile<T>(exportClientList, TypeOfExport.JSON, fullFileName, config);
        }

        private static ExportClientList<T> CreateExportClientList(List<Client> listClients)
        {
            var exportClientList = new ExportClientList<T>();
            exportClientList.Header = new Header
            {
                DateTimeCreated = DateTime.Now,
                FileName = "filename",
                TypeOfElement = typeof(T).Name.ToString()
            };
            exportClientList.Footer = new Footer
            {
                nrOfRecords = listClients.Count()
            };

            // code is goed, ff bewaard: 

            //exportClientList.ClientList = new List<T>();

            //var list1 = exportClientList.ClientList;
            //foreach (var clt in listClients)
            //{
            //    list1.Add(new T
            //    {
            //        Achternaam = clt.LastName,
            //        DateTimeCreated = DateTime.Now,
            //        FaktuurNummers = null,
            //        GeboorteDatum = clt.BirthDate,
            //        Geslacht = clt.Gender,
            //        IsVerzekerd = clt.IsInsured,
            //        Klantnummer = clt.ClientNumber,
            //        LandcodeIso = clt.Country?.CountryIsoCode, // Client hoeft geen land te hebben
            //        Voornaam = clt.FirstName 
            //    });
            //}

            var list = listClients.Select(clt => new T
            {
                Achternaam = clt.LastName,
                DateTimeCreated = DateTime.Now,
                FaktuurNummers = clt.InvoiceList?   // InvoiceList kan leeg zijn, dan werkt de .Select niet meer 
                        .Select(i => i.InvoiceNumber
                        .ToString())
                        .ToList(),
                GeboorteDatum = clt.BirthDate,
                Geslacht = clt.Gender,
                IsVerzekerd = clt.IsInsured,
                Klantnummer = clt.ClientNumber,
                LandcodeIso = clt.Country?.CountryIsoCode, // Client hoeft geen land te hebben
                Voornaam = clt.FirstName,
                BijNaam = clt.NickName,
                LengteKlantInMeters = clt.LengthInMeters
            }) .ToList();

            exportClientList.ClientList = list; 

            return exportClientList; 
        }
        
    }
}
