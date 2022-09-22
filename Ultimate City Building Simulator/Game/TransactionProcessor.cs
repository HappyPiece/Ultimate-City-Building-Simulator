using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UltimateCityBuildingSimulator.Game.TransactionTypes;

namespace UltimateCityBuildingSimulator.Game
{
    public class TransactionProcessor : ITransactionProcessor
    {
        private int balance;
        public bool PerformTransaction(ITransaction transaction)
        {
            switch (transaction)
            {
                case SetBalanceTransaction:
                    balance = transaction.getValue();
                    break;
                case AlterBalanceTransaction:
                    balance += transaction.getValue();
                    break;
                default:
                    return false;
            }
            return true;
        }

        public ITransactionProcessorTerminal GetTransactionProcessorTerminal()
        {
            return new TransactionProcessorTerminal(this);
        }

        public TransactionProcessor()
        {
            balance = 0;
        }
    }
}
