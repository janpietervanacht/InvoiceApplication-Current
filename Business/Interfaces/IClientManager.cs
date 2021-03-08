using System.Collections.Generic;
using Model;

namespace Business.Interfaces
{
    public interface IClientManager
    {
        Client GetClient(int clientId);
        void UpdateClient(Client client);
        void AddClient(Client client);
        void DeleteClient(int clientId);
        List<Client> GetAllClientsWithoutInvoices();
        List<Client> GetAllClientsIncludingInvoices();

        int CreateNewClientNumber();
        int MultiplyClientNumberBy100(int? clientId);
        string StringVoorDidactischUnitTest { get; set; } // Alleen voor didactiek

    }
}