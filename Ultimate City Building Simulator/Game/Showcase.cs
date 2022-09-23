using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UltimateCityBuildingSimulator.Game.Building;
using UltimateCityBuildingSimulator.Game.Building.Commercial;
using UltimateCityBuildingSimulator.Game.Building.Institutional;
using UltimateCityBuildingSimulator.Game.Building.Residential;

namespace UltimateCityBuildingSimulator.Game
{
    public class Showcase
    {
        public ReadOnlyCollection<IBuildable> BuildingsShowcase;
        public Showcase()
        {
            List<IBuildable> BuildingsList = new List<IBuildable>();
            BuildingsList.Add(new Shop());
            BuildingsList.Add(new Factory());
            BuildingsList.Add(new Office());
            BuildingsList.Add(new Hospital());
            BuildingsList.Add(new School());
            BuildingsList.Add(new PoliceStation());
            BuildingsList.Add(new SmallHouse());
            BuildingsList.Add(new MediumHouse());
            BuildingsList.Add(new LargeHouse());
            BuildingsShowcase = BuildingsList.AsReadOnly();
        }
    }
}
