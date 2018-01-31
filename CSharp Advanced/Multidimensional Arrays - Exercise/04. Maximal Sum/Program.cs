using System;
using System.Linq;

namespace _04._Maximal_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] matrixLenght = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int[][] matrix = new int[matrixLenght[0]][];

            for (int row = 0; row < matrix.Length; row++)
            {
                int[] arr = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                matrix[row] = new int[matrixLenght[1]];

                for (int coll = 0; coll < matrix[row].Length; coll++)
                {
                    matrix[row][coll] = arr[coll];
                }
            }

            int maxSum = 0;
            int r = 0;
            int c = 0;

            for (int row = 0; row < matrix.Length - 2; row++)
            {
               int currentSum = 0;
             
                for (int coll = 0; coll < matrix[row].Length - 2; coll++)
                {                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                           
                   
                   int firstRow = matrix[row][coll] + matrix[row][coll + 1] + matrix[row][coll + 2];          
                   int secondRow = matrix[row + 1][coll] + matrix[row + 1][coll + 1] + matrix[row + 1][coll + 2];          
                   int tirdhRow = matrix[row + 2][coll] + matrix[row + 2][coll + 1] + matrix[row + 2][coll + 2];
                   currentSum = firstRow + secondRow + tirdhRow;

                    if (currentSum > maxSum)
                    {
                        maxSum = currentSum;
                        r = row;
                        c = coll;
                    }
                }
            }

            Console.WriteLine("Sum = {0}", maxSum);
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine("{0} {1} {2}", matrix[r + i][c], matrix[r + i][c + 1], matrix[r + i][c + 2]);
            }
        }
    }
}
