using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ПрогаДляКаца
{
    public class Поворот
    {
        public float[,] МатрицаПослеПоворота(float[,] коордТочек, TextBox textBox1, TextBox textBox2, TextBox textBox3, Математика математика)
        {
            float[,] rez = new float[коордТочек.GetLength(0), коордТочек.GetLength(1)];
            double alphaX = 0;
            double alphaY = 0;
            double alphaZ = 0;

            if (!string.IsNullOrEmpty(textBox1.Text))
            {
                alphaX = Convert.ToDouble(textBox1.Text);
            }

            if (!string.IsNullOrEmpty(textBox2.Text))
            {
                alphaY = Convert.ToDouble(textBox2.Text);
            }

            if (!string.IsNullOrEmpty(textBox3.Text))
            {
                alphaZ = Convert.ToDouble(textBox3.Text);
            }            
            double[,] Пов = математика.МатрицаПоворота(alphaX, alphaY, alphaZ);
            математика.ПеремножениеМатриц(коордТочек, Пов, rez);
            return rez;
        }
    }
}
