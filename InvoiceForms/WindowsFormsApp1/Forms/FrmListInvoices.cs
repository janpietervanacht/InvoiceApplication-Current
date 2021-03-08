using Business.Interfaces;
using Model;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace InvoiceForms.Forms
{
    public partial class FrmListInvoices : Form
    {

        readonly IInvoiceManager _invoiceManager;

       // DI is klaargezet in StartMenuForm en bevat de 
       // registratie van Managers. 
        public FrmListInvoices(IInvoiceManager invoiceManager)
        {
            InitializeComponent();
            _invoiceManager = invoiceManager;
        }

        private void FrmListInvoices_Load(object sender, EventArgs e)
        {
            var listInvoices = _invoiceManager.GetAll(0); // Fact van alle clienten

            // Vergeet niet: prop ListViewInvoices.View op Details te zetten bij het design!!
            // Kan ook hieronder (niet aanbevolen, doe het in het design, dan zie je ook
            // de kolommen in het design) 
            // ListViewInvoices.View = View.Details;   // View is : enum System.Windows.Forms.View

            ListViewInvoices.Items.Clear();
            foreach (var invoice in listInvoices)
            {
                var row = new string[]
                {
                    invoice.InvoiceNumber.ToString(),
                    invoice.InvoiceDescription
                };
                var listViewItem = new ListViewItem(row)
                {
                    Tag = invoice
                };
                ListViewInvoices.Items.Add(listViewItem); 
            }
        }
    }
}
