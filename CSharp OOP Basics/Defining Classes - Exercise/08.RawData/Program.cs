using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.RawData
{
    class Program
    {
        static void Main(string[] args)
        {
            int numbersOfCars = int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>();

            for (int i = 0; i < numbersOfCars; i++)
            {
                string[] carInformation = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);

                List<int> tiresAge = TakeTiresAge(carInformation);
                List<double> tiresPressure = TakeTiresPressure(carInformation);
                Car car = TakeCarInformation(carInformation, tiresAge, tiresPressure);
                cars.Add(car);
            }

            string showCargoType = Console.ReadLine();

            foreach (var item in cars)
            {
                if (item.TiresPressure.Any(i => i < 1) && showCargoType == "fragile")
                {
                    Console.WriteLine(item.Name);
                }
                else if (item.EnginePower > 250 && showCargoType == "flamable")
                {
                    Console.WriteLine(item.Name);
                }
            }

        }

        private static Car TakeCarInformation(string[] carInformation, List<int> tiresAge, List<double> tiresPressure)
        {
            return new Car(carInformation[0], int.Parse(carInformation[1]), int.Parse(carInformation[2]), int.Parse(carInformation[3]), carInformation[4], tiresPressure, tiresAge);
        }

        private static List<int> TakeTiresAge(string[] carInformation)
        {
            return new List<int> { int.Parse(carInformation[6]), int.Parse(carInformation[8]), int.Parse(carInformation[10]), int.Parse(carInformation[12]) };
        }

        private static List<double> TakeTiresPressure(string[] carInformation)
        {
            return new List<double> { double.Parse(carInformation[5]), double.Parse(carInformation[7]), double.Parse(carInformation[9]), double.Parse(carInformation[11]) };
        }
    }
}
