using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _02._Crypto_Master
{
    class Program
    {
        static void Main(string[] args)
        {
            List<long> numbers = Console.ReadLine().Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries).Select(long.Parse).ToList();

            long maxLength = 0;

            for (int step = 1; step < numbers.Count; step++)
            {
                for (int currentIndex = 0; currentIndex < numbers.Count; currentIndex++)
                {
                    int currentMax = 1;

                    int nextIndex = (currentIndex + step) % numbers.Count;

                    while (numbers[nextIndex] > numbers[currentIndex])
                    {
                        currentMax++;

                        currentIndex = nextIndex;
                        nextIndex = (currentIndex + step) % numbers.Count;
                    }

                    if (maxLength < currentMax)
                    {
                        maxLength = currentMax;
                    }

                    if (maxLength == numbers.Count)
                    {
                        Console.WriteLine(maxLength);
                        return;
                    }
                }
            }
            Console.WriteLine(maxLength);
        }
    }
}
