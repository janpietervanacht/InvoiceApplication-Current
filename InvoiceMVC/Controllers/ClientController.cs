using Business.Interfaces;
using InvoiceMVC.Controllers.ComplexErrorChecks;
using InvoiceMVC.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace InvoiceMVC.Controllers
{
    public class ClientController : Controller
    {
        private readonly ILogger<ClientController> _logger;
        private readonly IClientManager _clientManager;
        private readonly ICountryManager _countryManager;
        private readonly IInvoiceManager _invoiceManager;

        public ClientController(ILogger<ClientController> logger,
                              IClientManager clientManager,
                              ICountryManager countryManager,
                              IInvoiceManager invoiceManager)
        {
            _logger = logger;
            _clientManager = clientManager;
            _countryManager = countryManager;
            _invoiceManager = invoiceManager;
        }

        public IActionResult Index()
        {
            var clientListFromDb = _clientManager.GetAllClientsWithoutInvoices();

            // Kopieer lijst naar nieuwe lijst met Select truc: 
            var listOfClientVM = clientListFromDb.Select(c => new ClientVM
            {
                Client = c,
                ListOfCountries = _countryManager.GetAll(),
                NumberOfInvoices = _invoiceManager.CountNrOfInvoices(c.Id)
                // ClientFullName wordt automatisch vanuit property Client gevuld
            }
            ).ToList();

            var result = new ClientIndexVM()
            {
                ListOfItems = listOfClientVM,
                KlokVM = new KlokVM()
            };

            for (int i = 0; i < 3; i++)
            {
                // ten behoeve van unit test
                _invoiceManager.DrieKeerZinloos(i); 
            }

            //--------------------------------------- 
            return View(result);
        }

       

        public IActionResult Details(int clientId)
        {
            var client = _clientManager.GetClient(clientId);

            // Bepaal het land van deze client
            var country = new Country();

            // Land is niet verplicht, het is een nullable value variabele (int?) 

            country.Id = client.CountryId.GetValueOrDefault(); // Heeft waarde of is nul 
            country.CountryIsoCode = client.Country?.CountryIsoCode; // Null propagation
            country.CountryDescription = client.Country?.CountryDescription; // Null propagation

            if (country.CountryDescription == null)
            {
                country.CountryDescription = $"Client \'{client.FirstName}\' has NO country";
            }

            var clientVM = new ClientVM
            {
                Client = client,
                // De dropdown-lijst van landen is geblokkeerd in de Details lijst
                // Creëer een lijst bestaande uit 1 land, namelijk het land
                // van deze client. Dan klapt de dropdown-list er niet uit en wordt
                // het juiste land getoond.

                ListOfCountries = new List<Country>()
                {
                   new Country()
                   {
                       Id = country.Id,
                       CountryIsoCode = country.CountryIsoCode,
                       CountryDescription = country.CountryDescription
                   }
                },

                // ListOfCountries = _countryManager.GetAll(),
                NumberOfInvoices = _invoiceManager.CountNrOfInvoices(clientId),

                // NumberOfInvoices en ClientFullName zijn get-properties
                // en worden vanzelf vanuit property Client gevuld

                KlokVM = new KlokVM()
        };
            return View(clientVM);
        }


        // Create Get ------------------------------------------------------------ 
        public IActionResult Create()
        {
            var cltVM = new ClientVM()
            {
                Client = new Client { ActionCode = 'A' }, // Alle overige velden zijn nog leeg
                ListOfCountries = _countryManager.GetAll(),
                KlokVM = new KlokVM()
            }; 
            return View(cltVM);
        }

        // ------------------------------------------------------------------------------------ 
        // POST is altijd het gevolg van een SUBMIT op FORM niveau. 
        // POST: Client/Create: Als je op Save Button drukt, POST je de nieuwe 
        // gegevens terug naar de controller. 

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ClientVM clientVM)
        {
            // Fase 1 - controleer op veld-niveau of ze voldoen
            // Aan de [DataAnnotations] attributen in het model
            if (!ModelState.IsValid)
            {
                // Geef de ViewModel terug:

                // Opmerking: onderstaande werkt niet.
                // "FirstNameChanged" komt niet in het scherm. 
                // Je kan bij return View(xxx) geen nieuwe veldwaarden meegeven 
                clientVM.Client.FirstName = "FirstNamechanged";

                // Geef de lijst van landen weer terug aan de view
                // Zo niet, dan klapt de applicatie en werkt de dropdownlist niet
                clientVM.ListOfCountries = _countryManager.GetAll(); // werkt wel 
                clientVM.KlokVM = new KlokVM(); 
                return View(clientVM);
            }

            // Fase 2 - controleer op veld-niveau of ze voldoen
            // Hieronder komen de complexe coderingen
            // mbt input fouten: 

            string errMsg = ComplexErrorChecking.CheckForClientVMErrors(clientVM);

            if (errMsg != null) // Specifieke fout gevonden
            {
                ModelState.AddModelError(string.Empty, errMsg);

                // Opmerking: onderstaande werkt niet.
                // "LastNameChanged" komt niet in het scherm. 
                // Je kan bij return View(xxx) geen nieuwe veldwaarden meegeven 
                clientVM.Client.LastName = "LastNamechanged";

                // Geef de lijst van landen weer terug aan de view
                // Zo niet, dan klapt de applicatie en werkt de dropdownlist niet
                clientVM.ListOfCountries = _countryManager.GetAll();
                clientVM.KlokVM = new KlokVM();
                return View(clientVM);
            }

            // Fase 3 - verwerk de correcte view 

            var clt = clientVM.Client; 

            // Maak het nieuwe client nummer vlak voordat je het client-record toevoegt: 
            clt.ClientNumber = _clientManager.CreateNewClientNumber();
            _clientManager.AddClient(clt);

            return RedirectToAction("Index");

        }

        //-------------------------------------------------------------------
        // Delete GET: tonen read-only scherm voor DELETE
        // Opmerking: parameter hieronder MOET "clientId" heten (conform de ActionLink in index.cshtml)
        public IActionResult Delete(int clientId)
        {
            var client = _clientManager.GetClient(clientId);

            // Bepaal het land van deze client
            var country = new Country
            {
                // Land is niet verplicht, het is een nullable value variabele (int?) 
                Id = client.CountryId.GetValueOrDefault(), // Heeft waarde of is nul 
                CountryIsoCode = client.Country?.CountryIsoCode, // Null propagation
                CountryDescription = client.Country?.CountryDescription // Null propagation
            };

            if (country.CountryDescription == null)
            {
                country.CountryDescription = $"Client \'{client.FirstName}\' has no country";
            }

            var clientVM = new ClientVM
            {
                Client = client,
                // De dropdown-lijst van landen is geblokkeerd in de Delete view. 
                // Creëer een lijst bestaande uit 1 land, namelijk het land
                // van deze client. Dan klapt de dropdown-list er niet uit en wordt
                // het juiste land getoond.

                ListOfCountries = new List<Country>()
                {
                    new Country()
                    {
                        Id = country.Id,
                        CountryIsoCode = country.CountryIsoCode,
                        CountryDescription = country.CountryDescription
                    }
                },

                // ListOfCountries = _countryManager.GetAll(),
                NumberOfInvoices = _invoiceManager.CountNrOfInvoices(clientId),

                // NumberOfInvoices en ClientFullName zijn get-properties
                // en worden vanzelf vanuit property Client gevuld

                KlokVM = new KlokVM() 
            };

            return View(clientVM);
        }

        //-------------------------------------------------------------------

        // Delete() is GET /  DeleteConfirmed() is POST 
        // GET en POST action methods bij Delete moeten verschillende 
        // namen hebben, want ze hebben 
        // beiden een int  als parameter, overloading kan dus niet. 
        // DAAROM De ActionName "Delete" is dus nodig om aan te geven
        // Dat methode DeleteConfirmed hoort bij de (Post) Action Method "Delete" 

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]

        // ATTENTIE: parameter hieronder moet exact dezelfde naam hebben
        // als in de GET actie voor Delete. Namelijk: "clientId".
        // Als deze parameter een andere naam heeft, wordt deze parameter 0. 
        // Er wordt dan geen client verwijderd.

        // public IActionResult DeleteConfirmed(int klantId) // WERKT dus NIET
        public IActionResult DeleteConfirmed(int clientId)

        {
            // _clientManager.DeleteClient(klantId); // WERKT NIET
            _clientManager.DeleteClient(clientId);
            return RedirectToAction("Index");
        }

        // Update GET  
        public IActionResult Update(int clientId)
        {
            var clt = _clientManager.GetClient(clientId);
            var clientVM = new ClientVM
            {
                Client = clt,
                KlokVM = null,
                ListOfCountries = _countryManager.GetAll(),
                NumberOfInvoices = _invoiceManager.CountNrOfInvoices(clientId) 
                // BirtDateAsString is een read only prop
                // En ook ClientFullName
            }; 

            return View(clientVM); 
        }

        // Update Put (ook inactief/actief maken)
        [HttpPost]  // NIET: HttpPut! 
        [ValidateAntiForgeryToken]
        public IActionResult Update(ClientVM clientVM)
        {
            // Fase 1 - controleer op veld-niveau of ze voldoen
            // Aan de [DataAnnotations] attributen in het model
            if (!ModelState.IsValid)
            {
                // Geef de ViewModel terug:

                // Opmerking: onderstaande werkt niet.
                // "FirstNameChanged" komt niet in het scherm. 
                // Je kan bij return View(xxx) geen nieuwe veldwaarden meegeven 
                clientVM.Client.FirstName = "FirstNamechanged";

                // Geef de lijst van landen weer terug aan de view
                // Zo niet, dan klapt de applicatie en werkt de dropdownlist niet
                clientVM.ListOfCountries = _countryManager.GetAll(); // werkt wel 
                return View(clientVM);
            }

            // Fase 2 - controleer op veld-niveau of ze voldoen
            // Hieronder komen de complexe coderingen
            // mbt input fouten: 

            string errMsg = ComplexErrorChecking.CheckForClientVMErrors(clientVM);

            if (errMsg != null) // Specifieke fout gevonden
            {
                ModelState.AddModelError(string.Empty, errMsg);

                // Opmerking: onderstaande werkt niet.
                // "LastNameChanged" komt niet in het scherm. 
                // Je kan bij return View(xxx) geen nieuwe veldwaarden meegeven 
                clientVM.Client.LastName = "LastNamechanged";

                // Geef de lijst van landen weer terug aan de view
                // Zo niet, dan klapt de applicatie en werkt de dropdownlist niet
                clientVM.ListOfCountries = _countryManager.GetAll();
                return View(clientVM);
            }

            // Fase 3 - verwerk de correcte view 

            var client = clientVM.Client;

            _clientManager.UpdateClient(client); 

            return RedirectToAction("Index");

        }
    }
}
