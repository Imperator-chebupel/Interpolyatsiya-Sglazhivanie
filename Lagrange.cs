using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ВычМат3
{
    public class Lagrange
    {
        public float[] X { get; set; }
        public float[] Y { get; set; }
        public float ToDo(float x)
        {
            float y = 0;
            for (int i = 0; i < X.Length; i++)
            {
                y += Y[i] * L(i, X, x);
            }
            return y;
        }
        public float L(int Index, float[] X, float x)
        {
            float l = 1;
            for (int i = 0; i < X.Length; i++)
            {
                if (i != Index)
                    l *= (x - X[i]) / (X[Index] - X[i]);
            }
            return l;
        }

    }
}
