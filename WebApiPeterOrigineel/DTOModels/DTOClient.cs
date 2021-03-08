using Model;
using Model.ConstantsAndEnums;
using System;
using System.Collections.Generic;

namespace WebApiPeterOrigineel.DTOModels
{
    public class DTOClient
    {
        // public int Id { get; set; } NIET BIJ INKOMENDE CLIENT 
        // public int ClientNumber { get; set; }  // automatische generatie

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

        public string BijNaam { get; set; }
        public float LengteKlantInMeters { get; set; }
    }
}
