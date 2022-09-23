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
        protected float Multiplier;

        public int ProvideCost()
        {
            return Cost;
        }
        public float ProvideMultiplier()
        {
            return Multiplier;
        }
        public object Clone()
        {
            return this.MemberwiseClone();
        }

        public Building()
        {
            Multiplier = 1.75F;
        }

    }
}
