using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UltimateCityBuildingSimulator
{
    internal interface  IBuildable
    {
        bool checkRequirement();
        bool buildSelf();
        bool demolishSelf();
        bool provideCost();
    }
}
