using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Jedi_Galaxy
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] matrixLength = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int[][] matrix = new int[matrixLength[0]][];

            FillTheMatrix(matrix, matrixLength);

            long ivoStarsSum = 0;
            string input = "";

            while ((input = Console.ReadLine()) != "Let the Force be with you")
            {
                int[] ivoStartsParameters = input.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                int[] evilStartsParameters = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                EvilDamage(evilStartsParameters, matrix, "Evil");

                ivoStarsSum += IvoStars(ivoStartsParameters, matrix, "Ivo");
            }
            Console.WriteLine(ivoStarsSum);
        }

        private static void FillTheMatrix(int[][] matrix, int[] matrixLength)
        {
            int count = 0;
            for (int row = 0; row < matrix.Length; row++)
            {
                matrix[row] = new int[matrixLength[1]];
                for (int coll = 0; coll < matrix[row].Length; coll++)
                {
                    matrix[row][coll] = count;
                    count++;
                }
            }
        }

        private static long IvoStars(int[] ivoStartsParameters, int[][] matrix, string v)
        {
            int row = ivoStartsParameters[0];
            int coll = ivoStartsParameters[1];

            long sum = 0;
            while (row >= 0 && coll < matrix[0].Length)
            {
                if (MatrixIsValid(matrix, row, coll))
                {
                    int value = matrix[row][coll];

                    sum += value;
                }
                row--;
                coll++;
            }
            return sum;
        }

        private static void EvilDamage(int[] evilStartsParameters, int[][] matrix, string v)
        {
            int row = evilStartsParameters[0];
            int coll = evilStartsParameters[1];

            while (row >= 0 && coll >= 0)
            {
                if (MatrixIsValid(matrix, row, coll))
                {
                    matrix[row][coll] = 0;
                }
                row--;
                coll--;
            }
        }

        private static bool MatrixIsValid(int[][] matrix, int row, int coll)
        {
            return row >= 0 && row < matrix.Length && coll >= 0 && coll < matrix[0].Length;
        }
    }
}
