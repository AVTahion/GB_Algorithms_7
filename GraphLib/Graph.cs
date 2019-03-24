using System;
using System.Collections.Generic;
using System.IO;

namespace GraphLib
{
    public class Graph
    {
        /// <summary>
        /// Метод считывает матрицу и выводит ее в консоль
        /// </summary>
        /// <param name="pathToFile">Путь к файлу с матрицей смежности</param>
        /// <param name="infinity">Обозначение +бесконечности в матрице(по умолчанию = 2 для невзвешанного графа),
        /// при выводе в консоль заменяетя "." для улучшения читаемости</param>
        /// <returns></returns>
        public static int[,] ReadAndPrint(string pathToFile, int infinity = 2)
        {
            int[,] testInt = new int[2, 2];
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
        public static int[] GraphToWide(int[,] matrix, int marker, int infinity = 2)
        {
            int[] resultArr = new int[matrix.GetLength(0)];
            Queue<int> queue = new Queue<int>();
            int colore = 2;
            queue.Enqueue(marker); // добавляем стартовую вершину в обработку
            resultArr[marker] = 1; // помечаем стартовую как обнаруженную
        W: while (queue.Count != 0)
            {
                Console.Write(queue.Peek() + " ");  // Вывод в консоль порядка обработки вершин
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
            Console.WriteLine();
            return resultArr;
        }

        /// <summary>
        /// Метод обхода неориентированного графа(взвешенного/не взвешенного) в глубину
        /// </summary>
        /// <param name="matrix">Матрица смежности</param>
        /// <param name="marker">Стартовая вершина(индекс матрицы)</param>
        /// <param name="infinity">Обозначение +бесконечности в матрице(по умолчанию = 2 для невзвешанного графа)</param>
        /// <returns>Массив окрашенных вершин графа</returns>
        public static int[] GraphToDepth(int[,] matrix, int marker, int infinity = 2)
        {
            int[] resultArr = new int[matrix.GetLength(0)];
            Stack<int> stack = new Stack<int>();
            int colore = 2;
            stack.Push(marker); // добавляем стартовую вершину в обработку
            resultArr[marker] = 1; // помечаем стартовую как обнаруженную
        W: while (stack.Count != 0)
            {
                Console.Write(stack.Peek() + " ");  // Вывод в консоль порядка обработки вершин
                int checkingEl = stack.Pop();
                for (int i = 0; i < matrix.GetLength(1); i++)
                {
                    if (infinity > matrix[checkingEl, i] && matrix[checkingEl, i] > 0 && resultArr[i] == 0)
                    {   // вершина обнаружена и добавлена в обработку
                        stack.Push(i);
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
                    stack.Push(i);
                    goto W;
                }
            }
            Console.WriteLine();
            return resultArr;
        }

        /// <summary>
        /// Метод рекурсивного обхода неориентированного графа(взвешенного/не взвешенного) в глубину
        /// </summary>
        /// <param name="matrix">Матрица смежности</param>
        /// <param name="resultArr">Массив окрашенных вершин графа</param>
        /// <param name="marker">Стартовая вершина(индекс матрицы)</param>
        /// <param name="infinity">Обозначение +бесконечности в матрице(по умолчанию = 2 для невзвешанного графа)</param>
        /// <param name="colore">Обозначение цвета для компонентов графа(от 2 до [infinity - (кол-во не связанных компонентов графа)])</param>
        public static void GraphToDepthRecurrent(ref int[,] matrix, ref int[] resultArr, int marker, int infinity = 2, int colore = 2)
        {
            resultArr[marker] = colore; // Красим обрабатываемую вершину
            Console.Write(marker + " ");  // Вывод в консоль порядка обработки вершин
            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                if (infinity > matrix[marker, i] && matrix[marker, i] > 0 && resultArr[i] == 0)
                {
                    GraphToDepthRecurrent(ref matrix, ref resultArr, i, infinity, colore);
                }
            }
            for (int i = 0; i < resultArr.Length; i++) // проверяем наличие несвязанных компонентов графа
            {
                if (resultArr[i] == 0)
                {
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        if (infinity > matrix[i, j] && matrix[i, j] > 0 && resultArr[j] == 0) // Проверяем отсутствие ребер с уже известными узлами
                        {
                            GraphToDepthRecurrent(ref matrix, ref resultArr, i, infinity, colore + 1);
                        }
                    }
                }
            }
        }
    }
}
