using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UltimateCityBuildingSimulator.Game.TransactionTypes
{
    public class Transaction: ITransaction
    {
        private int Value;
        public int getValue()
        {
            return Value;
        }

        public Transaction(int value)
        {
            Value = value;
        }
        public Transaction()
        {
            Value = 0;
        }
    }
}
