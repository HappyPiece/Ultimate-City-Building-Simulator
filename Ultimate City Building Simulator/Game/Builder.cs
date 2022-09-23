using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UltimateCityBuildingSimulator.Game
{
    public class Builder
    {
        private City AssignedCity;

        public Builder(City city)
        {
            AssignedCity = city;
        }

        public int CalcualteBuildingCost(Building.IBuildable building)
        {
            //
            IEnumerable<Building.IBuildable> buildings = GetCityBuildings();

            int buildingsOfTypeCount = buildings.Count((Building.IBuildable comp) => comp.GetType() == building.GetType());
            float resultingCostMultiplier = MathF.Pow(building.ProvideMultiplier(), buildingsOfTypeCount);
            int resultingCost = Convert.ToInt32(MathF.Round(resultingCostMultiplier * building.ProvideCost()));

            Console.WriteLine("Calculated cost for building " + building.GetType().ToString() + " :" + resultingCost);
            Console.WriteLine("Already built: " + buildingsOfTypeCount);
            return resultingCost;
        }

        private IEnumerable<Building.IBuildable> GetCityBuildings()
        {
            return AssignedCity.GetBuildings();
        }
    }
}
