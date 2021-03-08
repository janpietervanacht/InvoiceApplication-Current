using System;
using System.Collections.Generic;
using System.Text;

namespace InvoiceForms.ExportModels
{
    public class BigClient: BaseClient
    {
        public string OmschrijvingGroteKlant
        {
            get
            {
                return $"Grote klant met nummer {Klantnummer}";
            }
            set // set is nodig, anders neemt XML-serializer deze prop niet mee
            {

            }
        } 

    }
}
