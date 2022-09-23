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
            //IReadOnlyList<BuildingCatalogue.Item> catalogueItems = catalogue.GetList();
            //var output = new string[2, catalogueItems.Count];
            //for (int index = 0; index < catalogueItems.Count; index++)
            //{
            //    output[0, index] = catalogueItems[index].Name.ToString();
            //    output[1, index] = catalogueItems[index].Price.ToString();
            //}
            var output = $"{"Тип здания",-25} {"Стоимость",-25}\n";
            //foreach (var item in catalogue.GetList())
            //{
            //    output = string.Join("", output, "building name: ", item.Name,
            //        "\t", "current price: ", item.Price, "\n");
            //}
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
