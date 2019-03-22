using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
/*  1.  Написать функции, которые считывают матрицу смежности из файла и выводят её на экран.
    2.  Написать рекурсивную функцию обхода графа в глубину.
        Написать функцию обхода графа в ширину.
    3.  *Создать библиотеку функций для работы с графами.

    Александр Кушмилов
*/

namespace GB_Algorithms_7
{
    class Program
    {
        /// <summary>
        /// Метод считывает матрицу и выводит ее в консоль
        /// </summary>
        /// <param name="pathToFile">Путь к файлу с матрицей смежности</param>
        /// <param name="infinity">Обозначение +бесконечности в матрице(по умолчанию = 2 для невзвешанного графа),
        /// при выводе в консоль заменяетя "." для улучшения читаемости</param>
        /// <returns></returns>
        static int[,] ReadAndPrint (string pathToFile, int infinity = 2)
        {
            int[,] testInt = new int[2,2];
            try
            {
                string text = File.ReadAllText(pathToFile);
                string[] textArr = text.Split('\n');    //разбиение на массив с разделением по строкам
                string[,] textArr2D = new string[textArr[1].Split('\t').Length, textArr.Length];
                for (int i = 0; i < textArr2D.GetLength(0); i++)
                {
                    for (int j = 0; j < textArr2D.GetLength(1); j++)
                    {
                        textArr2D[i, j] = (string)textArr[i].Split('\t').GetValue(j);
                    }
                }

                testInt = new int[textArr2D.GetLength(0), textArr2D.GetLength(1)];

                for (int i = 0; i < textArr2D.GetLength(0); i++)
                {
                    for (int j = 0; j < textArr2D.GetLength(1); j++)
                    {
                        int x = 0;
                        Int32.TryParse(textArr2D[i, j], out x);
                        testInt[i, j] = x;
                    }
                }
                for (int i = 0; i < testInt.GetLength(0); i++)
                {
                    for (int j = 0; j < testInt.GetLength(1); j++)
                    {
                        if (testInt[i, j] == infinity)
                        {
                            Console.Write($".\t");
                        }
                        else Console.Write($"{testInt[i, j]}\t");
                    }
                    Console.WriteLine();
                }
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return testInt;
        }

        /// <summary>
        /// Метод обхода неориентированного графа(взвешенного/не взвешенного) в ширину
        /// </summary>
        /// <param name="matrix">Матрица смежности</param>
        /// <param name="marker">Стартовая вершина(индекс матрицы)</param>
        /// <param name="infinity">Обозначение +бесконечности в матрице(по умолчанию = 2 для невзвешанного графа)</param>
        /// <returns>Массив окрашенных вершин графа</returns>
        static int[] GraphToWide(int[,] matrix, int marker, int infinity = 2)
        {
            int[] resultArr = new int[matrix.GetLength(0)];
            Queue<int> queue = new Queue<int>();
            int colore = 2;
            queue.Enqueue(marker); // добавляем стартовую вершину в обработку
            resultArr[marker] = 1; // помечаем стартовую как обнаруженную
            W: while (queue.Count != 0)
            {
                int checkingEl = queue.Dequeue();
                for (int i = 0; i < matrix.GetLength(1); i++)
                {
                    if (infinity > matrix[checkingEl, i] && matrix[checkingEl, i] > 0 && resultArr[i] == 0)
                    {   // вершина обнаружена и добавлена в обработку
                        queue.Enqueue(i);
                        resultArr[i] = 1; 
                    }
                }
                resultArr[checkingEl] = colore; // вершина обработана
            }
            for (int i = 0; i < resultArr.Length; i++) // проверяем наличие несвязанных компонентов графа
            {
                if (resultArr[i] == 0)
                {
                    colore++;
                    queue.Enqueue(i);
                    goto W;
                }
            }
            return resultArr;
        }


        static void Main(string[] args)
        {
            int[,] arr = ReadAndPrint(@"..\..\123.txt", 9);
            Console.WriteLine();
            int[] res = GraphToWide(arr, 2, 9);
            foreach (var item in res)
            {
                Console.Write(item + " ");
            }
            Console.ReadKey();
        }
    }
}
