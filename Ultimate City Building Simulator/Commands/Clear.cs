using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UltimateCityBuildingSimulator.Commands.Manager;

namespace UltimateCityBuildingSimulator.Commands
{
    public class Clear : ConsoleCommand
    {
        public Clear(ConsoleCommandManager manager) : base(manager)
        {
            CommandWord = "clear";
        }
        public override bool Process(string[] args)
        {
            Output.ClearBuffer();
            return true;
        }
    }
}
