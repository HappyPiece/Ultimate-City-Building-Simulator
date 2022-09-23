using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UltimateCityBuildingSimulator.Game.TransactionTypes;
using static UltimateCityBuildingSimulator.Game.TransactionProcessor;

namespace UltimateCityBuildingSimulator.Game
{
    public class TransactionProcessorTerminal : ITransactionProcessorTerminal
    {
        ITransactionProcessor ParentalProcessor;
        public Guid Guid { get; private set; }
        public bool AlterTransaction(int value)
        {
            ParentalProcessor.PerformTransaction(new AlterBalanceTransaction(Guid, value), out TransactionState state, out int result);
            if (state == TransactionProcessor.TransactionState.OPERATION_SUCCESSFUL) return true;
            return false;
        }
        public bool SetTransaction(int value)
        {
            ParentalProcessor.PerformTransaction(new SetBalanceTransaction(Guid, value), out TransactionState state, out int result);
            if (state == TransactionProcessor.TransactionState.OPERATION_SUCCESSFUL) return true;
            return false;
        }
        public int GetTransaction()
        {
            ParentalProcessor.PerformTransaction(new GetBalanceTransaction(Guid), out TransactionState state, out int result);
            return result;
        }
        public bool EndSession()
        {
            ParentalProcessor.PerformTransaction(new EndSessionTransaction(Guid), out TransactionState state, out int result);
            if (state == TransactionProcessor.TransactionState.OPERATION_SUCCESSFUL) return true;
            return false;
        }
        public TransactionProcessorTerminal(ITransactionProcessor parentalProcessor, Guid guid)
        {
            ParentalProcessor = parentalProcessor;
            this.Guid = guid;
        }
    }
}
