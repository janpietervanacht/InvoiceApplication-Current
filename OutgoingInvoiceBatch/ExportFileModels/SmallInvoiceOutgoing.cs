namespace OutgoingInvoiceBatch.ExportFileModels
{
    public class SmallInvoiceOutgoing
        // Dit object staat niet in ApplicationDbContext
        // in een DbSet, dus het wordt geen tabel in SQL server
        // We gebruiken dit model om uitgaande facturen in een txt bestand
        // te zetten. 
    {
        public int Factuurnummertje { get; set; }

        public int Klantnummertje { get; set;  }

        public decimal Bedragje { get; set; }


    }
}
