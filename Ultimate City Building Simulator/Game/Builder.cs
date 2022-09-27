using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UltimateCityBuildingSimulator.Game.Building;
using UltimateCityBuildingSimulator.Game.Building.Commercial;
using UltimateCityBuildingSimulator.Game.Building.Institutional;
using UltimateCityBuildingSimulator.Game.Building.Residential;

namespace UltimateCityBuildingSimulator.Game
{
    public class Builder
    {
        private City AssignedCity;

        private Showcase Showcase;

        public Builder(City city)
        {
            AssignedCity = city;
            Showcase = new Showcase();
        }

        public int CalcualteBuildingCost(IBuildable building)
        {
            //
            IEnumerable<IBuildable> buildings = GetCityBuildings();

            int buildingsOfTypeCount = buildings.Count((IBuildable comp) => comp.GetType() == building.GetType());
            float resultingCostMultiplier = MathF.Pow(building.ProvideMultiplier(), buildingsOfTypeCount);
            int resultingCost = Convert.ToInt32(MathF.Round(resultingCostMultiplier * building.ProvideCost()));

            //Console.WriteLine("Calculated cost for building " + building.GetType().Name.ToString() + " : " + resultingCost);
            //Console.WriteLine("Already built: " + buildingsOfTypeCount);
            return resultingCost;
        }

        public IReadOnlyCollection<IBuildable> GetShowcase()
        {
            return Showcase.BuildingsShowcase;
        }

        public bool RequestBuildingToBuild(IBuildable template, out IBuildable building, out BuildRequestResponse response)
        {
            response = BuildRequestResponse.UnspecifiedFailure;
            int cost = CalcualteBuildingCost(template);
            building = (IBuildable)template.Clone();
            if (!AssignedCity.ChargePlayer(CalcualteBuildingCost(template)))
            {
                response = BuildRequestResponse.InsufficientFunds;
                return false;
            }
            response = BuildRequestResponse.Success;
            return true;
        }

        private IEnumerable<IBuildable> GetCityBuildings()
        {
            return AssignedCity.GetBuildings();
        }

        public BuildingCatalogue GetBuildingCatalogue()
        {
            List<IBuildable> buildings = GetShowcase().ToList();
            var catalogue = new BuildingCatalogue();

            foreach (var building in buildings)
            {
                catalogue.AddItem((IBuildable)building.Clone(), CalcualteBuildingCost(building));
            }

            return catalogue;
        }
        public enum BuildRequestResponse //
        {
            Success,
            InsufficientFunds,
            UnspecifiedFailure
        }
    }
}
