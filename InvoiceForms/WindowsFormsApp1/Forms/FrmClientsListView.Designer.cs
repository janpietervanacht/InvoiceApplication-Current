namespace InvoiceForms.Forms
{
    partial class FrmClientsListView
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
            this.FirstName = new System.Windows.Forms.ColumnHeader();
            this.NickName = new System.Windows.Forms.ColumnHeader();
            this.LengthInMeters = new System.Windows.Forms.ColumnHeader();
            this.LblTitel = new System.Windows.Forms.Label();
            this.RichTextBox1 = new System.Windows.Forms.RichTextBox();
            this.ButtonBigClientToXML = new System.Windows.Forms.Button();
            this.ButtonBigClientToJSON = new System.Windows.Forms.Button();
            this.ButtonSmallClientToXML = new System.Windows.Forms.Button();
            this.ButtonSmallClientToJSON = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ListViewClienten
            // 
            this.ListViewClienten.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ClientNumber,
            this.FirstName,
            this.NickName,
            this.LengthInMeters});
            this.ListViewClienten.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ListViewClienten.FullRowSelect = true;
            this.ListViewClienten.GridLines = true;
            this.ListViewClienten.HideSelection = false;
            this.ListViewClienten.Location = new System.Drawing.Point(67, 52);
            this.ListViewClienten.Name = "ListViewClienten";
            this.ListViewClienten.Size = new System.Drawing.Size(1084, 384);
            this.ListViewClienten.TabIndex = 2;
            this.ListViewClienten.UseCompatibleStateImageBehavior = false;
            this.ListViewClienten.View = System.Windows.Forms.View.Details;
            this.ListViewClienten.SelectedIndexChanged += new System.EventHandler(this.ListViewClienten_SelectedIndexChanged);
            // 
            // ClientNumber
            // 
            this.ClientNumber.Text = "Klantnr";
            this.ClientNumber.Width = 100;
            // 
            // FirstName
            // 
            this.FirstName.Text = "Voornaam";
            this.FirstName.Width = 300;
            // 
            // NickName
            // 
            this.NickName.Text = "Bijnaam";
            this.NickName.Width = 200;
            // 
            // LengthInMeters
            // 
            this.LengthInMeters.Text = "Len";
            // 
            // LblTitel
            // 
            this.LblTitel.AutoSize = true;
            this.LblTitel.Location = new System.Drawing.Point(43, 13);
            this.LblTitel.Name = "LblTitel";
            this.LblTitel.Size = new System.Drawing.Size(188, 20);
            this.LblTitel.TabIndex = 3;
            this.LblTitel.Text = "Lijst van Clienten (ListView)";
            // 
            // RichTextBox1
            // 
            this.RichTextBox1.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.RichTextBox1.ForeColor = System.Drawing.Color.Green;
            this.RichTextBox1.Location = new System.Drawing.Point(67, 480);
            this.RichTextBox1.Name = "RichTextBox1";
            this.RichTextBox1.Size = new System.Drawing.Size(1084, 236);
            this.RichTextBox1.TabIndex = 4;
            this.RichTextBox1.Text = "Japie\nSlapie";
            // 
            // ButtonBigClientToXML
            // 
            this.ButtonBigClientToXML.Location = new System.Drawing.Point(1169, 71);
            this.ButtonBigClientToXML.Name = "ButtonBigClientToXML";
            this.ButtonBigClientToXML.Size = new System.Drawing.Size(172, 29);
            this.ButtonBigClientToXML.TabIndex = 5;
            this.ButtonBigClientToXML.Text = "Big Client 2 XML";
            this.ButtonBigClientToXML.UseVisualStyleBackColor = true;
            this.ButtonBigClientToXML.Click += new System.EventHandler(this.ButtonBigClientToXML_Click);
            // 
            // ButtonBigClientToJSON
            // 
            this.ButtonBigClientToJSON.Location = new System.Drawing.Point(1169, 122);
            this.ButtonBigClientToJSON.Name = "ButtonBigClientToJSON";
            this.ButtonBigClientToJSON.Size = new System.Drawing.Size(172, 29);
            this.ButtonBigClientToJSON.TabIndex = 5;
            this.ButtonBigClientToJSON.Text = "Big Client 2 JSON";
            this.ButtonBigClientToJSON.UseVisualStyleBackColor = true;
            this.ButtonBigClientToJSON.Click += new System.EventHandler(this.ButtonBigClientToJSON_Click);
            // 
            // ButtonSmallClientToXML
            // 
            this.ButtonSmallClientToXML.Location = new System.Drawing.Point(1169, 174);
            this.ButtonSmallClientToXML.Name = "ButtonSmallClientToXML";
            this.ButtonSmallClientToXML.Size = new System.Drawing.Size(172, 29);
            this.ButtonSmallClientToXML.TabIndex = 5;
            this.ButtonSmallClientToXML.Text = "Small Client 2 XML";
            this.ButtonSmallClientToXML.UseVisualStyleBackColor = true;
            this.ButtonSmallClientToXML.Click += new System.EventHandler(this.ButtonSmallClientToXML_Click);
            // 
            // ButtonSmallClientToJSON
            // 
            this.ButtonSmallClientToJSON.Location = new System.Drawing.Point(1169, 226);
            this.ButtonSmallClientToJSON.Name = "ButtonSmallClientToJSON";
            this.ButtonSmallClientToJSON.Size = new System.Drawing.Size(172, 29);
            this.ButtonSmallClientToJSON.TabIndex = 5;
            this.ButtonSmallClientToJSON.Text = "Small Client 2 JSON";
            this.ButtonSmallClientToJSON.UseVisualStyleBackColor = true;
            this.ButtonSmallClientToJSON.Click += new System.EventHandler(this.ButtonSmallClientToJSON_Click);
            // 
            // FrmClientsListView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1484, 711);
            this.Controls.Add(this.ButtonSmallClientToJSON);
            this.Controls.Add(this.ButtonSmallClientToXML);
            this.Controls.Add(this.ButtonBigClientToJSON);
            this.Controls.Add(this.ButtonBigClientToXML);
            this.Controls.Add(this.RichTextBox1);
            this.Controls.Add(this.LblTitel);
            this.Controls.Add(this.ListViewClienten);
            this.MaximumSize = new System.Drawing.Size(1500, 750);
            this.MinimumSize = new System.Drawing.Size(1500, 750);
            this.Name = "FrmClientsListView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lijst met klanten in ListView (non modal)";
            this.Load += new System.EventHandler(this.FrmClientsListView_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView ListViewClienten;
        private System.Windows.Forms.Label LblTitel;
        private System.Windows.Forms.ColumnHeader ClientNumber;
        private System.Windows.Forms.ColumnHeader FirstName;
        private System.Windows.Forms.RichTextBox RichTextBox1;
        private System.Windows.Forms.Button ButtonBigClientToXML;
        private System.Windows.Forms.Button ButtonBigClientToJSON;
        private System.Windows.Forms.Button ButtonSmallClientToXML;
        private System.Windows.Forms.Button ButtonSmallClientToJSON;
        private System.Windows.Forms.ColumnHeader NickName;
        private System.Windows.Forms.ColumnHeader LengthInMeters;
    }
}