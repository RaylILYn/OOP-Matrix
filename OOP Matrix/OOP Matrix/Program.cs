using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceProcess;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.X509Certificates;
using System.Runtime.Intrinsics.X86;
using System.Net.Mime;
using System.Globalization;
using System.Security.Cryptography;

namespace ConsoleApplication2
{
    class Matrix
    {
        // Закрытое поле матрица целых чисел
        int[,] matrix;
        // Закрытое строковое поле для хранения имени матрицы
        string nameofmatrix;
        // Конструктор с параметрами
        public Matrix(int n)
        {
            bool f = true;
            while (f)
            {
                if (n <= 0)
                {
                    Console.WriteLine("Отрицательное или нулевое количество элементов. Повторите ввод. ");
                    n = Convert.ToInt32(Console.ReadLine());
                }
                else
                {
                    matrix = new int[n, n];
                    f = false;
                }
            }
        }
        public Matrix(string name, int n)
        {
            bool f = true;
            while (f)
            {
                if (n <= 0)
                {
                    Console.WriteLine("Отрицательное или нулевое количество элементов. Повторите ввод. ");
                    n = Convert.ToInt32(Console.ReadLine());
                }
                else
                {
                    matrix = new int[n, n];
                    nameofmatrix = name;
                    f = false;
                }
            }

        }

        // Метод ввода матрицы
        public void vvod()
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(Mname + " [ " + (i + 1) + "," + (j + 1) + " ] = ");
                    matrix[i, j] = Convert.ToInt32(Console.ReadLine());
                }
            }
        }
        // Метод вывода матрицы
        public void vyvod()
        {
            Console.WriteLine("Матрица " + Mname);
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                    Console.Write(matrix[i, j] + " ");
                Console.WriteLine();
            }
        }
        // Свойство для определения количества строк и столбцов
        public int Length
        {
            get { return matrix.GetLength(0); }
        }
        // Индексатор для доступа к элементам поля
        public int this[int i, int j]
        {
            get { return matrix[i, j]; }
            set { matrix[i, j] = value; }
        }
        public string Mname
        {
            get
            { return nameofmatrix; }
            set { nameofmatrix = value; }

        }
        // Перегруженный метод для определения произведения отрицательных элементов массива с выводом
        public int pr(string nameofmatrix)
        {
            int Pr = 1;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] < 0)
                    { Pr *= matrix[i, j]; }
                }
            }
            Console.WriteLine(nameofmatrix + Pr);
            return Pr;
        }
        // Перегруженный метод для определения произведения отрицательных элементов массива без вывода
        public int pr()
        {
            int Pr = 1;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] < 0)
                    { Pr *= matrix[i, j]; }
                }
            }
            return Pr;
        }
        // Поэлементное сложние матрицы одинаковой размерности
        public static Matrix operator +(Matrix A, Matrix B)
        {
            Matrix D = new Matrix((A.Length > B.Length) ? A.Length : B.Length);

            for (int i = 0; i < ((A.Length > B.Length) ? B.Length : A.Length); i++)
            {
                for (int j = 0; j < ((A.Length > B.Length) ? B.Length : A.Length); j++)
                {
                    D[i, j] = A[i, j] + B[i, j];
                }
            }
            for (int i = ((A.Length > B.Length) ? B.Length : A.Length); i < D.Length; i++)
            {
                for (int j = 0; j < ((A.Length > B.Length) ? B.Length : A.Length); j++)
                {
                    D[i, j] = (A.Length > B.Length) ? A[i, j] : (-B[i, j]);
                }
            }
            return D;
        }
        // Метод определения минимального значение последней строки матрицы
        public int Min()
        {
            int min = matrix[Length - 1, 0];
            for (int j = 0; j < Length; j++)
                if (matrix[Length - 1, j] < min)
                    min = matrix[Length - 1, j];
            return min;
        }
        // Скалярная сумма матриц с одинаковым размером
        public static int Skalyar(Matrix A, Matrix B)
        {
            int size = A.Length;
            int skl = 0;
            int[] arr = new int[size];
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                    arr[i] = A[i, j] + B[i, j];
                skl += arr[i];
            }
            return skl;
        }
        class Program
        {
            static void Main(string[] args)
            {
                //1. Ввод матриц
                Console.WriteLine("Введите количество элементов матрицы А: ");
                Matrix A = new Matrix(Convert.ToInt32(Console.ReadLine()));
                A.vvod();

                Console.WriteLine("Введите количество элементов матрицы B: ");
                Matrix B = new Matrix(Convert.ToInt32(Console.ReadLine()));
                B.vvod();

                Console.WriteLine("Введите количество элементов матрицы C: ");
                Matrix C = new Matrix(Convert.ToInt32(Console.ReadLine()));
                C.vvod();

                // 2. Вывод матриц
                Console.WriteLine();
                A.vyvod();
                Console.WriteLine();
                B.vyvod();
                Console.WriteLine();
                C.vyvod();
                Console.WriteLine();

                // 3. Вычисление и вывод произведения элементов каждой матрицы
                Console.WriteLine("Произведение элементов матрицы A равно: " + A.pr());
                Console.WriteLine();
                Console.WriteLine("Произведение элементов матрицы B равно: " + B.pr());
                Console.WriteLine();
                Console.WriteLine("Произведение элементов матрицы C равно: " + C.pr());
                Console.WriteLine();

                // 4. Скалярное сложение мартиц А и B
                Console.WriteLine("Скалярное сложение матриц А и В");
                if (A.Length != B.Length) Console.WriteLine("Для выполнения скалярного сложения матрицы должны иметь одинаковую размерность");
                else Console.WriteLine("Результат равен " + Convert.ToString(Matrix.Skalyar(A, B)));

                // 5. Поэлементное сложение двух матриц
                Console.WriteLine();
                Console.WriteLine("Поэлементное сложение матрицы А и В");
                if (A.Length != B.Length) Console.WriteLine("Для выполнения сложения матрицы должны иметь одинаковую размерность");
                else
                {
                    Matrix D = A + B;
                    D.vyvod();
                }

                // 6. Произведение отрицательных элементов первого массива больше заданного числа, а в третьей матрице есть ненуле-вые элементы, увеличить все отрицательные элементы этого массива на значение минимального среди элементов последней строки третьего массива.
                Console.WriteLine("Введите число num:");
                int num;
                num = Convert.ToInt32(Console.ReadLine());
                if (A.pr() > num)
                {
                    for (int i = 0; i < A.Length; i++)
                    {

                        for (int j = 0; j < A.Length; j++)
                        {
                            if (A[i, j] < 0)
                            {
                                A[i, j] *= C.Min();
                            }
                        }
                    }
                }
                Console.WriteLine();
                A.vyvod();
                Console.WriteLine();
                Console.ReadKey();
            }
        }
    }
}