using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UltimateCityBuildingSimulator.Game.TransactionTypes
{
    internal class EndSessionTransaction : Transaction
    {
        public EndSessionTransaction(Guid guid, int value = 0) : base(guid, value) { }
    }
}
