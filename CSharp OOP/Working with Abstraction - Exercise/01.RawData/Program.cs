using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        List<Car> cars = new List<Car>();
        int lines = int.Parse(Console.ReadLine());
        for (int i = 0; i < lines; i++)
        {
            string[] input = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string model = input[0];
            int engineSpeed = int.Parse(input[1]);
            int enginePower = int.Parse(input[2]);
            int cargoWeight = int.Parse(input[3]);
            string cargoType = input[4];

            List<Tire> tires = new List<Tire>();
            TakeTireInfo(input, tires);

            Car car = new Car(model, engineSpeed, enginePower, cargoWeight, cargoType, tires);
            cars.Add(car);
        }

        string command = Console.ReadLine();
        PrintCarsModels(cars, command);
    }

    private static void PrintCarsModels(List<Car> cars, string command)
    {
        if (command == "fragile")
        {
            cars.Where(x => x.cargoType == "fragile" && x.tire.Any(y => y.Pressure < 1)).ToList().ForEach(x => Console.WriteLine(string.Join(Environment.NewLine, x.model)));
        }
        else
        {
            cars.Where(x => x.cargoType == "flamable" && x.enginePower > 250).ToList().ForEach(x => Console.WriteLine(string.Join(Environment.NewLine, x.model)));
        }
    }

    private static List<Tire> TakeTireInfo(string[] parameters, List<Tire> tires)
    {
        for (int i = 5; i < 12; i+=2)
        {
            double pressure = double.Parse(parameters[i]);
            int age = int.Parse(parameters[i + 1]);
            Tire tire = new Tire(age, pressure);
            tires.Add(tire);
        }
        return tires;
    }
}
