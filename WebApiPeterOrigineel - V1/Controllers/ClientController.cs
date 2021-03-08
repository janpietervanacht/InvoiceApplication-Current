using DataAccess.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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
        private readonly ILogger<ClientsController> _logger;

        public ClientsController(IClientRepository clientRepository, 
            ILogger<ClientsController> logger)  // DI
        {
            _clientRepository = clientRepository;
            _logger = logger;
        }

        // GET: api/Clients   GETALL
        [HttpGet]
        //public async Task<ActionResult<IList<DTOClient>>> GetAllClients()
        //{
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
                        .ToList()  // Een lijst van integers lukte me niet
                }).ToList();

            // return await _context.Clients.ToListAsync();
            return DTOClientList;

        }

    }
}
