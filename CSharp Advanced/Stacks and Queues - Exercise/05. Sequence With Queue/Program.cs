using System;
using System.Collections;
using System.Collections.Generic;

namespace _05._Sequence_With_Queue
{
    class Program
    {
        static void Main(string[] args)
        {
            long n = long.Parse(Console.ReadLine());
            Queue<long> queue = new Queue<long>();
            queue.Enqueue(n);
            Queue<long> queuePrint = new Queue<long>();
            queuePrint.Enqueue(n);

            for (long i = 0; i < 50; i++)
            {
                long currentS = queue.Peek();
                long firstS = currentS + 1;
                long secondS = 2 * currentS + 1;
                long thirdS = currentS + 2;
                queue.Enqueue(firstS);
                queue.Enqueue(secondS);
                queue.Enqueue(thirdS);
                queue.Dequeue();
                queuePrint.Enqueue(firstS); 
                queuePrint.Enqueue(secondS); 
                queuePrint.Enqueue(thirdS);
            }
            for (long i = 0; i < 50; i++)
            {
                Console.Write("{0} ", queuePrint.Dequeue()); 
            }
        }
    }
}
