using System;

namespace _01._Dangerous_Floor
{
    class Program
    {
        static void Main(string[] args)
        {
            string[][] matrix = new string[8][];

            for (int row = 0; row < matrix.Length; row++)
            {
                matrix[row] = Console.ReadLine().Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
            }

            string input = "";
            while ((input = Console.ReadLine()) != "END")
            {
                string piece = input.Substring(0, 1);
                int row = int.Parse(input.Substring(1, 1));
                int coll = int.Parse(input.Substring(2, 1));
                int newRow = int.Parse(input.Substring(4, 1));
                int newColl = int.Parse(input.Substring(5, 1));

                if (IsCurrentPositionExist(matrix, input))
                {
                    if (IsCorrectMove(matrix, piece, row, coll, newRow, newColl))   // Invalid move!
                    {
                        if (IsPositionOnTheBoard(matrix, newRow, newColl)) // go on the board!
                        {
                            if (matrix[newRow][newColl] == "x")   // is place empty
                            {
                                matrix[row][coll] = "x";
                                matrix[newRow][newColl] = piece;
                            }
                            else
                            {
                                Console.WriteLine("Invalid move!");
                            }

                        }
                        else
                        {
                            Console.WriteLine("Move go out of board!");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid move!");
                    }

                }
                else
                {
                    Console.WriteLine("There is no such a piece!");
                }
            }
        }

        private static bool IsCorrectMove(string[][] matrix, string piece, int row, int coll, int newRow, int newColl)
        {
            bool diagonalLeftRight = (row - newRow) == (coll - newColl);
            bool diagonalRightLeft = (row - newRow) + (coll - newColl) == 0;
            bool horisontalVertical = (row == newRow || coll == newColl);

            if (piece == "K" && newRow >= row - 1 && newRow <= row + 1 && newColl >= coll - 1 && newColl <= coll + 1) return true;
            else if (piece == "R" && horisontalVertical) return true;
            else if (piece == "B" && (diagonalLeftRight || diagonalRightLeft)) return true;
            else if (piece == "Q" && (diagonalLeftRight || diagonalRightLeft || horisontalVertical)) return true;
            else if (piece == "P" && (coll == newColl && row - 1 == newRow)) return true;
            else return false;
        }

        private static bool IsCurrentPositionExist(string[][] matrix, string input)
        {
            string piece = input.Substring(0, 1);
            int currentPositionRow = int.Parse(input.Substring(1, 1));
            int currentPositionColl = int.Parse(input.Substring(2, 1));

            if (IsPositionOnTheBoard(matrix, currentPositionRow, currentPositionColl) && matrix[currentPositionRow][currentPositionColl] == piece)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private static bool IsPositionOnTheBoard(string[][] matrix, int row, int coll)
        {
            return (row >= 0 && row < matrix.Length && coll >= 0 && coll < matrix.Length);
        }
    }
}
