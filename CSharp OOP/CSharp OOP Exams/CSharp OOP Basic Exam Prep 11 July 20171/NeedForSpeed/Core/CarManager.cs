using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class CarManager
{
    public Dictionary<int, Car> cars = new Dictionary<int, Car>();
    public Dictionary<int, Race> races = new Dictionary<int, Race>();
    Garage garage = new Garage();

    public void Register(int id, string type, string brand, string model, int yearOfProduction, int horsepower, int acceleration, int suspension, int durability)
    {
        Car car = CarFactory.CreateCar(id, type, brand, model, yearOfProduction, horsepower, acceleration, suspension, durability);
        cars.Add(id, car);
    }

    public string Check(int id)
    {
        return cars[id].ToString().Trim();
    }

    public void Open(int id, string type, int length, string route, int prizePool)
    {
        Race race = RaceFactory.CreateRace(id, type, length, route, prizePool);
        races.Add(id, race);
    }

    public void Open(int id, string type, int length, string route, int prizePool, int extraParameter)
    {
        Race race = ExtraRaceFactory.CreateExtraRaceFactory(id, type, length, route, prizePool, extraParameter);
        races.Add(id, race);
    }

    public void Participate(int carId, int raceId)
    {
        if (garage.ParkedCars.Contains(cars[carId]) == false)
        {
            if (races[raceId] is TimeLimitRace && races[raceId].GetParticipants.Count < 1)
            {
                races[raceId].AddParticipants(cars[carId]);
            }
            else if (races[raceId] is TimeLimitRace == false)
            {
                races[raceId].AddParticipants(cars[carId]);
            }
        }
    }

    public string Start(int id)
    {
        string winners = string.Empty;
        if (races[id] is CasualRace)
        {
            var casualRaceWinners = races[id].GetParticipants.OrderByDescending(x => x.OverallPerformance()).ToList();
            winners = GetWinners(id, casualRaceWinners, "casual");
        }
        else if (races[id] is DragRace)
        {
            var dragRaceWinners = races[id].GetParticipants.OrderByDescending(x => x.EnginePerformance()).ToList();
            winners = GetWinners(id, dragRaceWinners, "drag");
        }
        else if (races[id] is DriftRace)
        {
            var driftRaceWinners = races[id].GetParticipants.OrderByDescending(x => x.SuspensionPerformance()).ToList();
            winners = GetWinners(id, driftRaceWinners, "drift");
        }
        else if (races[id] is TimeLimitRace)
        {
            var timeRaceWinners = races[id].GetParticipants.ToList();
            winners = GetTimeParticipant(id, timeRaceWinners, "time");
        }
        else if (races[id] is CircuitRace)
        {
            var circuitRaceWinners = races[id].GetParticipants.ToList(); 
            winners = GetWinners(id, circuitRaceWinners, "circuit");
        }
        return winners;
    }

    private string GetTimeParticipant(int id, List<Car> timeRaceWinners, string raceType)
    {
        if (timeRaceWinners.Count == 0)
        {
            return "Cannot start the race with zero participants.";
        }

        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"{races[id].Route} - {races[id].Lenght}");

        int winner = 0;
        int performance = CalculatePerformance(timeRaceWinners, raceType, winner, id);

        var currentRace = races[id] as TimeLimitRace;
        string participantEarnedTime = "";
        int wonPrize = 0;
        if (performance <= currentRace.GoldTime)
        {
            participantEarnedTime = "Gold";
            wonPrize = currentRace.PrizePool;
        }
        else if (performance <= currentRace.GoldTime + 15)
        {
            participantEarnedTime = "Silver";
            wonPrize = currentRace.PrizePool * 50 / 100;
        }
        else if (performance > currentRace.GoldTime + 15)
        {
            participantEarnedTime = "Bronze";
            wonPrize = currentRace.PrizePool * 30 / 100;
        }

        sb.AppendLine($"{timeRaceWinners[winner].Brand} {timeRaceWinners[winner].Model} - {performance} s.");
        sb.AppendLine($"{participantEarnedTime} Time, ${wonPrize}.");

        races.Remove(id);
        return sb.ToString().TrimEnd();
    }

    private string GetWinners(int id, List<Car> currentRaceWinners, string raceType)
    {
        if (currentRaceWinners.Count == 0)
        {
            return "Cannot start the race with zero participants.";
        }

        int laps = 1;
        int numberOfWiners = 3;
        if (raceType == "circuit")
        {
            var currentRace = races[id] as CircuitRace;
            laps = currentRace.Laps;
            numberOfWiners = 4;

            for (int i = 0; i < laps; i++)
            {
                currentRaceWinners.ForEach(x => x.Durability = x.Durability - (races[id].Lenght * races[id].Lenght));
            }
            currentRaceWinners = races[id].GetParticipants.OrderByDescending(x => x.OverallPerformance()).ToList();
        }

        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"{races[id].Route} - {races[id].Lenght * laps}");

        for (int winner = 0; winner < currentRaceWinners.Count && winner < numberOfWiners; winner++)
        {
            int prizePool = CalculatePrizePool(id, winner);
            int performance = CalculatePerformance(currentRaceWinners, raceType, winner, id);
            sb.AppendLine($"{winner + 1}. {currentRaceWinners[winner].Brand} {currentRaceWinners[winner].Model} {performance}PP - ${prizePool}");
        }

        races.Remove(id);
        return sb.ToString().TrimEnd();
    }

    private int CalculatePrizePool(int id, int index)
    {
        int prizePool = 0;
        if (races[id] is CircuitRace)
        {
            if (index + 1 == 1) prizePool = races[id].PrizePool * 40 / 100;
            else if (index + 1 == 2) prizePool = races[id].PrizePool * 30 / 100;
            else if (index + 1 == 3) prizePool = races[id].PrizePool * 20 / 100;
            else if (index + 1 == 4) prizePool = races[id].PrizePool * 10 / 100;
        }
        else
        {
            if (index + 1 == 1) prizePool = races[id].PrizePool * 50 / 100;
            else if (index + 1 == 2) prizePool = races[id].PrizePool * 30 / 100;
            else if (index + 1 == 3) prizePool = races[id].PrizePool * 20 / 100;
        }
        return prizePool;
    }

    private int CalculatePerformance(List<Car> currentRaceWinners, string raceType, int index, int raceId)
    {
        int performance = 0;
        if (raceType == "casual" || raceType == "circuit") performance = currentRaceWinners[index].OverallPerformance();
        else if (raceType == "drift") performance = currentRaceWinners[index].SuspensionPerformance();
        else if (raceType == "drag") performance = currentRaceWinners[index].EnginePerformance();
        else if (raceType == "time") performance = currentRaceWinners[index].TimePerformance(races[raceId]);
        return performance;
    }

    public void Park(int id)
    {
        foreach (var race in races)
        {
            if (race.Value.GetParticipants.Contains(cars[id]))
            {
                return;
            }
        }
        if (cars.ContainsKey(id)) // not in race??
        {
            garage.ParkCar(cars[id]);
        }
    }

    public void Unpark(int id)
    {
        if (cars.ContainsKey(id))
        {
            garage.UnparkCar(cars[id]);
        }
    }

    public void Tune(int tuneIndex, string addOn)
    {
        garage.ModifyCars(tuneIndex, addOn);
    }
}