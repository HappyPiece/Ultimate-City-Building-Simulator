using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UltimateCityBuildingSimulator.Commands.Manager;

namespace UltimateCityBuildingSimulator
{
    public abstract class ConsoleCommand : IConsoleCommand
    {
        protected string CommandWord = string.Empty;
        protected string Help = string.Empty;
        protected ConsoleCommandManager ParentManager;
        public ConsoleCommand(ConsoleCommandManager manager)
        {
            ParentManager = manager;
        }

        public string GetCommandName() { return CommandWord; }
        public string GetCommandHelp() { return Help + "\n"; }

        public abstract bool Process(string[] args);
    }
}
