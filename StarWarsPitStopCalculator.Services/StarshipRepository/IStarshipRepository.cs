using StarWarsPitStopCalculator.Services.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StarWarsPitStopCalculator.Services.StarshipRepository
{
    public interface IStarshipRepository
    {
          Task<IEnumerable<StarshipJsonModel>> DownloadStarshipList();
    }
}
