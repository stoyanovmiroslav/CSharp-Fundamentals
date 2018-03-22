using System;

class Program
{
    static void Main(string[] args)
    {
        string input = Console.ReadLine();
        int width = int.Parse(Console.ReadLine());
        DrawingTool drawingTool = new DrawingTool();

        if (input == "Square")
        {
            drawingTool.Square(width);
        }
        else if (input == "Rectangle")
        {
            int height = int.Parse(Console.ReadLine());
            drawingTool.Rectangle(width, height);
        }
    }
}