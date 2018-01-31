using System;
using System.Linq;

namespace _05._Rubiks_Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] matrixLenght = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int n = int.Parse(Console.ReadLine());
            int[][] matrix = new int[matrixLenght[0]][];

            int count = 1;
            for (int row = 0; row < matrix.Length; row++)
            {
                matrix[row] = new int[matrixLenght[1]];
                for (int coll = 0; coll < matrix[row].Length; coll++)
                {
                    matrix[row][coll] = count;  
                    count++;
                }
            }
            for (int i = 0; i < n; i++)
            {
                string[] commands = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                int collOrRow = int.Parse(commands[0]);
                int moves = int.Parse(commands[2]);
                moves = moves % matrix.Length;
                string command = commands[1];

                switch (command)
                {
                    case "left":
                        ShiftLeft(matrix, collOrRow, moves);
                        break;
                    case "right":
                        ShiftRight(matrix, collOrRow, moves);
                        break;
                    case "up":
                        ShiftUp(matrix, collOrRow, moves);
                        break;
                    case "down":
                        ShiftDown(matrix, collOrRow, moves);
                        break;
                }
            }
            CalculateAndPrintSwap(matrix);
        }

        private static void CalculateAndPrintSwap(int[][] matrix)
        {
            int position = 1;
            for (int row = 0; row < matrix.Length; row++)
            {
                for (int coll = 0; coll < matrix[row].Length; coll++)
                {
                    int number = matrix[row][coll];
                    if (number == position)
                    {
                        Console.WriteLine("No swap required");
                    }
                    else
                    {
                        FindAndPrintSwap(matrix, position, row, coll);
                        matrix[row][coll] = position;
                    }
                    position++;  
                }
            }
        }

        private static void FindAndPrintSwap(int[][] matrix, int position, int firsElementRow, int firstElementColl)
        {
            for (int row = firsElementRow; row < matrix.Length; row++)
            {
                for (int coll = 0; coll < matrix[row].Length; coll++)
                {
                    int foundNumber = matrix[row][coll];
                    if (foundNumber == position)
                    {
                        matrix[row][coll] = matrix[firsElementRow][firstElementColl];
                        Console.WriteLine("Swap ({0}, {1}) with ({2}, {3})", firsElementRow, firstElementColl, row, coll);
                        return;
                    }
                }
            }
        }

        private static void ShiftDown(int[][] matrix, int coll, int moves)
        {
            for (int i = 0; i < moves; i++)
            {
                int lastElement = matrix[matrix.Length - 1][coll];
                for (int j = matrix.Length - 1; j > 0; j--)
                {
                    matrix[j][coll] = matrix[j - 1][coll];
                }
                matrix[0][coll] = lastElement;
            }
        }

        private static void ShiftUp(int[][] matrix, int coll, int moves)
        {
            for (int i = 0; i < moves; i++)
            {
                int lastElement = matrix[0][coll];
                for (int j = 0; j < matrix.Length - 1; j++)
                {
                    matrix[j][coll] = matrix[j + 1][coll];
                }
                matrix[matrix.Length - 1][coll] = lastElement;
            }
        }

        private static void ShiftLeft(int[][] matrix, int row, int moves)
        {
            for (int i = 0; i < moves; i++)
            {
                int lastElement = matrix[row][0];
                for (int j = 0; j < matrix[row].Length - 1; j++)
                {
                    matrix[row][j] = matrix[row][j + 1];
                }
                matrix[row][matrix[row].Length - 1] = lastElement;
            }
        }

        private static void ShiftRight(int[][] matrix, int row, int moves)
        {
            for (int i = 0; i < moves; i++)
            {
                int lastElement = matrix[row][matrix[row].Length - 1];
                for (int j = matrix[row].Length - 1; j > 0; j--)
                {
                    matrix[row][j] = matrix[row][j - 1];
                }
                matrix[row][0] = lastElement;
            }
        }
    }
}
