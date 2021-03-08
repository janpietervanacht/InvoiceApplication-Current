namespace InvoiceForms.Forms
{
    partial class FrmClientsWithWebApi
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
            this.ListViewClienten = new System.Windows.Forms.ListView();
            this.ClientNumber = new System.Windows.Forms.ColumnHeader();
            this.ClientFullName = new System.Windows.Forms.ColumnHeader();
            this.CountryCode = new System.Windows.Forms.ColumnHeader();
            this.RichTextBoxClientDetails = new System.Windows.Forms.RichTextBox();
            this.LabelStatusMessage = new System.Windows.Forms.Label();
            this.RichTextBoxStatistics = new System.Windows.Forms.RichTextBox();
            this.Label2InfoClient = new System.Windows.Forms.Label();
            this.LabelStatistiekClient = new System.Windows.Forms.Label();
            this.ButtonDeleteInvoices = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ListViewClienten
            // 
            this.ListViewClienten.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ClientNumber,
            this.ClientFullName,
            this.CountryCode});
            this.ListViewClienten.HideSelection = false;
            this.ListViewClienten.Location = new System.Drawing.Point(53, 68);
            this.ListViewClienten.Name = "ListViewClienten";
            this.ListViewClienten.Size = new System.Drawing.Size(1349, 258);
            this.ListViewClienten.TabIndex = 0;
            this.ListViewClienten.UseCompatibleStateImageBehavior = false;
            this.ListViewClienten.View = System.Windows.Forms.View.Details;
            this.ListViewClienten.SelectedIndexChanged += new System.EventHandler(this.ListViewClienten_SelectedIndexChanged);
            // 
            // ClientNumber
            // 
            this.ClientNumber.Text = "Klant nr";
            this.ClientNumber.Width = 100;
            // 
            // ClientFullName
            // 
            this.ClientFullName.Text = "Gehele naam";
            this.ClientFullName.Width = 500;
            // 
            // CountryCode
            // 
            this.CountryCode.Text = "Land";
            this.CountryCode.Width = 50;
            // 
            // RichTextBoxClientDetails
            // 
            this.RichTextBoxClientDetails.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.RichTextBoxClientDetails.Location = new System.Drawing.Point(53, 403);
            this.RichTextBoxClientDetails.Name = "RichTextBoxClientDetails";
            this.RichTextBoxClientDetails.Size = new System.Drawing.Size(659, 231);
            this.RichTextBoxClientDetails.TabIndex = 1;
            this.RichTextBoxClientDetails.Text = "";
            // 
            // LabelStatusMessage
            // 
            this.LabelStatusMessage.AutoSize = true;
            this.LabelStatusMessage.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LabelStatusMessage.ForeColor = System.Drawing.Color.Red;
            this.LabelStatusMessage.Location = new System.Drawing.Point(53, 18);
            this.LabelStatusMessage.Name = "LabelStatusMessage";
            this.LabelStatusMessage.Size = new System.Drawing.Size(140, 25);
            this.LabelStatusMessage.TabIndex = 3;
            this.LabelStatusMessage.Text = "Status message";
            // 
            // RichTextBoxStatistics
            // 
            this.RichTextBoxStatistics.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.RichTextBoxStatistics.Location = new System.Drawing.Point(738, 403);
            this.RichTextBoxStatistics.Name = "RichTextBoxStatistics";
            this.RichTextBoxStatistics.Size = new System.Drawing.Size(664, 228);
            this.RichTextBoxStatistics.TabIndex = 4;
            this.RichTextBoxStatistics.Text = "";
            // 
            // Label2InfoClient
            // 
            this.Label2InfoClient.AutoSize = true;
            this.Label2InfoClient.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Label2InfoClient.ForeColor = System.Drawing.Color.Black;
            this.Label2InfoClient.Location = new System.Drawing.Point(53, 351);
            this.Label2InfoClient.Name = "Label2InfoClient";
            this.Label2InfoClient.Size = new System.Drawing.Size(96, 25);
            this.Label2InfoClient.TabIndex = 3;
            this.Label2InfoClient.Text = "Info client";
            // 
            // LabelStatistiekClient
            // 
            this.LabelStatistiekClient.AutoSize = true;
            this.LabelStatistiekClient.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LabelStatistiekClient.ForeColor = System.Drawing.Color.Black;
            this.LabelStatistiekClient.Location = new System.Drawing.Point(738, 351);
            this.LabelStatistiekClient.Name = "LabelStatistiekClient";
            this.LabelStatistiekClient.Size = new System.Drawing.Size(140, 25);
            this.LabelStatistiekClient.TabIndex = 3;
            this.LabelStatistiekClient.Text = "Statistiek Client";
            // 
            // ButtonDeleteInvoices
            // 
            this.ButtonDeleteInvoices.Location = new System.Drawing.Point(309, 347);
            this.ButtonDeleteInvoices.Name = "ButtonDeleteInvoices";
            this.ButtonDeleteInvoices.Size = new System.Drawing.Size(373, 29);
            this.ButtonDeleteInvoices.TabIndex = 5;
            this.ButtonDeleteInvoices.Text = "Verwijder Facturen";
            this.ButtonDeleteInvoices.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ButtonDeleteInvoices.UseVisualStyleBackColor = true;
            this.ButtonDeleteInvoices.Click += new System.EventHandler(this.ButtonDeleteInvoices_Click);
            // 
            // FrmClientsWithWebApi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1484, 711);
            this.Controls.Add(this.ButtonDeleteInvoices);
            this.Controls.Add(this.RichTextBoxStatistics);
            this.Controls.Add(this.LabelStatistiekClient);
            this.Controls.Add(this.Label2InfoClient);
            this.Controls.Add(this.LabelStatusMessage);
            this.Controls.Add(this.RichTextBoxClientDetails);
            this.Controls.Add(this.ListViewClienten);
            this.MaximumSize = new System.Drawing.Size(1500, 750);
            this.Name = "FrmClientsWithWebApi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Clienten via WEB API";
            this.Load += new System.EventHandler(this.FrmClientsWithWebApi_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        // ZET in de ListView PROPERTY View OP 'Details'
        private System.Windows.Forms.ListView ListViewClienten;
        
        private System.Windows.Forms.ColumnHeader ClientNumber;
        private System.Windows.Forms.ColumnHeader ClientFullName;
        private System.Windows.Forms.ColumnHeader CountryCode;
        private System.Windows.Forms.RichTextBox RichTextBoxClientDetails;
        private System.Windows.Forms.Label LabelStatusMessage;
        private System.Windows.Forms.RichTextBox RichTextBoxStatistics;
        private System.Windows.Forms.Label Label2InfoClient;
        private System.Windows.Forms.Label LabelStatistiekClient;
        private System.Windows.Forms.Button ButtonDeleteInvoices;
    }
}