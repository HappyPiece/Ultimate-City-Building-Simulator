using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UltimateCityBuildingSimulator.Game.Building.Commercial
{
    internal class Factory : Commercial
    {
        public Factory() : base()
        {
            Cost = 150;
            Income = 3;
        }
    }
}
