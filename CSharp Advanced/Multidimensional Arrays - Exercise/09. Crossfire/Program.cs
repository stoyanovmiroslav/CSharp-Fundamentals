using System;
using System.Collections.Generic;
using System.Linq;

namespace _09._Crossfire
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] matrixLength = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            List<List<long>> matrix = new List<List<long>>();
            ReadMatrix(matrix, matrixLength);

            string input = null;
            while ((input = Console.ReadLine()) != "Nuke it from orbit")
            {
                int[] splitInput = input.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                Strike(matrix, splitInput);
            }
            PrintOutput(matrix);
        }


        private static void PrintOutput(List<List<long>> matrix)
        {
            for (int row = 0; row < matrix.Count; row++)
            {
                if (matrix[row].Count > 0)
                {
                    Console.WriteLine(String.Join(" ", matrix[row]));
                }
            }
        }

        private static void ReadMatrix(List<List<long>> matrix, int[] matrixLength)
        {
            int numbers = 1;
            for (int row = 0; row < matrixLength[0]; row++)
            {
                List<long> numberList = new List<long>();
                for (int coll = 0; coll < matrixLength[1]; coll++)
                {
                    numberList.Add(numbers);
                    numbers++;
                }
                matrix.Add(numberList);
            }
        }

        private static void Strike(List<List<long>> matrix, int[] splitInput)
        {
            int inputRow = splitInput[0];
            int inputColl = splitInput[1];
            int inputRadius = splitInput[2];

            for (var row = inputRow - inputRadius; row <= inputRow + inputRadius; row++)
            {
                if (row < 0 || row >= matrix.Count)
                {
                    continue;
                }

                if (row == inputRow)
                {
                    for (var coll = inputColl + inputRadius; coll >= inputColl - inputRadius; coll--)
                    {
                        if (coll < 0 || coll >= matrix[row].Count)
                        {
                            continue;
                        }
                        matrix[row].RemoveAt(coll);
                    }
                }
                else
                {
                    if (inputColl < 0 || inputColl >= matrix[row].Count)
                    {
                        continue;
                    }
                    matrix[row].RemoveAt(inputColl);
                }
            }

            for (int row = 0; row < matrix.Count; row++)
            {
                if (matrix[row].Count == 0)
                {
                    matrix.RemoveAt(row);
                    row--;
                }
            }
        }
    }
}
