using System;
using System.Collections.Generic;

namespace InvoiceForms.DTOModels
{
    public class DTOClientStatistics
    {
        public int Klantnummer { get; set; }

        public string VolledigeNaamKlant { get; set; }

        public int AantalFacturen { get; set; }

        public decimal TotaalFactuurBedrag { get; set; }

        public List<string> FactuurNummers { get; set; }

        public int AantalLettersVoorNaamKlantZonderSpaties { get; set; }

        public int AantalLettersAchterNaamKlantZonderSpaties { get; set; }

    }
}
