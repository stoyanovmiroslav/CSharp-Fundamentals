using System;
using System.Collections;
using System.Collections.Generic;

namespace _10.ExplicitInterfaces
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = "";
         
            while ((input = Console.ReadLine()) != "End")
            {
                string[] person = input.Split();
                IResident resident = new Citizen(person[0], int.Parse(person[2]), person[1]);
                IPerson persons = new Citizen(person[0], int.Parse(person[2]), person[1]);
                persons.GetName();
                resident.GetName();
            }
        }
    }
}