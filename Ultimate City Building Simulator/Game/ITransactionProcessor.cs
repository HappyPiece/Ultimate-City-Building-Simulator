using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UltimateCityBuildingSimulator.Game;
using UltimateCityBuildingSimulator.Game.TransactionTypes;
using static UltimateCityBuildingSimulator.Game.TransactionProcessor;

namespace UltimateCityBuildingSimulator.Game
{
    public interface ITransactionProcessor
    {
        void PerformTransaction(Transaction transaction, out TransactionState state, out int value);
        ITransactionProcessorTerminal GetTransactionProcessorTerminal();
    }
}
