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
            var output = $"{"Building Type",-25} {"Price",-25}\n";
            foreach (var item in catalogue.GetList())
            {
                output += $"{item.Name,-25} {item.Price,-25}\n";
            }
            //return FormatOutputData(output);
            return output;
        }

        //private string FormatOutputData(string data)
        //{
        //    return String.Format("{0,10}", data);
        //}
    }
}
