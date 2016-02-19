using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

using GeoscienceMath;

namespace TestData
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] gr = File.ReadAllLines(@"C:\Users\Group10\Desktop\GR.csv");
            string[] rhoz = File.ReadAllLines(@"C:\Users\Group10\Desktop\RHOZ.csv");
            string[] nphi = File.ReadAllLines(@"C:\Users\Group10\Desktop\NPHI.csv");
            string[] rid = File.ReadAllLines(@"C:\Users\Group10\Desktop\RID.csv");
            string[] rim = File.ReadAllLines(@"C:\Users\Group10\Desktop\RIM.csv");
            string[] pef = File.ReadAllLines(@"C:\Users\Group10\Desktop\PEF.csv");
            string[] cali = File.ReadAllLines(@"C:\Users\Group10\Desktop\CALI.csv");
            double[] dGr = new double[gr.Length];
            double[] dRhoz = new double[gr.Length];
            double[] dNphi = new double[gr.Length];
            double[] dRid = new double[gr.Length];
            double[] dRim = new double[gr.Length];
            double[] dPef = new double[gr.Length];
            double[] dCali = new double[gr.Length];
            double[] y = new double[gr.Length];
            double[] md = new double[gr.Length];
            int count = 0;
            string output = "";

            Console.WriteLine("Starting checks");
            Dictionary<int, double> weights = new Dictionary<int, double>();
            ValidateRange vr = new ValidateRange();
            count = 0;

            for (int x = 0; x < gr.Length; x++)
            {
                string check = gr.ElementAt(x).Split(',')[1];
                double value = double.Parse(check);
                double sum = 0;
                dGr[x] = value;
                md[x] = double.Parse(gr.ElementAt(x).Split(',')[0]);
                sum += vr.checkRange(LogTypes.GR, value);

                //if (sum > 0)
                {
                    if (x < rhoz.Length)
                    {
                        check = rhoz.ElementAt(x).Split(',')[1];
                        value = double.Parse(check);
                        dRhoz[x] = value;
                        sum += vr.checkRange(LogTypes.RHOZ, value);
                    }

                    if (x < nphi.Length)
                    {
                        check = nphi.ElementAt(x).Split(',')[1];
                        value = double.Parse(check);
                        dNphi[x] = value;
                        sum += vr.checkRange(LogTypes.NPHI, value);
                    }

                    if (x < rid.Length)
                    {
                        check = rid.ElementAt(x).Split(',')[1];
                        value = double.Parse(check);
                        dRid[x] = value;
                        sum += vr.checkRange(LogTypes.RID, value);
                    }

                    if (x < rim.Length)
                    {
                        check = rim.ElementAt(x).Split(',')[1];
                        value = double.Parse(check);
                        dRim[x] = value;
                        sum += vr.checkRange(LogTypes.RIM, value);
                    }

                    if (x < pef.Length)
                    {
                        check = pef.ElementAt(x).Split(',')[1];
                        value = double.Parse(check);
                        dPef[x] = value;
                        sum += vr.checkRange(LogTypes.PEF, value);
                    }

                    if (x < cali.Length)
                    {
                        check = cali.ElementAt(x).Split(',')[1];
                        value = double.Parse(check);
                        dCali[x] = value;
                        sum += vr.checkRange(LogTypes.CALI, value);
                    }
                }

                weights.Add(x, sum);
            }

            double[] nGr = calc(dGr);
            double[] nRhoz = calc(dRhoz);
            double[] nNphi = calc(dNphi);
            double[] nRid = calc(dRid);
            double[] nRim = calc(dRim);
            double[] nPef = calc(dPef);
            double[] nCali = calc(dCali);

            Filter.avgFilter(md, dGr);
            Filter.avgFilter2(md, dGr);

            for (int z = 0; z < md.Length; z++) ;

            string[] outString = new string[gr.Length];

            for (int x = 0; x < weights.Count; x++)
            {
               // if (x % 388 == 0)
                {
                    int shale = (weights[x] > 0) ? (weights[x] > .70) ? 3 : 2 : 1;
                    outString[count++] = shale + " 1:" + calc(nGr, dGr[x]) +
                                                 " 2:" + calc(nRhoz, dRhoz[x]) +
                                                 " 3:" + calc(nNphi, dNphi[x]) +
                                                 " 4:" + calc(nRid, dRid[x]) +
                                                 " 5:" + calc(nRim, dRim[x]) +
                                                 " 6:" + calc(nPef, dPef[x]) +
                                                 " 7:" + calc(nCali, dCali[x]);
                }
            }

            File.WriteAllLines(@"C:\Users\Group10\Desktop\mod.txt", outString);

            Console.WriteLine("Finished!");
            Console.Read();
        }

        public static double[] calc(double[] value)
        {
            double[] norm = new double[2];
            double min = double.NaN;
            double max = double.NaN;

            for(int x = 0; x < value.Length; x++)
            {
                if(double.IsNaN(min))
                    min = value[x];
                else if(value[x] < min)
                    min = value[x];

                if(double.IsNaN(max))
                    max = value[x];
                else if(value[x] > max)
                    max = value[x];
            }

            norm[0] = 2 / (max - min);
            norm[1] = -(max + min) / (max - min);

            return norm;
        }

        public static double calc(double[] norm, double value)
        {
            return norm[0] * value + norm[1];
        }
    }
}
