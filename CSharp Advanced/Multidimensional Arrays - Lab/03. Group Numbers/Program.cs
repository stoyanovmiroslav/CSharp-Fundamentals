using System;
using System.Linq;

namespace _03._Group_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int[][] matrix = new int[3][];

            int[] lenght = new int[3];
            for (int i = 0; i < input.Length; i++)
            {
                int reminder = 0;
                reminder = Math.Abs(input[i] % 3);
                lenght[reminder]++;
            }

            for (int row = 0; row < matrix.Length; row++)
            {
                int elements = 0;
                matrix[row] = new int[lenght[row]];
                for (int numbers = 0; numbers < input.Length; numbers++)
                {
                    if (Math.Abs(input[numbers] % 3) == row)
                    {
                        matrix[row][elements] = input[numbers];
                        elements++;
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
