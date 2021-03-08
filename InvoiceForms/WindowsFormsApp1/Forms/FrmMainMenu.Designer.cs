using System.Windows.Forms;

namespace InvoiceForms.Forms
{
    partial class FrmMainMenu: Form
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStripBar = new System.Windows.Forms.MenuStrip();
            this.stripSchermen = new System.Windows.Forms.ToolStripMenuItem();
            this.SchermenClienten = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemClientsInListView = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemClientsInTextBox = new System.Windows.Forms.ToolStripMenuItem();
            this.SchermenFacturen = new System.Windows.Forms.ToolStripMenuItem();
            this.stripWebApi = new System.Windows.Forms.ToolStripMenuItem();
            this.menuClientWebAPI = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStripBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStripBar
            // 
            this.menuStripBar.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.menuStripBar.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStripBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stripSchermen,
            this.stripWebApi});
            this.menuStripBar.Location = new System.Drawing.Point(0, 0);
            this.menuStripBar.Name = "menuStripBar";
            this.menuStripBar.Padding = new System.Windows.Forms.Padding(10, 4, 0, 4);
            this.menuStripBar.Size = new System.Drawing.Size(1484, 42);
            this.menuStripBar.TabIndex = 0;
            this.menuStripBar.Text = "menuStrip1";
            // 
            // stripSchermen
            // 
            this.stripSchermen.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SchermenClienten,
            this.SchermenFacturen});
            this.stripSchermen.Name = "stripSchermen";
            this.stripSchermen.Size = new System.Drawing.Size(119, 34);
            this.stripSchermen.Text = "&Schermen";
            this.stripSchermen.ToolTipText = "Voor de schermen";
            // 
            // SchermenClienten
            // 
            this.SchermenClienten.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemClientsInListView,
            this.menuItemClientsInTextBox});
            this.SchermenClienten.Name = "SchermenClienten";
            this.SchermenClienten.Size = new System.Drawing.Size(212, 34);
            this.SchermenClienten.Text = "ClientLijsten";
            this.SchermenClienten.ToolTipText = "De klanten";
            // 
            // menuItemClientsInListView
            // 
            this.menuItemClientsInListView.Name = "menuItemClientsInListView";
            this.menuItemClientsInListView.Size = new System.Drawing.Size(274, 34);
            this.menuItemClientsInListView.Text = "Klanten in ListView";
            this.menuItemClientsInListView.Click += new System.EventHandler(this.MenuItemClientsInListView_Click);
            // 
            // menuItemClientsInTextBox
            // 
            this.menuItemClientsInTextBox.Name = "menuItemClientsInTextBox";
            this.menuItemClientsInTextBox.Size = new System.Drawing.Size(274, 34);
            this.menuItemClientsInTextBox.Text = "Klanten in TextBox";
            this.menuItemClientsInTextBox.Click += new System.EventHandler(this.MenuItemClientsInDataGridView_Click);
            // 
            // SchermenFacturen
            // 
            this.SchermenFacturen.Name = "SchermenFacturen";
            this.SchermenFacturen.Size = new System.Drawing.Size(212, 34);
            this.SchermenFacturen.Text = "Facturen";
            this.SchermenFacturen.ToolTipText = "De facturen";
            this.SchermenFacturen.Click += new System.EventHandler(this.SchermenFacturen_Click);
            // 
            // stripWebApi
            // 
            this.stripWebApi.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuClientWebAPI});
            this.stripWebApi.Name = "stripWebApi";
            this.stripWebApi.Size = new System.Drawing.Size(220, 34);
            this.stripWebApi.Text = "&Clienten via Web Api";
            this.stripWebApi.ToolTipText = "Voor de exports";
            // 
            // menuClientWebAPI
            // 
            this.menuClientWebAPI.Name = "menuClientWebAPI";
            this.menuClientWebAPI.Size = new System.Drawing.Size(430, 34);
            this.menuClientWebAPI.Text = "Clienten via Web API (MouseHover)";
            this.menuClientWebAPI.ToolTipText = "Web API clienten";
            this.menuClientWebAPI.MouseHover += new System.EventHandler(this.MenuClientWebApi_MouseHover);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(288, 42);
            this.toolStripMenuItem4.Text = "Export klanten";
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(288, 42);
            this.toolStripMenuItem5.Text = "Export fakturen";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(268, 42);
            this.toolStripMenuItem1.Text = "Nog Dieper 1";
            // 
            // FrmMainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 36F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1484, 711);
            this.Controls.Add(this.menuStripBar);
            this.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.MainMenuStrip = this.menuStripBar;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.MaximumSize = new System.Drawing.Size(1500, 750);
            this.MinimumSize = new System.Drawing.Size(1500, 750);
            this.Name = "FrmMainMenu";
            this.Text = "Hoofdmenu";
            this.menuStripBar.ResumeLayout(false);
            this.menuStripBar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MenuStrip menuStripBar;
        private ToolStripMenuItem stripSchermen;
        //private ToolStripMenuItem toolStripMenuExport;
        //private ToolStripMenuItem toolStripMenuSchermen;
        //private ToolStripMenuItem toolStripMenuItem3;
        private ToolStripMenuItem toolStripMenuItem4;
        private ToolStripMenuItem toolStripMenuItem5;
        //private ToolStripMenuItem toolStripExport;
        //private ToolStripMenuItem menuExport;
        //private ToolStripMenuItem toolStripMenuItem6;
        private ToolStripMenuItem SchermenClienten;
        //private ToolStripMenuItem menuSchermenFacturen;
        private ToolStripMenuItem menuClientWebAPI;
        //private ToolStripMenuItem stripMenuExport;
        private ToolStripMenuItem toolStripMenuItem1;
        private ToolStripMenuItem SchermenFacturen;
        private ToolStripMenuItem stripWebApi;
        private ToolStripMenuItem menuItemClientsInListView;
        private ToolStripMenuItem menuItemClientsInTextBox;
    }
}

