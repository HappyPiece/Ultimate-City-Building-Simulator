using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UltimateCityBuildingSimulator.City.Building.Residential
{
    public abstract class Residential : Building
    {
        public int Capacity { get; private set; }
    }
}
