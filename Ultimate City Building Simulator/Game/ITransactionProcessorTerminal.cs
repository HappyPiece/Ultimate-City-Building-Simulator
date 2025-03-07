﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UltimateCityBuildingSimulator.Game.TransactionTypes;
using static UltimateCityBuildingSimulator.Game.TransactionProcessor;

namespace UltimateCityBuildingSimulator.Game
{
    public interface ITransactionProcessorTerminal
    {
        public bool AlterTransaction(int value);
        public bool SetTransaction(int value);
        public int GetTransaction();
        public bool EndSession();
    }
}
