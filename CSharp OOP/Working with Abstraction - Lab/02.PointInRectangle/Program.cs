using System;
using System.Linq;

namespace _02.PointInRectangle
{
    class Program
    {
        static void Main(string[] args)
        {
            Rectangle rectangle = CreateRectangle();
            int lines = int.Parse(Console.ReadLine());

            for (int i = 0; i < lines; i++)
            {
                int[] points = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                Point point = new Point(points[0], points[1]);
                bool isPointInside = rectangle.Contains(point);

                if (isPointInside)
                {
                    Console.WriteLine("True");
                }
                else
                {
                    Console.WriteLine("False");
                }
            }
        }

        private static Rectangle CreateRectangle()
        {
            string[] coordinates = Console.ReadLine().Split();
            int topLeftX = int.Parse(coordinates[0]);
            int topLeftY = int.Parse(coordinates[1]);
            int bottomRightX = int.Parse(coordinates[2]);
            int bottomRightY = int.Parse(coordinates[3]);

            Point topLeft = new Point(topLeftX, topLeftY);
            Point bottomRight = new Point(bottomRightX, bottomRightY);
            Rectangle rectangle = new Rectangle(topLeft, bottomRight);
            return rectangle;
        }
    }
}
