using System;
using System.Drawing;
using System.Windows.Forms;

using Slb.Ocean.Petrel.Workflow;
using Slb.Ocean.Core;
using Slb.Ocean.Petrel.DomainObject.Well;
using Slb.Ocean.Petrel;
using Slb.Ocean.Petrel.DomainObject;
using System.Collections.Generic;
using Slb.Ocean.Petrel.UI.Controls;
using Slb.Ocean.Petrel.UI;

using GeoscienceMath;

namespace DigitalSignal
{
    /// <summary>
    /// This class is the user interface which forms the focus for the capabilities offered by the process.  
    /// This often includes UI to set up arguments and interactively run a batch part expressed as a workstep.
    /// </summary>
    partial class SignalProcessUI : UserControl
    {
        /// <summary>
        /// Contains the process instance.
        /// </summary>
        private SignalProcess process;
        private Borehole bh;
        private ValidateRange vr;

        /// <summary>
        /// Initializes a new instance of the <see cref="SignalProcessUI"/> class.
        /// </summary>
        public SignalProcessUI(SignalProcess process)
        {
            InitializeComponent();
            vr = new ValidateRange();
            initValues();
            initButtons();
            lbWellInput.SelectionMode = ListBoxSelectionMode.Multiple;

            this.process = process;
        }

        private void initButtons()
        {
            btnCancel.Image = PetrelImages.Cancel;
            btnOK.Image = PetrelImages.OK;
            btnDelete.Image = PetrelImages.RowDelete;
            btnApply.Image = PetrelImages.Apply;

            btnCancel.ImageAlign = ContentAlignment.MiddleLeft;
            btnOK.ImageAlign = ContentAlignment.MiddleLeft;
            btnApply.ImageAlign = ContentAlignment.MiddleLeft;
        }

        private void initValues()
        {
            ucGR.initialize(vr.getType(LogTypes.GR));
            ucNPHI.initialize(vr.getType(LogTypes.NPHI));
            ucCALI.initialize(vr.getType(LogTypes.CALI));
            ucRID.initialize(vr.getType(LogTypes.RID));
            ucRIM.initialize(vr.getType(LogTypes.RIM));
            ucPEF.initialize(vr.getType(LogTypes.PEF));
            ucRHOZ.initialize(vr.getType(LogTypes.RHOZ));
        }

        private void dtWells_DragDrop(object sender, DragEventArgs e)
        {
            bh = e.Data.GetData(typeof(object)) as Borehole;

            if (bh == null)
                PetrelLogger.WarnBox("Input wells only.");
            else
            {
                ListBoxItem lbi = new ListBoxItem();
                lbi.Text = bh.Name;
                lbi.Value = bh;

                foreach (ListBoxItem item in lbWellInput.Items)
                    if (item.Text == bh.Name)
                        return;

                lbWellInput.Items.Add(lbi);
            }
        }

        private void dtWells_DragOver(object sender, DragEventArgs e)
        {
            object dropped = e.Data.GetData(typeof(object));
            bh = dropped as Borehole;

            if (bh != null)
                e.Effect = DragDropEffects.All;
            else
                e.Effect = DragDropEffects.None;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            btnApply_Click(sender, e);
            FindForm().Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            
            FindForm().Close();
        }

        private void updateValues()
        {
            vr.setValues(LogTypes.CALI, ucCALI.Min, ucCALI.Max, ucCALI.Weight);
            vr.setValues(LogTypes.GR, ucGR.Min, ucGR.Max, ucGR.Weight);
            vr.setValues(LogTypes.NPHI, ucNPHI.Min, ucNPHI.Max, ucNPHI.Weight);
            vr.setValues(LogTypes.PEF, ucPEF.Min, ucPEF.Max, ucPEF.Weight);
            vr.setValues(LogTypes.RHOZ, ucRHOZ.Min, ucRHOZ.Max, ucRHOZ.Weight);
            vr.setValues(LogTypes.RID, ucRID.Min, ucRID.Max, ucRID.Weight);
            vr.setValues(LogTypes.RIM, ucRIM.Min, ucRIM.Max, ucRIM.Weight);
        }

        private void rb_CheckedChanged(object sender, EventArgs e)
        {
            if ((sender as RadioButton).Checked == true)
            {
                ucGR.toggle();
                ucNPHI.toggle();
                ucCALI.toggle();
                ucRID.toggle();
                ucRIM.toggle();
                ucPEF.toggle();
                ucRHOZ.toggle();
            }
        }

        private void SignalProcessUI_Load(object sender, EventArgs e)
        {
            ToolTipInfo info = new ToolTipInfo();

            info.Items.Add(new ToolTipItem("Exclude selected items"));
            toolTipManager1.SetToolTip(btnDelete, info);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            List<ListBoxItem> items = new List<ListBoxItem>();

            foreach (ListBoxItem lbi in lbWellInput.SelectedItems)
                items.Add(lbi);

            foreach (ListBoxItem lbi in items)
                lbWellInput.Items.Remove(lbi);
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            List<Borehole> listBh = new List<Borehole>();

            foreach (ListBoxItem lbi in lbWellInput.Items)
                listBh.Add(lbi.Value as Borehole);

            updateValues();

            process.updateWells(listBh, vr);
        }
    }
}
