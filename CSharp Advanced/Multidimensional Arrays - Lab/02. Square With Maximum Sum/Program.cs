using System;
using System.Linq;

namespace _02._Square_With_Maximum_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int[][] matrix = new int[input[0]][];

            for (int row = 0; row < matrix.Length; row++)
            {
                int[] matrixInput = Console.ReadLine().Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                matrix[row] = matrixInput;
            }

            int maxSum = 0;
            int rowMax = 0;
            int collMax = 0;
            for (int row = 0; row < matrix.Length - 1; row++)
            {
                for (int coll = 0; coll < matrix[row].Length - 1; coll++)
                {
                    int currentSum = matrix[row][coll] + matrix[row][coll + 1] + matrix[row + 1][coll] + matrix[row + 1][coll + 1];
                    if (currentSum > maxSum)
                    {
                        maxSum = currentSum;
                        rowMax = row;
                        collMax = coll;
                    }
                }
            }
            Console.WriteLine("{0} {1}", matrix[rowMax][collMax], matrix[rowMax][collMax + 1]);
            Console.WriteLine("{0} {1}", matrix[rowMax + 1][collMax], matrix[rowMax + 1][collMax + 1]);
            Console.WriteLine(maxSum);
        }
    }
}
