using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.IO;
using System.Numerics;

using MathNet.Numerics.LinearRegression;

using Slb.Ocean.Petrel;
using Slb.Ocean.Petrel.DomainObject;
using Slb.Ocean.Petrel.DomainObject.Well;
using Slb.Ocean.Petrel.UI;

using GeoscienceMath;

namespace DigitalSignal
{
    partial class DSPWindowUI : UserControl
    {
        Queue<double> value = new Queue<double>();
        Queue<double> depth = new Queue<double>();
        Random r = new Random(100);
        double[] y;
        double[] x;
        double[] modX;
        double[] modY;
        double[] output;
        int size;
        Series outSeries;
        const int SIZE = 1024;
        int blur, filter, predict;
        public bool addData;
        int min;
        int max;
        double d;

        public DSPWindowUI()
        {
            InitializeComponent();
            initChart();
            d = Math.Pow(Math.PI / (2 * SIZE), 2);
            addData = true;
        }

        private void initChart()
        {
            chtSignal.Series.Clear();
            chtSignal.ChartAreas[0].AxisX.LabelStyle.Format = "###";
            chtOutput.ChartAreas[0].AxisX.LabelStyle.Format = "###";
            initializeHandlers();
            initializeDynamicBoxes();
        }

        private void initializeDynamicBoxes()
        {
            //set labels to invisible
            ucDynBox.lblVar1.Visible = false;
            ucDynBox.lblVar2.Visible = false;
            ucDynBox.lblVar3.Visible = false;
            ucDynBox.lblVar4.Visible = false;
            ucDynBox.lblVar5.Visible = false;

            //set textboxes to invisible
            ucDynBox.tbVar1.Visible = false;
            ucDynBox.tbVar2.Visible = false;
            ucDynBox.tbVar3.Visible = false;
            ucDynBox.tbVar4.Visible = false;
            ucDynBox.tbVar5.Visible = false;

            ucDynBox.Visible = false;
        }

        #region EventHandlers
        public void initializeHandlers()
        {
            //initialize radio buttons
            blur = (int)Selection.deblurMethod.NONE;
            filter = (int)Selection.filterMethod.NONE;
            predict = (int)Selection.predictMethod.NONE;

            //***Checked

            //Deblurring
            ucSelection.rbConv.CheckedChanged += checkedChangedDeblur;
            ucSelection.rbDecon.CheckedChanged += checkedChangedDeblur;
            ucSelection.rbFFT.CheckedChanged += checkedChangedDeblur;
            ucSelection.rbDeblurNone.CheckedChanged += checkedChangedDeblur;

            //Filter
            ucSelection.rbAdaptive.CheckedChanged += checkedChangedFilter;
            ucSelection.rbAverage.CheckedChanged += checkedChangedFilter;
            ucSelection.rbFilterNone.CheckedChanged += checkedChangedFilter;

            //Linear Prediction
            ucSelection.rbSimpleLinear.CheckedChanged += checkedChangedPredict;
            ucSelection.rbPredictNone.CheckedChanged += checkedChangedPredict;
            ucSelection.rbPoly.CheckedChanged += checkedChangedPredict;


            /*
            //***MouseClick

            //Deblurring
            ucSelection.rbConv.MouseClick += rbConv_MouseClick;
            ucSelection.rbDecon.MouseClick += rbDecon_MouseClick;
            ucSelection.rbFFT.MouseClick += rbFFT_MouseClick;

            ////Filter
            ucSelection.rbAdaptive.MouseClick += rbAdaptive_MouseClick;
            ucSelection.rbAverage.MouseClick += rbAverage_MouseClick;

            ////Linear Prediction
            ucSelection.rbSimpleLinear.MouseClick += rbSimpleLinear_MouseClick;
            ucSelection.rbPoly.MouseClick += rbPoly_MouseClick;
            */

            //update Selections
            ucSelection.btnUpdate.Click += btnUpdate_Click;
            ucDynBox.btnApply.Click += btnApply_Click;
        }

        //Polynomial Regression
        void rbPoly_MouseClick(object sender, MouseEventArgs e)
        {
            ucDynBox.lblVar1.Text = "Polynomial";
            ucDynBox.lblVar2.Text = "Regression";

            ucDynBox.tbVar1.Text = "";
            ucDynBox.tbVar2.Text = "";

            ucDynBox.lblVar1.Visible = true;
            ucDynBox.lblVar2.Visible = true;
            ucDynBox.tbVar1.Visible = true;
            ucDynBox.tbVar2.Visible = true;

            ucDynBox.Show();
        }

        //Linear Regression Mouse Click
        private void rbSimpleLinear_MouseClick(object sender, MouseEventArgs e)
        {
            ucDynBox.lblVar1.Text = "Linear";
            ucDynBox.lblVar2.Text = "Regression";

            ucDynBox.tbVar1.Text = "";
            ucDynBox.tbVar2.Text = "";

            ucDynBox.lblVar1.Visible = true;
            ucDynBox.lblVar2.Visible = true;
            ucDynBox.tbVar1.Visible = true;
            ucDynBox.tbVar2.Visible = true;

            ucDynBox.Show();
        }

        //Average Filter Mouse Click
        private void rbAverage_MouseClick(object sender, MouseEventArgs e)
        {
            ucDynBox.lblVar1.Text = "Average";
            ucDynBox.lblVar2.Text = "Filter";

            ucDynBox.tbVar1.Text = "";
            ucDynBox.tbVar2.Text = "";

            ucDynBox.lblVar1.Visible = true;
            ucDynBox.lblVar2.Visible = true;
            ucDynBox.tbVar1.Visible = true;
            ucDynBox.tbVar2.Visible = true;

            ucDynBox.Show();
        }

        //Adaptive Filter Mouse Click
        private void rbAdaptive_MouseClick(object sender, MouseEventArgs e)
        {
            ucDynBox.lblVar1.Text = "Adaptive";
            ucDynBox.lblVar2.Text = "Filter";

            ucDynBox.tbVar1.Text = "";
            ucDynBox.tbVar2.Text = "";

            ucDynBox.lblVar1.Visible = true;
            ucDynBox.lblVar2.Visible = true;
            ucDynBox.tbVar1.Visible = true;
            ucDynBox.tbVar2.Visible = true;

            ucDynBox.Show();
        }

        //FFT Mouse Click
        private void rbFFT_MouseClick(object sender, MouseEventArgs e)
        {
            ucDynBox.lblVar1.Text = "Fast Forier";
            ucDynBox.lblVar2.Text = "Transformation";

            ucDynBox.tbVar1.Text = "";
            ucDynBox.tbVar2.Text = "";

            ucDynBox.lblVar1.Visible = true;
            ucDynBox.lblVar2.Visible = true;
            ucDynBox.tbVar1.Visible = true;
            ucDynBox.tbVar2.Visible = true;

            ucDynBox.Show();
        }

        //Deconvolution Mouse Click
        private void rbDecon_MouseClick(object sender, MouseEventArgs e)
        {
            ucDynBox.lblVar1.Text = "d Value";
            ucDynBox.tbVar1.Text = d + "";

            ucDynBox.lblVar1.Visible = true;
            ucDynBox.tbVar1.Visible = true;

            ucDynBox.Show();
        }

        //Convolution Mouse Click
        private void rbConv_MouseClick(object sender, MouseEventArgs e)
        {
            ucDynBox.lblVar1.Text = "Convo";
            ucDynBox.lblVar2.Text = "Lution";

            ucDynBox.tbVar1.Text = "";
            ucDynBox.tbVar2.Text = "";

            ucDynBox.lblVar1.Visible = true;
            ucDynBox.lblVar2.Visible = true;
            ucDynBox.tbVar1.Visible = true;
            ucDynBox.tbVar2.Visible = true;

            ucDynBox.Show();
        }

        private void selectionNoneMouseClick(object sender, MouseEventArgs e)
        { initializeDynamicBoxes(); }

        private void btnApply_Click(object sender, EventArgs e)
        {
            RadioButton rb = sender as RadioButton;

            if (rb.Name == "rbDecon")
                d = 6;

            initializeDynamicBoxes();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        { updateGraph(); }

        private void checkedChangedPredict(object sender, EventArgs e)
        {
            RadioButton rb = sender as RadioButton;
            int update = (rb.Name == "rbSimpleLinear") ? (int)Selection.predictMethod.LINEAR :
                         (rb.Name == "rbPoly") ? (int)Selection.predictMethod.POLYNOMIAL :
                         (int)Selection.predictMethod.NONE;

            if (update != predict)
                predict = update;
        }

        private void checkedChangedFilter(object sender, EventArgs e)
        {
            RadioButton rb = sender as RadioButton;
            int update = (rb.Name == "rbAdaptive") ? (int)Selection.filterMethod.ADAPTIVE :
                         (rb.Name == "rbAverage") ? (int)Selection.filterMethod.AVERAGE :
                         (int)Selection.filterMethod.NONE;

            if (update != filter)
                filter = update;
        }

        private void checkedChangedDeblur(object sender, EventArgs e)
        {
            RadioButton rb = sender as RadioButton;
            int update = (rb.Name == "rbFFT") ? (int)Selection.deblurMethod.FFT :
                         (rb.Name == "rbConv") ? (int)Selection.deblurMethod.CONVOLUTION :
                         (rb.Name == "rbDecon") ? (int)Selection.deblurMethod.DECONVOLUTION :
                         (int)Selection.deblurMethod.NONE;

            if (update != blur)
                blur = update;
        }
        #endregion

        #region chartStuff
        private void generateChart()
        {
            Complex[] b = new Complex[SIZE];
            Complex[] a = new Complex[SIZE];
            Complex[] c;

            if (chtSignal.Series.FindByName("Original Data") != null)
                chtSignal.Series.Remove(chtSignal.Series.FindByName("Original Data"));

            //if (chtSignal.Series.FindByName("gaussian") != null)
            //    chtSignal.Series.Remove(chtSignal.Series.FindByName("gaussian"));

            if (chtSignal.Series.FindByName("Deblurred Data") != null)
                chtSignal.Series.Remove(chtSignal.Series.FindByName("Deblurred Data"));

            chtSignal.Series.Add("Original Data");
            //chtSignal.Series.Add("gaussian");
            chtSignal.Series.Add("Deblurred Data");

            chtSignal.Series["Deblurred Data"].Color = Color.Red;

            chtSignal.Series["Deblurred Data"].ChartType = SeriesChartType.Line;
            //chtSignal.Series["gaussian"].ChartType = SeriesChartType.Line;
            chtSignal.Series["Original Data"].ChartType = SeriesChartType.Line;
            chtSignal.ChartAreas[0].AxisX.Minimum = 100;
            chtSignal.ChartAreas[0].AxisX.Maximum = 900;

            for (int z = 0; z < b.Length; z++)
            {
                a[z] = new Complex(gaussian(z), 0.000001);
                b[z] = new Complex(createRandom(z), 0);
            }

            c = WellLogging.deConvolution(b, a);
            double avgC = 0, avgB = 0, delta = 0,
                   maxC = 0, minC = 100, maxB = 0, 
                   minB = 1000, dilation = 1;

            for(int z = 0; z <c.Length; z++)
            {
                avgC += c[z].Real;
                avgB += b[z].Real;

                if (c[z].Real < minC)
                    minC = c[z].Real;
                if (c[z].Real > maxC)
                    maxC = c[z].Real;

                if (b[z].Real < minB)
                    minB = b[z].Real;
                if (b[z].Real > maxB)
                    maxB = b[z].Real;
            }

            avgC /= c.Length;
            avgB /= b.Length;
            delta = ((maxC * minB) - (maxB * minC)) / (maxC - minC);
            dilation = (maxB - minB) / (maxC - minC);

            for (int z = 0; z < a.Length; z++)
            {
                chtSignal.Series["Original Data"].Points.AddXY(z, b[z].Real);
               // chtSignal.Series["gaussian"].Points.AddXY(z, a[z].Real);
                chtSignal.Series["Deblurred Data"].Points.AddXY(z, dilation * c[z].Real + delta);
            }
        } 
        #endregion

        private void updateGraph()
        {
            min = (tbMin.Text == "") ? 0 : (int.Parse(tbMin.Text) < x[0]) ? 0 :
                (int)((int.Parse(tbMin.Text) - x[0]) / (x[x.Length - 1] - x[0]) * x.Length);
            max = (tbMax.Text == "") ? x.Length - 1 : 
                (int.Parse(tbMax.Text) >= (int)x[x.Length - 1]) ? x.Length - 1 :
                (int)((int.Parse(tbMax.Text) - x[0]) / (x[x.Length - 1] - x[0]) * x.Length);

            size = max - min;
            modX = new double[1024];
            modY = new double[1024];

            int skip = (int)Math.Ceiling(size / 1050f);
            int count = 0;

            for (int n = min; n < x.Length; n+=skip)
            {
                if (count < 1024)
                {
                    modX[count] = x[n];
                    modY[count++] = (double.IsNaN(y[n])) ? 0 : y[n];
                }
                else
                    break;
            }

            output = new double[1024];

            outSeries.Points.Clear();

            if (filter != 0)
                graphFilter();
            else
                modY.CopyTo(output, 0);

            if (blur != 0)
                graphBlur();

            if(filter != 0 || blur!= 0 || predict != 0)
                for (int n = 0; n < modX.Length; n++)
                    outSeries.Points.AddXY(modX[n], output[n]); 

            if (predict != 0)
                graphPredict();
        }

        private void graphPredict()
        {
            double[] nextX = new double[64];
            double step = x[1] - x[0];
            double count = x[x.Length - 1];

            switch (predict)
            {
                case (int)Selection.predictMethod.LINEAR:
                    //Tuple<double, double> tup = MathNet.Numerics.LinearRegression.SimpleRegression.Fit(modX, output);

                    //double slope = tup.Item2;
                    //double intercept = tup.Item1;

                    //for(int n = 0; n < 64; n++)
                    //{
                    //    count += step;
                    //    outSeries.Points.AddXY(count, (slope * count) + intercept);
                    //}

                    break;
                case (int)Selection.predictMethod.POLYNOMIAL:
                    //double[] weights = MathNet.Numerics.Fit.Polynomial(modX, output, 2);

                    //for (int n = 0; n < nextX.Length; n++)
                    //{
                    //    double sum = 0;
                    //    count += step;

                    //    for (int m = 0; m < weights.Length; m++)
                    //        sum += Math.Pow(weights[m] * count, weights[m]);

                    //    outSeries.Points.AddXY(count, sum);
                    //}

                    break;
            }
        }

        private void graphBlur()
        {
            Complex[] gaus = new Complex[output.Length];
            Complex[] cY = new Complex[output.Length];

            for (int n = 0; n < output.Length; n++)
            {
                gaus[n] = gaussian(n);
                cY[n] = output[n];
            }

            switch ((Selection.deblurMethod)blur)
            {
                case Selection.deblurMethod.CONVOLUTION: output = 
                        toDouble(WellLogging.convolution(cY, gaus));
                    break;
                case Selection.deblurMethod.DECONVOLUTION: output =
                        toDouble(WellLogging.deConvolution(cY, gaus));
                    break;
                case Selection.deblurMethod.FFT: output = toDouble(WellLogging.fft(cY));
                    break;
            }


        }

        private void graphFilter()
        {
            switch (filter)
            {
                case (int)Selection.filterMethod.AVERAGE:
                    output = Filter.avgFilter(modX, modY);
                    break;
            }
        }

        public void addSeries(WellLog wl)
        {
            addData = false;
            int count = 0;

            chtSignal.Series.Add(wl.Borehole.Name + ":" + wl.Name);
            chtOutput.Series.Add(wl.Borehole.Name + ":Filter");
            Series seriesO = chtSignal.Series.FindByName(wl.Borehole.Name + ":" + wl.Name);
            outSeries = chtOutput.Series.FindByName(wl.Borehole.Name + ":Filter");
            outSeries.Color = Color.Brown;
            x = new double[wl.SampleCount];
            y = new double[wl.SampleCount];

            seriesO.ChartType = SeriesChartType.FastLine;
            outSeries.ChartType = SeriesChartType.FastLine;
            //seriesF.BorderWidth = 3;

            //string[] lines = new string[wl.SampleCount];
            //int x = 0;


            chtSignal.Titles.Clear();
            chtOutput.Titles.Clear();

            Title signalTitle = chtSignal.Titles.Add(wl.Name);
            signalTitle.Font = new System.Drawing.Font("Arial", 18, FontStyle.Bold);
            signalTitle.ForeColor = System.Drawing.Color.FromArgb(0, 0, 205);

            Title outputTitle = chtOutput.Titles.Add(wl.Name);
            outputTitle.Font = new System.Drawing.Font("Arial", 18, FontStyle.Bold);
            outputTitle.ForeColor = Color.Brown;

            foreach (WellLogSample wls in wl.Samples)
            {
                seriesO.Points.AddXY(wls.MD, wls.Value);
                x[count] = wls.MD;
                y[count++] = wls.Value;
            }

            tbMin.Text = (int)x[0] + "";
            tbMax.Text = (int)x[x.Length - 1] + "";
        }

        #region Utility Functions
        private double deltaFunction(double x)
        {
            double a = 1/10f;

            return 1 / (a * Math.Sqrt(Math.PI)) * Math.Exp((-x * x) / (a * a));
        }

        private double[] toDouble(System.Numerics.Complex[] c)
        {
            double[] output = new double[c.Length];

            for (int x = 0; x < output.Length; x++)
                output[x] = -.4 * c[x].Real + .3;

            return output;
        }

        private double gaussian(double x)
        {
            return -1 / Math.Sqrt(2 * Math.PI) * Math.Exp((-1) * 1 / d * Math.Pow(x, 2));
        }

        private double createRandom(double x)
        {
            double ran = r.NextDouble();

            return Math.Tanh((x - SIZE / 2) * .05) + ran / 3;
        }
        #endregion

        public void removeSeries(WellLog wl)
        {
            addData = true;
            int pos = chtSignal.Series.IndexOf(wl.Borehole.Name + ":" + wl.Name);
            chtSignal.Series.RemoveAt(pos);

            pos = chtOutput.Series.IndexOf(wl.Borehole.Name + ":Filter");
            chtOutput.Series.RemoveAt(pos);
        }
    }
}
