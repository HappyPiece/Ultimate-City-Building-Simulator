using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UltimateCityBuildingSimulator
{
    internal class ConsoleCommandProcessor
    {
        private readonly IEnumerable<ICommand> Commands;

        public ConsoleCommandProcessor(IEnumerable<ICommand> commands)
        {
            this.Commands = commands;
        }

        public CommandInfo ProcessInput(string inputValue)
        {
            string[] inputSplit = inputValue.TrimEnd().Split(' ');
            string commandInput = inputSplit[0];
            string[] args = inputSplit.Skip(1).ToArray();
            return new CommandInfo(commandInput, args);
        }

        public void ProcessCommand(CommandInfo commandInfo)
        {
            foreach (var command in Commands)
            {
                //Console.WriteLine(command.GetCommandName() + " " + commandInfo.Name);
                if (!commandInfo.Name.Equals(command.GetCommandName(), StringComparison.OrdinalIgnoreCase))
                {
                    continue;
                }

                if (!command.Process(commandInfo.Arguments))
                {
                    Console.WriteLine(command.GetCommandHelp());
                }

                return;
            }
            Console.WriteLine("Unrecognised command " + commandInfo.Name);
        }
        public IEnumerable<ICommand> GetAvailableCommands()
        {
            return Commands;
        }
        public struct CommandInfo
        {
            public CommandInfo(string command, string[] args) { Name = command; Arguments = args; }
            public string Name;
            public string[] Arguments;
            //public DateTime Time;
        }
    }
}