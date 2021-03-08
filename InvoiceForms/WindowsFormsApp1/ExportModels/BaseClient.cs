using System;
using System.Collections.Generic;

namespace InvoiceForms.ExportModels
{
    // Alle clienten erven van deze class
    // Dwz ze hebben al deze properties.
    // Deze class kan je niet instantiëren, dus ook niet exporteren
    public abstract class BaseClient: IExportClient 
    {
        public int Klantnummer { get; set; }

        public char Geslacht { get; set; }

        public string Voornaam { get; set; }

        public string Achternaam { get; set; }

        public DateTime GeboorteDatum { get; set; }

        public bool IsVerzekerd { get; set; }

        public string LandcodeIso { get; set; }   //  Mag leeg zijn

        //---------------------------------------
        // Onderstaande gaat fout!! 
        // Bij aanmaak van uitgaande JSON van clienten zijn er bijvoorbeeld 3 invoices
        // voor één client. 
        // Maar die 3 invoices wijzen ook weer naar dezelfde client
        // en die client wijst weer naar die 3 invoices (oneindige diepte nesting  > 32)

        // public List<Invoice> ListOfInvoices { get; set;  }
        //---------------------------------------

        // Hieronder: lijst van strings gemaakt ipv lijst van ints
        // Want anders lukt het niet in ClientsController
        public List<string> FaktuurNummers { get; set; }
        public DateTime DateTimeCreated { get; set; } // verplicht vanuit interface

        public string BijNaam { get; set; }

        public float LengteKlantInMeters { get; set; }

    }
}
