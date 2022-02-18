using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NedraTriangle
{
    internal class Program
    {       
        //Запрашивает число и добивается правильности ввода
        static int checkedInput(int MinLimit, int MaxLimit)
        {
            int res = 0;

            Console.Write($"Введите количество уровней треугольника ({MinLimit} - {MaxLimit}): ");
            while (!int.TryParse(Console.ReadLine(), out res) || res < MinLimit || res > MaxLimit)
            {
                Console.WriteLine("Ошибка ввода");
                Console.Write($"Введите количество уровней треугольника ({MinLimit} - {MaxLimit}): ");
            }
            Console.WriteLine("");
            return res;
        }
        //Создание двумерной матрицы чисел, где каждая строка имеет на один элемент больше
        static int[][] createRandomTriangle(int rows, int MaxValue)
        {
            var rand = new Random();
            int[][] result = new int[rows][];

            for (int i = 0; i < rows; i++)
            {
                result[i] = new int[i + 1];

                for(int j = 0; j <= i; j++)
                    result[i][j] = rand.Next(MaxValue);
            }
            return result;
        }
        //Рекурсивный спуск по матрице Triangle, начиная с элемента [rowPosition][colPosition]. Находит 
        static int findMax(int[][] Triangle, int rowPosition, int colPosition)
        {
            if (rowPosition + 1 == Triangle.Length) //если данный элемент находится в нижнем ряду
                return Triangle[rowPosition][colPosition];


            int res = 0;

            if (rowPosition + 1 < Triangle.Length) //если есть ряды ниже
            {
                int left = findMax(Triangle, rowPosition + 1, colPosition);
                int right = findMax(Triangle, rowPosition + 1, colPosition + 1);

                res = (left > right)? left : right;
            }

            return Triangle[rowPosition][colPosition] + res;
        }

        static void Main(string[] args)
        {
            int rows = checkedInput(1, 100);

            int[][] tri = createRandomTriangle(rows, 10);

            for (int i = 0; i < rows; i++)
            {
                foreach (int j in tri[i])
                    Console.Write($"{j} ");
                Console.WriteLine();
            }

            Console.WriteLine();
            Console.WriteLine(findMax(tri, 0, 0));
        }
    }
}
