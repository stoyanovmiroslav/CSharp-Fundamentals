using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class RaceTower
{
    public int currentLaps;
    private int totalLaps;
    private int lengthOfTheTrack;
    private List<Driver> drivers;
    private string weather = "Sunny";
    private Dictionary<Driver, string> unfinishedDrivers = new Dictionary<Driver, string>();

    public RaceTower()
    {
        drivers = new List<Driver>();
    }

    public void SetTrackInfo(int lapsNumber, int trackLength)
    {
        this.totalLaps = lapsNumber;
        this.lengthOfTheTrack = trackLength;
    }

    public void RegisterDriver(List<string> commandArgs)
    {
        try
        {
            Tyre tyre = TyreFactory.CreateTyre(commandArgs);

            int hp = int.Parse(commandArgs[2]);
            double fuelAmount = double.Parse(commandArgs[3]);
            Car car = new Car(hp, fuelAmount, tyre);

            Driver driver = DriverFactory.CreateDriver(commandArgs, car);
            drivers.Add(driver);
        }
        catch { }
    }

    public string PrintWinner()
    {
        var winner = drivers.Where(d => d.Status == "racing").OrderBy(d => d.TotalTime).FirstOrDefault();
        return $"{winner.Name} wins the race for {winner.TotalTime:f3} seconds.";
    }

    public void DriverBoxes(List<string> commandArgs)
    {
        string driverName = commandArgs[1];
        var currentDriver = drivers.Where(d => d.Name == driverName).First();
        currentDriver.TotalTime += 20;

        switch (commandArgs[0])
        {
            case "Refuel":
                double fuelAmout = double.Parse(commandArgs[2]);
                currentDriver.Car.Refuel(fuelAmout);
                break;
            case "ChangeTyres":
                Tyre tyre = null;
                double tyreHardness = double.Parse(commandArgs[3]);

                if (commandArgs[2] == "Hard")
                {
                    tyre = new HardTyre(tyreHardness);
                }
                else if (commandArgs[2] == "Ultrasoft")
                {
                    double grip = double.Parse(commandArgs[4]);
                    tyre = new UltrasoftTyre(tyreHardness, grip);
                }
                currentDriver.Car.ChangeTyre(tyre);
                break;
        }
    }

    public string GetLeaderboard()
    {
        int count = 1;
        StringBuilder stringBuilder = new StringBuilder();
        stringBuilder.AppendLine($"Lap {this.currentLaps}/{this.totalLaps}");

        foreach (var driver in drivers.OrderBy(d => d.TotalTime).Where(x => x.Status == "racing"))
        {
            stringBuilder.AppendLine($"{count++} {driver.Name} {driver.TotalTime:f3}");
        }

        var sortedUnfinishedDrivers = this.unfinishedDrivers.Reverse();
        foreach (var driver in sortedUnfinishedDrivers)
        {
            stringBuilder.AppendLine($"{count++} {driver.Key.Name} {driver.Value}");
        }

        return stringBuilder.ToString().TrimEnd();
    }

    public void ChangeWeather(List<string> commandArgs)
    {
        this.weather = commandArgs[0];
    }

    public string CompleteLaps(List<string> commandArgs)
    {
        StringBuilder stringBuilder = new StringBuilder();
        int lapsInput = int.Parse(commandArgs[0]);

        if (lapsInput + this.currentLaps > this.totalLaps)
        {
            stringBuilder.AppendLine($"There is no time! On lap {this.currentLaps}.");
            return stringBuilder.ToString().TrimEnd();
        }

        for (int lap = 0; lap < lapsInput; lap++)
        {
            this.currentLaps++;

            CalculateDriversTotalTime();
            ReduceFuelAndDegradationOnDriversCars();
            TryOvertakeOtherCars(stringBuilder);
        }
        return stringBuilder.ToString().TrimEnd();
    }

    private void ReduceFuelAndDegradationOnDriversCars()
    {
        foreach (var driver in drivers.Where(x => x.Status == "racing"))
        {
            try
            {
                driver.Car.ReduceFuelAmount(this.lengthOfTheTrack, driver.FuelConsumptionPerKm);
                driver.Car.Tyre.ReduceDegradation();
            }
            catch (ArgumentException argEx)
            {
                driver.ChangeDriverStatus(argEx.Message);
                this.unfinishedDrivers.Add(driver, argEx.Message);
            }
        }
    }

    private void CalculateDriversTotalTime()
    {
        foreach (var driver in drivers.Where(x => x.Status == "racing"))
        {
            driver.TotalTime += 60 / (this.lengthOfTheTrack / driver.Speed);
        }
    }

    private void TryOvertakeOtherCars(StringBuilder stringBuilder)
    {
        var orderedDrivers = drivers.OrderByDescending(x => x.TotalTime).ToList();

        for (int j = 0; j < orderedDrivers.Count - 1; j++)
        {
            Driver firstDriver = orderedDrivers[j];
            Driver secondDriver = orderedDrivers[j + 1];
            double diff = Math.Abs(secondDriver.TotalTime - firstDriver.TotalTime);
            int interval = 0;

            bool aggressiveDriver = firstDriver is AggressiveDriver && firstDriver.Car.Tyre is UltrasoftTyre && diff <= 3;
            bool enduranceDriver = firstDriver is EnduranceDriver && firstDriver.Car.Tyre is HardTyre && diff <= 3;

            if ((aggressiveDriver && this.weather == "Foggy") || (enduranceDriver && this.weather == "Rainy"))
            {
                firstDriver.ChangeDriverStatus("Crashed");
                this.unfinishedDrivers.Add(firstDriver, "Crashed");
                continue;
            }

            if (enduranceDriver || aggressiveDriver) interval = 3;
            else if (diff <= 2) interval = 2;

            if (interval != 0)
            {
                secondDriver.TotalTime += interval;
                firstDriver.TotalTime -= interval;
                orderedDrivers = orderedDrivers.OrderByDescending(x => x.TotalTime).ToList();
                stringBuilder.AppendLine($"{firstDriver.Name} has overtaken {secondDriver.Name} on lap {this.currentLaps}.");
            }
        }
    }
}