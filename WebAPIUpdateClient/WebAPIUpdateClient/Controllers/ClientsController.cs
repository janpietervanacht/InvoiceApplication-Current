using DataAccess.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using WebApiPeterOrigineel.DTOModels;

namespace WebApiPeterOrigineel.Controllers
{
    // [Route("api/[controller]")]  // Zet https://localhost:44303/api/clients in URL
    [Route("api/v{version:ApiVersion}/Clients")]  // https://localhost:44303/clients in URL

    [ApiController] // Dit geeft aan dat de controller reageert op Web API requests
    [ProducesResponseType(StatusCodes.Status400BadRequest)] // Voor alle ActionMethods geldig

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

    public class ClientsController : ControllerBase
#pragma warning restore CS1591
    {
        //private readonly WebApiDbContext _context;
        private readonly IClientRepository _clientRepository;


        public ClientsController(IClientRepository clientRepository)  // DI
        {
            _clientRepository = clientRepository;
        }

        // GET: api/Clients   GETALL
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(List<DTOClient>))]
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
