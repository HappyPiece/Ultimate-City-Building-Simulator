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
        private Thread InputProcessingThread;
        private bool IsRunning;
        public ConsoleCommandManager(Application app)
        {
            InputReader = new ConsoleInputReader();
            InputProcessingThread = new Thread(Update);
            Commands = new List<ConsoleCommand>();

            //Initialise all commands
            Commands.Add(new Quit(app));
            Commands.Add(new Print());
            Commands.Add(new Show());

            //Feed to processor
            Processor = new ConsoleCommandProcessor(Commands);
            IsRunning = false;
        }
        ~ConsoleCommandManager()
        {
            InputProcessingThread.Join();
        }
        public void ProcessInput(string input)
        {
            CommandInfo commandInfo = Processor.ProcessInput(input);
            Processor.ProcessCommand(commandInfo);
        }

        public void StartCommandProcessing()
        {
            IsRunning = true;
            InputProcessingThread.Start();
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
