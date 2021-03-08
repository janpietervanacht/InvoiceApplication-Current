using Model;
using System.Collections.Generic;
using System.Linq;

namespace InvoiceMVC.ViewModels
{
    public class InvoiceIndexVM
    {
       
        //----------------------------------
        public List<InvoiceVM> ListOfItems { get; set; }

        public string ClientFullName { get; set; }
        public int ClientNumber { get; set; }
        // NrOfItems hoef je nooit te setten

        public int NrOfItems
        {
            get
            {
                return ListOfItems.Count();
            }
        }
    }
}
