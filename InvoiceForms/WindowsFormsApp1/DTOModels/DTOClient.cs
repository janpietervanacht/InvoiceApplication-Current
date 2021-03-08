// Deze Windows Forms communiceert met WebApiPeter

using System;
using System.Collections.Generic;

namespace InvoiceForms.DTOModels
{
    public class DTOClient // komt uit WebApiPeter
    {

        public int Klantnummer { get; set; }

        public char Geslacht { get; set; }

        public string Voornaam { get; set; }

        public string Achternaam { get; set; }

        public DateTime GeboorteDatum { get; set; }

        public bool IsVerzekerd { get; set; }

        public string LandcodeIso { get; set; }   //  Mag leeg zijn
        
        public List<string> FaktuurNummers { get; set; }

        public string BijNaam { get; set; }
        public float LengteKlantInMeters { get; set; }
    }
}
