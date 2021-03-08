using Business.Interfaces;
using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace InvoiceForms.Forms
{
    public partial class FrmClientsTextBox : Form
    {
        readonly IClientManager _clientManager;

        public FrmClientsTextBox(IClientManager clientManager)
        {
            InitializeComponent();
            _clientManager = clientManager; 
        }

        private void FrmListClients_Load(object sender, EventArgs e)
        {
            var listClients = _clientManager.GetAllClientsWithoutInvoices();

            // Kopieer de lijst van <Client> objecten naar een nieuwe lijst van 1 string per lijstelement: 

            var listClientStrings = listClients.Select
                (
                  c =>
                  c.ClientNumber + ";" + 
                  c.FirstName + ";" + 
                  c.LastName + ";" + 
                  c.BirthDate.ToString("dd-MM-yyyy") 
                ).ToList();

            StringBuilder stringBuilder = new StringBuilder();
             
            using (var stringWriter = new StringWriter(stringBuilder)) // using ruimt alle connecties op 
            {
                foreach (var clientString in listClientStrings)
                {
                    stringWriter.WriteLine(clientString);
                }
                //stringWriter.Flush();  // NIET MEER NODIG
                //stringWriter.Close();  // IDEM 
            }

            using (var stringReader = new StringReader(stringBuilder.ToString())) // using ruimt alle connecties op 
            {
                while (stringReader.Peek() > -1) // character ahead
                {
                    // Read a line from the string and display it
                    var result = stringReader.ReadLine() + "\n";
                    richTextBox1.Text += result;
                }
                //stringReader.Close();  // NIET MEER NODIG 
            }
        }
    }
}
