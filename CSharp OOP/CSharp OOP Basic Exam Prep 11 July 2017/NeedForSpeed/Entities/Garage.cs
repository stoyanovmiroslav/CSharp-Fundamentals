using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Garage
{
    private List<Car> parkedCars;

    public Garage()
    {
        parkedCars = new List<Car>();
    }

    public void ParkCar(Car car)
    {
        parkedCars.Add(car);
    }

    public void UnparkCar(Car car)
    {
        parkedCars.Remove(car);
    }

    public void ModifyCars(int tuneIndex, string addOn)
    {
        if (parkedCars.Count == 0)
        {
            return;
        }

        foreach (var car in parkedCars)
        {
            car.TuneUpgrade(tuneIndex);

            if (car is PerformanceCar)
            {
                var tuneCar = (PerformanceCar)car;
                tuneCar.AddOnsService(addOn);
            }
            else if (car is ShowCar)
            {
                var showCar = (ShowCar)car;
                showCar.IncreaseStars(tuneIndex);
            }
        }
    }

    public List<Car> ParkedCars
    {
        get { return parkedCars; }
        set { parkedCars = value; }
    }
}