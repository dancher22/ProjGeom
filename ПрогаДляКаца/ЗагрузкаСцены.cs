using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ПрогаДляКаца
{
    public class ЗагрузкаСцены
    {
        public void Сцена_В_Грид(StreamReader streamReader, DataGridView dgv)
        {
            dgv.Rows.Clear();
            string value = streamReader.ReadLine();
            int j = 0;
            while (value != string.Empty && value != null)
            {
                string[] col = Regex.Split(value, ",");

                dgv.Rows.Add();
                for (int i = 0; i < col.Length; i++)
                {
                    dgv[i, j].Value = col[i];
                }
                j++;
                value = streamReader.ReadLine();
            }
        }
        public float[,] Сцена_В_Массив(DataGridView dgv)
        {
            int i = dgv.ColumnCount;
            int j = dgv.RowCount;

            float[,] points = new float[i, j];
            for (int k = 0; k < j; k++)
            {
                for (int l = 0; l < i; l++)
                {
                    points[l, k] = Convert.ToSingle(dgv[l, k].Value);
                }
            }
            return points;
        }
        public int[,] pointNumber(DataGridView dgv)
        {
            int i = dgv.ColumnCount;
            int j = dgv.RowCount;

            int[,] pointNumb = new int[i, j];
            for (int k = 0; k < j; k++)
            {
                for (int l = 0; l < i; l++)
                {
                    pointNumb[l, k] = Convert.ToInt32(dgv[l, k].Value);
                }
            }
            return pointNumb;
        }
    }
}
