using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _10._The_Heigan_Dance
{
    class Program
    {
        static private double playerPoints;
        static private double heiganPoints;
        static private double leftCloudPoint;
        static private int playerRow;
        static private int playerColl;

        static void Main(string[] args)
        {
            double heiganDamage = double.Parse(Console.ReadLine());
            int[][] matrix = new int[15][];
            playerRow = 7;
            playerColl = 7;
            playerPoints = 18500;
            heiganPoints = 3000000;
            leftCloudPoint = 0;

            ReadEmptyMatrix(matrix, playerRow, playerColl);

            while (playerPoints >= 0 || heiganPoints >= 0)
            {
                string[] input = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                string spell = input[0];
                int row = int.Parse(input[1]);
                int coll = int.Parse(input[2]);

                heiganPoints -= heiganDamage;
                bool escape = false;
                if (playerPoints <= 0 || heiganPoints <= 0)
                {
                    PrintOutputAndCheck(heiganPoints, spell);
                    return;
                }
                if (matrix[row][coll] == 1)
                {
                    Damage(spell, escape);
                    PrintOutputAndCheck(heiganPoints, spell);
                    continue;
                }

                DamageWalls(matrix, row, coll);
                escape = EscapeOrDamage(matrix);

                if (escape)
                {
                    ReadEmptyMatrix(matrix, playerRow, playerColl);
                }

                Damage(spell, escape);
                PrintOutputAndCheck(heiganPoints, spell);
            }
        }

        private static bool EscapeOrDamage(int[][] matrix)
        {
            bool escape = false;
            try
            {
                if (matrix[playerRow - 1][playerColl] != 2)
                {
                    escape = true;
                    playerRow = playerRow - 1;
                }
            }
            catch (Exception)
            {
                
            }
            try
            {
                if (matrix[playerRow][playerColl + 1] != 2 && escape == false)
                {
                    escape = true;
                    playerColl = playerColl + 1;
                }
            }
            catch (Exception)
            {

              
            }
            try
            {
                if (matrix[playerRow + 1][playerColl] != 2 && escape == false)
                {
                    escape = true;
                    playerRow = playerRow + 1;
                }
            }
            catch (Exception)
            {

            }
            try
            {
                if (matrix[playerRow][playerColl - 1] != 2 && escape == false)
                {
                    escape = true;
                    playerColl = playerColl - 1;
                }
            }
            catch (Exception)
            {
                
            }
           

            return escape;
        }

        private static void PrintOutputAndCheck(double heiganPoints, string spell)
        {
            if (playerPoints <= 0)
            {
                if (spell == "Cloud")
                {
                    spell = "Plague Cloud";
                }
                Console.WriteLine("Heigan: {0:f2}", heiganPoints);
                Console.WriteLine("Player: Killed by {0}", spell);
                Console.WriteLine("Final position: {0}, {1}", playerRow, playerColl);
                Environment.Exit(0);
            }
            else if (heiganPoints <= 0)
            {
                Console.WriteLine("Heigan: Defeated!");
                Console.WriteLine("Player: {0}", playerPoints);
                Console.WriteLine("Final position: {0}, {1}", playerRow, playerColl);
                Environment.Exit(0);
            }
        }

        private static void DamageWalls(int[][] matrix, int row, int coll)
        {
            int rowPlus = row + 1;
            int rowMinus = row - 1;
            int collPlus = coll + 1;
            int collMinus = coll - 1;
            if (matrix.Length - 1 < rowPlus)
            {
                rowPlus = matrix.Length - 1;
            }
            if (0 > rowMinus)
            {
                rowMinus = 0;
            }
            if (matrix.Length - 1 < collPlus)
            {
                collPlus = matrix.Length - 1;
            }
            if (0 > collMinus)
            {
                collMinus = 0;
            }

            if (matrix[rowPlus][coll] != 1) matrix[rowPlus][coll] = 2;
            if (matrix[row][coll] != 1) matrix[row][coll] = 2;
            if (matrix[rowPlus][collMinus] != 1) matrix[rowPlus][collMinus] = 2;
            if (matrix[rowPlus][collPlus] != 1) matrix[rowPlus][collPlus] = 2;
            if (matrix[rowMinus][coll] != 1) matrix[rowMinus][coll] = 2;
            if (matrix[rowMinus][collMinus] != 1) matrix[rowMinus][collMinus] = 2;
            if (matrix[rowMinus][collPlus] != 1) matrix[rowMinus][collPlus] = 2;
            if (matrix[row][collMinus] != 1) matrix[row][collMinus] = 2;
            if (matrix[row][collPlus] != 1) matrix[row][collPlus] = 2;
        }


        private static void Damage(string spell, bool escape)
        {
            double spellCloud = 3500;
            double eruptionCloud = 6000;

            if (leftCloudPoint > 0)
            {
                playerPoints -= spellCloud;
                leftCloudPoint = 0;
            }

            if (spell == "Cloud" && escape != true)
            {
                playerPoints -= spellCloud;
                leftCloudPoint += spellCloud;
            }
            else if (spell == "Eruption" && escape != true)
            {
                playerPoints -= eruptionCloud;
            }
        }

        private static void ReadEmptyMatrix(int[][] matrix, int rowPlayer, int collPlayer)
        {
            for (int row = 0; row < matrix.Length; row++)
            {
                matrix[row] = new int[matrix.Length];
                for (int coll = 0; coll < matrix[row].Length; coll++)
                {
                    if (row == rowPlayer && coll == collPlayer)
                    {
                        matrix[row][coll] = 1;
                    }
                    else
                    {
                        matrix[row][coll] = 0;
                    }
                }
            }
        }
    }
}