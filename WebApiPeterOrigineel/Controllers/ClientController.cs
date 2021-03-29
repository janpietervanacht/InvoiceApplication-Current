using DataAccess.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Model;
using Model.ConstantsAndEnums;
using System;
using System.Collections.Generic;
using System.Linq;
using WebApiPeterOrigineel.DTOModels;

namespace WebApiPeterOrigineel.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class ClientsController : ControllerBase
    {
        //private readonly WebApiDbContext _context;
        private readonly IClientRepository _clientRepository;
        private readonly ICountryRepository _countryRepository;
        private readonly IInvoiceRepository _invoiceRepository;
        private readonly ILogger<ClientsController> _logger;

        public ClientsController(IClientRepository clientRepository,
                                ICountryRepository countryRepository,
                                IInvoiceRepository invoiceRepository,
                                ILogger<ClientsController> logger)  // DI
        {
            _clientRepository = clientRepository;
            _countryRepository = countryRepository;
            _invoiceRepository = invoiceRepository;
            _logger = logger;
        }

        // GET: api/Clients   GETALL
        // URL haal je uit Swagger: na aanroep via Request URL:  https://localhost:44302/Clients
        // Zet deze ook in je client applicatie. 

        [HttpGet]

        public IList<DTOClient> GetAllClients()
        {
            // Bij het exporteren naar buiten, geven we per client ook alle
            // bijbehorende facturen
            // In de MVC applicatie (index client) is deze include van facturen 
            // niet toegepast omdat het daar ook niet nodig is
            var clientList = _clientRepository.GetAllClientsWithIncludingInvoices();

            var DTOClientList = clientList
                .Select(c => new DTOClient
                {
                    Klantnummer = c.ClientNumber,
                    GeboorteDatum = c.BirthDate,
                    LandcodeIso = c.Country?.CountryIsoCode, // null propagation
                    Voornaam = c.FirstName,
                    Geslacht = c.Gender,
                    Achternaam = c.LastName,
                    IsVerzekerd = c.IsInsured,
                    FaktuurNummers = c.InvoiceList
                        .Select(i => i.InvoiceNumber.ToString())
                        .ToList(),  // Een lijst van integers lukte me niet
                    BijNaam = c.NickName,
                    LengteKlantInMeters = c.LengthInMeters
                }).ToList();

            // return await _context.Clients.ToListAsync();
            return DTOClientList;

        }

        // [HttpGet("{clientNumber:int}", Name = "GetByClientNumber")] // werkt ook, maar dan URL in client aanpassen! 
        // Kijk naar de Request URL die verschijnt ná aanroep in Swagger:
        //  https://localhost:44302/Clients/GetByClientNumber/100001
        // Zet deze URL ook in de client applicatie.
        [HttpGet("GetByClientNumber/{clientNumber:int}")]
        public DTOClient GetByClientNumber(int clientNumber)
        {

            var clt = _clientRepository.GetByClientNumber(clientNumber);
            if (clt == null)
            {
                return null;
            }
            else
            {
                var cltDTO = new DTOClient
                {
                    Achternaam = clt.LastName,
                    FaktuurNummers = clt.InvoiceList.
                                Select(i => i.InvoiceNumber
                                .ToString().PadLeft(8, '0'))
                                .ToList(),
                    GeboorteDatum = clt.BirthDate,
                    Geslacht = clt.Gender,
                    IsVerzekerd = clt.IsInsured,
                    Klantnummer = clientNumber,
                    LandcodeIso = clt.Country?.CountryIsoCode, // Country is optioneel
                    Voornaam = clt.FirstName,
                    BijNaam = clt.NickName,
                    LengteKlantInMeters = clt.LengthInMeters
                };
                return cltDTO;
            }

        }


        //------------------------ delete ------------------------------------------- 

        // Request URL na aanroep in Swagger: https://localhost:44302/Clients/100003
        // Zet deze ook in je client applicatie. 

        [HttpDelete("{clientNumber}")]
        public void DeleteClient(int clientNumber)
        {
            _clientRepository.DeleteByClientNumber(clientNumber);
        }

        // ---------------------- toevoegen (POST) ------------------------------------------- 

        // Request URL na aanroep in Swagger: https://localhost:44302/Clients
        // Zet deze ook in je client applicatie. 

        [HttpPost]  // Aan de 'Post' zie je dat het toevoegen betreft 
        public void CrtClient([FromBody] DTOClient dTOClient)
        {

            if (dTOClient == null)
            {
                return;
            }

            var newClientNumber = _clientRepository.GetNewClientNumber();

            //  Haal het land op, mits het bestaat
            var country = _countryRepository.getCountryByIsoCode(dTOClient.LandcodeIso);

            var client = new Client()
            {
                ActionCode = 'A',
                BirthDate = dTOClient.GeboorteDatum,
                ClientNumber = newClientNumber,
                Country = country,
                CountryId = country?.Id, // mag null zijn
                FirstName = dTOClient.Voornaam,
                Gender = dTOClient.Geslacht,
                InvoiceList = null,
                IsInsured = dTOClient.IsVerzekerd,
                IsPopstar = false,
                PopstarYearIncome = null,
                LastName = dTOClient.Achternaam,
                NickName = dTOClient.BijNaam,
                LengthInMeters = dTOClient.LengteKlantInMeters
            };


            // Zorg ervoor dat alle niet-nullable velden gevuld zijn voordat
            // je het record aan de database toevoegt

            _clientRepository.Add(client);

        }

        // ---- Update (PUT de U van Update) -------------------------------- 

        // --- Onderstaande werkt ook: ---------------------------------------------------
        // Request URL na aanroep in Swagger = https://localhost:44302/Clients/100001
        // [HttpPut("{clientNumber}")]
        // -------------------------------------------------------------------------------

        // Request URL na aanroep in Swagger: https://localhost:44302/Clients/UpdateClient/100001
        [HttpPut("UpdateClient/{clientNumber:int}")]

        public void UpdateClient(int clientNumber, [FromBody] DTOClient dTOClient)
        {

            if (dTOClient == null)
            {
                return;
            }

            //  Haal het land op, mits het bestaat
            var country = _countryRepository.getCountryByIsoCode(dTOClient.LandcodeIso);

            var client = new Client()
            {
                ActionCode = 'A',
                BirthDate = dTOClient.GeboorteDatum,
                ClientNumber = clientNumber,
                Country = country,
                CountryId = country?.Id, // mag null zijn
                FirstName = dTOClient.Voornaam,
                Gender = dTOClient.Geslacht,
                InvoiceList = null,
                IsInsured = dTOClient.IsVerzekerd,
                IsPopstar = false,
                PopstarYearIncome = null,
                LastName = dTOClient.Achternaam,
                LengthInMeters = dTOClient.LengteKlantInMeters,
                NickName = dTOClient.BijNaam
            };

            var success = _clientRepository.UpdateByClientNumber(client);

        }

        // Kijk naar de Request URL die verschijnt ná aanroep in Swagger (Request URL):
        //  https://localhost:44302/Clients/GetStatisticsByClientNumber/100001
        // Zet deze URL ook in de client applicatie.
        [HttpGet("GetStatisticsByClientNumber/{clientNumber:int}")]
        public DTOClientStatistics GetStatisticsByClientNumber(int clientNumber)
        {

            var clt = _clientRepository.GetByClientNumber(clientNumber);

            dummyCalledMethod(); // Voor verify

            if (clt == null)
            {
                return null;
            }
            else
            {
                var firstNameWithNoSpaces = clt.FirstName.Replace(" ", "");
                var lastNameWithNoSpaces = clt.LastName.Replace(" ", "");
                var invoiceNumbers = clt.InvoiceList?  // invoiceNumbers kan lege lijst zijn
                    .Select(i => i.InvoiceNumber.ToString().PadLeft(8, '0'))
                        .ToList();
                var totalInvoiceAmount = clt.InvoiceList?.Sum(i => i.Amount);

                var dtoClientStatistics = new DTOClientStatistics
                {
                    AantalFacturen = _invoiceRepository.CountNrOfInvoices(clt.Id),
                    AantalLettersAchterNaamKlantZonderSpaties = lastNameWithNoSpaces.Length,
                    AantalLettersVoorNaamKlantZonderSpaties = firstNameWithNoSpaces.Length,
                    FactuurNummers = invoiceNumbers,
                    Klantnummer = clientNumber,
                    TotaalFactuurBedrag = totalInvoiceAmount.GetValueOrDefault(),
                    VolledigeNaamKlant = clt.FirstName + " " + clt.LastName
                };
                return dtoClientStatistics;
            }

        }

        private void dummyCalledMethod()
        {
            var x = 1;
        }

        // Kijk naar de Request URL die verschijnt ná aanroep in Swagger (Request URL):
        //  https://localhost:44302/Clients/DeleteAllInvoicesForOneClientNumber/100001
        // Zet deze URL ook in de client applicatie.
        [HttpDelete("DeleteAllInvoicesForOneClientNumber/{clientNumber:int}")]
        public void DeleteAllInvoicesForOneClientNumber(int clientNumber)
        {
            var clt = _clientRepository.GetByClientNumber(clientNumber); 
            if (clt != null)
            {
                _invoiceRepository.DeleteAllInvoices(clt.Id); 
            }
        }
    }
}
