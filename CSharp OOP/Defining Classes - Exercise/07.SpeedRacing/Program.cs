using System;
using System.Collections.Generic;
using System.Linq;


class Program
{
    static void Main(string[] args)
    {
        int numbersOfCars = int.Parse(Console.ReadLine());
        List<Car> cars = new List<Car>();

        for (int i = 0; i < numbersOfCars; i++)
        {
            string[] carInformation = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            Car car = new Car(carInformation[0], double.Parse(carInformation[1]), double.Parse(carInformation[2]));

            cars.Add(car);

        }
        string driveInformation = "";

        while ((driveInformation = Console.ReadLine()) != "End")
        {
            string[] carAndDistance = driveInformation.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            string car = carAndDistance[1];
            double distance = double.Parse(carAndDistance[2]);

            var currentCar = cars.First(c => c.Model == car);

            double neededFuel = currentCar.FuelConsumption * distance;

            if (neededFuel <= currentCar.Fuel)
            {
                currentCar.Fuel -= neededFuel;
                currentCar.TraveledDistance += distance;
            }
            else
            {
                Console.WriteLine("Insufficient fuel for the drive");
            }
        }

        foreach (var car in cars)
        {
            Console.WriteLine($"{car.Model} {car.Fuel:f2} {car.TraveledDistance}");
        }
    }
}

