using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ПрогаДляКаца
{
    public class Математика
    {
        public void ПеремножениеМатриц(float[,] matr1, double[,] matr2, float[,] rez)
        {
            for (int i = 0; i < matr1.GetLength(1); i++)
            {
                for (int j = 0; j < matr1.GetLength(0); j++)
                {
                    rez[j, i] = 0;
                    for (int k = 0; k < matr2.GetLength(1); k++)
                    {
                        rez[j, i] = rez[j, i] + matr1[k, i] * Convert.ToSingle(matr2[k, j]);
                    }
                }
            }
        }

        public void ПеремножениеМатриц(double[,] matr1, double[,] matr2, double[,] rez)
        {
            for (int i = 0; i < matr1.GetLength(1); i++)
            {
                for (int j = 0; j < matr1.GetLength(0); j++)
                {
                    rez[j, i] = 0;
                    for (int k = 0; k < matr2.GetLength(1); k++)
                    {
                        rez[j, i] = rez[j, i] + matr1[k, i] * matr2[k, j];
                    }
                }
            }
        }

        public void Нормализация(float[,] matr1, float[,] rez)
        {
            double d = 0;
            double[,] нормал = new double[4, 4];
            for (int i = 0; i < matr1.GetLength(1); i++)
            {
                d = matr1[3, i];
                нормал = МатрицаНормализации(d);
                for (int j = 0; j < matr1.GetLength(0); j++)
                {
                    rez[j, i] = 0;                   
                    for (int k = 0; k < нормал.GetLength(1); k++)
                    {
                        rez[j, i] = rez[j, i] + matr1[k, i] * Convert.ToSingle(нормал[k, j]);
                    }
                }
            }
        }

        public double[,] МатрицаПоворота(double alphaX, double alphaY, double alphaZ)
        {
            alphaX = alphaX * Math.PI / 180;
            alphaY = alphaY * Math.PI / 180;
            alphaZ = alphaZ * Math.PI / 180;
            double[,] ПовX = new double[4, 4] { { 1, 0,                 0,                0 },
                                                { 0, Math.Cos(alphaX),  Math.Sin(alphaX), 0 },
                                                { 0, -Math.Sin(alphaX), Math.Cos(alphaX), 0 },
                                                { 0, 0,                 0,                1 } };

            double[,] ПовY = new double[4, 4] { { Math.Cos(alphaY), 0, Math.Sin(alphaY),  0},
                                                { 0,                 1, 0,                0},
                                                { -Math.Sin(alphaY), 0, Math.Cos(alphaY), 0},
                                                { 0,                 0, 0,                1} };

            double[,] ПовZ = new double[4, 4] { { Math.Cos(alphaZ),  Math.Sin(alphaZ), 0, 0 },
                                                { -Math.Sin(alphaZ), Math.Cos(alphaZ), 0, 0 },
                                                { 0,                 0,                1, 0 },
                                                { 0,                 0,                0, 1 } };
            ;
            double[,] XY = new double[4, 4];
            ПеремножениеМатриц(ПовX, ПовY, XY);
            double[,] XYZ = new double[4, 4];
            ПеремножениеМатриц(ПовZ, XY, XYZ);
            return XYZ;
        }

        public double[,] МатрицаПереноса(double X, double Y, double Z)
        {
            double[,] Пер = new double[4, 4]  { { 1, 0, 0, 0 },
                                                { 0, 1, 0, 0 },
                                                { 0, 0, 1, 0 },
                                                { X, Y, Z, 1 } };
            return Пер;
        }

        public double[,] МатрицаМасштабирования(double K)
        {
            double[,] Масшт = new double[4, 4] { { K, 0, 0, 0 },
                                                 { 0, K, 0, 0 },
                                                 { 0, 0, K, 0 },
                                                 { 0, 0, 0, 1 } };
            return Масшт;
        }

        public double[,] МатрицаКосогоСдвигаXпоY(double K)
        {
            double[,] Масшт = new double[4, 4] { { 1, 0, 0, 0 },
                                                 { K, 1, 0, 0 },
                                                 { 0, 0, 1, 0 },
                                                 { 0, 0, 0, 1 } };
            return Масшт;
        }

        public double[,] МатрицаОПП(double d)
        {
            double[,] ОПП = new double[4, 4] { { 1, 0, 0, 0 },
                                               { 0, 1, 0, 0 },
                                               { 0, 0, 1, d },
                                               { 0, 0, 0, 1 } };
            return ОПП;
        }

        public double[,] МатрицаНормализации(double d)
        {

            double[,] нормализация = new double[4, 4] { { 100/d, 0, 0, 0 },
                                                        { 0, 100/d, 0, 0 },
                                                        { 0, 0, 100/d, 0 },
                                                        { 0, 0, 0, 100/d } };
            return нормализация;
        }
    }
}
