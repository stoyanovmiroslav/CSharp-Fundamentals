using System;
using System.Globalization;

class Program
{
    static void Main(string[] args)
    {
        DateTime fitstDate = DateTime.ParseExact(Console.ReadLine(), "yyyy MM dd", CultureInfo.InvariantCulture);
        DateTime secondDate = DateTime.ParseExact(Console.ReadLine(), "yyyy MM dd", CultureInfo.InvariantCulture);


        DateModifier dateModifier = new DateModifier();
        dateModifier.firstDate = fitstDate;
        dateModifier.secondDate = secondDate;

        int daysDiffence = Math.Abs((int)dateModifier.CalculatesTheDifference());

        Console.WriteLine(Math.Abs(daysDiffence));
    }
}
