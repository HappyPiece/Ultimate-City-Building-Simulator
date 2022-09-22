using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UltimateCityBuildingSimulator.Game
{
    internal class City
    {
        private ITransactionProcessorTerminal PlayerTransactionProcessorTerminal;
        public City(Player player)
        {
            PlayerTransactionProcessorTerminal = player.GetTransactionProcessor().GetTransactionProcessorTerminal();
        }

    }
}
