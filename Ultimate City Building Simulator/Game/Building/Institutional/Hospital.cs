﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UltimateCityBuildingSimulator.Game.Building.Institutional
{
    internal class Hospital : Institutional
    {
        public Hospital() : base()
        {
            Cost = 270;
            SatisfactionValue = 65;
        }
    }
}
