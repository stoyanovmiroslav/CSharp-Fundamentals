using System;
using System.Collections.Generic;
using System.Text;


class DateModifier
{
    public DateTime firstDate;
    public DateTime secondDate;

    public double CalculatesTheDifference()
    {
        return (firstDate - secondDate).TotalDays;
    }
}
