using System;
using System.Collections.Generic;
using System.Text;

public class Ferrari : ICar
{
    public string Model { get; set; }
    public string Driver { get; set; }

    public Ferrari(string model, string driver)
    {
        this.Model = model;
        this.Driver = driver;
    }

    private string Breaks()
    {
        return "Brakes!";
    }

    private string Gas()
    {
        return "Zadu6avam sA!";
    }

    public override string ToString()
    {
        return $"{this.Model}/{Breaks()}/{Gas()}/{this.Driver}";
    }
}