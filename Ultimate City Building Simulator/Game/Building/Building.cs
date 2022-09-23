using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UltimateCityBuildingSimulator.Game.Building
{
    public abstract class Building : IBuildable
    {
        protected int Cost;
        protected int Multiplier;

        public int ProvideCost()
        {
            return Cost;
        }
        public int ProvideMultiplier()
        {
            return Multiplier;
        }

    }
}
