using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _02._Cubic_s_Rube
{
    class Program
    {
        static void Main(string[] args)
        {
            int matrixLength = int.Parse(Console.ReadLine());
            string input = "";

            long allDamage = 0;

            var dict = new Dictionary<string, long>();
            while ((input = Console.ReadLine()) != "Analyze")
            {
                long[] splitInput = input.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(long.Parse).ToArray();

                if (!IsMatrixValid(splitInput, matrixLength))
                {
                    continue;
                }

                string keyDict = $"{splitInput[0]} {splitInput[1]} {splitInput[2]}";
                if (!dict.ContainsKey(keyDict))
                {
                    dict.Add(keyDict, new long());
                    dict[keyDict] = splitInput[3];
                }
                else
                {
                    dict[keyDict] += splitInput[3];
                }
                allDamage += splitInput[3];

            }

            int allMatrixCells = (int)(Math.Pow((double)matrixLength, 3.0));
            int changedMatrixCells = dict.Where(x => x.Value > 0).Count();
            int notChangedCalls = allMatrixCells - changedMatrixCells;

            Console.WriteLine(allDamage);
            Console.WriteLine(notChangedCalls);
        }

        private static bool IsMatrixValid(long[] splitInput, int matrixLength)
        {
            bool maxIndex = splitInput[0] < matrixLength && splitInput[1] < matrixLength && splitInput[2] < matrixLength;
            bool minIndex = splitInput[0] >= 0 && splitInput[1] >= 0 && splitInput[2] >= 0;
            return maxIndex && minIndex;
        }
    }
}
