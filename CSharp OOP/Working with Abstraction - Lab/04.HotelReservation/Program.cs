using System;

class Program
{
    static void Main(string[] args)
    {
        string[] reservationInfo = Console.ReadLine().Split();
        decimal pricePerDay = decimal.Parse(reservationInfo[0]);
        int numberOfDays = int.Parse(reservationInfo[1]);
        Seasons seasons = (Seasons)Enum.Parse(typeof(Seasons), reservationInfo[2]);
        Discount discount = Discount.None;

        if (reservationInfo.Length == 4)
        {
            discount = (Discount)Enum.Parse(typeof(Discount), reservationInfo[3]);
        }

        PriceCalculator priceCalculator = new PriceCalculator();
        decimal totalPrice = priceCalculator.CalculatePrice(pricePerDay, numberOfDays, seasons, discount);
        Console.WriteLine($"{totalPrice:f2}");
    }
}