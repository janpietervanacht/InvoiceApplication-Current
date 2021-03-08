using DataAccess.ApplicDbContext;
using DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Model;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Repositories
{
    public class InvoiceRepository: IInvoiceRepository
    {
        private readonly ApplicDbContext.DatabaseContext _dbContext;
        private readonly ILogger<ClientRepository> _logger;

        //private string dbgPref = "Debug level from JPVA: ";
        //private string infoPref = "Info level from JPVA: ";
        //private string warnPref = "Warning level from JPVA: ";
        //private string errPref = "Error level from JPVA: ";

        public InvoiceRepository(ApplicDbContext.DatabaseContext dbContext, ILogger<ClientRepository> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public void Add(Invoice invoice)
        {
            throw new System.NotImplementedException();
        }

        public int CountNrOfInvoices(int clientId)
        {
            var result = _dbContext.Invoices
               .Where(i => i.ClientId == clientId) 
               .Count();
            return result; 
        }

        public void Delete(int InvoiceId)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteAllInvoices(int clientId)
        {
            // Method syntax mag ook:

            //var invLineListDb = (from inv in _dbContext.Invoices
            //                     where inv.ClientId == clientId
            //                     select inv)
            //                  .ToList();  // ToList() niet vergeten 

            var invListDb = _dbContext.Invoices.Where(i => i.ClientId == clientId).ToList(); 

            foreach (var inv in invListDb)
            {
                // Invoice inv =_dbContext.Invoics.Find(inv.Id);  // NEE, NIET DOEN
                _dbContext.Invoices.Remove(inv);
                _dbContext.SaveChanges();  // (*)
            }
        }

        public Invoice Get(int InvoiceId)
        {
            throw new System.NotImplementedException();
        }

        public List<Invoice> GetAll()
        {
            var result = _dbContext.Invoices 
                .OrderBy(i => i.InvoiceNumber)
                .Include(i => i.Client)
                .ToList();

            return result;
        }

        public List<Invoice> GetAll(int clientId)
        {
            var result = _dbContext.Invoices
                .Where(i => i.ClientId == clientId)
                .Include(i => i.Client)
                .OrderBy(i=>i.InvoiceNumber)
                .ToList();

            return result; 
        }

        public List<Invoice> GetAllNotSend()
        {
            var result = _dbContext.Invoices
                .Where(i => i.InvoiceSend == false)
                .ToList();
            return result; 
        }

        public void Update(Invoice invoice)
        {
            throw new System.NotImplementedException();
        }
    }
}
