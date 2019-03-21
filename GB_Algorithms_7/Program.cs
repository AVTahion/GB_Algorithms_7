using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
/*  2.  Написать функции, которые считывают матрицу смежности из файла и выводят её на экран.
        Написать рекурсивную функцию обхода графа в глубину.
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
        /// <param name="pathToFile"></param>
        static int[,] ReadAndPrint (string pathToFile)
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
                        Console.Write($"{testInt[i, j]}\t");
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

        static void Main(string[] args)
        {
            int[,] arr = ReadAndPrint(@"..\..\123.txt");
            Console.WriteLine();
            Console.ReadKey();
        }
    }
}
