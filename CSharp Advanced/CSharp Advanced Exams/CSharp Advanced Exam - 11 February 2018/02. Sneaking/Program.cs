using System;

namespace _02._Sneaking
{
    class Program
    {
        static void Main(string[] args)
        {
            int matrixLenght = int.Parse(Console.ReadLine());
            char[][] matrix = new char[matrixLenght][];

            int samRow = 0;
            int samColl = 0;

            for (int row = 0; row < matrix.Length; row++)
            {
                char[] inputRow = Console.ReadLine().ToCharArray();
                matrix[row] = inputRow;

                int findSam = Array.IndexOf(matrix[row], 'S');

                if (findSam >= 0)
                {
                    samRow = row;
                    samColl = findSam;
                }
            }

            char[] moves = Console.ReadLine().ToCharArray();

            for (int i = 0; i < moves.Length; i++)
            {
                MoveEnemies(matrix);
                CheckForEmines(matrix, samRow, samColl);

                switch (moves[i])
                {
                    case 'U':
                        matrix[samRow][samColl] = '.';
                        matrix[samRow - 1][samColl] = 'S';
                        samRow -= 1;
                        break;
                    case 'D':
                        matrix[samRow][samColl] = '.';
                        matrix[samRow + 1][samColl] = 'S';
                        samRow += 1;
                        break;
                    case 'L':
                        matrix[samRow][samColl] = '.';
                        matrix[samRow][samColl - 1] = 'S';
                        samColl -= 1;
                        break;
                    case 'R':
                        matrix[samRow][samColl] = '.';
                        matrix[samRow][samColl + 1] = 'S';
                        samColl += 1;
                        break;
                    case 'W':
                        break;
                }
                IsNicolasFinD(matrix, samRow, samColl);
            }
        }

        private static void MoveEnemies(char[][] matrix)
        {
            for (int row = 0; row < matrix.Length; row++)
            {
                int indexb = Array.IndexOf(matrix[row], 'b');
                int indexd = Array.IndexOf(matrix[row], 'd');

                if (indexb >= 0) // move right
                {
                    if (indexb == matrix[row].Length - 1)
                    {
                        matrix[row][indexb] = 'd';
                    }
                    else
                    {
                        matrix[row][indexb] = '.';
                        matrix[row][indexb + 1] = 'b';
                    }
                }
                else if (indexd >= 0) //move left
                {
                    if (indexd == 0)
                    {
                        matrix[row][indexd] = 'b';
                    }
                    else
                    {
                        matrix[row][indexd] = '.';
                        matrix[row][indexd - 1] = 'd';
                    }
                }
            }
        }

        private static void IsNicolasFinD(char[][] matrix, int samRow, int samColl)
        {
            int indexN = Array.IndexOf(matrix[samRow], 'N');
            if (indexN >= 0)
            {
                Console.WriteLine("Nikoladze killed!");
                matrix[samRow][indexN] = 'X';
                PrintFinalMatrix(matrix);
            }
        }

        private static void CheckForEmines(char[][] matrix, int samRow, int samColl)
        {
            int indexb = Array.IndexOf(matrix[samRow], 'b');
            int indexd = Array.IndexOf(matrix[samRow], 'd');

            if (indexb >= 0)
            {
                if (indexb < samColl)
                {
                    matrix[samRow][samColl] = 'X';
                    Console.WriteLine($"Sam died at {samRow}, {samColl}");
                    PrintFinalMatrix(matrix);
                    Environment.Exit(0);
                }
            }
            else if (indexd >= 0)
            {
                if (indexd > samColl) //|| indexd == 0)
                {
                    matrix[samRow][samColl] = 'X';
                    Console.WriteLine($"Sam died at {samRow}, {samColl}");
                    PrintFinalMatrix(matrix);
                    Environment.Exit(0);
                }
            }
        }

        private static void PrintFinalMatrix(char[][] matrix)
        {
            for (int row = 0; row < matrix.Length; row++)
            {
                Console.WriteLine(String.Join("", matrix[row]));
            }
            Environment.Exit(0);
        }
    }
}
