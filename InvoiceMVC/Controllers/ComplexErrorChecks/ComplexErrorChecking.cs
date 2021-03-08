using InvoiceMVC.ViewModels;
using Model.ConstantsAndEnums;
using System;

namespace InvoiceMVC.Controllers.ComplexErrorChecks
{
    static internal class ComplexErrorChecking
    {
        internal static string CheckForClientVMErrors(ClientVM clientVM)
        {
            string result = null;

            // Gebruik Nederlandse volledige namen van maanden: 11 augustus 1943 
            // Alle clienten uit clientVM.Client.BirthDate mogen niet ouder zijn dan tante Betsie
            var gebDatumTanteBetsie = new DateTime(1943, 08, 11);  
            if (clientVM.Client.BirthDate < gebDatumTanteBetsie)
            {

                // Retourneert 11-08-1943
                result = $"Geboortedatum is eerder dan " +
                    $"{gebDatumTanteBetsie.ToString("dd MMMM yyyy", Const.cCultureDutch.DateTimeFormat)} ";

                return result; 
            }

            // Check dat de naam Trump niet voorkomt in voornaam / achternaam
            if (clientVM.Client.FirstName.ToLower().Contains("trump"))
            {
                result = $"De voornaam \"{clientVM.Client.FirstName}\" " +
                    $"bevat de naam \'Trump\' ";

                return result;
            }

            if (clientVM.Client.LastName.ToLower().Contains("trump"))
            {
                result = $"De achternaam \"{clientVM.Client.LastName}\" " +
                    $"bevat de naam \'Trump\' ";

                return result;
            }

            return null; // No error
        }
    }
}
