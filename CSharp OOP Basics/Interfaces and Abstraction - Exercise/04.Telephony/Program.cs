using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.Telephony
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> phoneNumbers = Console.ReadLine().Split().ToList();
            List<string> sites = Console.ReadLine().Split().ToList();

            Smartphone smartphone = new Smartphone();
            smartphone.Call(phoneNumbers);
            smartphone.Browse(sites);
        }
    }
}