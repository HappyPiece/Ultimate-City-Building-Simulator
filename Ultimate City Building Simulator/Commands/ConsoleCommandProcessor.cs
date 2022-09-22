using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UltimateCityBuildingSimulator
{
    internal class ConsoleCommandProcessor
    {
        private readonly IEnumerable<IConsoleCommand> commands;

        public ConsoleCommandProcessor()
        {
            commands = new List<IConsoleCommand>();
        }

        public ConsoleCommandProcessor(IEnumerable<IConsoleCommand> commands)
        {
            this.commands = commands;
        }

        public CommandInfo ProcessInput(string inputValue)
        {
            string[] inputSplit = inputValue.Split(' ');
            string commandInput = inputSplit[0];
            string[] args = inputSplit.Skip(1).ToArray();

            return new CommandInfo(commandInput, args);
        }

        public void ProcessCommand(CommandInfo commandInfo)
        {
            foreach (var command in commands)
            {
                if (!commandInfo.Name.Equals(command.GetCommandName(), StringComparison.OrdinalIgnoreCase))
                {
                    continue;
                }

                if (command.Process(commandInfo.Arguments))
                {
                    return;
                }
            }
            Console.WriteLine("Unrecognised command " + commandInfo.Name);
        }
        public struct CommandInfo
        {
            public CommandInfo(string command, string[] args) { Name = command; Arguments = args; }
            public string Name;
            public string[] Arguments;
        }
    }
}