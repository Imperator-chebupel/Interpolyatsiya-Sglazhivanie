using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ВычМат3
{
    public class Nueton
    {
        public float[] MasX { get; set; }
        public float[] MasY { get; set; }
         public float ToDo(double x, int n, double step)
        {
            float[,] mas = new float[n + 2, n + 1];
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < n + 1; j++)
                {
                    if (i == 0)
                        mas[i, j] = MasX[j];
                    else if (i == 1)
                        mas[i, j] = MasY[j];
                }
            }
            int m = n;
            for (int i = 2; i < n + 2; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    mas[i, j] = mas[i - 1, j + 1] - mas[i - 1, j];
                }
                m--;
            }

            float[] dy0 = new float[n + 1];

            for (int i = 0; i < n + 1; i++)
            {
                dy0[i] = mas[i + 1, 0];
            }

            float res = dy0[0];
            float[] xn = new float[n];
            xn[0] = (float)(x - mas[0, 0]);

            for (int i = 1; i < n; i++)
            {
                double ans = xn[i - 1] * (x - mas[0, i]);
                xn[i] = (float)ans;
                ans = 0;
            }

            int m1 = n + 1;
            int fact = 1;
            for (int i = 1; i < m1; i++)
            {
                fact = fact * i;
                res = (float)(res + (dy0[i] * xn[i - 1]) / (fact * Math.Pow(step, i)));
            }

            return res;
        }
    }
}
