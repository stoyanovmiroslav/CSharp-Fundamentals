using System;
using System.Collections.Generic;
using System.Linq;

namespace _12._String_Matrix_Rotation
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] command = Console.ReadLine().Split(new string[] { "(", ")", " " }, StringSplitOptions.RemoveEmptyEntries);
            int rotate = int.Parse(command[1]);

            char[][] matrix =  GetMatrix();

            rotate %= 360;

            switch (rotate)
            {
                case 0: PrintMatrix(matrix); break;
                case 90: PrintMatrix90(matrix); break;
                case 180: PrintMatrix180(matrix); break;
                case 270: PrintMatrix270(matrix); break;
            }
        }

        private static char[][] GetMatrix()
        {
            string readText = "";
            List<string> textList = new List<string>();

            int maxLenght = 0;
            while ((readText = Console.ReadLine()) != "END")
            {
                int currentLegth = readText.Length;
                if (currentLegth > maxLenght)
                {
                    maxLenght = currentLegth;
                }
                textList.Add(readText);
            }

            char[][] matrix = new char[textList.Count][];

            for (int row = 0; row < matrix.Length; row++)
            {
                matrix[row] = new char[maxLenght];

                for (int coll = 0; coll < matrix[row].Length; coll++)
                {
                    if (textList[row].Length > coll)
                    {
                        matrix[row][coll] = textList[row][coll];
                    }
                    else
                    {
                        matrix[row][coll] = ' ';
                    }
                }
            }
            return matrix;
        }

        private static void PrintMatrix90(char[][] matrix)
        {
            for (int coll = 0; coll < matrix[0].Length; coll++)
            {
                for (int row = matrix.Length - 1; row >= 0; row--)
                {
                    Console.Write("{0}", matrix[row][coll]);
                }
                Console.WriteLine();
            }
        }

        private static void PrintMatrix270(char[][] matrix)
        {
            for (int coll = matrix[0].Length - 1; coll >= 0; coll--)
            {
                for (int row = 0; row < matrix.Length; row++)
                {
                    Console.Write("{0}", matrix[row][coll]);
                }
                Console.WriteLine();
            }
        }

        private static void PrintMatrix180(char[][] matrix)
        {
            for (int row = matrix.Length - 1; row >= 0; row--)
            {
                Console.WriteLine(string.Join("", matrix[row].Reverse()));
            }
        }

        private static void PrintMatrix(char[][] matrix)
        {
            for (int row = 0; row < matrix.Length; row++)
            {
                Console.WriteLine(string.Join("", matrix[row]));
            }
        }
    }
}
