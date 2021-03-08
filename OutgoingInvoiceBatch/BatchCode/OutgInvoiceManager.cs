using DataAccess.Interfaces;
using Microsoft.Extensions.Configuration;
using OutgoingInvoiceBatch.ExportFileModels;
using OutgoingInvoiceBatch.Interfaces;
using System;
using System.IO;
using System.Collections.Generic;
using System.Text.Json;
using System.Xml.Serialization;
using OutgoingInvoiceBatch.ModelsExport;
using OutgoingInvoiceBatch.ModelsFactory;
using Model;
using System.ComponentModel.DataAnnotations;

namespace OutgoingInvoiceBatch.BatchCode
{
    public class OutgoingInvoiceManager : IOutgoingInvoiceManager
    {

        private readonly IInvoiceRepository _invoiceRepository;
        private readonly IConfiguration _configuration;
        private readonly IClientRepository _clientRepository;

        // CTOR: 
        public OutgoingInvoiceManager(IInvoiceRepository invoiceRepository,
                                IClientRepository clientRepository)   // DI
        {
            _invoiceRepository = invoiceRepository;
            _clientRepository = clientRepository;
            _configuration = new ConfigurationBuilder()
                   .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                   .Build();  // haal de appsettings (file lokaties) binnen

        }

        //-------------------------------------------------- 

        public string CreateOutgBigInvoiceFile()
        {
            Console.WriteLine("-- Retrieving all not send invoices from database ---");

            // 1. Haal alle facturen op 
            var listInv = _invoiceRepository.GetAllNotSend();

            // 2. Kopieer de lijst van facturen naar de te exporteren lijst van facturen
            var listOutgInv = new List<BigInvoiceOutgoing>();
            foreach (var inv in listInv)
            {
                var client = _clientRepository.Get(inv.ClientId);

                var outgBigInv = InvoiceOutgoingFactory.CreateBigInvoiceOutgoing(inv, client);

                listOutgInv.Add(outgBigInv);

            }

            string fileNameJSON, fileNameXML, fullFileNameJSONWithPath, fullFileNameXMLWithPath;
            CreateOutputFileAttributes("big invoice", out fileNameJSON, out fileNameXML, out fullFileNameJSONWithPath, out fullFileNameXMLWithPath);

            var invoiceExportFileModel = new BaseExportFile<BigInvoiceOutgoing>();
            invoiceExportFileModel.HeaderOutgoing = HeaderFooterOutgoingFactory<BigInvoiceOutgoing>.GetHeader(fullFileNameJSONWithPath);
            invoiceExportFileModel.LijstMetItems = listOutgInv;
            invoiceExportFileModel.FooterOutgoing = HeaderFooterOutgoingFactory<BigInvoiceOutgoing>.GetFooter(listOutgInv.Count);

            SchrijfJSONFile<BigInvoiceOutgoing>(listInv, fileNameJSON, fullFileNameJSONWithPath, invoiceExportFileModel);
            SchrijfXMLFile<BigInvoiceOutgoing>(listInv, fileNameXML, fullFileNameXMLWithPath, invoiceExportFileModel);

            string errorCode = "0";
            return errorCode;

        }


        public string CreateOutgSmallInvoiceFile()
        {
            Console.WriteLine("-- Retrieving all not send SMALL invoices from database ---");

            // 1. Haal alle facturen op 
            var listInv = _invoiceRepository.GetAllNotSend();

            // 2. Kopieer de lijst van facturen naar de te exporteren lijst van facturen
            var listOutgInv = new List<SmallInvoiceOutgoing>();
            foreach (var inv in listInv)
            {
                var outgSmallInv = InvoiceOutgoingFactory.CreateSmallInvoiceOutgoing(inv);
                listOutgInv.Add(outgSmallInv);
            }

            string  fileNameJSON, fileNameXML, fullFileNameJSONWithPath, fullFileNameXMLWithPath;
            CreateOutputFileAttributes("small invoice", out fileNameJSON, out fileNameXML, out fullFileNameJSONWithPath, out fullFileNameXMLWithPath);

            // 6. Maak het InvoiceExportFileModel aan: header, lijst van outgoing invoices, footer

             var invoiceExportFileModel = new BaseExportFile<SmallInvoiceOutgoing>();
            invoiceExportFileModel.HeaderOutgoing = HeaderFooterOutgoingFactory<SmallInvoiceOutgoing>.GetHeader(fullFileNameJSONWithPath);
            invoiceExportFileModel.LijstMetItems = listOutgInv;
            invoiceExportFileModel.FooterOutgoing = HeaderFooterOutgoingFactory<SmallInvoiceOutgoing>.GetFooter(listOutgInv.Count);

            // Schrijf JSON file weg

            SchrijfJSONFile<SmallInvoiceOutgoing>(listInv, fileNameJSON, fullFileNameJSONWithPath, invoiceExportFileModel);
            SchrijfXMLFile<SmallInvoiceOutgoing>(listInv, fileNameXML, fullFileNameXMLWithPath, invoiceExportFileModel);

            string errorCode = "0";
            return errorCode;
        }


        private void CreateOutputFileAttributes(string typeInvoice, out string fileNameJSON, out string fileNameXML,
            out string fullFileNameJSONWithPath, out string fullFileNameXMLWithPath)
        {
            // 3. Haal settings voor folders en namen uit appsettings.json 

            var baseDirExport = _configuration.GetSection("AppSettings")["BasisFolderExport"];
            var subFolderInvoices = _configuration.GetSection("AppSettings")["SubFolderFacturen"];
            var fileNameJSONPrefix = _configuration.GetSection("AppSettings")["NaamJSONExportFilePrefix"];

            // 4. Verleng de file-naam met een date-time stamp (NOW) 

            var dateTimeExport = DateTime.Now.ToString("yyyyMMdd-HHmmss");
            fileNameJSON = fileNameJSONPrefix + " " + dateTimeExport   + " " + typeInvoice + ".txt";

            // 5. Construeer het volledige filepath
            // Combine zorgt ervoor dat er geen verwarring ontstaat
            // bij het verbinden van folder-paden (soms zijn er wel of geen extra slashes aanwezig)

            var pathString = Path.Combine(baseDirExport, subFolderInvoices);
            fullFileNameJSONWithPath = Path.Combine(pathString, fileNameJSON);
            if (!Directory.Exists(pathString))
            {
                Directory.CreateDirectory(pathString);
            }

            var fileNameXMLPrefix = _configuration.GetSection("AppSettings")["NaamXMLExportFilePrefix"];
            fileNameXML = fileNameXMLPrefix + " " + dateTimeExport + " " + typeInvoice + ".xml";
            fullFileNameXMLWithPath = Path.Combine(pathString, fileNameXML);

        }

        private void SchrijfJSONFile<T>(List<Invoice> listInv, string fileNameJSON, string fullFileNameJSONWithPath, BaseExportFile<T> invoiceExportFileModel)
        {
            Console.WriteLine($"Header filename: {fileNameJSON} ----- \n");
            foreach (var i in listInv)
            {
                Console.WriteLine($"faktuur met nummer {i.InvoiceNumber} wordt geëxporteerd naar JSON");
            }
            Console.WriteLine($"\nFooter - aantal BIG facturen in JSON file: " +
                $"{listInv.Count} ----- \n");

            var jsonString = JsonSerializer.Serialize(invoiceExportFileModel);

            using (var file = new StreamWriter(fullFileNameJSONWithPath))
            {
                file.WriteLine(jsonString);
            }
        }

        private void SchrijfXMLFile<T>(List<Invoice> listInv, string fileNameXML, string fullFileNameXMLWithPath, BaseExportFile<T> invoiceExportFileModel)
        {

            invoiceExportFileModel.HeaderOutgoing.FileName = fileNameXML;

            Console.WriteLine($"Header filename: {fileNameXML} ----- \n");
            foreach (var i in listInv)
            {
                Console.WriteLine($"faktuur met nummer {i.InvoiceNumber} wordt geëxporteerd naar XML");
            }
            Console.WriteLine($"\nFooter - aantal BIG facturen in XML file: " +
                $"{listInv.Count} ----- \n");

            var serialWriter = new StreamWriter(fullFileNameXMLWithPath);

            var xmlWriter = new XmlSerializer(invoiceExportFileModel.GetType());
            xmlWriter.Serialize(serialWriter, invoiceExportFileModel);
            serialWriter.Close();
        }


    }
}
