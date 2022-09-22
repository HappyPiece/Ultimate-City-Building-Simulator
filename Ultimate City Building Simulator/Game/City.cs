using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UltimateCityBuildingSimulator.Game.TransactionTypes;

namespace UltimateCityBuildingSimulator.Game
{
    public class City
    {
        private ITransactionProcessorTerminal PlayerTransactionProcessorTerminal;
        public City(Player player)
        {
            PlayerTransactionProcessorTerminal = player.GetTransactionProcessor().GetTransactionProcessorTerminal();
            PlayerTransactionProcessorTerminal.SendTransaction(new SetBalanceTransaction(100));
            PlayerTransactionProcessorTerminal.SendTransaction(new AlterBalanceTransaction(-30));
        }

    }
}
