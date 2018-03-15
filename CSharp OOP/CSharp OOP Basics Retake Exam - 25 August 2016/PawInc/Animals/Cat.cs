using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Cat : Animal
{
    private int intelligenceCoefficient;

    public Cat(string name, int age, int intelligenceCoefficient)
    : base(name, age)
    {
        this.IntelligenceCoefficient = intelligenceCoefficient;
    }

    public int IntelligenceCoefficient
    {
        get { return intelligenceCoefficient; }
        private set { intelligenceCoefficient = value; }
    }

    public override string ToString()
    {
        return this.Name;
    }
}