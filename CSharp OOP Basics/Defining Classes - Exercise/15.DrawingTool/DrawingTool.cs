using System;
using System.Collections.Generic;
using System.Text;

public class DrawingTool
{
    public int Width { get; set; }
    public int Height { get; set; }

    public void Square(int width)
    {
        Width = width;
        Draw(width, width);
    }
   
    public void Rectangle(int width, int height)
    {
        Width = width;
        Height = height;
        Draw(width, height);
    }

    private void Draw(int width, int height)
    {
        for (int i = 0; i < height; i++)
        {
            if (i == 0 || i == height - 1)
            {
                Console.WriteLine("|{0}|", new string('-', width));
            }
            else
            {
                Console.WriteLine("|{0}|", new string(' ', width));
            }
        }
    }
}