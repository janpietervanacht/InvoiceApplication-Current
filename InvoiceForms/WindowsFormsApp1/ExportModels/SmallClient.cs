using System;
using System.Collections.Generic;
using System.Text;

namespace InvoiceForms.ExportModels
{
    public class SmallClient: BaseClient
    {
        public string OmschrijvingKleineKlant
        {
            get
            {
                return $"Kleine klant met nummer {Klantnummer}"; 
            }
            set // set is nodig, anders neemt XML-serializer deze prop niet mee
            {

            }
        }
    }
}
