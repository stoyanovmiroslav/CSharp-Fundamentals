using System;

namespace _04._Pascal_Triangle
{
    class Program
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());
            long[][] matrix = new long[input][];

            for (int row = 0; row < matrix.Length; row++)
            {
                matrix[row] = new long[row + 1];
                matrix[row][0] = 1;
                matrix[row][matrix[row].Length - 1] = 1;
                if (row > 1)
                {
                    for (int coll = 1; coll < matrix[row].Length - 1; coll++)
                    {
                        matrix[row][coll] = matrix[row - 1][coll] + matrix[row - 1][coll - 1];
                    }
                }
            }

            for (int row = 0; row < matrix.Length; row++)
            {
                for (int coll = 0; coll < matrix[row].Length; coll++)
                {
                    Console.Write("{0} ", matrix[row][coll]);
                }
                Console.WriteLine();
            }
        }
    }
}
