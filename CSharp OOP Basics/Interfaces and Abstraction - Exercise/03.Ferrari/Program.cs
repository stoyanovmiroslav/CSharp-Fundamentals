using System;

class Program
{
    static void Main(string[] args)
    {
        string model = "488-Spider";
        string driver = Console.ReadLine();
        ICar car = new Ferrari(model, driver);
        Console.WriteLine(car);
    }
}