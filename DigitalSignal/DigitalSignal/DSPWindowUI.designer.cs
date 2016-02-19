namespace DigitalSignal
{
    partial class DSPWindowUI
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            this.chtSignal = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chtOutput = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.ucDynBox = new GeoscienceMath.DynamicBoxes();
            this.ucSelection = new GeoscienceMath.Selection();
            this.lblMin = new System.Windows.Forms.Label();
            this.lblMax = new System.Windows.Forms.Label();
            this.tbMin = new System.Windows.Forms.TextBox();
            this.tbMax = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.chtSignal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chtOutput)).BeginInit();
            this.SuspendLayout();
            // 
            // chtSignal
            // 
            chartArea1.Name = "ChartArea1";
            this.chtSignal.ChartAreas.Add(chartArea1);
            legend1.AutoFitMinFontSize = 14;
            legend1.Name = "Legend1";
            this.chtSignal.Legends.Add(legend1);
            this.chtSignal.Location = new System.Drawing.Point(206, 4);
            this.chtSignal.Name = "chtSignal";
            this.chtSignal.Size = new System.Drawing.Size(1281, 402);
            this.chtSignal.TabIndex = 0;
            this.chtSignal.Text = "chart1";
            // 
            // chtOutput
            // 
            chartArea2.Name = "ChartArea1";
            this.chtOutput.ChartAreas.Add(chartArea2);
            legend2.AutoFitMinFontSize = 14;
            legend2.Name = "Legend1";
            this.chtOutput.Legends.Add(legend2);
            this.chtOutput.Location = new System.Drawing.Point(206, 412);
            this.chtOutput.Name = "chtOutput";
            this.chtOutput.Size = new System.Drawing.Size(1281, 402);
            this.chtOutput.TabIndex = 0;
            this.chtOutput.Text = "chart1";
            // 
            // ucDynBox
            // 
            this.ucDynBox.Location = new System.Drawing.Point(16, 474);
            this.ucDynBox.Name = "ucDynBox";
            this.ucDynBox.Size = new System.Drawing.Size(167, 287);
            this.ucDynBox.TabIndex = 3;
            // 
            // ucSelection
            // 
            this.ucSelection.Location = new System.Drawing.Point(3, 103);
            this.ucSelection.Name = "ucSelection";
            this.ucSelection.Size = new System.Drawing.Size(200, 365);
            this.ucSelection.TabIndex = 1;
            // 
            // lblMin
            // 
            this.lblMin.AutoSize = true;
            this.lblMin.Location = new System.Drawing.Point(28, 22);
            this.lblMin.Name = "lblMin";
            this.lblMin.Size = new System.Drawing.Size(59, 13);
            this.lblMin.TabIndex = 4;
            this.lblMin.Text = "Min Range";
            // 
            // lblMax
            // 
            this.lblMax.AutoSize = true;
            this.lblMax.Location = new System.Drawing.Point(112, 22);
            this.lblMax.Name = "lblMax";
            this.lblMax.Size = new System.Drawing.Size(62, 13);
            this.lblMax.TabIndex = 4;
            this.lblMax.Text = "Max Range";
            // 
            // tbMin
            // 
            this.tbMin.Location = new System.Drawing.Point(16, 48);
            this.tbMin.Name = "tbMin";
            this.tbMin.Size = new System.Drawing.Size(80, 20);
            this.tbMin.TabIndex = 5;
            // 
            // tbMax
            // 
            this.tbMax.Location = new System.Drawing.Point(106, 48);
            this.tbMax.Name = "tbMax";
            this.tbMax.Size = new System.Drawing.Size(80, 20);
            this.tbMax.TabIndex = 5;
            // 
            // DSPWindowUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.tbMax);
            this.Controls.Add(this.tbMin);
            this.Controls.Add(this.lblMax);
            this.Controls.Add(this.lblMin);
            this.Controls.Add(this.ucDynBox);
            this.Controls.Add(this.ucSelection);
            this.Controls.Add(this.chtOutput);
            this.Controls.Add(this.chtSignal);
            this.Name = "DSPWindowUI";
            this.Size = new System.Drawing.Size(1721, 889);
            ((System.ComponentModel.ISupportInitialize)(this.chtSignal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chtOutput)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chtSignal;
        private GeoscienceMath.Selection ucSelection;
        private System.Windows.Forms.DataVisualization.Charting.Chart chtOutput;
        private GeoscienceMath.DynamicBoxes ucDynBox;
        private System.Windows.Forms.Label lblMin;
        private System.Windows.Forms.Label lblMax;
        private System.Windows.Forms.TextBox tbMin;
        private System.Windows.Forms.TextBox tbMax;
    }
}
