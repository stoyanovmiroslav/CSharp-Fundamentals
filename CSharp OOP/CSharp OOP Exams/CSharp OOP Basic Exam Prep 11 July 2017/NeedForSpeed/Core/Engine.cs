using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Engine
{
    CarManager carManager;

    public Engine()
    {
        this.carManager = new CarManager();
    }

    public void Run()
    {
        string command = "";
        while ((command = Console.ReadLine()) != "Cops Are Here")
        {
            string[] splitCommand = command.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);

            switch (splitCommand[0])
            {
                case "register":
                    int id = int.Parse(splitCommand[1]);
                    string type = splitCommand[2];
                    string brand = splitCommand[3];
                    string model = splitCommand[4];
                    int yearOfProduction = int.Parse(splitCommand[5]);
                    int horsePower = int.Parse(splitCommand[6]);
                    int acceleration = int.Parse(splitCommand[7]);
                    int suspention = int.Parse(splitCommand[8]);
                    int durability = int.Parse(splitCommand[9]);
                    carManager.Register(id, type, brand, model, yearOfProduction, horsePower, acceleration, suspention, durability);
                    break;
                case "check":
                    int idCheck = int.Parse(splitCommand[1]);
                    Console.WriteLine(carManager.Check(idCheck));
                    break;
                case "open":
                    int openId = int.Parse(splitCommand[1]);
                    string openType = splitCommand[2];
                    int length = int.Parse(splitCommand[3]);
                    string route = splitCommand[4];
                    int prizePool = int.Parse(splitCommand[5]);
                    if (splitCommand.Length > 6)
                    {
                        int extraParameter = int.Parse(splitCommand[6]);
                        carManager.Open(openId, openType, length, route, prizePool, extraParameter);
                    }
                    else
                    {
                        carManager.Open(openId, openType, length, route, prizePool);
                    }
                    break;
                case "participate":
                    int carId = int.Parse(splitCommand[1]);
                    int raceId = int.Parse(splitCommand[2]);
                    carManager.Participate(carId, raceId);
                    break;
                case "start":
                    int startId = int.Parse(splitCommand[1]);
                    Console.WriteLine(carManager.Start(startId));
                    break;
                case "park":
                    int carIdPark = int.Parse(splitCommand[1]);
                    carManager.Park(carIdPark);
                    break;
                case "unpark":
                    int carIdUnPark = int.Parse(splitCommand[1]);
                    carManager.Unpark(carIdUnPark);
                    break;
                case "tune":
                    int tuneIndex = int.Parse(splitCommand[1]);
                    string addOn = splitCommand[2];
                    carManager.Tune(tuneIndex, addOn);
                    break;
            }
        }
    }
}