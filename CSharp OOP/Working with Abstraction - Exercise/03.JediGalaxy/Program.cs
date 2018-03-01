using System;
using System.Linq;

class Program
{
    static void Main()
    {
        int[] dimestions = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
        int row = dimestions[0];
        int coll = dimestions[1];

        int[,] matrix = new int[row, coll];

        ReadMatrix(row, coll, matrix);

        long sumOfStar = 0;
        string command = "";

        while ((command = Console.ReadLine()) != "Let the Force be with you")
        {
            int[] ivoStartPosition = command.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int[] evilStartPosition = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            EvilDamage(matrix, evilStartPosition);

            sumOfStar = IvoStars(matrix, sumOfStar, ivoStartPosition);
        }
        Console.WriteLine(sumOfStar);
    }

    private static long IvoStars(int[,] matrix, long sum, int[] ivoS)
    {
        int rowIvo = ivoS[0];
        int collIvo = ivoS[1];

        while (rowIvo >= 0 && collIvo < matrix.GetLength(1))
        {
            if (rowIvo >= 0 && rowIvo < matrix.GetLength(0) && collIvo >= 0 && collIvo < matrix.GetLength(1))
            {
                sum += matrix[rowIvo, collIvo];
            }
            collIvo++;
            rowIvo--;
        }
        return sum;
    }

    private static void EvilDamage(int[,] matrix, int[] evil)
    {
        int rowEvil = evil[0];
        int collEvil = evil[1];

        while (rowEvil >= 0 && collEvil >= 0)
        {
            if (rowEvil >= 0 && rowEvil < matrix.GetLength(0) && collEvil >= 0 && collEvil < matrix.GetLength(1))
            {
                matrix[rowEvil, collEvil] = 0;
            }
            rowEvil--;
            collEvil--;
        }
    }

    private static void ReadMatrix(int row, int coll, int[,] matrix)
    {
        int value = 0;
        for (int i = 0; i < row; i++)
        {
            for (int j = 0; j < coll; j++)
            {
                matrix[i, j] = value++;
            }
        }
    }
}

