using System;
using System.Collections.Generic;

namespace _06._Traffic_Jam
{
    class Program
    {
        static void Main(string[] args)
        {
            int numbersOfCars = int.Parse(Console.ReadLine());
            string input = "";
            Queue<string> queue = new Queue<string>();
            int passedCars = 0;
            while ((input = Console.ReadLine()) != "end")
            {
                if (input != "green")
                {
                    queue.Enqueue(input);
                }
                else
                {
                    int length = Math.Min(queue.Count, numbersOfCars);
                    for (int i = 0; i < length; i++)
                    {
                        Console.WriteLine("{0} passed!", queue.Dequeue());
                        passedCars++;
                    }
                }
            }
            Console.WriteLine("{0} cars passed the crossroads.", passedCars);
        }
    }
}
