using System;
using System.Collections.Generic;
using System.Linq;

namespace _09.RectangleIntersection
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int numberOfRectangles = input[0];
            int intersectionChecks = input[1];
            List<Rectangle> listOfRectangle = new List<Rectangle>();
          
                for (int i = 0; i < numberOfRectangles; i++)
                {
                    string[] rectangleData = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                    Rectangle rectangle = ParceRectangle(rectangleData);
                    listOfRectangle.Add(rectangle);
                }

            try
            {
                for (int i = 0; i < intersectionChecks; i++)
                {
                    string[] pairOfRectangles = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                    string firstRectangleId = pairOfRectangles[0];
                    string secondRectangleId = pairOfRectangles[1];

                    var firstRectangle = listOfRectangle.FirstOrDefault(x => x.Id == firstRectangleId);
                    var secondRectangle = listOfRectangle.FirstOrDefault(x => x.Id == secondRectangleId);

                    if (IsRectanglesIntersect(firstRectangle, secondRectangle) && firstRectangle != null && secondRectangle != null)
                    {
                        Console.WriteLine("true");
                    }
                    else
                    {
                        Console.WriteLine("false");
                    }
                }
            }
            catch (Exception)
            {

      
            }

           
        }

        private static bool IsRectanglesIntersect(Rectangle rectangle1, Rectangle rectangle2)
        {
            return rectangle1.X + rectangle1.Width >= rectangle2.X && rectangle1.X <= rectangle2.X + rectangle2.Width &&
                            rectangle1.Y >= rectangle2.Y - rectangle2.Height && rectangle1.Y - rectangle1.Height <= rectangle2.Y;
        }

        private static Rectangle ParceRectangle(string[] rectangleData)
        {
           return new Rectangle(rectangleData[0], int.Parse(rectangleData[1]), int.Parse(rectangleData[2]), double.Parse(rectangleData[3]), int.Parse(rectangleData[4]));
        }
    }
}
