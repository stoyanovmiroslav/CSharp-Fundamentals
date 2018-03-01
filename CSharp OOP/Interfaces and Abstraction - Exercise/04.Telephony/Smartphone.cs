using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Smartphone : ICall, IBrowse
{
    public List<string> Sites { get; set; }
    public List<string> Phones { get; set; }

    public Smartphone()
    {
        this.Sites = new List<string>();
        this.Phones = new List<string>();
    }
    public void Browse(List<string> sites)
    {
        foreach (var site in sites)
        {
            try
            {
                if (site.Any(c => char.IsDigit(c)))
                {
                    throw new ArgumentException("Invalid URL!");
                }
                else
                {
                    Console.WriteLine($"Browsing: {site}!");
                }
            }
            catch (ArgumentException argEx)
            {
                Console.WriteLine(argEx.Message);
            }
        }
    }

    public void Call(List<string> phones)
    {
        foreach (var phone in phones)
        {
            try
            {
                if (phone.Any(c => char.IsDigit(c) == false))
                {
                    throw new ArgumentException("Invalid number!");
                }
                else
                {
                    Console.WriteLine($"Calling... {phone}");
                }
            }
            catch (ArgumentException argEx)
            {
                Console.WriteLine(argEx.Message);
            }
        }
    }
}