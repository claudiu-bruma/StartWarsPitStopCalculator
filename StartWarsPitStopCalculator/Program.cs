
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using StarWarsPitStopCalculator.Services.StarshipService;
using StarWarsPitStopCalculator.Services.StarshipRepository;
using StarWarsPitStopCalculator.Services.Utilities.StringParsers;
using System;
using System.Threading.Tasks;

namespace StartWarsPitStopCalculator
{
    class Program
    {
        static ServiceProvider IoCSetup()
        {
            //setup our DI
            return new ServiceCollection()
                .AddScoped<IStarshipService,SWStarshipService>()
                .AddScoped<IStringParser,StringParser>()
                .AddScoped<IStarshipRepository,SWStarshipRepository>()
                .BuildServiceProvider();

           

        }
        static async Task Main(string[] args)
        {

            var dependencyInjectionProvider = IoCSetup();
            var starshipService = dependencyInjectionProvider.GetService<IStarshipService>();
            var starshipList = await starshipService.GetShipsWithValidDetails();

            Console.WriteLine(" Write exit when done!");
            var finished = false;
            while (!finished)
            {
                Console.Write("Distance : ");
                var inputValue = Console.ReadLine();
                finished = inputValue.Trim().ToLower() == "exit";
                
               
                long distance = 0;
                if (!finished &&long.TryParse(inputValue, out distance))
                {
                    foreach (var ship in starshipList)
                    {
                        Console.WriteLine($"{ship.Name} : {ship.NecesaryNumberOfStops(distance)}");
                    }
                }

            }


        }
    }
}
