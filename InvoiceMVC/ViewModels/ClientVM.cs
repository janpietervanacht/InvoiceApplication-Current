using Model;
using Model.ConstantsAndEnums;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace InvoiceMVC.ViewModels
{
    public class ClientVM   // SVP Niet: ClientDetailsVM noemen
                            // Want er is een shared view voor Details/Add/Update/Delete
    {
        public Client Client { get; set; }

        // In dit ViewModel nemen we alle landen mee
        // zodat we in de CREATE CLIENT / UPDATE CLIENT dropdownlist 
        // alle landen kunnen tonen met hun omschrijvingen.

        // Let op: bij de DETAILS en DELETE moet je een lijst van 1 land naar de 
        // view sturen, namelijk het land van de betreffende klant.
        // En een klant hoeft geen land te hebben. 

        // Ik gebruik een afgeleide Get-Property om Nederlands formaat als datums te tonen
        // Alleen in de Client Index: 
        public string BirthDateAsString 
        { 
            get
            {
                return Client.BirthDate.ToString("dd MMMM yyyy", Const.cCultureDutch.DateTimeFormat);
            }   
        }
        public List<Country> ListOfCountries { get; set; }

        [DisplayName("Aantal facturen:")]
        public int NumberOfInvoices { get; set; }

        // ClientFullName hoef je nooit te setten
        [DisplayName("Volledige naam client:")]
        public string ClientFullName
        {
            get
            {
                return Client.FirstName + " " + Client.LastName;
            }
        }
        public KlokVM KlokVM { get; set;  }

    }
}
