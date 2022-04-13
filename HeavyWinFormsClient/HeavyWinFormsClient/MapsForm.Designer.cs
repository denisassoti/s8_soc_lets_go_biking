namespace HeavyWinFormsClient
{
    partial class MapsForm
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
            this.listView3 = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // listView3
            // 
            this.listView3.Location = new System.Drawing.Point(25, 25);
            this.listView3.Name = "listView3";
            this.listView3.Size = new System.Drawing.Size(1312, 638);
            this.listView3.TabIndex = 5;
            this.listView3.UseCompatibleStateImageBehavior = false;
            // 
            // MapsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1379, 723);
            this.Controls.Add(this.listView3);
            this.Name = "MapsForm";
            this.Text = "Maps";
            this.Load += new System.EventHandler(this.MapsForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private ListView listView3;
    }
}