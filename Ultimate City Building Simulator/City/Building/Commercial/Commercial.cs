using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UltimateCityBuildingSimulator.City.Building.Commercial
{
    public abstract class Commercial : Building
    {
        public int Income { get; private set; }
    }
}
