using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ПрогаДляКаца
{
    public class Масштабирование
    {
        public float[,] МатрицаПослеМасштабирования(float[,] коордТочек, TextBox textBox1, Математика математика)
        {
            float[,] rez = new float[коордТочек.GetLength(0), коордТочек.GetLength(1)];
            double K = 1;

            if (!string.IsNullOrEmpty(textBox1.Text))
            {
                K = Convert.ToDouble(textBox1.Text);
            }

            double[,] Масшт = математика.МатрицаМасштабирования(K);
            математика.ПеремножениеМатриц(коордТочек, Масшт, rez);
            return rez;
        }
    }
}
