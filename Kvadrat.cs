using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ВычМат3
{
    public class Kvadrat
    {
        public float[] x;
        public float[] y;
        public float[] Answer = new float[4];
        public int RowCount = 4, ColumCount =4;
        public float SolveLeastSquares(float Chislo)
        {
            int n = x.Length;

            /*float[,] coefficientsMatrix = {{n, sumX, sumX2, sumX3},
                                         {sumX, sumX2, sumX3, sumX4},
                                         {sumX2, sumX3, sumX4, sumX3},
                                         {sumX3, sumX4, sumX3, sumX4}};*/
            float[,] coefficientsMatrix = { {Summa(3), Summa(2), Summa(1), n },
                                            {Summa(4),Summa(3),Summa(2),Summa(1) },
                                            {Summa(5),Summa(4),Summa(3),Summa(2) },
                                            {Summa(6),Summa(5),Summa(4),Summa(3) } };

            float[] constantsVector = {y.Sum(), DveSummy(1), DveSummy(2), DveSummy(3)  };

            SolveMatrix(coefficientsMatrix, constantsVector);

            return (float)(Math.Pow(Chislo, 3) * Answer[0] + Math.Pow(Chislo, 2) * Answer[1] + Answer[2]*Chislo + Answer[3] );
        }

        public float Summa(int stepen)
        {
            float To_Return = 0;
            for (int i = 0; i < x.Length; i++)
            {
                To_Return += (float)Math.Pow(x[i] , stepen);
            }
            return To_Return;
        }

        public float DveSummy(int stepen)
        {
            float To_Return = 0;
            for (int i = 0; i < x.Length; i++)
            {
                To_Return += ((float)Math.Pow(x[i], stepen) * y[i]);
            }
            return To_Return;
        }



        public void SolveMatrix(float[,] Matrix, float[] RightPart)
        {
            for (int i = 0; i < RowCount - 1; i++)
            {
                SortRows(i,  Matrix,  RightPart);
                for (int j = i + 1; j < RowCount; j++)
                {
                    if (Matrix[i,i] != 0) //если главный элемент не 0, то производим вычисления
                    {
                        float MultElement = Matrix[j,i] / Matrix[i,i];
                        for (int k = i; k < ColumCount; k++)
                            Matrix[j,k] -= Matrix[i,k] * MultElement;
                        RightPart[j] -= RightPart[i] * MultElement;
                    }
                }
            }
            //решение
            for (int i = (int)(RowCount - 1); i >= 0; i--)
            {
                Answer[i] = RightPart[i];
                for (int j = (int)(RowCount - 1); j > i; j--)
                    Answer[i] -= Matrix[i,j] * Answer[j];
                Answer[i] /= Matrix[i,i];
            }
        }


        private void SortRows(int SortIndex,float[,] Matrix, float[] RightPart)
        {

            float MaxElement = Matrix[SortIndex,SortIndex];
            int MaxElementIndex = SortIndex;
            for (int i = SortIndex + 1; i < RowCount; i++)
            {
                if (Matrix[i,SortIndex] > MaxElement)
                {
                    MaxElement = Matrix[i, SortIndex];
                    MaxElementIndex = i;
                }
            }

            if (MaxElementIndex > SortIndex)//если это не первый элемент
            {
                float Temp;

                Temp = RightPart[MaxElementIndex];
                RightPart[MaxElementIndex] = RightPart[SortIndex];
                RightPart[SortIndex] = Temp;

                for (int i = 0; i < ColumCount; i++)
                {
                    Temp = Matrix[MaxElementIndex,i];
                    Matrix[MaxElementIndex,i] = Matrix[SortIndex,i];
                    Matrix[SortIndex,i] = Temp;
                }
            }
        }

    }
}
