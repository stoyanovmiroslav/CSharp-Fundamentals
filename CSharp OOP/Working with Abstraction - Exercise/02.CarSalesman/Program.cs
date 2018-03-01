using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


class CarSalesman
{
    static void Main(string[] args)
    {
        List<Car> cars = new List<Car>();
        List<Engine> engines = new List<Engine>();
        int engineCount = int.Parse(Console.ReadLine());
        for (int i = 0; i < engineCount; i++)
        {
            TakeEngineInfo(engines);
        }

        int carCount = int.Parse(Console.ReadLine());
        for (int i = 0; i < carCount; i++)
        {
            TakeCarInfo(cars, engines);
        }

        foreach (var car in cars)
        {
            Console.WriteLine(car);
        }
    }

    private static void TakeCarInfo(List<Car> cars, List<Engine> engines)
    {
        string[] input = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        string model = input[0];
        string engineModel = input[1];

        Engine engine = engines.FirstOrDefault(x => x.model == engineModel);

        string weight = "n/a";
        string color = "n/a";

        if (input.Length == 3 && int.TryParse(input[2], out _))
        {
            weight = input[2];
        }
        else if (input.Length == 3)
        {
            color = input[2];
        }
        else if (input.Length == 4)
        {
            weight = input[2];
            color = input[3];
        }
        Car car = new Car(model, engine, weight, color);
        cars.Add(car);
    }

    private static void TakeEngineInfo(List<Engine> engines)
    {
        string[] input = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        string model = input[0];
        int power = int.Parse(input[1]);
        string displacement = "n/a";
        string efficiency = "n/a";

        if (input.Length == 3 && int.TryParse(input[2], out _))
        {
            displacement = input[2];
        }
        else if (input.Length == 3)
        {
            efficiency = input[2];
        }
        else if (input.Length == 4)
        {
            displacement = input[2];
            efficiency = input[3];
        }

        Engine engine = new Engine(model, power, displacement, efficiency);
        engines.Add(engine);
    }
}