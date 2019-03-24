using System;
using GraphLib;

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
        static void Main(string[] args)
        {
            int[,] arr = Graph.ReadAndPrint(@"..\..\123.txt", 9);
            Console.WriteLine();
            Console.WriteLine("Порядок обработки вершин графа методом GraphToWide:");
            int[] res = Graph.GraphToWide(arr, 2, 9);
            foreach (var item in res)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();

            Array.Clear(res, 0, res.Length);
            Console.WriteLine("Порядок обработки вершин графа методом GraphToDepth:");
            res = Graph.GraphToDepth(arr, 2, 9);
            foreach (var item in res)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();

            Array.Clear(res, 0, res.Length);
            Console.WriteLine("Порядок обработки вершин графа методом GraphToDepthRecurrent:");
            Graph.GraphToDepthRecurrent(ref arr, ref res, 2, 9);
            Console.WriteLine();
            foreach (var item in res)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();

            Console.ReadKey();
        }
    }
}
