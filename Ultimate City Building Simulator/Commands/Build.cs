using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UltimateCityBuildingSimulator.Commands.Manager;
using UltimateCityBuildingSimulator.Game.Building;
using static UltimateCityBuildingSimulator.Game.Builder;
using static UltimateCityBuildingSimulator.Game.Building.BuildingCatalogue;
using UltimateCityBuildingSimulator.Utility;
using UltimateCityBuildingSimulator.Game;


namespace UltimateCityBuildingSimulator.Commands
{
    internal class Build : ConsoleCommand
    {
        public Build(ConsoleCommandManager manager) : base(manager)
        {
            CommandWord = "build";
            Help = "Use: build [list|buildname]";
        }
        public override bool Process(string[] args)
        {
            if (args.Length != 1) return false;

            City city = ParentManager.ParentApplication.City;
            if (args[0] == "list")
            {
                var catalogue = city.GetAvailableBuildings();
                Console.WriteLine(ParentManager.CatalogueParser.Parse(catalogue));
            }
            else
            {
                var catalogue = city.GetAvailableBuildings();
                if (!catalogue.RequestItemByName(args[0], out Item item)) return false;
                if (!city.TryBuildBuilding(item.Building, out BuildRequestResponse response))
                {
                    Console.WriteLine(response.ToString());
                    return false;
                }
                Console.WriteLine("Buliding successfuly built");
            }
            return true;
        }
    }
}
