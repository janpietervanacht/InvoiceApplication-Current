using System.Collections.Generic;
using System.Threading.Tasks;
using Model;

namespace DataAccess.Interfaces
{
    public interface IClientRepository
    {

        List<Client> GetAllClientsWithoutIncludingInvoices(); // All clients without including invoices

        void Add(Client client);

        void Update(Client client);

        void Delete(int id);

        Client Get(int Id);

        Client GetByClientNumber(int clientNumber); // functioneel clientnummer

        bool UpdateByClientNumber(Client client);

        bool DeleteByClientNumber(int clientNumber);

        int DetermineNewClientNumber();
        List<Client> GetAllClientsWithIncludingInvoices();
        int GetMaxClientNumber();
        Task GetAllClientsWithIncludingInvoicesAsync(string q);
        int GetNewClientNumber();
    }
}