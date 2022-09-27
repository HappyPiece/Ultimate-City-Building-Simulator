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
        protected IOutputWriter Output { get { return ParentManager.Output; } }
        public ConsoleCommand(ConsoleCommandManager manager)
        {
            ParentManager = manager;
        }

        public string GetCommandName() { return CommandWord; }
        public string GetCommandHelp() { return Help; }

        public abstract bool Process(string[] args);
    }
}
