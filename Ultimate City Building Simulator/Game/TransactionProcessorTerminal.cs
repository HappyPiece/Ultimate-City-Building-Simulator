using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UltimateCityBuildingSimulator.Game.TransactionTypes;

namespace UltimateCityBuildingSimulator.Game
{
    public class TransactionProcessorTerminal: ITransactionProcessorTerminal
    {
        ITransactionProcessor ParentalProcessor;
        public void SendTransaction(ITransaction transaction)
        {
            ParentalProcessor.PerformTransaction(transaction);
        }
        public TransactionProcessorTerminal(ITransactionProcessor parentalProcessor)
        {
            ParentalProcessor = parentalProcessor;
        }
    }
}
