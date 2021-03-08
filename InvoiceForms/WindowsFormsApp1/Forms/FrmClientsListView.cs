using Business.Interfaces;
using InvoiceForms.ExportFolder;
using InvoiceForms.ExportModels;
using Model;
using System;
using System.Windows.Forms;
using InvoiceForms.ConstantsAndEnums;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace InvoiceForms.Forms
{
    public partial class FrmClientsListView : Form
    {
        readonly IClientManager _clientManager;
        readonly IConfiguration _config;
        readonly string _initialDirectoryForExport; 


        List<Client> listClients;

        public FrmClientsListView(IClientManager clientManager)
        {
            InitializeComponent();
            _clientManager = clientManager;

            // appsettings.json 
           _config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .Build();

            _initialDirectoryForExport = _config.GetSection("appsettings")["DefaultFolderExport"];
            if (!Directory.Exists(_initialDirectoryForExport))
            {
                Directory.CreateDirectory(_initialDirectoryForExport);
            }
        }

        private void FrmClientsListView_Load(object sender, EventArgs e)
        {
            listClients = _clientManager.GetAllClientsIncludingInvoices();

            ListViewClienten.Items.Clear();
            foreach (var client in listClients)
            {
                var row = new string[]
                    {
                        client.ClientNumber.ToString(),
                        client.FirstName,
                        client.NickName,
                        client.LengthInMeters.ToString()  
                    };
                var listViewItem = new ListViewItem(row)
                {
                    Tag = client // onder water kan je een volledige Client aan de rij koppelen
                };
                ListViewClienten.Items.Add(listViewItem);
            }
        }

        private void ListViewClienten_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Dankzij de try parse kan je achter elkaar meerdere clienten selecteren
            // Zonder try parse  gaat dat fout vanaf de 2e geselecteerde client
            try
            {
                var selectedItem = (Client) ListViewClienten.SelectedItems[0].Tag;
                if (selectedItem != null)
                {
                    var result = 
                              $"Client Voornaam     : {selectedItem.FirstName} " +
                            $"\nClient Achternaam   : {selectedItem.LastName} " +
                            $"\nClient Klantnummer  : {selectedItem.ClientNumber} " +
                            $"\nClient Geboortedatum: {selectedItem.BirthDate:dd MMM yyyy}" + 
                            $"\nClient Lengte (m)   : {selectedItem.LengthInMeters}";
                    // MessageBox.Show(result); Mag ook
                    RichTextBox1.Text = result;
                }
            }
            catch (Exception)
            {
            }

            // SelectedItems is enumerable, zie intellisense en de parent classes

        }

        private void ButtonBigClientToXML_Click(object sender, EventArgs e)
        {
            var saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text filetje|*.txt|XML filetje|*.xml";
            saveFileDialog.Title = "Save je Grote Klant naar TXT of xml file";
            saveFileDialog.InitialDirectory = _initialDirectoryForExport; 
            saveFileDialog.RestoreDirectory = true;

            saveFileDialog.ShowDialog();
            if (saveFileDialog.FileName != "")
            {
                Export<SmallClient>.ExportClientToXML(listClients, saveFileDialog.FileName, _config);
            }
        }

        private void ButtonBigClientToJSON_Click(object sender, EventArgs e)
        {
            var saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text filetje|*.txt|JSON filetje|*.json";
            saveFileDialog.Title = "Save je Grote Klant naar TXT of JSON file";
            saveFileDialog.InitialDirectory = _initialDirectoryForExport;
            saveFileDialog.ShowDialog();
            if (saveFileDialog.FileName != "")
            {
                Export<BigClient>.ExportClientToJSON(listClients, saveFileDialog.FileName, _config);
            }
        }

        private void ButtonSmallClientToXML_Click(object sender, EventArgs e)
        {
            var saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text filetje|*.txt|XML filetje|*.xml";
            saveFileDialog.Title = "Save je text of xml file, knul!";
            saveFileDialog.Title = "Save je Kleine Klant naar TXT of XML file";
            saveFileDialog.InitialDirectory = _initialDirectoryForExport;
            saveFileDialog.ShowDialog();
            if (saveFileDialog.FileName != "")
            {
                Export<SmallClient>.ExportClientToXML(listClients, saveFileDialog.FileName, _config);
            }
        }

        private void ButtonSmallClientToJSON_Click(object sender, EventArgs e)
        {
            var saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text filetje|*.txt|JSON filetje|*.json";
            saveFileDialog.Title = "Save je Kleine Klant naar TXT of JSON file, knul!";
            saveFileDialog.InitialDirectory = _initialDirectoryForExport;
            saveFileDialog.ShowDialog();
            if (saveFileDialog.FileName != "")
            {
                Export<SmallClient>.ExportClientToJSON(listClients, saveFileDialog.FileName, _config);
            }
        }
    }
}
