using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static UltimateCityBuildingSimulator.ConsoleCommandProcessor;

namespace UltimateCityBuildingSimulator.Commands.Manager
{
    internal class ConsoleCommandManager
    {
        private ConsoleCommandProcessor Processor;
        private List<ConsoleCommand> Commands;
        private IInputReader InputReader;
        private Thread Thread;
        private bool IsRunning;
        public ConsoleCommandManager(Application app)
        {
            InputReader = new ConsoleInputReader();
            Thread = new Thread(Update);
            Commands = new List<ConsoleCommand>();

            //Initialise all commands
            Commands.Add(new Quit(app));
            Commands.Add(new Print());

            //Feed to processor
            Processor = new ConsoleCommandProcessor(Commands);
            IsRunning = false;
        }
        ~ConsoleCommandManager()
        {
            Thread.Join();
        }
        public void ProcessInput(string input)
        {
            CommandInfo commandInfo = Processor.ProcessInput(input);
            Processor.ProcessCommand(commandInfo);
        }

        public void StartCommandProcessing()
        {
            IsRunning = true;
            Thread.Start();
        }
        public void StopCommandProcessing()
        {
            IsRunning = false;
        }
        private void Update()
        {
            while (IsRunning)
            {
                var input = InputReader.GetInput();
                if (input != String.Empty)
                {
                    ProcessInput(input);
                }
            }
        }

    }
}
