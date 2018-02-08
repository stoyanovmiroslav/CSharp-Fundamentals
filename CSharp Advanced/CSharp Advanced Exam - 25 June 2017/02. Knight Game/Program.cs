using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Knight_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            int matrixLength = int.Parse(Console.ReadLine());
            char[][] matrix = new char[matrixLength][];
            ReadMatrix(matrix, matrixLength);

            var dict = new Dictionary<string, int>();
            int countRemovetKnight = 0;

            while (true)
            {
                for (int row = 0; row < matrix.Length; row++)
                {
                    for (int coll = 0; coll < matrix[row].Length; coll++)
                    {
                        if (matrix[row][coll] == 'K')
                        {
                            CheckPosition(dict, row, coll, matrix);
                        }
                    }
                }

                string maxPosition = "";
                foreach (var item in dict.Where(x => x.Value != 0).OrderByDescending(x => x.Value))
                {
                    maxPosition = item.Key;
                    break;
                }

                if (maxPosition != "")
                {
                    countRemovetKnight++;
                    dict.Remove(maxPosition);
                    int[] rowAndColl = maxPosition.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                    matrix[rowAndColl[0]][rowAndColl[1]] = '0';
                }
                else
                {
                    Console.WriteLine(countRemovetKnight);
                    return;
                }
            }
        }

        private static void ReadMatrix(char[][] matrix, int matrixLength)
        {

            for (int row = 0; row < matrixLength; row++)
            {
                matrix[row] = new char[matrixLength];
                matrix[row] = Console.ReadLine().ToCharArray();
            }
        }

        private static bool IsPositionAttacked(int row, int coll, char[][] matrix)
        {
            return (row >= 0 && row < matrix.Length && coll >= 0 && coll < matrix.Length && matrix[row][coll] == 'K');
        }

        private static void CheckPosition(Dictionary<string, int> dict, int row, int coll, char[][] matrix)
        {
            int count = 0;
            if (IsPositionAttacked(row - 2, coll - 1, matrix)) count++;
            if (IsPositionAttacked(row - 1, coll - 2, matrix)) count++;
            if (IsPositionAttacked(row + 1, coll - 2, matrix)) count++;
            if (IsPositionAttacked(row + 2, coll - 1, matrix)) count++;
            if (IsPositionAttacked(row - 2, coll + 1, matrix)) count++;
            if (IsPositionAttacked(row - 1, coll + 2, matrix)) count++;
            if (IsPositionAttacked(row + 1, coll + 2, matrix)) count++;
            if (IsPositionAttacked(row + 2, coll + 1, matrix)) count++;

            string position = $"{row} {coll}";
            if (count != 0)
            {
                if (dict.ContainsKey(position))
                {
                    dict[position] = count;
                }
                else
                {
                    dict.Add(position, count);
                }
            }
            else if(dict.ContainsKey(position))
            {
                dict[position] = count;
            }
        }
    }
}