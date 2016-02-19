namespace GeoscienceMath
{
    partial class Selection
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
            this.grpDeblur = new System.Windows.Forms.GroupBox();
            this.rbDeblurNone = new System.Windows.Forms.RadioButton();
            this.rbDecon = new System.Windows.Forms.RadioButton();
            this.rbConv = new System.Windows.Forms.RadioButton();
            this.rbFFT = new System.Windows.Forms.RadioButton();
            this.grpFilter = new System.Windows.Forms.GroupBox();
            this.rbFilterNone = new System.Windows.Forms.RadioButton();
            this.rbAverage = new System.Windows.Forms.RadioButton();
            this.rbAdaptive = new System.Windows.Forms.RadioButton();
            this.grpPredict = new System.Windows.Forms.GroupBox();
            this.rbPredictNone = new System.Windows.Forms.RadioButton();
            this.rbPoly = new System.Windows.Forms.RadioButton();
            this.rbSimpleLinear = new System.Windows.Forms.RadioButton();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.grpDeblur.SuspendLayout();
            this.grpFilter.SuspendLayout();
            this.grpPredict.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpDeblur
            // 
            this.grpDeblur.Controls.Add(this.rbDeblurNone);
            this.grpDeblur.Controls.Add(this.rbDecon);
            this.grpDeblur.Controls.Add(this.rbConv);
            this.grpDeblur.Controls.Add(this.rbFFT);
            this.grpDeblur.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpDeblur.ForeColor = System.Drawing.Color.Blue;
            this.grpDeblur.Location = new System.Drawing.Point(3, 3);
            this.grpDeblur.Name = "grpDeblur";
            this.grpDeblur.Size = new System.Drawing.Size(189, 114);
            this.grpDeblur.TabIndex = 0;
            this.grpDeblur.TabStop = false;
            this.grpDeblur.Text = "Deblurring";
            // 
            // rbDeblurNone
            // 
            this.rbDeblurNone.AutoSize = true;
            this.rbDeblurNone.Checked = true;
            this.rbDeblurNone.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbDeblurNone.Location = new System.Drawing.Point(5, 89);
            this.rbDeblurNone.Name = "rbDeblurNone";
            this.rbDeblurNone.Size = new System.Drawing.Size(59, 19);
            this.rbDeblurNone.TabIndex = 0;
            this.rbDeblurNone.TabStop = true;
            this.rbDeblurNone.Text = "None";
            this.rbDeblurNone.UseVisualStyleBackColor = true;
            // 
            // rbDecon
            // 
            this.rbDecon.AutoSize = true;
            this.rbDecon.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbDecon.Location = new System.Drawing.Point(6, 66);
            this.rbDecon.Name = "rbDecon";
            this.rbDecon.Size = new System.Drawing.Size(116, 19);
            this.rbDecon.TabIndex = 0;
            this.rbDecon.Text = "Deconvolution";
            this.rbDecon.UseVisualStyleBackColor = true;
            // 
            // rbConv
            // 
            this.rbConv.AutoSize = true;
            this.rbConv.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbConv.Location = new System.Drawing.Point(6, 43);
            this.rbConv.Name = "rbConv";
            this.rbConv.Size = new System.Drawing.Size(100, 19);
            this.rbConv.TabIndex = 0;
            this.rbConv.Text = "Convolution";
            this.rbConv.UseVisualStyleBackColor = true;
            // 
            // rbFFT
            // 
            this.rbFFT.AutoSize = true;
            this.rbFFT.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbFFT.Location = new System.Drawing.Point(7, 20);
            this.rbFFT.Name = "rbFFT";
            this.rbFFT.Size = new System.Drawing.Size(164, 19);
            this.rbFFT.TabIndex = 0;
            this.rbFFT.Text = "Forier Transformation";
            this.rbFFT.UseVisualStyleBackColor = true;
            // 
            // grpFilter
            // 
            this.grpFilter.Controls.Add(this.rbFilterNone);
            this.grpFilter.Controls.Add(this.rbAverage);
            this.grpFilter.Controls.Add(this.rbAdaptive);
            this.grpFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpFilter.ForeColor = System.Drawing.Color.Red;
            this.grpFilter.Location = new System.Drawing.Point(3, 123);
            this.grpFilter.Name = "grpFilter";
            this.grpFilter.Size = new System.Drawing.Size(189, 93);
            this.grpFilter.TabIndex = 0;
            this.grpFilter.TabStop = false;
            this.grpFilter.Text = "Filtering";
            // 
            // rbFilterNone
            // 
            this.rbFilterNone.AutoSize = true;
            this.rbFilterNone.Checked = true;
            this.rbFilterNone.Location = new System.Drawing.Point(10, 66);
            this.rbFilterNone.Name = "rbFilterNone";
            this.rbFilterNone.Size = new System.Drawing.Size(59, 19);
            this.rbFilterNone.TabIndex = 0;
            this.rbFilterNone.TabStop = true;
            this.rbFilterNone.Text = "None";
            this.rbFilterNone.UseVisualStyleBackColor = true;
            // 
            // rbAverage
            // 
            this.rbAverage.AutoSize = true;
            this.rbAverage.Location = new System.Drawing.Point(10, 43);
            this.rbAverage.Name = "rbAverage";
            this.rbAverage.Size = new System.Drawing.Size(113, 19);
            this.rbAverage.TabIndex = 0;
            this.rbAverage.Text = "Average Filter";
            this.rbAverage.UseVisualStyleBackColor = true;
            // 
            // rbAdaptive
            // 
            this.rbAdaptive.AutoSize = true;
            this.rbAdaptive.Location = new System.Drawing.Point(10, 20);
            this.rbAdaptive.Name = "rbAdaptive";
            this.rbAdaptive.Size = new System.Drawing.Size(116, 19);
            this.rbAdaptive.TabIndex = 0;
            this.rbAdaptive.Text = "Adaptive Filter";
            this.rbAdaptive.UseVisualStyleBackColor = true;
            // 
            // grpPredict
            // 
            this.grpPredict.Controls.Add(this.rbPredictNone);
            this.grpPredict.Controls.Add(this.rbPoly);
            this.grpPredict.Controls.Add(this.rbSimpleLinear);
            this.grpPredict.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpPredict.Location = new System.Drawing.Point(3, 222);
            this.grpPredict.Name = "grpPredict";
            this.grpPredict.Size = new System.Drawing.Size(189, 105);
            this.grpPredict.TabIndex = 0;
            this.grpPredict.TabStop = false;
            this.grpPredict.Text = "Prediction";
            // 
            // rbPredictNone
            // 
            this.rbPredictNone.AutoSize = true;
            this.rbPredictNone.Checked = true;
            this.rbPredictNone.Location = new System.Drawing.Point(10, 68);
            this.rbPredictNone.Name = "rbPredictNone";
            this.rbPredictNone.Size = new System.Drawing.Size(59, 19);
            this.rbPredictNone.TabIndex = 0;
            this.rbPredictNone.TabStop = true;
            this.rbPredictNone.Text = "None";
            this.rbPredictNone.UseVisualStyleBackColor = true;
            // 
            // rbPoly
            // 
            this.rbPoly.AutoSize = true;
            this.rbPoly.Location = new System.Drawing.Point(7, 43);
            this.rbPoly.Name = "rbPoly";
            this.rbPoly.Size = new System.Drawing.Size(96, 19);
            this.rbPoly.TabIndex = 0;
            this.rbPoly.Text = "Polynomial";
            this.rbPoly.UseVisualStyleBackColor = true;
            // 
            // rbSimpleLinear
            // 
            this.rbSimpleLinear.AutoSize = true;
            this.rbSimpleLinear.Location = new System.Drawing.Point(7, 20);
            this.rbSimpleLinear.Name = "rbSimpleLinear";
            this.rbSimpleLinear.Size = new System.Drawing.Size(66, 19);
            this.rbSimpleLinear.TabIndex = 0;
            this.rbSimpleLinear.Text = "Linear";
            this.rbSimpleLinear.UseVisualStyleBackColor = true;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(54, 333);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnUpdate.TabIndex = 1;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            // 
            // Selection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.grpPredict);
            this.Controls.Add(this.grpFilter);
            this.Controls.Add(this.grpDeblur);
            this.Name = "Selection";
            this.Size = new System.Drawing.Size(195, 370);
            this.grpDeblur.ResumeLayout(false);
            this.grpDeblur.PerformLayout();
            this.grpFilter.ResumeLayout(false);
            this.grpFilter.PerformLayout();
            this.grpPredict.ResumeLayout(false);
            this.grpPredict.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpDeblur;
        public System.Windows.Forms.RadioButton rbConv;
        public System.Windows.Forms.RadioButton rbFFT;
        public System.Windows.Forms.RadioButton rbDecon;
        private System.Windows.Forms.GroupBox grpFilter;
        public System.Windows.Forms.RadioButton rbFilterNone;
        public System.Windows.Forms.RadioButton rbAdaptive;
        private System.Windows.Forms.GroupBox grpPredict;
        public System.Windows.Forms.RadioButton rbPredictNone;
        public System.Windows.Forms.RadioButton rbSimpleLinear;
        public System.Windows.Forms.RadioButton rbDeblurNone;
        public System.Windows.Forms.RadioButton rbAverage;
        public System.Windows.Forms.RadioButton rbPoly;
        public System.Windows.Forms.Button btnUpdate;
    }
}
