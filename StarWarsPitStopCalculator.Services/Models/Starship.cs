﻿using System;
using System.Collections.Generic;
using System.Text;

namespace StarWarsPitStopCalculator.Services.Models
{
    public class Starship
    {
        public string Name { get; set; }
        public string Model { get; set; }
        public int? NoOfDaysBetweenPitStops { get; set; }
        public int? MegalightYearsPerHour { get; set; }

        public int? NecesaryNumberOfStops(int distance)
        {
            if (!NoOfDaysBetweenPitStops.HasValue || !MegalightYearsPerHour.HasValue)
                return null;
            var pitStopsNecessary = distance / (MegalightYearsPerHour.Value * 24) / NoOfDaysBetweenPitStops.Value;
            return pitStopsNecessary;
        }
    }
}
