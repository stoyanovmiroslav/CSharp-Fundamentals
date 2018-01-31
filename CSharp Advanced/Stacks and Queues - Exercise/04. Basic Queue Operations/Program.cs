using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Basic_Queue_Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nsx = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int numberOfElements = nsx[0];
            int elementsToPop = nsx[1];
            int x = nsx[2];
            int[] numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            Queue<int> queue = new Queue<int>(numbers);

            for (int i = 0; i < elementsToPop; i++)
            {
                queue.Dequeue();
            }

            int length = queue.Count;
            int smallestElement = int.MaxValue;

            for (int i = 0; i < length; i++)
            {
                int currentElement = queue.Dequeue();
                if (x == currentElement)
                {
                    Console.WriteLine("true");
                    return;
                }
                else if (currentElement < smallestElement)
                {
                    smallestElement = currentElement;
                }
            }

            if (smallestElement == int.MaxValue)
            {
                Console.WriteLine(0);
            }
            else
            {
                Console.WriteLine(smallestElement);
            }
        }
    }
}
