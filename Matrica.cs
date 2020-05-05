using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;


namespace firsttry
{
    class Matrica<T>
    {

        [JsonProperty]
        T[,] arr;
        public int Rows { get; set; }
        public int Cells { get; set; }

        public Matrica()
        {
        }

        public Matrica(int rows, int cells)
        {
            Rows = rows;
            Cells = cells;
            arr = new T[rows, cells];
        }
        public Matrica(T[,] arr)
        {
            this.arr = arr;
            Rows = arr.GetLength(0);
            Cells = arr.GetLength(1);
        }
        public T this[int i, int j]
        {
            get => arr[i, j];
            set => arr[i, j] = value;
        }

        public static Matrica<T> operator *(Matrica<T> m1, Matrica<T> m2)
        {
            if (m1.Cells != m2.Rows)
            {
                throw new Exception("Wrong matrix size!");
            }
            Matrica<T> m3 = new Matrica<T>(m1.Rows, m2.Cells);

            for (int i = 0; i < m1.Rows; i++)
            {
                for (int k = 0; k < m2.Cells; k++)
                {
                    for (int j = 0; j < m1.Cells; j++)
                    {
                        dynamic a = m1[i, j];
                        dynamic b = m2[j, k];
                        m3[i, k] += a * b;
                    }
                }
            }
            return m3;
        }

        public static Matrica<T> operator +(Matrica<T> a, Matrica<T> b)
        {
            Matrica<T> resMass = new Matrica<T>(a.Rows, b.Cells);
            for (int i = 0; i < a.Rows; i++)
            {
                for (int j = 0; j < b.Cells; j++)
                {
                    dynamic aa = a[i, j];
                    dynamic bb = b[i, j];
                    resMass[i, j] =  aa + bb;
                }
            }
            return resMass;
        }
        // Перегрузка сложения
        





    }
}
