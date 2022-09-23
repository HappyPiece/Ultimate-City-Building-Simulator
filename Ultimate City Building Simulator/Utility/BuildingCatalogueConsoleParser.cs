using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UltimateCityBuildingSimulator.Game.Building;

namespace UltimateCityBuildingSimulator.Utility
{
    internal class BuildingCatalogueConsoleParser : IBuildingCatalogueParser
    {
        public string Parse(BuildingCatalogue catalogue)
        {
            string output = String.Empty;
            foreach (var item in catalogue.GetList())
            {
                output = string.Join("", output, "building name: ", item.Name,
                    "\t", "current price: ", item.Price, "\n");
            }
            return output;
        }
    }
}
