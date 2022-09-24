using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UltimateCityBuildingSimulator.Game.Building.Institutional
{
    internal class PoliceStation : Institutional
    {
        public PoliceStation() : base()
        {
            Cost = 70;
            SatisfactionValue = 20;
        }
    }
}
