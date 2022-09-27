using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UltimateCityBuildingSimulator.Commands.Manager;

namespace UltimateCityBuildingSimulator.Commands
{
    internal class Help : ConsoleCommand
    {
        public Help(ConsoleCommandManager manager) : base(manager)
        {
            CommandWord = "help";
            Help = "Use: help [command] - Shows each command's help prompt";
        }
        public override bool Process(string[] args)
        {
            var commands = ParentManager.GetCommands();
            foreach (var command in commands)
            {
                if (args.Length == 1 && args[0] != command.GetCommandName())
                {
                    continue;
                }
                Output.WriteLine(command.GetCommandHelp());
            }
            return true;
        }
    }
}
