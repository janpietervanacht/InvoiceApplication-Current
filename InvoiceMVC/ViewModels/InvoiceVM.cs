using Model;
using Model.ConstantsAndEnums;

namespace InvoiceMVC.ViewModels
{
    public class InvoiceVM  
    {
        // InvoiceVM bevat alle velden van Invoice, plus extra afgeleide velden
        public Invoice Invoice { get; set; }

        // Afgeleide velden: 

        // InvoiceVM maakt een string aan voor de datum
        // Dit via een Get Property hieronder, die uit Invoice de InvoiceDate property omzet
        public string InvoiceDateAsString
        {
            get
            {
                // retourneert bijv "11 augustus 1943": 
                return Invoice.InvoiceDate.ToString("dd MMMM yyyy", Const.cCultureDutch.DateTimeFormat);
            }
        }
        // Om didactische redenen, is DueDate wèl als DateTime veld naar de Invoice Index view gestuurd. 

        // In het lijstscherm kan je ToBeExported aanvinken via een CheckBoxFor
        public bool ToBeExported { get; set; }
    }
}
