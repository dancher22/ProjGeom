using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace ПрогаДляКаца
{
    public partial class Form1 : Form
    {
        public float[,] коордТочек;
        int[,] номераТочек;

        public bool ОтобрСцену = false;
        public bool Повернуть = false;
        public bool ПарПер = false;
        public bool Масшт = false;
        public bool косСдвиг = false;
        public bool однПП = false;

        Point3D p1 = new Point3D();
        Point3D p2 = new Point3D();
        Поворот поворот = new Поворот();
        ПарПеренос парПеренос = new ПарПеренос();
        Масштабирование масштабирование = new Масштабирование();
        КосойСдвиг косойСдвиг = new КосойСдвиг();
        ОПП опп = new ОПП();
        Математика математика = new Математика();

        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            if (ОтобрСцену)
            {
                Рисовалка(p1, p2, e, коордТочек, номераТочек);
                ОтобрСцену = false;
            }
            if (Повернуть)
            {
                коордТочек = поворот.МатрицаПослеПоворота(коордТочек, textBox1, textBox2, textBox3, математика);
                Рисовалка(p1, p2, e, коордТочек, номераТочек);
                Повернуть = false;
            }
            if (ПарПер)
            {
                коордТочек = парПеренос.МатрицаПослеПереноса(коордТочек, textBox4, textBox5, textBox6, математика);
                Рисовалка(p1, p2, e, коордТочек, номераТочек);
                ПарПер = false;               
            }
            if (Масшт)
            {
                коордТочек = масштабирование.МатрицаПослеМасштабирования(коордТочек, textBox7, математика);
                Рисовалка(p1, p2, e, коордТочек, номераТочек);
                Масшт = false;
            }
            if (косСдвиг)
            {
                коордТочек = косойСдвиг.МатрицаПослеКосогоСдвига(коордТочек, textBox8, математика);
                Рисовалка(p1, p2, e, коордТочек, номераТочек);
                косСдвиг = false;
            }
            if (однПП)
            {
                коордТочек = опп.МатрицаПослеОПП(коордТочек, textBox9, математика);
                Рисовалка(p1, p2, e, коордТочек, номераТочек);
                однПП = false;
            }
        }

        private void ЗагрСцены_Click(object sender, EventArgs e)
        {
            ЗагрузкаСцены загрузка = new ЗагрузкаСцены();
            StreamReader streamReader = new StreamReader(Path.GetFullPath("Точки.txt"));
            загрузка.Сцена_В_Грид(streamReader, dataGridView1);
            загрузка.Сцена_В_Грид(streamReader, dataGridView2);
            коордТочек = загрузка.Сцена_В_Массив(dataGridView1);
            номераТочек = загрузка.pointNumber(dataGridView2);
        }

        public void Рисовалка(Point3D p1, Point3D p2, PaintEventArgs e, float[,] коордТочек, int[,] номераТочек) 
        {
            e.Graphics.TranslateTransform(pictureBox1.Width / 2, pictureBox1.Height / 2);
            e.Graphics.RotateTransform(270);
            for (int i = 0; i < dataGridView2.RowCount; i++)
            {
                p1.X = коордТочек[0, номераТочек[0, i] - 1];
                p1.Y = коордТочек[1, номераТочек[0, i] - 1];
                
                p2.X = коордТочек[0, номераТочек[1, i] - 1];
                p2.Y = коордТочек[1, номераТочек[1, i] - 1];

                e.Graphics.DrawLine(Pens.Blue, p1.X, p1.Y, p2.X, p2.Y);
            }
        }
     
        private void ОтобрСцену_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
            ОтобрСцену = true;
            pictureBox1.Refresh();
        }

        private void ОчиститьКартинку_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
        }

        private void Пов_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
            Повернуть = true;
            pictureBox1.Refresh();
        }

        private void ПарПер_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
            ПарПер = true;
            pictureBox1.Refresh();
        }

        private void Масштаб_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
            Масшт = true;
            pictureBox1.Refresh();
        }

        private void КосСдвиг_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
            косСдвиг = true;
            pictureBox1.Refresh();
        }

        private void ОднПП_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
            однПП = true;
            pictureBox1.Refresh();
        }
    }
}
