using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UltimateCityBuildingSimulator
{
    public abstract class ConsoleCommand : IConsoleCommand
    {
        protected string commandWord = string.Empty;
        protected string help = string.Empty;
        public string GetCommandName() { return commandWord; }
        public string GetCommandHelp() { return help + "\n"; }

        public abstract bool Process(string[] args);
    }
}
