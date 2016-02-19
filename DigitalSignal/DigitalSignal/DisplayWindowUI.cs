using Slb.Ocean.Petrel;
using Slb.Ocean.Petrel.DomainObject.Well;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

using GeoscienceMath;

namespace DigitalSignal
{
    partial class chtData : UserControl
    {
        public chtData()
        {
            InitializeComponent();

            chtWindow.ChartAreas[0].AxisX.LabelStyle.Format = "###";
            chtWindow.ChartAreas[0].AxisY.Interval = 0.25;
        }

        

        private double[] getSamples(WellLog wl)
        {
            double[] samples = new double[wl.SampleCount];
            int count = 0;

            foreach (WellLogSample sample in wl.Samples)
                samples[count++] = sample.Value;

            return samples; 
        }

        public double[] getDepth(WellLog wl)
        {
            double[] samples = new double[wl.SampleCount];
            int count = 0;

            foreach (WellLogSample sample in wl.Samples)
                samples[count++] = sample.MD;

            return samples; 
        }

        public void addSeries(Borehole bh)
        {
            Dictionary<int, double> weights = new Dictionary<int, double>();
            ValidateRange vr;
            double[] gr = null, nphi = null, rhoz = null,
                pef = null, rid = null, rim = null, cali = null,
                md = null;

            foreach (WellLog wl in bh.Logs.WellLogs)
            {
                switch (wl.Name)
                {
                    case "GR": gr = getSamples(wl);
                        md = getDepth(wl);
                        break;
                    case "NPHI": nphi = getSamples(wl);
                        break;
                    case "RHOZ": rhoz = getSamples(wl);
                        break;
                    case "PEF": pef = getSamples(wl);
                        break;
                    case "RID": rid = getSamples(wl);
                        break;
                    case "RIM": rim = getSamples(wl);
                        break;
                    case "CALI": cali = getSamples(wl);
                        break;
                }
            }

            chtWindow.Series.Add(bh.Name);
            //chtWindow.Series[bh.Name].BorderColor = Color.Red;

            Console.WriteLine("Starting checks");

            vr = new ValidateRange();

            for (int x = 0; x < gr.Length; x++)
            {
                double sum = 0;
                sum += vr.checkRange(LogTypes.GR, gr[x]);

                if (sum > 0)
                {
                    if (x < rhoz.Length)
                        sum += vr.checkRange(LogTypes.RHOZ, rhoz[x]);

                    if (x < nphi.Length)
                        sum += vr.checkRange(LogTypes.NPHI, nphi[x]);

                    if (x < rid.Length)
                        sum += vr.checkRange(LogTypes.RID, rid[x]);

                    if (x < rim.Length)
                        sum += vr.checkRange(LogTypes.RIM, rim[x]);

                    if (x < pef.Length)
                        sum += vr.checkRange(LogTypes.PEF, pef[x]);

                    if (x < cali.Length)
                        sum += vr.checkRange(LogTypes.CALI, cali[x]);
                }

                weights.Add(x, sum);
            }

            //chtWindow.Series[bh.Name].ChartType = SeriesChartType.Bar;

            for(int x = 0; x < weights.Count; x++)
            {
                chtWindow.Series[bh.Name].Points.AddXY(md[x] * 3.28084, weights[x]);
            }
        }

        public void removeSeries(Borehole bh)
        {
        }
    }
}
