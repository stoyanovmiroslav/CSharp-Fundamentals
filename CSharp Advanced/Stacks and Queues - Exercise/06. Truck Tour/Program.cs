using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Truck_Tour
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Queue<int[]> queue = new Queue<int[]>();

            for (int i = 0; i < n; i++)
            {
                int[] petrolDistance = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                queue.Enqueue(petrolDistance);
            }

            for (int currentStart = 0; currentStart < n; currentStart++)
            {
                int fuel = 0;
                int length = queue.Count();
                for (int currentPump = 0; currentPump < length; currentPump++)
                {
                    int[] petrolDistance = queue.Dequeue();
                    int pumpFuel = petrolDistance[0];
                    int nextPumpDistance = petrolDistance[1];
                    fuel += pumpFuel - nextPumpDistance;

                    if (fuel >= 0)
                    {
                        if(queue.Count == 0) //(i == length - 1)
                        {
                            Console.WriteLine(currentStart);
                            Environment.Exit(0);
                        }
                    }
                    else
                    {
                        currentStart += currentPump;
                        break;
                    }
                }
            }
        }
    }
}
