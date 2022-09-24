using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UltimateCityBuildingSimulator.Game.Building.Institutional
{
    public abstract class Institutional: Building
    {
        public int SatisfactionValue { get; protected set; }
    }
}
