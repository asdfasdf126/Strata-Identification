using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Diagnostics;

namespace GeoscienceMath
{
    public class InducedSiesmicity
    {
        private static double getValue(int pos, double a, double D, double t, double t0)
        {

            if(pos > 2)
            {
                a = Math.Sqrt(6 * D * t * (t / t0 - 1) * Math.Log(Math.Abs(t / (t - t0))));
                pos -= 2;
            }

            if(pos == 1)
                return (-a / Math.Sqrt(D * t)) * Math.Exp((-a * a) / (4 * D * t));
            else
                return Math.Sqrt(Math.PI) * erf(a / Math.Sqrt(4 * D * t));
        }

        public static double seismicityRate(double a, double D, double t, double t0, double F)
        {
            if (t < t0)
                return Rb(a, D, t, F);
            else
                return R0b (t/t0, F);
        }

        private static double Ra(double a, double D, double t, double t0, double F)
        {
            double u = 0, v = 0;

            for(int x = 1; x <= 4; x++)
            {
                u += (x > 2) ? -getValue(x, a, D, t, t0) : getValue(x, a, D, t, t0);
                v += (x > 2) ? -getValue(x, a, D, t - t0, t0) : getValue(x, a, D, t - t0, t0);
            }

            return F * (v - u);
        }

        private static double R0b(double t, double F)                                                                                                                                                                                                                                                                                                                                                                                            
        {
            double lnt = Math.Log(t / (t - 1));
            double c = 3 / 2;

            return F * (erf(Math.Sqrt(c * t * lnt)) 
                - erf(Math.Sqrt((t-1)*c*lnt))
                + Math.Sqrt(6/Math.PI) * Math.Pow(t/(t-1), -c*t) 
                * (-Math.Sqrt(t/(t-1)) + Math.Pow(t/(t-1), c)
                * Math.Sqrt((t-1)*lnt)));
        }


        private static double Rb(double a, double D, double t, double F)
        {
            if (t == 0)
                return F * Math.Sqrt(Math.PI);
            else
                return F * (Math.Sqrt(Math.PI) * erf(a / Math.Sqrt(4 * D * t)) - (a / Math.Sqrt(D * t)) * Math.Exp(-(a * a) / (4 * D * t)));
        }

        public static double erf(double x)
        {
            int sign = (x < 0) ? -1 : 1;
            double t, p, ans = 0;

            double[] a = { 0.254829592,
                          -0.284496736,
                           1.421413741,
                          -1.453152027,
                           1.061405429 };

            p = 0.3275911;            
            x = Math.Abs(x);
            t = 1.0 / (1.0 + p * x);

            for(int y = a.Length-1; y >= 0; y--)
                ans = (ans + a[y]) * t;

            return sign * 1 - ans * Math.Exp(-x * x);
        }
    }
}
