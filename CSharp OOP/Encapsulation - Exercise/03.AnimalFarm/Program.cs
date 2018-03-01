﻿using System;

public class Program
{
    static void Main(string[] args)
    {
        try
        {
            string name = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());

            Chicken chicken = new Chicken(name, age);
            Console.WriteLine($"Chicken {chicken.Name} (age {chicken.Age}) can produce {chicken.ProductPerDay} eggs per day.");
        }
        catch (ArgumentException argEx)
        {
            Console.WriteLine(argEx.Message);
        }
    }
}