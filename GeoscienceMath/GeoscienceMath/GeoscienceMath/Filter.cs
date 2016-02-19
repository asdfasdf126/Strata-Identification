using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MathNet.Filtering.Kalman;
using MathNet.Filtering.FIR;
using MathNet.Filtering.IIR;
using MathNet.Filtering.DataSources;
using MathNet.Filtering.Median;
using MathNet.Filtering.Windowing;
using MathNet.Filtering.Windows;
using MathNet.Filtering;

using MathNet.Numerics.LinearAlgebra;

namespace GeoscienceMath
{
    public class Filter
    {
        public static double[] avgFilter2(double[] x, double[] y)
        {
            Queue<double> value = new Queue<double>();
            Queue<double> depth = new Queue<double>();
            double[] output = new double[x.Length];
            int size = (int)Math.Ceiling(x.Length / 2000f);
            int count = 0;


            for (int z = 0; z < x.Length; z++)
            {
                value.Enqueue(y[z]);
                depth.Enqueue(x[z]);

                if (count < 100)
                    depth.Dequeue();

                if (value.Count == size)
                {
                    output[z] = getAvg(value, depth, size);
                    printD(depth, y[z]);
                }
                else
                    output[z] = 0;

                count++;
            }

            return output;
        }

        private static void printD(Queue<double> depth, double value)
        {
            for (int x = 0; x < depth.Count; x++)
                Console.WriteLine(depth.ElementAt(x));

            Console.WriteLine(depth.Count);
        }

        private static double getAvg(Queue<double> value, Queue<double> depth, int size)
        {
            double avg = 0;

            foreach (double d in value)
                avg += d;

            value.Dequeue();

            return avg / size;
        }

        public static double[] avgFilter(double[] x, double[] y)
        {
            int size = 200;
            double sum;
            double[] output = new double[x.Length];
            int count = 100;

            for (int j = size / 2; j < x.Length - 100; j++)
            {
                sum = 0;

                for (int i = j - size / 2; i < j + size / 2; i++)
                    sum += y[i];

                output[count++] = sum / size;
            }

            return output;
        }

        public static double[] kalmanFilter(double[] y)
        {
            MathNet.Filtering.DataSources.WhiteGaussianNoiseSource a = new WhiteGaussianNoiseSource();

            OnlineFilter olf = OnlineFilter.CreateDenoise(201);

            return olf.ProcessSamples(y);

            //MathNet.Filtering.Median.OnlineMedianFilter omf = new OnlineMedianFilter(200);
            //return omf.ProcessSamples(y);
        }

        static public double[] CleanData(double[] noisy, int range, double decay)
        {
            double[] clean = new double[noisy.Length];
            double[] coefficients = Coefficients(range, decay);
 
            // Calculate divisor value.
            double divisor = 0;
            for (int i = -range; i <= range; i++)
                divisor += coefficients[Math.Abs(i)];
 
            // Clean main data.
            for (int i = range; i < clean.Length - range; i++)
            {
                double temp = 0;
                for (int j = -range; j <= range; j++)
                    temp += noisy[i + j] * coefficients[Math.Abs(j)];
                clean[i] = temp / divisor;
            }
 
            // Calculate leading and trailing slopes.
            double leadSum = 0;
            double trailSum = 0;
            int leadRef = range;
            int trailRef = clean.Length - range - 1;
            for (int i = 1; i <= range; i++)
            {
                leadSum += (clean[leadRef] - clean[leadRef + i]) / i;
                trailSum += (clean[trailRef] - clean[trailRef - i]) / i;
            }
            double leadSlope = leadSum / range;
            double trailSlope = trailSum / range;
 
            // Clean edges.
            for (int i = 1; i <= range; i++)
            {
                clean[leadRef - i] = clean[leadRef] + leadSlope * i;
                clean[trailRef + i] = clean[trailRef] + trailSlope * i;
            }
            return clean;
        }

        static private double[] Coefficients(int range, double decay)
        {
            // Precalculate coefficients.
            double[] coefficients = new double[range + 1];
            for (int i = 0; i <= range; i++)
                coefficients[i] = Math.Pow(decay, i);
            return coefficients;
        }
    }
}
