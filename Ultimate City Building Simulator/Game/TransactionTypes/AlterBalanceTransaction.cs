using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UltimateCityBuildingSimulator.Game.TransactionTypes
{
    internal class AlterBalanceTransaction : Transaction
    {
        public AlterBalanceTransaction(int value)
        {
            Value = value;
        }
    }
}
