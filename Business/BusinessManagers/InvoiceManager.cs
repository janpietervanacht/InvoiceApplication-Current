using Business.Interfaces;
using DataAccess.Interfaces;
using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.BusinessManagers
{
    public class InvoiceManager : IInvoiceManager
    {
        private readonly IInvoiceRepository _invoiceRepository;

        public InvoiceManager(IInvoiceRepository invoiceRepository)
        {
            _invoiceRepository = invoiceRepository;
        }

        public void DrieKeerZinloos(int teller)
        {
            var zinloos = teller;
            // Tbv de Verify in unit test
            // 3 keer aangeroepen in ClientController.Index()
        }

        public void AddInvoice(Invoice invoice)
        {
            throw new NotImplementedException();
        }

        public int CountNrOfInvoices(int clientId)
        {
            var result = _invoiceRepository.CountNrOfInvoices(clientId);
            return result; 
        }

        public void DeleteInvoice(int invoiceId)
        {
            throw new NotImplementedException();
        }

        public Invoice Get(int invoiceId)
        {
            throw new NotImplementedException();
        }

        public List<Invoice> GetAll(int clientId)
        {
            List<Invoice> result; 

            if (clientId == 0)
            {
                result = _invoiceRepository.GetAll();
            }
            else
            {
                result = _invoiceRepository.GetAll(clientId);
            }
            return result;
        }


        public void UpdateInvoice(Invoice invoice)
        {
            throw new NotImplementedException();
        }
    }
}
