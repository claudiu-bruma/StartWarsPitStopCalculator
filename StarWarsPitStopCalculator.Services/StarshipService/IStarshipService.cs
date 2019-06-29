using StarWarsPitStopCalculator.Services.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StarWarsPitStopCalculator.Services.StarshipService
{
    
    public interface IStarshipService
    {
        Task<IEnumerable<Starship>> GetAllStarships();
        Task<IEnumerable<Starship>> GetShipsWithValidDetails();
    }
}
