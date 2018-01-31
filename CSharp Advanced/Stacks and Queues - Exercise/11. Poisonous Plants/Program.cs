using System;
using System.Collections.Generic;
using System.Linq;

namespace _11._Poisonous_Plants
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] plants = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            Queue<int> queue = new Queue<int>(plants);

            
            int days = 0;
            bool clean = true;
            while (true)
            {
                days++;
                int length = queue.Count;
                for (int i = 0; i < length; i++)
                {
                    int firstElement = queue.Dequeue();
                    int secondElemnt = queue.Peek();

                    if (firstElement >= secondElemnt)
                    {
                        queue.Enqueue(firstElement);
                    }
                    else
                    {
                        queue.Enqueue(firstElement);
                        if (true)
                        {
                            queue.Dequeue();
                        }
                        clean = false;
                    }
                }
                if (clean == true)
                {
                    Console.WriteLine(days);
                    Environment.Exit(0);
                }
            }
          
        }
    }
}
