using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UltimateCityBuildingSimulator.Game.Building
{
    internal interface IBuildable
    {
        bool CheckRequirement();
        void BuildSelf();
        void DemolishSelf();
        int ProvideCost();
    }
}
