using System;
using System.Runtime.InteropServices;

namespace _06.TrafficLights
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                ChangeLights(input);
                Console.WriteLine(string.Join(" ", input));
            }

        }

        private static void ChangeLights(string[] input)
        {
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == Lights.Yellow.ToString())
                {
                    input[i] = Lights.Red.ToString();
                }
                else if(input[i] == Lights.Green.ToString())
                {
                    input[i] = Lights.Yellow.ToString();
                }
                else if (input[i] == Lights.Red.ToString())
                {
                    input[i] = Lights.Green.ToString();
                }
            }
        }
    }
}
