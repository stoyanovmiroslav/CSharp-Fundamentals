using System;
using System.Collections;
using System.Collections.Generic;

namespace _08._Recursive_Fibonacci
{
    class Program
    {
        static long[] memoization;
        static void Main(string[] args)
        {
            long n = long.Parse(Console.ReadLine());
            memoization = new long[n];
            Console.WriteLine(getFibonacci(n));
        }
        static long getFibonacci(long n)
        {
            if (memoization[n - 1] == 0)
            {
                if (n <= 2)
                {
                    memoization[n - 1] = 1;
                }
                else
                {
                    long a = getFibonacci(n - 1);
                    long b = getFibonacci(n - 2);
                    memoization[n - 1] = a + b;
                }
            }
            return memoization[n - 1];
        }
    }
}
