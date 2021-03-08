using System.Collections.Generic;
using Model;

namespace Business.Interfaces
{
    public interface IInvoiceManager
    {
        Invoice Get(int invoiceId);
        void UpdateInvoice(Invoice invoice);
        void AddInvoice(Invoice invoice);
        void DeleteInvoice(int invoiceId);
        List<Invoice> GetAll(int clientId); // Als clientId == 0: alle invoices van alle clienten
        int CountNrOfInvoices(int clientId);
    }
}