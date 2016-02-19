namespace DigitalSignal.Forms
{
    partial class GroupLog
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
            this.gbLogType = new System.Windows.Forms.GroupBox();
            this.tbWeight = new System.Windows.Forms.TextBox();
            this.tbMax = new System.Windows.Forms.TextBox();
            this.tbMin = new System.Windows.Forms.TextBox();
            this.lblWeight = new System.Windows.Forms.Label();
            this.lblMax = new System.Windows.Forms.Label();
            this.lblMin = new System.Windows.Forms.Label();
            this.gbLogType.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbLogType
            // 
            this.gbLogType.Controls.Add(this.tbWeight);
            this.gbLogType.Controls.Add(this.tbMax);
            this.gbLogType.Controls.Add(this.tbMin);
            this.gbLogType.Controls.Add(this.lblWeight);
            this.gbLogType.Controls.Add(this.lblMax);
            this.gbLogType.Controls.Add(this.lblMin);
            this.gbLogType.Enabled = false;
            this.gbLogType.Location = new System.Drawing.Point(3, 3);
            this.gbLogType.Name = "gbLogType";
            this.gbLogType.Size = new System.Drawing.Size(101, 94);
            this.gbLogType.TabIndex = 21;
            this.gbLogType.TabStop = false;
            this.gbLogType.Text = "Log Type";
            // 
            // tbWeight
            // 
            this.tbWeight.Location = new System.Drawing.Point(59, 64);
            this.tbWeight.Name = "tbWeight";
            this.tbWeight.Size = new System.Drawing.Size(36, 20);
            this.tbWeight.TabIndex = 3;
            // 
            // tbMax
            // 
            this.tbMax.Location = new System.Drawing.Point(59, 39);
            this.tbMax.Name = "tbMax";
            this.tbMax.Size = new System.Drawing.Size(36, 20);
            this.tbMax.TabIndex = 2;
            // 
            // tbMin
            // 
            this.tbMin.Location = new System.Drawing.Point(59, 13);
            this.tbMin.Name = "tbMin";
            this.tbMin.Size = new System.Drawing.Size(36, 20);
            this.tbMin.TabIndex = 1;
            // 
            // lblWeight
            // 
            this.lblWeight.AutoSize = true;
            this.lblWeight.Location = new System.Drawing.Point(7, 67);
            this.lblWeight.Name = "lblWeight";
            this.lblWeight.Size = new System.Drawing.Size(44, 13);
            this.lblWeight.TabIndex = 0;
            this.lblWeight.Text = "Weight:";
            // 
            // lblMax
            // 
            this.lblMax.AutoSize = true;
            this.lblMax.Location = new System.Drawing.Point(7, 42);
            this.lblMax.Name = "lblMax";
            this.lblMax.Size = new System.Drawing.Size(30, 13);
            this.lblMax.TabIndex = 0;
            this.lblMax.Text = "Max:";
            // 
            // lblMin
            // 
            this.lblMin.AutoSize = true;
            this.lblMin.Location = new System.Drawing.Point(7, 20);
            this.lblMin.Name = "lblMin";
            this.lblMin.Size = new System.Drawing.Size(27, 13);
            this.lblMin.TabIndex = 0;
            this.lblMin.Text = "Min:";
            // 
            // GroupLog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gbLogType);
            this.Name = "GroupLog";
            this.Size = new System.Drawing.Size(107, 102);
            this.gbLogType.ResumeLayout(false);
            this.gbLogType.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox tbWeight;
        private System.Windows.Forms.TextBox tbMax;
        private System.Windows.Forms.TextBox tbMin;
        private System.Windows.Forms.Label lblWeight;
        private System.Windows.Forms.Label lblMax;
        private System.Windows.Forms.Label lblMin;
        private System.Windows.Forms.GroupBox gbLogType;
    }
}
