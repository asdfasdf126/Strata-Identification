using System;
using System.Numerics;

namespace GeoscienceMath
{

    public class WellLogging
    {
        private static double d = (4 * Math.PI * Math.PI)/ (3 * 1000);

        #region FFT

        public static Complex[] ifft(Complex[] amplitudes)
        {
            Complex[] ampCopy = new Complex[amplitudes.Length];

            amplitudes.CopyTo(ampCopy, 0);

            for (int x = 0; x < amplitudes.Length; x++)
                ampCopy[x] = Complex.Conjugate(ampCopy[x]);

            //apply fourier transform
            ampCopy = fft(ampCopy);

            for (int x = 0; x < ampCopy.Length; x++)
            {
                //conjugate again
                ampCopy[x] = Complex.Conjugate(ampCopy[x]);
                //scale
                ampCopy[x] /= ampCopy.Length;
            }

            return ampCopy;
        }

        public static Complex[] fft(Complex[] amplitudes)
        {
            Complex[] ampCopy = new Complex[amplitudes.Length];

            amplitudes.CopyTo(ampCopy, 0);

            if (ampCopy.Length <= 1)
                return ampCopy;

            Complex[] even = new Complex[ampCopy.Length / 2];
            Complex[] odd = new Complex[ampCopy.Length / 2];

            for (int x = 0; x < even.Length; ++x)
            {
                even[x] = ampCopy[x * 2];
                odd[x] = ampCopy[x * 2 + 1];
            }

            even = fft(even);
            odd = fft(odd);

            for (int x = 0; x < even.Length; ++x)
            {
                Complex c = Complex.FromPolarCoordinates(1.0, -2 * Math.PI * x / ampCopy.Length) * odd[x];
                ampCopy[x] = Complex.Add(even[x], c);
                ampCopy[x + even.Length] = Complex.Subtract(even[x], c);
            }

            return ampCopy;
        }
        #endregion

        #region convolution
        public static Complex[] convolution(Complex[] a, Complex[] b)
        {
            Complex[] aCopy;
            Complex[] bCopy;
            Complex[] c = new Complex[a.Length];


            aCopy = fft(a);
            bCopy = fft(b);

           for(int x = 0; x < a.Length; x++)
                c[x] = Complex.Multiply(aCopy[x], bCopy[x]);

            return ifft(c);
        }

        public static Complex[] deConvolution(Complex[] b, Complex[] a)
        {
            Complex[] aCopy;
            Complex[] bCopy;
            Complex[] c = new Complex[a.Length];

            aCopy= fft(a);
            bCopy = fft(b);

            for (int x = 0; x < c.Length; x++)
            {
                c[x] = Complex.Divide(bCopy[x], aCopy[x]);
            }

            return ifft(c);
        }
        #endregion

        public static double gaussian(double x)
        {
            return -1 / Math.Sqrt(2 * Math.PI) * Math.Exp((-1) * 1 / d * Math.Pow(x, 2));
        }
    }
}

