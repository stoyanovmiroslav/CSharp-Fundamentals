using System;

namespace P06_Sneaking
{
    class Sneaking
    {
        static char[][] room;
        static void Main()
        {
            ReadTheRoom();
            char[] moves = Console.ReadLine().ToCharArray();
            int[] samPosition = SamPosition();

            for (int i = 0; i < moves.Length; i++)
            {
                MoveEneny();

                int[] enemyPosition = EnemyPosition(samPosition);

                IsSamDied(samPosition, enemyPosition);

                MoveSam(moves[i], samPosition);

                enemyPosition = EnemyPosition(samPosition);

                IsNikoladzeKilled(samPosition, enemyPosition);
            }
        }

        private static void IsSamDied(int[] samPosition, int[] getEnemy)
        {
            if (samPosition[1] < getEnemy[1] && room[getEnemy[0]][getEnemy[1]] == 'd' && getEnemy[0] == samPosition[0])
            {
                Console.WriteLine($"Sam died at {samPosition[0]}, {samPosition[1]}");
                PrintTheMatrix(samPosition[0], samPosition[1]);
            }
            else if (getEnemy[1] < samPosition[1] && room[getEnemy[0]][getEnemy[1]] == 'b' && getEnemy[0] == samPosition[0])
            {
                Console.WriteLine($"Sam died at {samPosition[0]}, {samPosition[1]}");
                PrintTheMatrix(samPosition[0], samPosition[1]);
            }
        }

        private static int[] EnemyPosition(int[] samPosition)
        {
            int[] getEnemy = new int[2];
            for (int j = 0; j < room[samPosition[0]].Length; j++)
            {
                if (room[samPosition[0]][j] != '.' && room[samPosition[0]][j] != 'S')
                {
                    getEnemy[0] = samPosition[0];
                    getEnemy[1] = j;
                }
            }
            return getEnemy;
        }

        private static void IsNikoladzeKilled(int[] samPosition, int[] getEnemy)
        {
            if (room[getEnemy[0]][getEnemy[1]] == 'N' && samPosition[0] == getEnemy[0])
            {
                Console.WriteLine("Nikoladze killed!");
                PrintTheMatrix(getEnemy[0], getEnemy[1]);
            }
        }

        private static void PrintTheMatrix(int rowX, int collX)
        {
            room[rowX][collX] = 'X';

            for (int row = 0; row < room.Length; row++)
            {
                for (int col = 0; col < room[row].Length; col++)
                {
                    Console.Write(room[row][col]);
                }
                Console.WriteLine();
            }
            Environment.Exit(0);
        }

        private static void MoveSam(char move, int[] samPosition)
        {
            room[samPosition[0]][samPosition[1]] = '.';
            switch (move)
            {
                case 'U':
                    samPosition[0]--;
                    break;
                case 'D':
                    samPosition[0]++;
                    break;
                case 'L':
                    samPosition[1]--;
                    break;
                case 'R':
                    samPosition[1]++;
                    break;
                default:
                    break;
            }
            room[samPosition[0]][samPosition[1]] = 'S';
        }

        private static void MoveEneny()
        {
            for (int row = 0; row < room.Length; row++)
            {
                for (int col = 0; col < room[row].Length; col++)
                {
                    if (room[row][col] == 'b')
                    {
                        if (row >= 0 && row < room.Length && col + 1 >= 0 && col + 1 < room[row].Length)
                        {
                            room[row][col] = '.';
                            room[row][col + 1] = 'b';
                            col++;
                        }
                        else
                        {
                            room[row][col] = 'd';
                        }
                    }
                    else if (room[row][col] == 'd')
                    {
                        if (row >= 0 && row < room.Length && col - 1 >= 0 && col - 1 < room[row].Length)
                        {
                            room[row][col] = '.';
                            room[row][col - 1] = 'd';
                        }
                        else
                        {
                            room[row][col] = 'b';
                        }
                    }
                }
            }
        }

        private static int[] SamPosition()
        {
            int[] samPosition = new int[2];

            for (int row = 0; row < room.Length; row++)
            {
                for (int col = 0; col < room[row].Length; col++)
                {
                    if (room[row][col] == 'S')
                    {
                        samPosition[0] = row;
                        samPosition[1] = col;
                    }
                }
            }

            return samPosition;
        }

        private static void ReadTheRoom()
        {
            int n = int.Parse(Console.ReadLine());
            room = new char[n][];

            for (int row = 0; row < n; row++)
            {
                room[row] = Console.ReadLine().ToCharArray();
            }
        }
    }
}