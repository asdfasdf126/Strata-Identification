namespace DigitalSignal
{
    partial class SignalProcessUI
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
            this.components = new System.ComponentModel.Container();
            this.lblWellInput = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.dtWells = new Slb.Ocean.Petrel.UI.DropTarget();
            this.rbUserDefined = new System.Windows.Forms.RadioButton();
            this.rbDefault = new System.Windows.Forms.RadioButton();
            this.lblInput = new System.Windows.Forms.Label();
            this.lbWellInput = new Slb.Ocean.Petrel.UI.Controls.ListBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.toolTipManager1 = new Slb.Ocean.Petrel.UI.Controls.ToolTipManager(this.components);
            this.ucRHOZ = new DigitalSignal.Forms.GroupLog();
            this.ucPEF = new DigitalSignal.Forms.GroupLog();
            this.ucRIM = new DigitalSignal.Forms.GroupLog();
            this.ucRID = new DigitalSignal.Forms.GroupLog();
            this.ucCALI = new DigitalSignal.Forms.GroupLog();
            this.ucNPHI = new DigitalSignal.Forms.GroupLog();
            this.ucGR = new DigitalSignal.Forms.GroupLog();
            this.btnApply = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.toolTipManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblWellInput
            // 
            this.lblWellInput.AutoSize = true;
            this.lblWellInput.Location = new System.Drawing.Point(1, 30);
            this.lblWellInput.Name = "lblWellInput";
            this.lblWellInput.Size = new System.Drawing.Size(58, 13);
            this.lblWellInput.TabIndex = 5;
            this.lblWellInput.Text = "Well Input:";
            // 
            // btnOK
            // 
            this.btnOK.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOK.Location = new System.Drawing.Point(268, 327);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 8;
            this.btnOK.Text = "OK";
            this.btnOK.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(349, 327);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // dtWells
            // 
            this.dtWells.AllowDrop = true;
            this.dtWells.Location = new System.Drawing.Point(105, 24);
            this.dtWells.Name = "dtWells";
            this.dtWells.Size = new System.Drawing.Size(26, 23);
            this.dtWells.TabIndex = 11;
            this.dtWells.TabStop = false;
            this.dtWells.DragDrop += new System.Windows.Forms.DragEventHandler(this.dtWells_DragDrop);
            this.dtWells.DragOver += new System.Windows.Forms.DragEventHandler(this.dtWells_DragOver);
            // 
            // rbUserDefined
            // 
            this.rbUserDefined.AutoSize = true;
            this.rbUserDefined.Location = new System.Drawing.Point(4, 81);
            this.rbUserDefined.Name = "rbUserDefined";
            this.rbUserDefined.Size = new System.Drawing.Size(90, 17);
            this.rbUserDefined.TabIndex = 12;
            this.rbUserDefined.Text = "User Defined:";
            this.rbUserDefined.UseVisualStyleBackColor = true;
            this.rbUserDefined.CheckedChanged += new System.EventHandler(this.rb_CheckedChanged);
            // 
            // rbDefault
            // 
            this.rbDefault.AutoSize = true;
            this.rbDefault.Checked = true;
            this.rbDefault.Location = new System.Drawing.Point(4, 58);
            this.rbDefault.Name = "rbDefault";
            this.rbDefault.Size = new System.Drawing.Size(72, 17);
            this.rbDefault.TabIndex = 13;
            this.rbDefault.TabStop = true;
            this.rbDefault.Text = "Automatic";
            this.rbDefault.UseVisualStyleBackColor = true;
            this.rbDefault.CheckedChanged += new System.EventHandler(this.rb_CheckedChanged);
            // 
            // lblInput
            // 
            this.lblInput.AutoSize = true;
            this.lblInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInput.Location = new System.Drawing.Point(134, 8);
            this.lblInput.Name = "lblInput";
            this.lblInput.Size = new System.Drawing.Size(60, 13);
            this.lblInput.TabIndex = 21;
            this.lblInput.Text = "Input Data:";
            // 
            // lbWellInput
            // 
            this.lbWellInput.Location = new System.Drawing.Point(137, 24);
            this.lbWellInput.Name = "lbWellInput";
            this.lbWellInput.Size = new System.Drawing.Size(309, 81);
            this.lbWellInput.TabIndex = 22;
            this.lbWellInput.TabStop = false;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(105, 52);
            this.btnDelete.MinimumSize = new System.Drawing.Size(16, 16);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(26, 23);
            this.btnDelete.TabIndex = 23;
            this.btnDelete.TabStop = false;
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // ucRHOZ
            // 
            this.ucRHOZ.Description = "Log Type";
            this.ucRHOZ.Location = new System.Drawing.Point(279, 219);
            this.ucRHOZ.Name = "ucRHOZ";
            this.ucRHOZ.Size = new System.Drawing.Size(107, 102);
            this.ucRHOZ.TabIndex = 7;
            // 
            // ucPEF
            // 
            this.ucPEF.Description = "Log Type";
            this.ucPEF.Location = new System.Drawing.Point(166, 219);
            this.ucPEF.Name = "ucPEF";
            this.ucPEF.Size = new System.Drawing.Size(107, 102);
            this.ucPEF.TabIndex = 6;
            // 
            // ucRIM
            // 
            this.ucRIM.Description = "Log Type";
            this.ucRIM.Location = new System.Drawing.Point(53, 219);
            this.ucRIM.Name = "ucRIM";
            this.ucRIM.Size = new System.Drawing.Size(107, 102);
            this.ucRIM.TabIndex = 5;
            // 
            // ucRID
            // 
            this.ucRID.Description = "Log Type";
            this.ucRID.Location = new System.Drawing.Point(339, 111);
            this.ucRID.Name = "ucRID";
            this.ucRID.Size = new System.Drawing.Size(107, 102);
            this.ucRID.TabIndex = 4;
            // 
            // ucCALI
            // 
            this.ucCALI.Description = "Log Type";
            this.ucCALI.Location = new System.Drawing.Point(226, 111);
            this.ucCALI.Name = "ucCALI";
            this.ucCALI.Size = new System.Drawing.Size(107, 102);
            this.ucCALI.TabIndex = 3;
            // 
            // ucNPHI
            // 
            this.ucNPHI.Description = "Log Type";
            this.ucNPHI.Location = new System.Drawing.Point(113, 111);
            this.ucNPHI.Name = "ucNPHI";
            this.ucNPHI.Size = new System.Drawing.Size(107, 102);
            this.ucNPHI.TabIndex = 2;
            // 
            // ucGR
            // 
            this.ucGR.Description = "Log Type";
            this.ucGR.Location = new System.Drawing.Point(0, 111);
            this.ucGR.Name = "ucGR";
            this.ucGR.Size = new System.Drawing.Size(107, 102);
            this.ucGR.TabIndex = 1;
            // 
            // btnApply
            // 
            this.btnApply.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnApply.Location = new System.Drawing.Point(187, 327);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(75, 23);
            this.btnApply.TabIndex = 8;
            this.btnApply.Text = "Apply";
            this.btnApply.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // SignalProcessUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dtWells);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.lbWellInput);
            this.Controls.Add(this.lblInput);
            this.Controls.Add(this.ucRHOZ);
            this.Controls.Add(this.ucPEF);
            this.Controls.Add(this.ucRIM);
            this.Controls.Add(this.ucRID);
            this.Controls.Add(this.ucCALI);
            this.Controls.Add(this.ucNPHI);
            this.Controls.Add(this.ucGR);
            this.Controls.Add(this.rbUserDefined);
            this.Controls.Add(this.rbDefault);
            this.Controls.Add(this.lblWellInput);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.btnOK);
            this.Name = "SignalProcessUI";
            this.Size = new System.Drawing.Size(450, 355);
            this.Load += new System.EventHandler(this.SignalProcessUI_Load);
            ((System.ComponentModel.ISupportInitialize)(this.toolTipManager1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblWellInput;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private Slb.Ocean.Petrel.UI.DropTarget dtWells;
        private System.Windows.Forms.RadioButton rbUserDefined;
        private System.Windows.Forms.RadioButton rbDefault;
        private Forms.GroupLog ucGR;
        private Forms.GroupLog ucNPHI;
        private Forms.GroupLog ucCALI;
        private Forms.GroupLog ucRID;
        private Forms.GroupLog ucRIM;
        private Forms.GroupLog ucPEF;
        private Forms.GroupLog ucRHOZ;
        private System.Windows.Forms.Label lblInput;
        private Slb.Ocean.Petrel.UI.Controls.ListBox lbWellInput;
        private System.Windows.Forms.Button btnDelete;
        private Slb.Ocean.Petrel.UI.Controls.ToolTipManager toolTipManager1;
        private System.Windows.Forms.Button btnApply;
    }
}
