using System;
using System.Linq;
using System.Windows.Forms;
 

namespace ВычМат3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            float[] X_value = new float[5] { -1, 0, 1, 2 , 3 };
            float[] Y_value = new float[5] { -2, -2, -7, 1 , 14 };
            for (int i = 0; i < X_value.Length; i++)
            {
                this.chart1.Series[0].Points.AddXY(X_value[i], Y_value[i]);
            }

            Lagrange La = new Lagrange() {X = X_value, Y = Y_value };
            Nueton Nu = new Nueton() { MasX = X_value, MasY = Y_value };
            Spline Sp = new Spline();
            Kvadrat Kv = new Kvadrat() {x = X_value, y = Y_value };
            Sp.CubicSplineInterpolation(X_value, Y_value);
            Kv.SolveLeastSquares(1);

            float g = X_value.Min();
            while (g < X_value.Max())
            {
                this.chart1.Series[1].Points.AddXY(g, La.ToDo(g));
                this.chart1.Series[2].Points.AddXY(g, Nu.ToDo(g, X_value.Length -1, 1f));
                this.chart1.Series[3].Points.AddXY(g, Sp.Interpolate(g));
                this.chart1.Series[4].Points.AddXY(g, Kv.SolveLeastSquares(g));
                g += 0.01f;
            }
            textBox1.Text += (Kv.Answer[0] + " " + Kv.Answer[1] + " "+ Kv.Answer[2] + " "+ Kv.Answer[3] + " ");
        }
    }
}
