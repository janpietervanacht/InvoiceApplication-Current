using Business.Interfaces;
using InvoiceForms.DependencyInfra;
using System.Windows.Forms;

namespace InvoiceForms.Forms
{
    public partial class FrmMainMenu : Form
    {

        readonly IClientManager _clientManager; 
        readonly IInvoiceManager _invoiceManager; 
        public FrmMainMenu()
        {
            InitializeComponent();

            // Dependency injection doe je één keer, namelijk in dit startscherm
            // We moeten werken met de out variabelen, dat zijn allemaal nieuwe managers
            // Dit principe van out variabelen moet ook voor DI bij het background project
            // dat een console project is.

            // DI: in de constructor van een object zitten alle objecten die dit object
            // gebruikt. Al deze objecten zijn geadministreerd als DI.
            Dependency.InitialiseerDI(out _clientManager,
            out _invoiceManager);

        }

        private void SchermenFacturen_Click(object sender, System.EventArgs e)
        {
            var frmListInvoices = new FrmListInvoices(_invoiceManager);
            // frmListInvoices.Show(); // Non Modal (parent form also accessible) 
            frmListInvoices.ShowDialog(); // Modal (lock parent form)
        }

        private void MenuClientWebApi_MouseHover(object sender, System.EventArgs e)
        {
            // Nieuw scherm start op als je met de muis erover heen beweegt
            var frmClientsWithWebApi = new FrmClientsWithWebApi();
            frmClientsWithWebApi.ShowDialog(); // Modal (lock parent form)
        }

        private void MenuExportFacturen_Click(object sender, System.EventArgs e)
        {
            // Nieuw scherm start op als je met de muis erover heen beweegt
            var frmExportInvoices = new FrmExportInvoices();  
            frmExportInvoices.ShowDialog(); // Modal (lock parent form)
        }

        private void MenuItemClientsInListView_Click(object sender, System.EventArgs e)
        {
            //var frmLijstClienten = new FrmLijstClienten
            //{
            // ZET OOK property IsMdiContainer op true voor de FrmMainMenu
            //    MdiParent = this // LijstClienten komt binnen de form FrmMainMenu
            //};
            //frmLijstClienten.Show();

            var frmClientsListView = new FrmClientsListView(_clientManager);
            frmClientsListView.Show(); // Non Modal (parent form also accessible) 
        }

        private void MenuItemClientsInDataGridView_Click(object sender, System.EventArgs e)
        {
            var frmClientsTextBox = new FrmClientsTextBox(_clientManager);
            frmClientsTextBox.Show(); // Non Modal (parent form also accessible) 
        }
    }
}
