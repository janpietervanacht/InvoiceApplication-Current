using Business.Interfaces;
using InvoiceMVC.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Model;
using Model.ConstantsAndEnums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace InvoiceMVC.Controllers
{
    public class InvoiceController : Controller
    {
        private readonly ILogger<InvoiceController> _logger;
        private readonly IInvoiceManager _invoiceManager;
        private readonly IClientManager _clientManager;

        public InvoiceController(ILogger<InvoiceController> logger,
                              IInvoiceManager invoiceManager,
                              IClientManager clientManager)
        {
            _logger = logger;
            _invoiceManager = invoiceManager;
            _clientManager = clientManager;
        }

        public IActionResult Index(int? clientId)
        {
            //-------------------------------- 
            // Stukje dummy code om Verify uit te proberen:

            DummyCallsForUnitTest(clientId);
            //--------------------------------

            Client client = null;

            // Deze routine kan zowel een null clientId (invoices alle klanten)
            // als een bestaande waarde van clientId verwerken (invoices van één klant).
            var invoiceList = _invoiceManager.GetAll(clientId.GetValueOrDefault());
            if (clientId.HasValue)
            {
                client = _clientManager.GetClient(clientId.Value); //  
            }

            // Kopieer lijst naar nieuwe lijst - via de Select....New.... ToList() methode
            var invoiceVMList = invoiceList
                .Select(i => new InvoiceVM
                {
                    Invoice = i,
                    // InvoiceDateAsString // Via Get Prop geset
                    ToBeExported = false // checkbox voor te exporteren facturen
                }).ToList();

            InvoiceIndexVM result;
            string clientFullName;
            int clientNumber;

            if (clientId.HasValue)
            {
                clientFullName = client.FirstName + " " + client.LastName;
                clientNumber = client.ClientNumber;
            }
            else
            {
                clientFullName = "Voor alle clienten";
                clientNumber = 0;
            }

            result = new InvoiceIndexVM()
            {
                ListOfItems = invoiceVMList,
                ClientFullName = clientFullName,
                ClientNumber = clientNumber
                // NrOfItems wordt automatisch gevuld vanuit ListOfItems
            };

            return View(result);
        }

        private void DummyCallsForUnitTest(int? clientId)
        {
            // Dient om te oefenen met Verify
            for (int i = 0; i < 3; i++)
            {
                var maal100 = _clientManager.MultiplyClientNumberBy100(clientId);
            };

            int x = 1, y = 2; 
            if ( (x > y) ) //false
            {
                _clientManager.DeleteClient(clientId.GetValueOrDefault());  // nul keer aangeroepen
            }
        }

        private void DoeNiets()
        {
            // Aangemaakt om Verify te testen
        }

        public IActionResult ExportSelectedInvoices(InvoiceIndexVM invoiceIndexVM)
        {
            return RedirectToAction("Index"); 
        }

    }
}
