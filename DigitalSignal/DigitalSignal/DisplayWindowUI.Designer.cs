namespace DigitalSignal
{
    partial class chtData
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
            this.chtWindow = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.chtWindow)).BeginInit();
            this.SuspendLayout();
            // 
            // chtWindow
            // 
            chartArea1.Name = "ChartArea1";
            this.chtWindow.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chtWindow.Legends.Add(legend1);
            this.chtWindow.Location = new System.Drawing.Point(3, 3);
            this.chtWindow.Name = "chtWindow";
            this.chtWindow.Size = new System.Drawing.Size(849, 559);
            this.chtWindow.TabIndex = 0;
            this.chtWindow.Text = "chart1";
            // 
            // chtData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.chtWindow);
            this.Name = "chtData";
            this.Size = new System.Drawing.Size(1721, 889);
            ((System.ComponentModel.ISupportInitialize)(this.chtWindow)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chtWindow;
    }
}
