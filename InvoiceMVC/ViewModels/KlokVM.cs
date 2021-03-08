using Model.ConstantsAndEnums;
using System;

namespace InvoiceMVC.ViewModels
{
    public class KlokVM
    {
        public string KlokTijd
        {
            // KlokTijd wordt automatisch gevuld: 
            get
            {
                // niet: "dd/mm/yyyy HH:mm:ss"
                return DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss", Const.cCultureDutch.DateTimeFormat); 
            }  
        } 
    }
}
