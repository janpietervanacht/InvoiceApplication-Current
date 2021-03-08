using System.Collections.Generic;
using Model;

namespace DataAccess.Interfaces
{
    public interface IInvoiceRepository
    {

        List<Invoice> GetAll(); // For all clients

        List<Invoice> GetAll(int clientId); // For 1 client

        List<Invoice> GetAllNotSend(); // for outgoing JSON en outgoing XML

        void Add(Invoice invoice);

        void Update(Invoice invoice);

        void Delete(int InvoiceId);

        Invoice Get(int InvoiceId);
        int CountNrOfInvoices(int clientId);
        void DeleteAllInvoices(int clientId);
    }
}