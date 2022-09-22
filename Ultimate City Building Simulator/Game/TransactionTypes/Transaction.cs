using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UltimateCityBuildingSimulator.Game.TransactionTypes
{
    public class Transaction
    {
        public int Value { get; protected set; }
        public Guid TerminalGuid { get; private set; }
        public int GetValue()
        {
            return Value;
        }

        public Guid GetTerminalGuid()
        {
            return TerminalGuid;
        }

        public Transaction(Guid guid, int value = 0)
        {
            TerminalGuid = guid;
            Value = value;
        }
    }
}
