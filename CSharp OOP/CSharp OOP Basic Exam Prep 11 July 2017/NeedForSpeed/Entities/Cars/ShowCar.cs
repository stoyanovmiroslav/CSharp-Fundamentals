using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class ShowCar : Car
{
    private int stars;

    public ShowCar(string brand, string model, int yearOfProduction, int horsepower, int acceleration, int suspension, int durability) : base(brand, model, yearOfProduction, horsepower, acceleration, suspension, durability)
    {
        this.Stars = 0;
    }

    public void IncreaseStars(int tuneIndex)
    {
        this.Stars += tuneIndex;
    }

    public int Stars
    {
        get { return stars; }
        set { stars = value; }
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"{this.Stars} *");

        return base.ToString() + sb.ToString().Trim();
    }
}