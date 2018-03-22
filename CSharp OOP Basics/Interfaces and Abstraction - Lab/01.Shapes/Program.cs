﻿using System;

public class Program
{
    static void Main()
    {
        int radius = int.Parse(Console.ReadLine());
        IDrawable circle = new Circle(radius);

        int width = int.Parse(Console.ReadLine());
        int height = int.Parse(Console.ReadLine());

        IDrawable rectangle = new Rectangle(radius, height);

          circle.Draw();
         rectangle.Draw();
    }
}