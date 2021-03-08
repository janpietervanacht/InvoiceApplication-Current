using Model;
using OutgoingInvoiceBatch.ExportFileModels;

namespace OutgoingInvoiceBatch.ModelsFactory
{
    public static class InvoiceOutgoingFactory
    {
        public static BigInvoiceOutgoing CreateBigInvoiceOutgoing(Invoice inv, Client client)
        {
            return new BigInvoiceOutgoing
            {
                Bedrag = inv.Amount,
                FactuurDatum = inv.InvoiceDate.ToString("yyyy-MM-dd"),
                FactuurNummer = inv.InvoiceNumber,
                KlantNummer = client.ClientNumber,
                VervalDatum = inv.DueDate.ToString("yyyy-MM-dd"),
                VolledigeNaamClient = client.FirstName + " " + client.LastName
            };
        }

        public static SmallInvoiceOutgoing CreateSmallInvoiceOutgoing(Invoice inv)
        {
            return new SmallInvoiceOutgoing
            {
                Bedragje = inv.Amount,
                Factuurnummertje = inv.InvoiceNumber,
                Klantnummertje = inv.Client.ClientNumber
            };
        }
    }


}