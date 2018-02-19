using System;
using System.Globalization;

public class DateModifier
{
    public static int CalculateDateDifference(string firstDate, string secondDate)
    {
        var difference = DateTime.Parse(firstDate) - DateTime.Parse(secondDate);
        return Math.Abs(difference.Days);
    }
}

