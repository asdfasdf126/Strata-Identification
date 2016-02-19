using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ABMath.ModelFramework.Models;
using ABMath.ModelFramework.Data;
using MathNet.Numerics.Distributions;
using MathNet.Numerics;
using MathNet.Numerics.LinearAlgebra.Complex32;
using MathNet.Numerics.LinearAlgebra.Factorization;

namespace GeoscienceMath
{
    public class Prediction
    {
        public static double[] simpleRegress(double[] x, double[] y)
        {
            int N = x.Length;
            double sumX = 0, sumY = 0,
                   sumXY = 0, sumX2 = 0,
                   a, b, count = x[N-1];
            double[] output = new double[N+64];
            double step = x[1] - x[0];

            for (int len = 0; len < x.Length; len++)
            {
                sumX += x[len];
                sumY += y[len];
                sumXY += x[len] * y[len];
                sumX2 += x[len] * x[len];
            }

            b = (N * sumXY - sumX * sumY) / (N * sumX2 - Math.Pow(sumX,2));
            a = (sumY - b * sumX) / N;

            Console.WriteLine(a + " " + b);

            y.CopyTo(output, 0);

            for (int z = N; z < output.Length; z++)
            {
                count += step;
                output[z] = b * (count + N) + a;
            }

            return output;
        }

        public static double[] Polyfit(double[] x, double[] y, int degree)
        {
            double[] output = new double[x.Length];
            // Vandermonde matrix
            var v = new DenseMatrix(x.Length, degree + 1);
            for (int i = 0; i < v.RowCount; i++)
                for (int j = 0; j <= degree; j++) v[i, j] = new Complex32((float)Math.Pow(x[i], j), 0);
            var yv = toDenseVector(y).ToColumnMatrix();
            QR<Complex32> qr = v.QR();
            // Math.Net doesn't have an "economy" QR, so:
            // cut R short to square upper triangle, then recompute Q
            var r = qr.R.SubMatrix(0, degree + 1, 0, degree + 1);
            var q = v.Multiply(r.Inverse());
            var p = r.Inverse().Multiply(q.TransposeThisAndMultiply(yv));

            for (int z = 0; z < x.Length; z++)
                output[z] = p.Column(0)[z].Real;

            return output;
        }

        public static DenseVector toDenseVector(double[] a)
        {
            Complex32[] c = new Complex32[a.Length];

            for (int x = 0; x < c.Length; x++)
                c[x] = new Complex32((float)a[x], 0);

            return new DenseVector(c);
        }

        public static ARMAModel SVM(double[] x, double[] y)
        {
            //Specify the AR and MA paramaters
            ARMAModel model1 = new ARMAModel(4, 3);
            //Make new time series variable
            TimeSeries ts1 = new TimeSeries();
            var dt = new DateTime(2001, 1, 1);

            //Create the data
            for (int t = 0; t < y.Length; ++t)
            {
                dt = new DateTime(t);
                ts1.Add(dt, y[t], false);
            }

            model1.SetInput(0, ts1, null);
            //Maximum Likelihood Estimation
            model1.FitByMLE(10, 10, 10, null);
            //Compute the residuals
            //model1.ComputeResidualsAndOutputs();

            return model1;
        }
    }
}
