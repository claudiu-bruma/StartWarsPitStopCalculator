using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace StarWarsPitStopCalculator.Services.Utilities.StringParsers
{
    public class StringParser :IStringParser 
    {
        public   int? ParseConsumablesDuration(string consumables)
        {
            if (CheckIntervalType(consumables, "y"))
            {
                return ExtractNumberFromBeginingOfString(consumables) * 365;
            }
            if (CheckIntervalType(consumables, "m"))
            {
                return ExtractNumberFromBeginingOfString(consumables) * 30;
            }
            if (CheckIntervalType(consumables, "w"))
            {
                return ExtractNumberFromBeginingOfString(consumables) * 7;
            }
            if (CheckIntervalType(consumables, "d"))
            {
                return ExtractNumberFromBeginingOfString(consumables);
            }
            return null;
        }

        public   int? ExtractNumberFromBeginingOfString(string consumables)
        {
            var regex = Regex.Match(consumables, @"[0-9]+");
            if (regex.Success)
                return int.Parse(regex.Value);
            return null;
        }

        private   bool CheckIntervalType(string consumables, string intervalType)
        {
            return Regex.Match(consumables, $"[0-9]+ {intervalType}[a-z]+").Success;
        }
    }
}
