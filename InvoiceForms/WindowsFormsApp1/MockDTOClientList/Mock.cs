using InvoiceForms.DTOModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace InvoiceForms.MockDTOClientList
{
    public static class Mock
    {
        public static List<DTOClient> CreateListDTOClients()
        {
            var result = new List<DTOClient>
            {
                new DTOClient
                {
                    BijNaam = "BijNaam klant 100001",
                    Achternaam = "Achternaam klant 100001",
                    FaktuurNummers = new List<string>{"10000001", "10000002"},
                    GeboorteDatum = new DateTime(1967, 3, 1),
                    Geslacht = 'M',
                    IsVerzekerd = true,
                    Klantnummer = 100001,
                    LandcodeIso = "NL",
                    LengteKlantInMeters = 1.81f,
                    Voornaam = "Voornaam klant 100001"
                },

                new DTOClient
                {
                    BijNaam = "BijNaam klant 100002",
                    Achternaam = "Achternaam klant 100002",
                    FaktuurNummers = new List<string>{"20000001", "20000002"},
                    GeboorteDatum = new DateTime(1967, 4, 2),
                    Geslacht = 'V',
                    IsVerzekerd = false,
                    Klantnummer = 100002,
                    LandcodeIso = null,
                    LengteKlantInMeters = 1.82f,
                    Voornaam = "Voornaam klant 100002"
                },

            };

            return result; 
        }
    }
}
