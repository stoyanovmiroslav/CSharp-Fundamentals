using System;
using System.Linq;

namespace _07._Lego_Blocks
{
    class Program
    {
        static void Main(string[] args)
        {
            int linesMatrix = int.Parse(Console.ReadLine());
            int[][] firstMatrix = new int[linesMatrix][];
            int[][] secondMatrix = new int[linesMatrix][];

            for (int row = 0; row < linesMatrix; row++)
            {
                int[] collInput = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                firstMatrix[row] = collInput;
            }
            for (int row = 0; row < linesMatrix; row++)
            {
                int[] collInput = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).Reverse().ToArray();
                secondMatrix[row] = collInput;
            }

            bool correctMatrix = IsMatrixCorrect(firstMatrix, secondMatrix);
            if (!correctMatrix)
            {
                Environment.Exit(0);
            }

            int[][] matrix = new int[linesMatrix][];
            int collLength = firstMatrix[0].Length + secondMatrix[0].Length;

            for (int row = 0; row < matrix.Length; row++)
            {
                matrix[row] = new int[collLength];

                for (int coll = 0; coll < collLength; coll++)
                {
                    if (firstMatrix[row].Length > coll)
                    {
                        matrix[row][coll] = firstMatrix[row][coll];
                    }
                    else
                    {
                        int lengthColl = coll - firstMatrix[row].Length;
                        matrix[row][coll] = secondMatrix[row][lengthColl];
                    }
                }
                Console.WriteLine("[{0}]", string.Join(", ", matrix[row]));
            }
        }

        private static bool IsMatrixCorrect(int[][] firstMatrix, int[][] secondMatrix)
        {
            bool isCorrect = true;
            int length = firstMatrix[0].Length + secondMatrix[0].Length;
            int sumCells = 0;
            for (int row = 0; row < firstMatrix.Length; row++)
            {
                int currentLength = firstMatrix[row].Length + secondMatrix[row].Length;
                sumCells += firstMatrix[row].Length + secondMatrix[row].Length;

                if (currentLength != length)
                {
                    isCorrect = false;
                }
            }
            if (!isCorrect)
            {
                Console.WriteLine("The total number of cells is: {0}", sumCells);
            }
            return isCorrect;
        }
    }
}
    

