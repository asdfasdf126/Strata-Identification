namespace DigitalSignal
{
    partial class WellSelection
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lbWells = new Slb.Ocean.Petrel.UI.Controls.ListBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbWells
            // 
            this.lbWells.Location = new System.Drawing.Point(3, 19);
            this.lbWells.Name = "lbWells";
            this.lbWells.Size = new System.Drawing.Size(137, 193);
            this.lbWells.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new System.Drawing.Point(53, 3);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(40, 13);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "LABEL";
            // 
            // WellSelection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lbWells);
            this.Name = "WellSelection";
            this.Size = new System.Drawing.Size(150, 224);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public Slb.Ocean.Petrel.UI.Controls.ListBox lbWells;
        public System.Windows.Forms.Label lblTitle;

    }
}
