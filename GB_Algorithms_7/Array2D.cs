using System;
using System.IO;

/*  5)  *а) Реализовать библиотеку с классом для работы с двумерным массивом.Реализовать конструктор, заполняющий массив случайными числами.
            Создать методы, которые возвращают сумму всех элементов массива, сумму всех элементов массива больше заданного, свойство, 
            возвращающее минимальный элемент массива, свойство, возвращающее максимальный элемент массива, метод, возвращающий номер максимального
            элемента массива(через параметры, используя модификатор ref или out).
        **б) Добавить конструктор и методы, которые загружают данные из файла и записывают данные в файл.
        **в) Обработать возможные исключительные ситуации при работе с файлами.
        
        Александр Кушмилов.
*/

namespace GB_CSharp_lvl_1._4
{
    /// <summary>
    /// Класс для работы с двумерным массивом.
    /// </summary>
    class Array2D
    {
        int[,] Arr;

        public int[,] Arr1 { get => Arr; set => Arr = value; }

        /// <summary>
        /// Конструктор заполняющий массив [a,b] случайными числами из заданного диапозона 
        /// </summary>
        /// <param name="a">кол-во строк массива</param>
        /// <param name="b">кол-во столбцов массива</param>
        /// <param name="min">минимальное значение элемента</param>
        /// <param name="max">максимальное значение элемента</param>
        public Array2D(int a, int b, int min, int max)
        {
            Arr = new int[a, b];
            Random rnd = new Random();
            for (int i = 0; i < a; i++)
            {
                for (int j = 0; j < b; j++)
                {
                    Arr[i, j] = rnd.Next(min, max);
                }
            }
        }

        /// <summary>
        /// Конструктор заполняющий массив [a,b] случайными числами из заданного диапозона и записывающий его в заданный фаил.
        /// </summary>
        /// <param name="a">кол-во строк массива</param>
        /// <param name="b">кол-во столбцов массива</param>
        /// <param name="min">минимальное значение элемента</param>
        /// <param name="max">максимальное значение элемента</param>
        /// <param name="pathToFile">Путь к файлу</param>
        public Array2D(int a, int b, int min, int max, string pathToFile)
        {
            Arr = new int[a, b];
            Random rnd = new Random();
            for (int i = 0; i < a; i++)
            {
                for (int j = 0; j < b; j++)
                {
                    Arr[i, j] = rnd.Next(min, max);
                }
            }
            this.PrintToFile(pathToFile);
        }

        /// <summary>
        /// Свойство возвращающее минимальный элемент массива
        /// </summary>
        public int Min
        {
            get
            {
                int min = Arr[0, 0];
                for (int i = 0; i < Arr.GetLength(0); i++)
                {
                    for (int j = 0; j < Arr.GetLength(1); j++)
                    {
                        if (Arr[i, j] < min) min = Arr[i, j];
                    }
                }
                return min;
            }
        }

        /// <summary>
        /// Свойство возвращающее максимальный элемент массива
        /// </summary>
        public int Max
        {
            get
            {
                int max = Arr[0, 0];
                for (int i = 0; i < Arr.GetLength(0); i++)
                {
                    for (int j = 0; j < Arr.GetLength(1); j++)
                    {
                        if (Arr[i, j] > max) max = Arr[i, j];
                    }
                }
                return max;
            }
        }

        /// <summary>
        /// Метод выводит массив в консоль
        /// </summary>
        public void Print()
        {
            for (int i = 0; i < Arr.GetLength(0); i++)
            {
                for (int j = 0; j < Arr.GetLength(1); j++)
                {
                    Console.Write($"{Arr[i, j]}\t");
                }
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Метод возвращает сумму всех элементов массива
        /// </summary>
        /// <returns></returns>
        public long Sum()
        {
            long sum = 0;
            for (int i = 0; i < Arr.GetLength(0); i++)
            {
                for (int j = 0; j < Arr.GetLength(1); j++)
                {
                    sum += Arr[i,j];
                }
            }
            return sum;
        }

        /// <summary>
        /// Метод возвращает сумму всех элементов массива больше заданного
        /// </summary>
        /// <param name="min"></param>
        /// <returns></returns>
        public long Sum(int min)
        {
            long sum = 0;
            for (int i = 0; i < Arr.GetLength(0); i++)
            {
                for (int j = 0; j < Arr.GetLength(1); j++)
                {
                    if (Arr[i,j] > min) sum += Arr[i, j];
                }
            }
            return sum;
        }

        /// <summary>
        /// Метод возвращающий индекс максимального элемента массива
        /// </summary>
        /// <param name="indexI"></param>
        /// <param name="indexJ"></param>
        public void IndexOfMax(out int indexI, out int indexJ)
        {
           
            indexI = 0;
            indexJ = 0;
            //int max = Max;

            //Реализация проходит весь массив и выдает индекс последнего из максимальных элементов если их несколько
            //for (int i = 0; i < Arr.GetLength(0); i++)
            //{
            //    for (int j = 0; j < Arr.GetLength(1); j++)
            //    {
            //        if (Arr[i, j] == max)
            //        {
            //            indexI = i;
            //            indexJ = j;
            //        }
            //    }
            //}

            //Реализация выдает индекс первого найденного максимального элемента массива, не проходя весь массив
            //int i = 0;
            //while (indexI == 0 && i < Arr.GetLength(0) && indexJ == 0)
            //{
            //    int j = 0;
            //    while (indexJ == 0 && j < Arr.GetLength(1))
            //    {
            //        if (Arr[i, j] == max)
            //        {
            //            indexI = i;
            //            indexJ = j;
            //        }
            //        j++;
            //    }
            //    i++;
            //}

            //Реализация не использует свойство Max, а является его модификацией
            int max = Arr[0, 0];
            for (int i = 0; i < Arr.GetLength(0); i++)
            {
                for (int j = 0; j < Arr.GetLength(1); j++)
                {
                    if (Arr[i, j] > max)
                    {
                        max = Arr[i, j];
                        indexI = i;
                        indexJ = j;
                    }
                }
            }
        }

        /// <summary>
        /// Метод записывает массив в фаил.
        /// </summary>
        public void PrintToFile()
        {
            try
            {
                string[] txt = new string[Arr.GetLength(1)];
                for (int i = 0; i < Arr.GetLength(0); i++)
                {
                    for (int j = 0; j < Arr.GetLength(1); j++) txt[i] = txt[i] + Convert.ToString(Arr[i, j]) + "\t";

                    File.WriteAllLines("D:\\out_lvl_1.4.txt", txt);
                }
            }
            catch (UnauthorizedAccessException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// Метод записывает массив в заданный фаил.
        /// </summary>
        /// <param name="pathToFile">Путь к файлу</param>
        public void PrintToFile(string pathToFile)
        {
            try
            {
                string[] txt = new string[Arr.GetLength(1)];
                for (int i = 0; i < Arr.GetLength(0); i++)
                {
                    for (int j = 0; j < Arr.GetLength(1); j++) txt[i] = txt[i] + Convert.ToString(Arr[i, j]) + "\t";

                    File.WriteAllLines(pathToFile, txt);
                }
            }
            catch (UnauthorizedAccessException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// Метод заполняет двумерный массив значениями из указанного файла.
        /// </summary>
        /// <param name="pathToFile">Путь к файлу</param>
        public void ReadFile(string pathToFile)
        {
            try
            {
                string text = File.ReadAllText(pathToFile);
                string[] textArr = text.Split('\t');    //разбиение на массив с разделением по табуляции
                int[] testInt = new int[textArr.Length];

                for (int k = 0; k < textArr.Length; k++)
                {
                    int x = 0;
                    Int32.TryParse(textArr[k], out x);
                    testInt[k] = x;
                }

                int y = 0;
                for (int i = 0; i < Arr.GetLength(0); i++)
                {
                    for (int j = 0; j < Arr.GetLength(1); j++)
                    {
                        Arr[i, j] = testInt[y];
                        y++;
                    }
                }
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }

}
