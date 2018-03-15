using System;

public class Car
{
    private int hp;
    private double fuelAmount;
    private Tyre tyre;

    public Car(int hp , double fuelAmout, Tyre tyre)
    {
        this.Hp = hp;
        this.FuelAmount = fuelAmout;
        this.Tyre = tyre;
    }

    public void Refuel(double fuelAmount)
    {
        this.FuelAmount += fuelAmount;
    }

    public void ReduceFuelAmount(int lengthOfTheTrack, double fuelConsumationPerKm)
    {
        this.FuelAmount -= lengthOfTheTrack * fuelConsumationPerKm;
    } 

    public void ChangeTyre(Tyre tyre)
    {
        this.Tyre = tyre;
    }

    public Tyre Tyre
    {
        get { return tyre; }
        private set { tyre = value; }
    }

    public double FuelAmount
    {
        get { return fuelAmount; }
        private set
        {
            if (value > 160)
            {
                fuelAmount = 160;
            }
            else if (value < 0)
            {
                throw new ArgumentException("Out of fuel");
            }
            else
            {
                fuelAmount = value;
            }
        }
    }

    public int Hp
    {
        get { return hp; }
        set { hp = value; }
    }
}