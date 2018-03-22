using System;

namespace _01.RhombusOfStars
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int stars = 1; stars <= n; stars++)
            {
                PrintRow(stars, n);
            }

            for (int stars = n - 1; stars > 0; stars--)
            {
                PrintRow(stars, n);
            }
        }

        private static void PrintRow(int stars, int spaces)
        {
            Console.Write(new string(' ', spaces - stars));

            for (int j = 0; j < stars; j++)
            {
                Console.Write("* ");
            }
            Console.WriteLine();
        }
    }
}
