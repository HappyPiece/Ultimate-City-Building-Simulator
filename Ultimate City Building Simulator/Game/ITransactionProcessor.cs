using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UltimateCityBuildingSimulator.Game;
using UltimateCityBuildingSimulator.Game.TransactionTypes;

namespace UltimateCityBuildingSimulator.Game
{
    public interface ITransactionProcessor
    {
        bool PerformTransaction(ITransaction transaction);
        ITransactionProcessorTerminal GetTransactionProcessorTerminal();
    }
}
