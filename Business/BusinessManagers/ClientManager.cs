using Business.Interfaces;
using DataAccess.Interfaces;
using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.BusinessManagers
{
    public class ClientManager : IClientManager
    {
        private readonly IClientRepository _clientRepository;

        // In de constructor geven we alle objecten mee
        // die deze class zelf weer gebruikt. 

        public ClientManager(IClientRepository clientRepository)
        {
            // Bij Dependency Injection in startup.cs is geregeld
            // dat IClientRepository slechts één keer (lifetime) een 
            // instantie van ClientRepository aanwijst. 
            _clientRepository = clientRepository;
        }

        public string StringVoorDidactischUnitTest { get; set; }


        public void AddClient(Client client)
        {
            _clientRepository.Add(client); 
        }

        public int CreateNewClientNumber()
        {
            var maxClientNumber = _clientRepository.GetMaxClientNumber() + 1;
            return maxClientNumber; 
        }

        public void DeleteClient(int clientId)
        {
            _clientRepository.Delete(clientId);  
        }

        public List<Client> GetAllClientsIncludingInvoices()
        {
            var result = _clientRepository.GetAllClientsWithIncludingInvoices(); 
            return result;
        }

        public List<Client> GetAllClientsWithoutInvoices()
        {
            var result = _clientRepository.GetAllClientsWithoutIncludingInvoices();
            return result; 
        }

        public Client GetClient(int clientId)
        {
            var result = _clientRepository.Get(clientId); 
            return result;
        }

        public int MultiplyClientNumberBy100(int? clientId)  
        {
            // Deze routine is didactisch voor unit testen  
            return clientId.GetValueOrDefault() * 100;   // retourneert 0*100 (0 dus) of retourneert clientId * 100
        }

        public void UpdateClient(Client client)
        {
            _clientRepository.Update(client); 
        }
    }
}
