using System;
using System.Linq;

namespace _11._Parking_System
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] matrixSize = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            bool[][] matrix = new bool[matrixSize[0]][];

            string input = "";
            while ((input = Console.ReadLine()) != "stop")
            {
                int[] splitInput = input.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                int entryRow = splitInput[0];
                int parkingRow = splitInput[1];
                int parkingColl = splitInput[2];

                if (matrix[parkingRow] == null)
                {
                    matrix[parkingRow] = new bool[matrixSize[1]];
                }

                int position = 0;
                bool parked = false;
                if (matrix[parkingRow][parkingColl] == false)
                {
                    matrix[parkingRow][parkingColl] = true;
                    parked = true;
                    position = CountParkingPosition(matrix, entryRow, parkingRow, parkingColl);
                }
                else
                {
                    int indexEmptyPositionBefore = int.MaxValue;
                    int indexEmptyPositionAfter = int.MaxValue;

                    for (int coll = parkingColl - 1; coll > 0; coll--)
                    {
                        if (matrix[parkingRow][coll] == false)
                        {
                            indexEmptyPositionBefore = coll;
                            parked = true;
                            break;
                        }
                    }
                    for (int coll = parkingColl + 1; coll < matrix[parkingRow].Length; coll++)
                    {
                        if (matrix[parkingRow][coll] == false)
                        {
                            indexEmptyPositionAfter = coll;
                            parked = true;
                            break;
                        }
                    }
                    if (parked)
                    {
                        int diffBefore = Math.Abs(parkingColl - indexEmptyPositionBefore);
                        int diffAfter = Math.Abs(parkingColl - indexEmptyPositionAfter);

                        if (diffBefore <= diffAfter)
                        {
                            matrix[parkingRow][indexEmptyPositionBefore] = true;
                            position = CountParkingPosition(matrix, entryRow, parkingRow, indexEmptyPositionBefore);
                        }
                        else
                        {
                            matrix[parkingRow][indexEmptyPositionAfter] = true;
                            position = CountParkingPosition(matrix, entryRow, parkingRow, indexEmptyPositionAfter);
                        }
                    }
                }

                if (parked)
                {
                    Console.WriteLine(position);
                }
                else
                {
                    Console.WriteLine("Row {0} full", parkingRow);
                }
            }
        }
        private static int CountParkingPosition(bool[][] matrix, int entryRow, int parkingRow, int parkingColl)
        {
            int position = 0;
            int row = Math.Abs(entryRow - parkingRow);
            int coll = parkingColl + 1;
            position = coll + row;
            return position;
        }
    }
}

