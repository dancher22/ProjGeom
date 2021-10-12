using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ПрогаДляКаца
{
    public class ОПП
    {
        public float[,] МатрицаПослеОПП(float[,] коордТочек, TextBox textBox1, Математика математика)
        {
            float[,] послеОПП = new float[коордТочек.GetLength(0), коордТочек.GetLength(1)];
            float[,] послеНорм = new float[коордТочек.GetLength(0), коордТочек.GetLength(1)];
            double d = 0;

            if (!string.IsNullOrEmpty(textBox1.Text))
            {
                d = Convert.ToDouble(textBox1.Text);
            }

            double[,] матрОПП = математика.МатрицаОПП(d);
            математика.ПеремножениеМатриц(коордТочек, матрОПП, послеОПП);
            математика.Нормализация(послеОПП, послеНорм);                       
            return послеНорм;
        }
    }
}
