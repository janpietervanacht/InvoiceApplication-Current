namespace InvoiceForms.Forms
{
    partial class FrmListInvoices
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ListViewInvoices = new System.Windows.Forms.ListView();
            this.invoiceNumber = new System.Windows.Forms.ColumnHeader();
            this.invoiceDescription = new System.Windows.Forms.ColumnHeader();
            this.SuspendLayout();
            // 
            // ListViewInvoices
            // 
            this.ListViewInvoices.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.invoiceNumber,
            this.invoiceDescription});
            this.ListViewInvoices.FullRowSelect = true;
            this.ListViewInvoices.GridLines = true;
            this.ListViewInvoices.HideSelection = false;
            this.ListViewInvoices.Location = new System.Drawing.Point(67, 52);
            this.ListViewInvoices.Name = "ListViewInvoices";
            this.ListViewInvoices.Size = new System.Drawing.Size(1000, 500);
            this.ListViewInvoices.TabIndex = 2;
            this.ListViewInvoices.UseCompatibleStateImageBehavior = false;
            this.ListViewInvoices.View = System.Windows.Forms.View.Details;
            // 
            // invoiceNumber
            // 
            this.invoiceNumber.Text = "Factuur nr";
            this.invoiceNumber.Width = 200;
            // 
            // invoiceDescription
            // 
            this.invoiceDescription.Text = "Factuur Omschrijving";
            this.invoiceDescription.Width = 200;
            // 
            // FrmListInvoices
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1486, 719);
            this.Controls.Add(this.ListViewInvoices);
            this.Name = "FrmListInvoices";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lijst met facturen";
            this.Load += new System.EventHandler(this.FrmListInvoices_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView ListViewInvoices;
        private System.Windows.Forms.ColumnHeader invoiceNumber;
        private System.Windows.Forms.ColumnHeader invoiceDescription;
    }
}