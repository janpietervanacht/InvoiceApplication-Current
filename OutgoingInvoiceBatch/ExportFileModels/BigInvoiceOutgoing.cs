namespace OutgoingInvoiceBatch.ExportFileModels
{
    public class BigInvoiceOutgoing
        // Dit object staat niet in ApplicationDbContext
        // in een DbSet, dus het wordt geen tabel in SQL server
        // We gebruiken dit model om uitgaande facturen in een txt bestand
        // te zetten. 
    {

        public int FactuurNummer { get; set; }

        public int KlantNummer { get; set;  }

        public string VolledigeNaamClient { get; set; }

        public decimal Bedrag { get; set; }

        public string FactuurDatum { get; set; }  
        public string VervalDatum { get; set; }  


    }
}
