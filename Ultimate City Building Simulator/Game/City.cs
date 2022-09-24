using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UltimateCityBuildingSimulator.Game.TransactionTypes;
using UltimateCityBuildingSimulator.Game.Building;
using static UltimateCityBuildingSimulator.Game.Builder;
using UltimateCityBuildingSimulator.Game.Building.Commercial;
using UltimateCityBuildingSimulator.Game.Building.Residential;
using UltimateCityBuildingSimulator.Game.Building.Institutional;

namespace UltimateCityBuildingSimulator.Game
{
    public class City
    {
        public int Capacity { get; private set; }
        public int Population { get; private set; }
        public float Happiness { get; private set; }
        private ITransactionProcessorTerminal PlayerTransactionProcessorTerminal;
        private Builder Builder;

        private List<IBuildable> Buildings;
        public City(Player player)
        {
            Buildings = new List<IBuildable>();
            PlayerTransactionProcessorTerminal = player.GetTransactionProcessor().GetTransactionProcessorTerminal();
            Builder = new Builder(this);
        }
        public void UpdateCity(double deltaTime)
        {
            var income = Math.Round(GenerateIncome() * deltaTime);
            PlayerTransactionProcessorTerminal.AlterTransaction(Convert.ToInt32(income));
        }
        public IEnumerable<IBuildable> GetBuildings()
        {
            return Buildings.AsReadOnly();
        }
        public bool ChargePlayer(int amount)
        {
            return PlayerTransactionProcessorTerminal.AlterTransaction(-1 * amount);
        }
        public BuildingCatalogue GetAvailableBuildings()
        {
            return Builder.GetBuildingCatalogue();
        }
        public bool TryBuildBuilding(IBuildable buildable, out BuildRequestResponse response)
        {
            if (!Builder.RequestBuildingToBuild(buildable, out IBuildable building, out response)) return false;
            Buildings.Add(building);
            UpdateCityStats();
            return true;
        }

        public CityStatistics GetCityStatistics()
        {
            int institutional = 0, residential = 0, commercial = 0;
            foreach (var building in Buildings)
            {
                switch (building)
                {
                    case Institutional:
                        institutional += 1;
                        break;
                    case Residential:
                        residential += 1;
                        break;
                    case Commercial:
                        commercial += 1;
                        break;
                    default: break;
                }
            }
            return new CityStatistics(Capacity,
                Population,
                Happiness,
                Buildings.Count,
                commercial,
                institutional,
                residential,
                GenerateIncome());
        }
        private void UpdateCityStats()
        {
            UpdateCapacity();
            UpdateHappiness();
            UpdatePopulation();
        }

        private void UpdateCapacity()
        {
            int CountedCapacity = 0;
            foreach (var buildable in Buildings)
            {
                if (buildable is Residential)
                {
                    CountedCapacity += ((Residential)buildable).Capacity;
                }
            }
            Capacity = CountedCapacity;
        }
        private void UpdatePopulation()
        {
            double PopulationMultiplier = 1;
            PopulationMultiplier = (Happiness / (Capacity + 10));
            Population = Math.Clamp((int)(Capacity * PopulationMultiplier), 0, Capacity);
        }
        private void UpdateHappiness()
        {
            int CountedHappiness = 10;
            foreach (var buildable in Buildings)
            {
                if (buildable is Institutional)
                {
                    CountedHappiness += ((Institutional)buildable).SatisfactionValue;
                }
            }
            Happiness = CountedHappiness;
        }
        private int GenerateIncome()
        {
            float BasePopulationIncomeMultiplier = 0.5F;
            int IncomePerSecond = (int)(BasePopulationIncomeMultiplier * Population);
            foreach (var buildable in Buildings)
            {
                if (buildable is Commercial)
                {
                    IncomePerSecond += ((Commercial)buildable).Income;
                }
            }
            return IncomePerSecond;
        }
        public struct CityStatistics
        {
            public int Capacity;
            public int Population;
            public float Happiness;
            public int BuildingsTotal;
            public int BuildingsCommercial;
            public int BuildingsInstitutional;
            public int BuildingsResidential;
            public int Income;

            public CityStatistics(int capacity,
                int population,
                float happiness,
                int total,
                int commercial,
                int institutional,
                int residential,
                int income)
            {
                this.Capacity = capacity;
                this.Population = population;
                this.Happiness = happiness;
                this.BuildingsTotal = total;
                this.BuildingsInstitutional = institutional;
                this.BuildingsCommercial = commercial;
                this.BuildingsResidential = residential;
                this.Income = income;
            }
        }
    }
}
