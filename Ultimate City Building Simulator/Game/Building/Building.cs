using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UltimateCityBuildingSimulator.Game.Building
{
    public abstract class Building : IBuildable
    {
        private int cost;

        public abstract void BuildSelf();

        public abstract bool CheckRequirement();

        public abstract void DemolishSelf();

        public int ProvideCost()
        {
            return cost;
        }
    }
}
