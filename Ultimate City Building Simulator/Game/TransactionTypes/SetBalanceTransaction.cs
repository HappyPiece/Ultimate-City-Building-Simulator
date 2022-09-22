using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UltimateCityBuildingSimulator.Game.TransactionTypes
{
    internal class SetBalanceTransaction: Transaction
    {
        public SetBalanceTransaction(int value)
        {
            Value = value;
        }
    }
}
