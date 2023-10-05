using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Lab04
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int nn, mm, minn, maxx;
            Console.WriteLine("Введите длину матрицы:");
            nn = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Введите ширину матрицы:");
            mm = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Введите минимальное значение элементов матрицы:");
            minn = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Введите максимальное значение элементов матрицы:");
            maxx = Int32.Parse(Console.ReadLine());

            MyMatrix mat1 = new MyMatrix(nn, mm, minn, maxx);
            Console.WriteLine("\nЗаданная матрица:");
            mat1.print();
            Console.WriteLine("\n" + new string('=', Console.WindowWidth) + "\n");

            MyMatrix mat2 = new MyMatrix(3, 3, -10, 10);
            Console.WriteLine("\nМатрица 1:");
            mat2.print();
            MyMatrix mat3 = new MyMatrix(3, 3, -20, -10);
            Console.WriteLine("\nМатрица 2:");
            mat3.print();
            MyMatrix mat4, mat5, mat6, mat7;

            Console.WriteLine("\nСложение матрицы 1 и матрицы 2:");
            mat4 = mat2 + mat3;
            mat4.print();

            Console.WriteLine("\nВычитание из матрицы 1 матрицы 2:");
            mat5 = mat2 - mat3;
            mat4.print();

            Console.WriteLine("\nУмножение матрицы 1 на матрицу 2");
            mat6 = mat2 * mat3;
            mat6.print();

            Console.WriteLine("\nУмножение матрицы 1 на константу 3");
            mat7 = mat2 * 3;
            mat7.print();

            Console.WriteLine("Обращение по индексу");
            Console.WriteLine(mat7[2, 2]);

        }
    }

    class MyMatrix
    {
        public int n, m;
        private double[,] arr;

        public MyMatrix(int n1, int m1, int min, int max)
        {
            Random random = new Random();
            n = n1;
            m = m1;
            arr = new double[n, m];
            for (int i = 0; i < n; i++)
                for (int j = 0; j < m; j++)
                {
                    arr[i, j] = random.Next(min, max);
                }
        }
        /// 
        /// 

        public double this[int n1, int m1]
        {
            get { return arr[n1, m1]; }
            set { arr[n1, m1] = value; }
        }


        ///
        /// 


        public MyMatrix(double[,] arr2)
        {
            n = arr2.GetLength(0);
            m = arr2.GetLength(1);
            arr = arr2;
        }

        public void print()
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write(arr[i, j] + "\t");
                }
                Console.WriteLine("\n");
            }
        }

        public double elemAt(int x, int y)
        {
            return arr[x, y];
        }


        public static MyMatrix operator /(MyMatrix matrix1, double k)
        {
            double[,] result = new double[matrix1.n, matrix1.m];
            for (int i = 0; i < matrix1.n; i++)
                for (int j = 0; j < matrix1.m; j++)
                {
                    result[i, j] = matrix1.elemAt(i, j) / k;
                }
            return new MyMatrix(result);
        }

        public static MyMatrix operator *(MyMatrix matrix1, double k)
        {
            double[,] result = new double[matrix1.n, matrix1.m];
            for (int i = 0; i < matrix1.n; i++)
                for (int j = 0; j < matrix1.m; j++)
                {
                    result[i, j] = matrix1.elemAt(i, j) * k;
                }
            return new MyMatrix(result);
        }

        public static MyMatrix operator +(MyMatrix matrix1, MyMatrix matrix2)
        {
            if (matrix1.n != matrix2.n || matrix1.m != matrix2.m)
            {
                Console.WriteLine("Складывать можно только матрицы одного порядка");
            }
            double[,] result = new double[matrix1.n, matrix1.m];
            for (int i = 0; i < matrix1.n; i++)
                for (int j = 0; j < matrix1.m; j++)
                {
                    result[i, j] = matrix1.elemAt(i, j) + matrix2.elemAt(i, j);
                }
            return new MyMatrix(result);

        }

        public static MyMatrix operator -(MyMatrix matrix1, MyMatrix matrix2)
        {
            if (matrix1.n != matrix2.n || matrix1.m != matrix2.m)
            {
                Console.WriteLine("Вычитать можно только матрицы одного порядка");
            }
            double[,] result = new double[matrix1.n, matrix1.m];
            for (int i = 0; i < matrix1.n; i++)
                for (int j = 0; j < matrix1.m; j++)
                {
                    result[i, j] = matrix1.elemAt(i, j) - matrix2.elemAt(i, j);
                }
            return new MyMatrix(result);

        }

        public static MyMatrix operator *(MyMatrix matrix1, MyMatrix matrix2)
        {
            if (matrix1.m != matrix2.n)
            {
                Console.WriteLine("Операция умножения двух матриц выполнима только в том случае, " +
                    "если число столбцов в первом сомножителе равно числу строк во втором");

            }
            double[,] result = new double[matrix1.n, matrix2.m];
            for (int i = 0; i < matrix1.n; i++)
                for (int j = 0; j < matrix2.m; j++)
                    for (int k = 0; k < matrix2.n; k++) //
                    {
                        result[i, j] += matrix1.elemAt(i, k) * matrix2.elemAt(k, j);
                    }

            return new MyMatrix(result);

        }
    }
}
