using System;
using System.Collections.Generic;

namespace _05._Hot_Potato
{
    class Program
    {
        static void Main(string[] args)
        {
            var childrens = Console.ReadLine().Split(' ');
            int number = int.Parse(Console.ReadLine());
            Queue<string> queue = new Queue<string>(childrens);
            int count = 1;

            while (queue.Count > 1)
            {

                if (count % number == 0)
                {
                    Console.WriteLine("Removed {0}", queue.Dequeue());
                }
                else
                {
                    string children = queue.Dequeue();
                    queue.Enqueue(children);
                }
                count++;
            }
            Console.WriteLine("Last is {0}", queue.Dequeue());
        }
    }
}
