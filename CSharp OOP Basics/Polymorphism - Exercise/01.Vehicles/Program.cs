using System;

namespace _01.Vehicles
{
    class Program
    {
        static void Main()
        {
            string[] carInfo = Console.ReadLine().Split();
            string[] truckInfo = Console.ReadLine().Split();

            Car car = new Car(carInfo[0], double.Parse(carInfo[1]), double.Parse(carInfo[2]));
            Truck truck = new Truck(truckInfo[0], double.Parse(truckInfo[1]), double.Parse(truckInfo[2]));

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] args = Console.ReadLine().Split();

                switch (args[1])
                {
                    case "Car":
                        MakeAction(car, args);
                        break;
                    case "Truck":
                        MakeAction(truck, args);
                        break;
                }
            }

            Console.WriteLine(car);
            Console.WriteLine(truck);
        }

        private static void MakeAction(Vehicle vehicle, string[] args)
        {
            switch (args[0])
            {
                case "Drive":
                    vehicle.Drive(double.Parse(args[2]));
                    break;

                case "Refuel":
                    vehicle.Refuel(double.Parse(args[2]));
                    break;
            }
        }
    }
}
