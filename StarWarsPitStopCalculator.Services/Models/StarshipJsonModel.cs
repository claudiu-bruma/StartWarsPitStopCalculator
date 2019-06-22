using System;
using System.Collections.Generic;
using System.Text;

namespace StarWarsPitStopCalculator.Services.Models
{
    public class StarshipJsonModel
    {
        public string Name { get; set; }
        public string Model { get; set; }
        public string Consumables { get; set; }
        public string MGLT { get; set; }
        public string Url { get; set; }
    }
}
