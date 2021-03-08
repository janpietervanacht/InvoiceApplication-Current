using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Model
{ 
    public class Invoice
    {
        public int Id { get; set; } // [Required] niet nodig voor CodeFirst generation

        [Required]
        [DisplayName("Factuurnummer:")] // automatisch gegenereerd
        public int InvoiceNumber { get; set; }  // functioneel fact nr

        [Required]
        public int ClientId { get; set; }  // Factuur kent 1 Client Id (FK)
        // Dit is een Foreign Key naar de hele CLIENT tabel in SQL server .Include in LINQ
        // Let op: in Client is een 1:N relatie gelegd via een List
        public Client Client { get; set; }


        [DisplayName("Bedrag:")]
        [Required(ErrorMessage = "Bedrag is verplicht")]
        public decimal Amount { get; set; }


        [DisplayName("Factuuromschrijving:")]
        [Required(ErrorMessage = "Factuuromschrijving is verplicht")]
        public string InvoiceDescription { get; set; }


        [DisplayName("Factuurdatum:")]
        [Required(ErrorMessage = "Factuurdatum is verplicht")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime InvoiceDate { get; set; }


        [DisplayName("Vervaldatum:")]
        [Required(ErrorMessage = "Vervaldatum is verplicht")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DueDate { get; set; }


        [Required]
        [DisplayName("Status (Open, Paid):")]   // O, P, geregeld in achtergrond
        public char Status { get; set; }

        // BUG in MSSM (Microsoft SQL Sever Management): een bool kolom mag niet SEND heten!
        // https://eur03.safelinks.protection.outlook.com/?url=https%3A%2F%2Fstackoverflow.com%2Fquestions%2F63469145%2Fchanging-data-in-ms-sql-management-studio-ssms-with-bit-field-named-send-fai&data=02%7C01%7C%7C62fbbdb55de143a23d3008d86c57d723%7C84df9e7fe9f640afb435aaaaaaaaaaaa%7C1%7C0%7C637378471805665540&sdata=DXpOsIEGlMw%2BDd1g%2Blt%2BEgLRHeOd6COblXkAdWuKDC0%3D&reserved=0

        [Required]
        [DisplayName("Verzonden (?):")]   // Geregeld in achtergrond
        public bool InvoiceSend { get; set; } // Naam dus veranderd van Send naar InvoiceSend

    }
}
