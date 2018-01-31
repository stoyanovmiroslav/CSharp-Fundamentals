using System;
using System.Linq;

namespace _03._Squares_in_Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] matrixLenght = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            char[][] matrix = new char[matrixLenght[0]][];

            for (int row = 0; row < matrix.Length; row++)
            {
                char[] arr = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();
                matrix[row] = new char[matrixLenght[1]];

                for (int coll = 0; coll < matrix[row].Length; coll++)
                {
                    matrix[row][coll] = arr[coll];
                }
            }

            int count = 0;
            for (int row = 0; row < matrix.Length - 1; row++)
            {
                for (int coll = 0; coll < matrix[row].Length - 1; coll++)
                {
                    bool condition = matrix[row][coll] == matrix[row][coll + 1] && matrix[row + 1][coll] == matrix[row + 1][coll + 1] && matrix[row][coll] == matrix[row + 1][coll];
                    if (condition)
                    {
                        count++;
                    }   
                    
                }
            }
                Console.WriteLine(count);
        }
    }
}
