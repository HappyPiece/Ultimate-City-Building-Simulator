using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UltimateCityBuildingSimulator.Game.TransactionTypes;
using UltimateCityBuildingSimulator.Game.Building;

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

            //PlayerTransactionProcessorTerminal.SetTransaction(100);
            //Console.WriteLine(PlayerTransactionProcessorTerminal.GetTransaction());
            //PlayerTransactionProcessorTerminal.AlterTransaction(-30);
            //Console.WriteLine(PlayerTransactionProcessorTerminal.GetTransaction());
        }
        public void UpdateCapacity() { throw new NotImplementedException(); }
        public void UpdatePopulation() { throw new NotImplementedException(); }
        public void UpdateHappiness() { throw new NotImplementedException(); }

        public IEnumerable<IBuildable> GetBuildings()
        {
            return Buildings.AsReadOnly();
        }
    }
}
