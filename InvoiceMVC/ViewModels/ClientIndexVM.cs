using Model;
using System.Collections.Generic;
using System.Linq;

namespace InvoiceMVC.ViewModels
{
    public class ClientIndexVM
    {
        public KlokVM KlokVM { get; set; }

        // NrOfClients hoef je nooit te setten
        public int NrOfItems
        {
            get
            {
                return ListOfItems.Count(); 
            }
        }
        public List<ClientVM> ListOfItems { get; set; }

    }
}
