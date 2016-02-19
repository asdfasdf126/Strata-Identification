using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GeoscienceMath
{
    public partial class Selection : UserControl
    {
        public Selection()
        {
            InitializeComponent();
        }

        public enum deblurMethod
        {
            NONE,
            FFT,
            CONVOLUTION,
            DECONVOLUTION
        }

        public enum filterMethod
        {
            NONE,
            ADAPTIVE,
            AVERAGE
        }

        public enum predictMethod
        {
            NONE,
            LINEAR,
            POLYNOMIAL
        }
    }
}
