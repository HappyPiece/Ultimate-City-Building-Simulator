using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UltimateCityBuildingSimulator.Game.Building;

namespace UltimateCityBuildingSimulator.Utility
{
    public interface IBuildingCatalogueParser
    {
        public string Parse(BuildingCatalogue catalogue);

        //Possible implementations:
        //Parse names
        //Parse Buildings
        //Parse to string/list
    }
}
