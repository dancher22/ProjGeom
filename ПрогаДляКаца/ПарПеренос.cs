using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ПрогаДляКаца
{
    public class ПарПеренос
    {
        public float[,] МатрицаПослеПереноса(float[,] коордТочек, TextBox textBox1, TextBox textBox2, TextBox textBox3, Математика математика)
        {
            float[,] rez = new float[коордТочек.GetLength(0), коордТочек.GetLength(1)];
            double X = 0;
            double Y = 0;
            double Z = 0;

            if (!string.IsNullOrEmpty(textBox1.Text))
            {
                X = Convert.ToDouble(textBox1.Text);
            }

            if (!string.IsNullOrEmpty(textBox2.Text))
            {
                Y = Convert.ToDouble(textBox2.Text);
            }

            if (!string.IsNullOrEmpty(textBox3.Text))
            {
                Z = Convert.ToDouble(textBox3.Text);
            }

            double[,] Пер = математика.МатрицаПереноса(X, Y, Z);
            математика.ПеремножениеМатриц(коордТочек, Пер, rez);
            return rez;
        }
    }
}
