using System;
using System.Linq;

namespace _01._Matrix_of_Palindromes
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            string[][] matrix = new string[input[0]][];

            for (int row = 0; row < matrix.Length; row++)
            {
                matrix[row] = new string[input[1]];
                for (int coll = 0; coll < matrix[row].Length; coll++)
                {
                    int a = 97 + row;
                    int b = 97 + coll + row;
                    string newString = "" + (char)a + (char)b + (char)a;
                    matrix[row][coll] = newString;
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
