using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UltimateCityBuildingSimulator.Game
{
    internal class Player
    {
        private ITransactionProcessor PlayerTransactionProcessor = new TransactionProcessor();

        public ITransactionProcessor GetTransactionProcessor()
        {
            return PlayerTransactionProcessor;
        }
    }
}
