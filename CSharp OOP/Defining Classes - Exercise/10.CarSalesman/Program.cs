using System;
using System.Collections.Generic;
using System.Linq;

namespace _10.CarSalesman
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Engine> engines = new List<Engine>();
            ReadAndWriteEngines(engines);

            List<Car> cars = new List<Car>();
            ReadAndWriteCars(cars);

            PrintOutput(cars, engines);           
        }

        private static void PrintOutput(List<Car> cars, List<Engine> engines)
        {
            foreach (var car in cars)
            {
                Console.WriteLine($"{car.Model}:");

                var engine = engines.First(x => x.Model == car.Engine);
                Console.WriteLine($"  {engine.Model}:");
                Console.WriteLine($"    Power: {engine.Power}");
                Console.WriteLine($"    Displacement: {engine.Displacement}");
                Console.WriteLine($"    Efficiency: {engine.Efficiency}");
                Console.WriteLine($"  Weight: {car.Weight}");
                Console.WriteLine($"  Color: {car.Color}");
            }
        }

        private static void ReadAndWriteCars(List<Car> cars)
        {
            int carsNumbers = int.Parse(Console.ReadLine());
            for (int i = 0; i < carsNumbers; i++)
            {
                string[] readCars = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                string model = readCars[0];
                string engine = readCars[1];
                string weight = "n/a";
                string color = "n/a";

                if (readCars.Length == 4)
                {
                    weight = readCars[2];
                    color = readCars[3];
                }
                else if (readCars.Length == 3)
                {
                    bool isNumber = int.TryParse(readCars[2], out _);

                    if (!isNumber)
                    {
                        color = readCars[2];
                    }
                    else
                    {
                        weight = readCars[2];
                    }
                }

                Car car = new Car(model, engine, weight, color);
                cars.Add(car);
            }
        }

        private static void ReadAndWriteEngines(List<Engine> engines)
        {
            int enginesNumbers = int.Parse(Console.ReadLine());

            for (int i = 0; i < enginesNumbers; i++)
            {
                string[] readEngines = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                string model = readEngines[0];
                int power = int.Parse(readEngines[1]);
                string displacement = "n/a";
                string efficiency = "n/a";

                if (readEngines.Length == 4)
                {
                    displacement = readEngines[2];
                    efficiency = readEngines[3];
                }
                else if (readEngines.Length == 3)
                {
                    bool isNumber = int.TryParse(readEngines[2], out _);

                    if (!isNumber)
                    {
                        efficiency = readEngines[2];
                    }
                    else
                    {
                        displacement = readEngines[2];
                    }
                }

                Engine engine = new Engine(model, power, displacement, efficiency);
                engines.Add(engine);
            }
        }
    }
}
