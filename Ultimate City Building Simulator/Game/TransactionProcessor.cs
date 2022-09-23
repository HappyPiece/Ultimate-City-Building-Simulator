using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UltimateCityBuildingSimulator.Game.TransactionTypes;

namespace UltimateCityBuildingSimulator.Game
{
    public class TransactionProcessor : ITransactionProcessor
    {
        private Dictionary<Guid, int> TerminalsPermissions;

        private enum Permissions
        {
            GET = 1,
            SET = 2,
            ALTER = 4
        }
        public enum TransactionState
        {
            OPERATION_SUCCESSFUL = 1,
            INTERNAL_ERROR = -1,
            ACCESS_DENIED = 2
        }
        private int balance;
        public void PerformTransaction(Transaction transaction, out TransactionState state, out int value)
        {
            value = -1;
            state = TransactionState.INTERNAL_ERROR;
            if (!TerminalsPermissions.ContainsKey(transaction.TerminalGuid))
            {
                return;
            }
            switch (transaction)
            {
                case SetBalanceTransaction:
                    if ((TerminalsPermissions[transaction.TerminalGuid] & (int)Permissions.SET) != 0)
                    {
                        balance = transaction.Value;
                        state = TransactionState.OPERATION_SUCCESSFUL;
                    }
                    else
                    {
                        state = TransactionState.ACCESS_DENIED;
                    }
                    break;
                case AlterBalanceTransaction:
                    if ((TerminalsPermissions[transaction.TerminalGuid] & (int)Permissions.ALTER) != 0)
                    {
                        if (balance + transaction.Value >= 0)
                        {
                            balance += transaction.Value;
                            state = TransactionState.OPERATION_SUCCESSFUL;
                        }
                        else
                        {
                            state = TransactionState.INTERNAL_ERROR;
                        }
                    }
                    else
                    {
                        state = TransactionState.ACCESS_DENIED;
                    }
                    break;
                case GetBalanceTransaction:
                    if ((TerminalsPermissions[transaction.TerminalGuid] & (int)Permissions.GET) != 0)
                    {
                        value = balance;
                        state = TransactionState.OPERATION_SUCCESSFUL;
                    }
                    else
                    {
                        state = TransactionState.ACCESS_DENIED;
                    }
                    break;
                case EndSessionTransaction:
                    TerminalsPermissions.Remove(transaction.TerminalGuid);
                    state = TransactionState.OPERATION_SUCCESSFUL;
                    break;
            }
            return;
        }

        public ITransactionProcessorTerminal GetTransactionProcessorTerminal()
        {
            TransactionProcessorTerminal NewTransactionProcessorTerminal = new TransactionProcessorTerminal(this, Guid.NewGuid());
            TerminalsPermissions.Add(NewTransactionProcessorTerminal.Guid, (int)(Permissions.GET | Permissions.SET | Permissions.ALTER));
            return NewTransactionProcessorTerminal;
        }

        public TransactionProcessor()
        {
            balance = 30;
            TerminalsPermissions = new Dictionary<Guid, int>();
        }
    }
}
