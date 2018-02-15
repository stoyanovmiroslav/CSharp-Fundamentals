using System;
using System.Collections.Generic;
using System.Text;

public class PriceCalculator
{
    public decimal CalculatePrice(decimal pricePerDay, int numberOfDays, Seasons seasons, Discount discount)
    {
        int seasonMultiple = (int)seasons;
        decimal currentAmount = pricePerDay * numberOfDays * seasonMultiple;
        decimal calculateDiscout = currentAmount * (int)discount / 100;
        decimal totalResult = currentAmount - calculateDiscout; 
        return totalResult;
    }
}

