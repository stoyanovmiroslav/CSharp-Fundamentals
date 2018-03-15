using System;


public class Program
{
    static void Main(string[] args)
    {
        Rectangle rectangle = new Rectangle(5, 6);
        Console.WriteLine(rectangle.CalculateArea());
        Console.WriteLine(rectangle.CalculatePerimeter());
        Console.WriteLine(rectangle.Draw());

        Circle circle = new Circle(5);
        Console.WriteLine(circle.CalculateArea());
        Console.WriteLine(circle.CalculatePerimeter());
        Console.WriteLine(circle.Draw());
    }
}