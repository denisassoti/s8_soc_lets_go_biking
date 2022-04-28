namespace HeavyWinFormsClient
{
    partial class ItineraireForm
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
            this.departStDpListView = new System.Windows.Forms.ListView();
            this.instructionsHeader = new System.Windows.Forms.ColumnHeader();
            this.nomHeader = new System.Windows.Forms.ColumnHeader();
            this.dureeHeader = new System.Windows.Forms.ColumnHeader();
            this.distanceHeader = new System.Windows.Forms.ColumnHeader();
            this.panel1 = new System.Windows.Forms.Panel();
            this.arriveeTxt = new System.Windows.Forms.Label();
            this.stationArriveeTxt = new System.Windows.Forms.Label();
            this.stationDepartTxt = new System.Windows.Forms.Label();
            this.departTxt = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.saArriveeListView = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.sdSaListView = new System.Windows.Forms.ListView();
            this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader7 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader8 = new System.Windows.Forms.ColumnHeader();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // departStDpListView
            // 
            this.departStDpListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.instructionsHeader,
            this.nomHeader,
            this.dureeHeader,
            this.distanceHeader});
            this.departStDpListView.FullRowSelect = true;
            this.departStDpListView.GridLines = true;
            this.departStDpListView.Location = new System.Drawing.Point(0, 121);
            this.departStDpListView.Name = "departStDpListView";
            this.departStDpListView.Size = new System.Drawing.Size(953, 448);
            this.departStDpListView.TabIndex = 0;
            this.departStDpListView.UseCompatibleStateImageBehavior = false;
            this.departStDpListView.View = System.Windows.Forms.View.Details;
            this.departStDpListView.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // instructionsHeader
            // 
            this.instructionsHeader.Text = "Instructions";
            this.instructionsHeader.Width = 500;
            // 
            // nomHeader
            // 
            this.nomHeader.Text = "Nom";
            this.nomHeader.Width = 250;
            // 
            // dureeHeader
            // 
            this.dureeHeader.Text = "Durée (s)";
            this.dureeHeader.Width = 75;
            // 
            // distanceHeader
            // 
            this.distanceHeader.Text = "Distance (m)";
            this.distanceHeader.Width = 100;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.arriveeTxt);
            this.panel1.Controls.Add(this.stationArriveeTxt);
            this.panel1.Controls.Add(this.stationDepartTxt);
            this.panel1.Controls.Add(this.departTxt);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1922, 48);
            this.panel1.TabIndex = 1;
            // 
            // arriveeTxt
            // 
            this.arriveeTxt.AutoSize = true;
            this.arriveeTxt.Location = new System.Drawing.Point(1588, 17);
            this.arriveeTxt.Name = "arriveeTxt";
            this.arriveeTxt.Size = new System.Drawing.Size(73, 20);
            this.arriveeTxt.TabIndex = 5;
            this.arriveeTxt.Text = "arriveeTxt";
            // 
            // stationArriveeTxt
            // 
            this.stationArriveeTxt.AutoSize = true;
            this.stationArriveeTxt.Location = new System.Drawing.Point(1179, 17);
            this.stationArriveeTxt.Name = "stationArriveeTxt";
            this.stationArriveeTxt.Size = new System.Drawing.Size(120, 20);
            this.stationArriveeTxt.TabIndex = 6;
            this.stationArriveeTxt.Text = "stationArriveeTxt";
            // 
            // stationDepartTxt
            // 
            this.stationDepartTxt.AutoSize = true;
            this.stationDepartTxt.Location = new System.Drawing.Point(648, 17);
            this.stationDepartTxt.Name = "stationDepartTxt";
            this.stationDepartTxt.Size = new System.Drawing.Size(119, 20);
            this.stationDepartTxt.TabIndex = 5;
            this.stationDepartTxt.Text = "stationDepartTxt";
            // 
            // departTxt
            // 
            this.departTxt.AutoSize = true;
            this.departTxt.Location = new System.Drawing.Point(142, 16);
            this.departTxt.Name = "departTxt";
            this.departTxt.Size = new System.Drawing.Size(72, 20);
            this.departTxt.TabIndex = 4;
            this.departTxt.Text = "departTxt";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Harlow Solid Italic", 16.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(946, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(240, 35);
            this.label4.TabIndex = 3;
            this.label4.Text = "Station d\'arrivée : ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Harlow Solid Italic", 16.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(414, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(244, 35);
            this.label3.TabIndex = 2;
            this.label3.Text = "Station de départ : ";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Harlow Solid Italic", 16.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(1457, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(136, 35);
            this.label2.TabIndex = 1;
            this.label2.Text = "Arrivée : ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Harlow Solid Italic", 16.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(10, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 35);
            this.label1.TabIndex = 0;
            this.label1.Text = "Départ : ";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // saArriveeListView
            // 
            this.saArriveeListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.saArriveeListView.FullRowSelect = true;
            this.saArriveeListView.GridLines = true;
            this.saArriveeListView.Location = new System.Drawing.Point(0, 613);
            this.saArriveeListView.Name = "saArriveeListView";
            this.saArriveeListView.Size = new System.Drawing.Size(953, 440);
            this.saArriveeListView.TabIndex = 2;
            this.saArriveeListView.UseCompatibleStateImageBehavior = false;
            this.saArriveeListView.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Instructions";
            this.columnHeader1.Width = 500;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Nom";
            this.columnHeader2.Width = 250;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Durée (s)";
            this.columnHeader3.Width = 75;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Distance (m)";
            this.columnHeader4.Width = 100;
            // 
            // sdSaListView
            // 
            this.sdSaListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader8});
            this.sdSaListView.FullRowSelect = true;
            this.sdSaListView.GridLines = true;
            this.sdSaListView.Location = new System.Drawing.Point(959, 121);
            this.sdSaListView.Name = "sdSaListView";
            this.sdSaListView.Size = new System.Drawing.Size(953, 448);
            this.sdSaListView.TabIndex = 3;
            this.sdSaListView.UseCompatibleStateImageBehavior = false;
            this.sdSaListView.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Instructions";
            this.columnHeader5.Width = 500;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Nom";
            this.columnHeader6.Width = 250;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Durée (s)";
            this.columnHeader7.Width = 75;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Distance (m)";
            this.columnHeader8.Width = 100;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(203, 579);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(313, 31);
            this.label5.TabIndex = 6;
            this.label5.Text = "Station d\'arrivée 🚶 Arrivée";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label6.Location = new System.Drawing.Point(286, 87);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(319, 31);
            this.label6.TabIndex = 7;
            this.label6.Text = "Départ 🚶 Station de départ";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label7.Location = new System.Drawing.Point(1224, 85);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(422, 31);
            this.label7.TabIndex = 8;
            this.label7.Text = "Station de départ 🚴 Station d\'arrivée";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label8.Location = new System.Drawing.Point(848, 62);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(197, 31);
            this.label8.TabIndex = 9;
            this.label8.Text = "Liste du parcours";
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // ItineraireForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1924, 1055);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.sdSaListView);
            this.Controls.Add(this.saArriveeListView);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.departStDpListView);
            this.Name = "ItineraireForm";
            this.Text = "Itinéraire";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.ItineraireForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ListView departStDpListView;
        private Panel panel1;
        private Label label1;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label arriveeTxt;
        private Label stationArriveeTxt;
        private Label stationDepartTxt;
        private Label departTxt;
        private ColumnHeader instructionsHeader;
        private ColumnHeader nomHeader;
        private ColumnHeader dureeHeader;
        private ColumnHeader distanceHeader;
        private ListView saArriveeListView;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader3;
        private ColumnHeader columnHeader4;
        private ListView sdSaListView;
        private ColumnHeader columnHeader5;
        private ColumnHeader columnHeader6;
        private ColumnHeader columnHeader7;
        private ColumnHeader columnHeader8;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
    }
}