using System;
using System.Collections.Generic;
using System.Text;

namespace StarWarsPitStopCalculator.Services.Utilities.StringParsers
{
    public interface IStringParser
    {
        int? ParseConsumablesDuration(string consumables);
        int? ExtractNumberFromBeginingOfString(string consumables);
    }
}
