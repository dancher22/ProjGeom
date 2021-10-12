using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ПрогаДляКаца
{
    public class КосойСдвиг
    {
        public float[,] МатрицаПослеКосогоСдвига(float[,] коордТочек, TextBox textBox1, Математика математика)
        {
            float[,] rez = new float[коордТочек.GetLength(0), коордТочек.GetLength(1)];
            double K = 0;

            if (!string.IsNullOrEmpty(textBox1.Text))
            {
                K = Convert.ToDouble(textBox1.Text);
            }

            double[,] КосойСдвиг = математика.МатрицаКосогоСдвигаXпоY(K);
            математика.ПеремножениеМатриц(коордТочек, КосойСдвиг, rez);
            return rez;
        }
    }
}
