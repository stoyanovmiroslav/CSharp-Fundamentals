using System;
using System.Dynamic;

public class StartUp
{
    static void Main(string[] args)
    {

        string[] nameAddress = Console.ReadLine().Split();
        string name = $"{nameAddress[0]} {nameAddress[1]}";
        string[] nameLitersOfBeer = Console.ReadLine().Split();
        string[] numbers = Console.ReadLine().Split();

        var tupleFullNameAddress = new Tuple<string, string>(name, nameAddress[2]);
        var tupleNameLitersOfBeer = new Tuple<string, double>(nameLitersOfBeer[0], int.Parse(nameLitersOfBeer[1]));
        var tupleNumbers = new Tuple<int, double>(int.Parse(numbers[0]), double.Parse(numbers[1]));

        Console.WriteLine(tupleFullNameAddress);
        Console.WriteLine(tupleNameLitersOfBeer);
        Console.WriteLine(tupleNumbers);
    }
}