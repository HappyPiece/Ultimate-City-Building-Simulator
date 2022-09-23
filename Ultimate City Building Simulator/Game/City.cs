using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UltimateCityBuildingSimulator.Game.TransactionTypes;
using UltimateCityBuildingSimulator.Game.Building;
using static UltimateCityBuildingSimulator.Game.Builder;

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
            //PlayerTransactionProcessorTerminal.SetTransaction(100);
            //Console.WriteLine(PlayerTransactionProcessorTerminal.GetTransaction());
            //PlayerTransactionProcessorTerminal.AlterTransaction(-30);
            //Console.WriteLine(PlayerTransactionProcessorTerminal.GetTransaction());

        }
        public void UpdateCapacity() { throw new NotImplementedException(); }
        public void UpdatePopulation() { throw new NotImplementedException(); }
        public void UpdateHappiness() { throw new NotImplementedException(); }
        public BuildingCatalogue GetAvailableBuildings()
        {
            return Builder.GetBuildingCatalogue();
        }
        public bool TryBuildBuilding(IBuildable buildable, out BuildRequestResponse response)
        {
            if (!Builder.RequestBuildingToBuild(buildable, out IBuildable building, out response)) return false;
            Buildings.Add(building);
            return true;
        }
        public IEnumerable<IBuildable> GetBuildings()
        {
            return Buildings.AsReadOnly();
        }
        public bool ChargePlayer(int amount)
        {
            return PlayerTransactionProcessorTerminal.AlterTransaction(-1*amount);
        }
    }
}
