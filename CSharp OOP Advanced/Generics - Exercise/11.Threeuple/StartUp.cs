using System;
using System.Dynamic;

public class StartUp
{
    static void Main(string[] args)
    {

        string[] firstLine = Console.ReadLine().Split();
        string name = $"{firstLine[0]} {firstLine[1]}";
        string[] secondLine = Console.ReadLine().Split();
        string[] thirdLine = Console.ReadLine().Split();

        var tupleFullNameAddress = new Threeuple<string, string, string>(name, firstLine[2], firstLine[3]);
        var tupleNameLitersOfBeer = new Threeuple<string, int, bool>(secondLine[0], int.Parse(secondLine[1]), secondLine[2] == "drunk" ? true : false);
        var tupleNumbers = new Threeuple<string, double, string>(thirdLine[0], double.Parse(thirdLine[1]), thirdLine[2]);

        Console.WriteLine(tupleFullNameAddress);
        Console.WriteLine(tupleNameLitersOfBeer);
        Console.WriteLine(tupleNumbers);
    }
}