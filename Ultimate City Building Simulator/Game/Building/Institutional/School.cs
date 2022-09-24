using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UltimateCityBuildingSimulator.Game.Building.Institutional
{
    internal class School : Institutional
    {
        public School() : base()
        {
            Cost = 170;
            SatisfactionValue = 40;
        }
    }
}
