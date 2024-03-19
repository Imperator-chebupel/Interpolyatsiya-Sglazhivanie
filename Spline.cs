using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ВычМат3
{
    public class Spline
    {
        private float[] x;
        private float[] y;
        private float[] a;
        private float[] b;
        private float[] c;
        private float[] d;

        public void CubicSplineInterpolation(float[] x, float[] y)
        {
            this.x = x;
            this.y = y;
            a = y;

            int n = x.Length;
            double[] h = new double[n - 1];

            for (int i = 0; i < n - 1; i++)
            {
                h[i] = x[i + 1] - x[i];
            }

            double[] alpha = new double[n];
            for (int i = 1; i < n - 1; i++)
            {
                alpha[i] = (3 / h[i]) * (a[i + 1] - a[i]) - (3 / h[i - 1]) * (a[i] - a[i - 1]);
            }

            double[] l = new double[n];
            double[] mu = new double[n];
            double[] z = new double[n];
            l[0] = 1;
            mu[0] = 0;
            z[0] = 0;

            for (int i = 1; i < n - 1; i++)
            {
                l[i] = 2 * (x[i + 1] - x[i - 1]) - h[i - 1] * mu[i - 1];
                mu[i] = h[i] / l[i];
                z[i] = (alpha[i] - h[i - 1] * z[i - 1]) / l[i];
            }

            l[n - 1] = 1;
            z[n - 1] = 0;
            c = new float[n];
            b = new float[n];
            d = new float[n];
            for (int j = n - 2; j >= 0; j--)
            {
                c[j] = (float)(z[j] - mu[j] * c[j + 1]);
                b[j] = (float)(((a[j + 1] - a[j]) / h[j]) - (h[j] * (c[j + 1] + 2 * c[j]) / 3));
                d[j] = (float)((c[j + 1] - c[j]) / (3 * h[j]));
            }
        }

        public double Interpolate(double xi)
        {
            int j = 0;
            while (j < x.Length - 1 && xi > x[j + 1])
            {
                j++;
            }

            double dx = xi - x[j];
            return a[j] + b[j] * dx + c[j] * dx * dx + d[j] * dx * dx * dx;
        }
    }
}

