using InvoiceForms.ConstantsAndEnums;
using InvoiceForms.DTOModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InvoiceForms.Forms
{
    public partial class FrmClientsWithWebApi : Form
    {
        private readonly HttpClient _client;
        DTOClient _selectedItem; 

        public FrmClientsWithWebApi()
        {
            InitializeComponent();
            _client = new HttpClient(); 
        }

        // ZET in de ListView PROPERTY View OP 'Details'

        private void FrmClientsWithWebApi_Load(object sender, EventArgs e)
        {
            // Haal lijst van DTOClients op via Web Api: 

            LabelStatusMessage.Text = "Retrieving clients from Web Api.....";
            RichTextBoxClientDetails.Text = "";
            RichTextBoxStatistics.Text = "";
            ButtonDeleteInvoices.Visible = false; 


            RetrieveDTOClientList();

            // Het vullen van ListViewClienten moet in de asynchrone thread 
            // en niet hier, dit omdat deze thread meteen doorloopt als de
            // asynchrone thread nog aan het ophalen is van gegevens uit de WEB API
        }

        public async Task RetrieveDTOClientList()
        {
            string jsonString;
            List<DTOClient> listDTOClients = null; 

            try
            {
                var Url = "https://localhost:44302/Clients";
                // De code hieronder in springt in zijn geheel naar een nieuwe thread
                var stringTask = _client.GetStringAsync(Url);
                // De routine die deze Task heeft aangeroepen loopt vanaf nu meteen door. 
                jsonString = await stringTask; // in debug mode F11 zie je dat het even tijd kost!
                listDTOClients = JsonConvert.DeserializeObject<List<DTOClient>>(jsonString);
            }
            catch(Exception ex)
            {
                // Nog ff niets
            }

            // Het vullen van ListViewClienten moet hier: in deze thread 

            ListViewClienten.Items.Clear();
            foreach (var DTOclient in listDTOClients)
            {
                var row = new string[]
                    {
                        DTOclient.Klantnummer.ToString(),
                        DTOclient.Voornaam + " " + DTOclient.Achternaam,
                        DTOclient.LandcodeIso
                    };
                var listViewItem = new ListViewItem(row)
                {
                    Tag = DTOclient // onder water kan je via Tag een volledige Client aan de rij koppelen
                };
                ListViewClienten.Items.Add(listViewItem);
                LabelStatusMessage.Text = "Done";

            }
        }

        private void ListViewClienten_SelectedIndexChanged(object sender, EventArgs e)
        {
            ButtonDeleteInvoices.Visible = false;
           

            try
            {
                var selectedItem = (DTOClient)ListViewClienten.SelectedItems[0].Tag;
                if (selectedItem != null)
                {
                    _selectedItem = selectedItem; 
                    ButtonDeleteInvoices.Visible = true;
                    ButtonDeleteInvoices.Text = $"Verwijder facturen van {selectedItem.Klantnummer}"; 
                    FillRichTextBoxClient(selectedItem);
                    RetrieveStatistics(selectedItem);
                }

            }
            catch (Exception)
            {
            }
        }


        private void FillRichTextBoxClient(DTOClient selectedItem)
        {
            LabelStatusMessage.Text = "";
            var result = $"Client Voornaam     : {selectedItem.Voornaam}\n" +
                         $"Client Achternaam   : {selectedItem.Achternaam}\n" +
                         $"Client Klantnummer  : {selectedItem.Klantnummer}\n" +
                         $"Client Geboortedatum: " +
                    $"{selectedItem.GeboorteDatum.ToString("dd MMM yyyy", Const.CultureDutch.DateTimeFormat)}\n\n";

            result += "Factuurnummers:\n";
            foreach (var invString in selectedItem.FaktuurNummers)
            {
                result += invString + "\n";
            }
            RichTextBoxClientDetails.Text = result;
        }

        public async Task RetrieveStatistics(DTOClient dtoClient)
        {
            string jsonString;
            var clientNumberAlfa = dtoClient.Klantnummer.ToString().PadLeft(6, '0');

            DTOClientStatistics dtoClientStatistics = null;

            try
            {
                var url = "https://localhost:44302/Clients/GetStatisticsByClientNumber/" + clientNumberAlfa;
                // De code hieronder in springt in zijn geheel naar een nieuwe thread
                var stringTask = _client.GetStringAsync(url);
                // De routine die deze Task heeft aangeroepen loopt vanaf nu meteen door. 
                jsonString = await stringTask; // in debug mode F11 zie je dat het even tijd kost!
                dtoClientStatistics = JsonConvert.DeserializeObject<DTOClientStatistics>(jsonString);
            }
            catch
            {
                // Nog ff niets
            }

            // Het vullen van RichTextBox voor statistieken: gebeurt hier IN DEZE THREAD ! 
            var result = $"Client Klantnummer         : {dtoClientStatistics.Klantnummer}\n" +
                         $"Client Volledige naam      : {dtoClientStatistics.VolledigeNaamKlant}\n" +
                         $"Client # facturen          : {dtoClientStatistics.AantalFacturen}\n" +
                         $"Client TotaalFactuurbedrag : {dtoClientStatistics.TotaalFactuurBedrag}\n" +
                         $"Client #letters voornaam   : {dtoClientStatistics.AantalLettersVoorNaamKlantZonderSpaties}\n" +
                         $"Client #letters achternaam : {dtoClientStatistics.AantalLettersAchterNaamKlantZonderSpaties}\n\n";

            result += "Factuurnummers:\n";
            foreach (var invString in dtoClientStatistics.FactuurNummers)
            {
                result += invString + "\n";
            }
            RichTextBoxStatistics.Text = result; 
        }

        private void ButtonDeleteInvoices_Click(object sender, EventArgs e)
        {
            if (_selectedItem == null)
            {
                return;
            }

            // Stuur Web Api boodschap voor delete van alle facturen

            DeleteAllInvoices();

        }

        public async Task DeleteAllInvoices()
        {
            HttpResponseMessage httpResponseMessage;
            var clientNumberAlfa = _selectedItem.Klantnummer.ToString().PadLeft(6, '0');

            try
            {
                var url = "https://localhost:44302/Clients/DeleteAllInvoicesForOneClientNumber/" + clientNumberAlfa;
                var stringTask = _client.DeleteAsync(url);
                httpResponseMessage = await stringTask;  // wacht op succesvolle delete
                // de code hieronder gaat ook door in sub thread: herlaad de lijst
                FrmClientsWithWebApi_Load(null, null); 
            }
            catch
            {
                // Nog ff niets
            }
        }
    }
}
