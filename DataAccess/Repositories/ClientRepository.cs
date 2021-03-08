using DataAccess.ApplicDbContext;
using DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Model;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class ClientRepository : IClientRepository
    {
        readonly ApplicDbContext.DatabaseContext _dbContext;
        readonly ILogger<ClientRepository> _logger;

        readonly string dbgPref = "debug niveau: ";
        readonly string errPref = "error niveau:  ";
        readonly string infoPref = "info niveau: : ";
        readonly string warnPref = "warning niveau:  ";

        public ClientRepository(ApplicDbContext.DatabaseContext dbContext, ILogger<ClientRepository> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public void Add(Client client)
        {
            _dbContext.Clients.Add(client);
            _dbContext.SaveChanges();

            // Logging in MVC = naar database // TODO 
            // Logging in Web API = naar Windows Event Viewer // TODO
            // Logging in Outgoing Invoices - naar een text file // TODO

            var txt = $"Client \"{client.FirstName} {client.LastName}\" " +
               $"met clientnummer {client.ClientNumber} toegevoegd";

            _logger.LogDebug(dbgPref + txt);
            _logger.LogInformation(infoPref + txt);
            _logger.LogWarning(warnPref + txt);
            _logger.LogError(errPref + txt);
        }

        public void Delete(int id)
        {
            Client clt = _dbContext.Clients.Find(id);
            _dbContext.Clients.Remove(clt);
            _dbContext.SaveChanges();

            var txt = $"Method Delete: Client \"{clt.FirstName} {clt.LastName}\" " +
               $"met clientnummer {clt.ClientNumber} verwijderd";

            _logger.LogDebug(dbgPref + txt);
            _logger.LogInformation(infoPref + txt);
            _logger.LogWarning(warnPref + txt);
            _logger.LogError(errPref + txt);

        }

        public Client Get(int clientId) // Haal Client op, maar ook zijn land en al zijn invoices
        {
            var client = _dbContext.Clients
                .Where(c => c.Id == clientId)
                .Include(c => c.Country)
                .Single();

            return client;
            // return (_dbContext.Clients.Find(Id));  // kan ook
        }

        // Web API retrieves all clients
        public List<Client> GetAllClientsWithoutIncludingInvoices()
        {
            // Include foreign key Country (mag null zijn) 

            var clientList = _dbContext.Clients
                .Include(c => c.Country)  // Foreign key, optioneel
                .ToList();

            var txt = $"Method GetAll: {clientList.Count} clienten gevonden ";

            // Logging vindt plaats in een andere database
            // dan waar de gewone tabellen in staan
            // Zie NLog.Config.
            _logger.LogDebug(dbgPref + txt);  // Wordt nooit afgedrukt? 
            _logger.LogInformation(infoPref + txt);
            _logger.LogWarning(warnPref + txt);
            _logger.LogError(errPref + txt);

            return clientList;
        }

        public void Update(Client client)
        {
            // var clt = _dbContext.Clients.Find(client.Id);
            _dbContext.Entry(client).State = EntityState.Modified;
            _dbContext.SaveChanges();

            var txt = $"Method Update: Client \"{client.FirstName} {client.LastName}\" " +
               $"met clientnummer {client.ClientNumber} veranderd";

            _logger.LogDebug(dbgPref + txt);
            _logger.LogInformation(infoPref + txt);
            _logger.LogWarning(warnPref + txt);
            _logger.LogError(errPref + txt);

        }

        /// <summary>
        ///   Ophalen client via Swagger of Postman op basis 
        ///   van functioneel clientnummer = geimplementeerd met
        ///   een stored procedure in database
        /// </summary>
        /// <param name="clientNumber"></param>
        /// <returns></returns>
        public Client GetByClientNumber(int clientNumber)
        {
            // een client nummer hoeft niet te bestaan
            var client = _dbContext.Clients?  // null propagation
                .Include(c => c.InvoiceList)
                .Include(c => c.Country)
                .SingleOrDefault(c => c.ClientNumber == clientNumber);
            // Je kan Include en SingleOrDefault niet verwisselen
            // Eerst de Include, daarna de SingleOrDefault

            if (client != null)
            {
                var txt = $"Method GetByClientNumber: " +
               $" client {client.FirstName} {client.LastName} opgehaald";
            }

            return client;

            // OUDE CODE (ZONDER STORED PROCEDURE): 

            //var result = _dbContext.Clients
            //    .Where(c => c.ClientNumber == clientNumber)
            //    .SingleOrDefault(); // klapt eruit als er 2 of meer bestaan
            // return result; 

        }

        public bool UpdateByClientNumber(Client client) // client wordt ook wel [body] genoemd
        {
            // Clients tabel kan leeg zijn, vandaar het ? achter Clients
            var dbClient = _dbContext.Clients?.FirstOrDefault(c => c.ClientNumber.Equals(client.ClientNumber));
            // MAG OOK: var clt = _dbContext.Clients?.FirstOrDefault(c => c.ClientNumber == (client.ClientNumber));

            bool success;
            if (dbClient == null)
            {
                success = false;
                return success;
            }

            client.Id = dbClient.Id;
            client.ActionCode = dbClient.ActionCode;

            _dbContext.Entry(dbClient).CurrentValues.SetValues(client);
            _dbContext.SaveChanges();

            var txt = $"Method UpdateByClientNumber: Client \"{client.FirstName} {client.LastName}\" " +
             $"met clientnummer {client.ClientNumber} veranderd";

            _logger.LogDebug(dbgPref + txt);
            _logger.LogInformation(infoPref + txt);
            _logger.LogWarning(warnPref + txt);
            _logger.LogError(errPref + txt);

            success = true;
            return success;
        }

        /// <summary>
        ///  DeleteByClientNumber wordt uitgevoerd middels een usp (user stored procedure) 
        /// </summary>
        /// <param name="clientNumber"></param>
        /// <returns></returns>
        public bool DeleteByClientNumber(int clientNumber)
        {
            bool success;
            Client clt = _dbContext.Clients.SingleOrDefault(c => c.ClientNumber == clientNumber);
            if (clt != null)
            {

                //-------------------------------------------- 
                // Onderstaande werkt ook goed (NIET VERWIJDEREN):

                _dbContext.Clients.Remove(clt);
                _dbContext.SaveChanges();
                success = true;
                //--------------------------------------------

                // Gebruik niet _dbContext.Clients.FromSqlRaw maar onderstaande: _dbContext.Database.ExecuteSqlRaw
                // want je retourneert geen clienten 

                // var result = _dbContext.Database.ExecuteSqlRaw($"EXECUTE dbo.uspDeleteClientByClientNumber {clientNumber}");
                success = true;

                var txt = $"Method DeleteByClientNumber: Client \"{clt.FirstName} {clt.LastName}\" " +
                         $"met clientnummer {clt.ClientNumber} verwijderd";

                _logger.LogDebug(dbgPref + txt);
                _logger.LogInformation(infoPref + txt);
                _logger.LogWarning(warnPref + txt);
                _logger.LogError(errPref + txt);
            }
            else
            {
                success = false;
            }
            return success;
        }

        public int DetermineNewClientNumber()
        {
            var newClientNumber = _dbContext.Clients
                .Max(c => c.ClientNumber) + 1;
            return newClientNumber;
        }

        public List<Client> GetAllClientsWithIncludingInvoices()
        {
            // Include foreign key Country (mag null zijn) 

            var clientList = _dbContext.Clients
                .Include(c => c.Country)  // Foreign key, optioneel
                .Include(c => c.InvoiceList) // Neem ook alle invoices mee per client
                .ToList();

            var txt = $"Method GetAll: {clientList.Count} clienten gevonden ";

            // Logging vindt plaats in een andere database
            // dan waar de gewone tabellen in staan
            // Zie NLog.Config.
            _logger.LogDebug(dbgPref + txt);  // Wordt nooit afgedrukt? 
            _logger.LogInformation(infoPref + txt);
            _logger.LogWarning(warnPref + txt);
            _logger.LogError(errPref + txt);

            return clientList;
        }

        public int GetMaxClientNumber()
        {
            var result = _dbContext.Clients.Max(c => c.ClientNumber);
            return result;
        }

        public Task GetAllClientsWithIncludingInvoicesAsync(string q)
        {
            throw new System.NotImplementedException();
        }

        public int GetNewClientNumber()
        {
            // Als er 0 clienten zijn, dan wordt newClientNumber gelijk aan 1:  
            int? newClientNumber = _dbContext.Clients?.Max(c => c.ClientNumber);
            return newClientNumber.GetValueOrDefault() + 1;  
        }
    }
}
