using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using GeoscienceMath;

namespace DigitalSignal.Forms
{
    public partial class GroupLog : UserControl
    {
        public double Min
        {
            get { return double.Parse(tbMin.Text); }
            set { tbMin.Text = value + ""; }
        }

        public double Max
        {
            get { return double.Parse(tbMax.Text); }
            set { tbMax.Text = value + ""; }
        }

        public double Weight
        {
            get { return double.Parse(tbWeight.Text); }
            set { tbWeight.Text = value + ""; }
        }

        public string Description
        {
            get { return gbLogType.Text; }
            set { gbLogType.Text = value; }
        }

        public GroupLog()
        {
            InitializeComponent();
        }

        public void initialize(LogMeasurements log)
        {
            Description = log.Description;
            Min = log.Min;
            Max = log.Max;
            Weight = log.Weight;
        }

        public void toggle()
        {
            gbLogType.Enabled = !gbLogType.Enabled;
        }
    }
}
