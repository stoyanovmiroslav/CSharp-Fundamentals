using System;
using System.Linq;

namespace _02._Diagonal_Difference
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[][] matrix = new int[n][];

            for (int row = 0; row < matrix.Length; row++)
            {
                int[] numbers = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                matrix[row] = new int[n];
                for (int coll = 0; coll < matrix[row].Length; coll++)
                {
                    matrix[row][coll] = numbers[coll];
                }
            }

            int sumLeftDiagonal = 0;
            int sumRightDiagonal = 0;
            for (int row = 0; row < matrix.Length; row++)
            {
                for (int coll = 0; coll < matrix[row].Length; coll++)
                {
                    if (coll == row)
                    {
                        sumLeftDiagonal += matrix[row][coll];
                    }
                    if (coll == matrix[row].Length - 1 - row)
                    {
                        sumRightDiagonal += matrix[row][coll];
                    }
                }
            }

            int diff = Math.Abs(sumLeftDiagonal - sumRightDiagonal);
            Console.WriteLine(diff);
        }
    }
}
