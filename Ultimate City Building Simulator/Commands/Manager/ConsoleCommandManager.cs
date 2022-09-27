using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static UltimateCityBuildingSimulator.ConsoleCommandProcessor;
using UltimateCityBuildingSimulator.Utility;

namespace UltimateCityBuildingSimulator.Commands.Manager
{
    public class ConsoleCommandManager : CommandManager
    {
        private ConsoleCommandProcessor Processor;        
        private Thread InputProcessingThread;
        private bool IsRunning;

        public ConsoleCommandManager(Application app)
        {
            InputReader = new ConsoleInputReader();
            InputProcessingThread = new Thread(Update);
            CatalogueParser = new BuildingCatalogueConsoleParser();
            ParentApplication = app;
            AmogusManager = new ConsoleAmogusManager();
            Output = new ConsoleOutputWriter();

            List<ConsoleCommand> Commands = new List<ConsoleCommand>();

            //Initialise all commands
            Commands.Add(new Quit(this));
            Commands.Add(new Print(this));
            Commands.Add(new Show(this));
            Commands.Add(new Build(this));
            Commands.Add(new Clear(this));
            Commands.Add(new Help(this));

            //Feed to processor
            Processor = new ConsoleCommandProcessor(Commands);
            IsRunning = false;
        }
        ~ConsoleCommandManager()
        {
            InputProcessingThread.Join();
        }        

        public override void ProcessInput(string input)
        {
            CommandInfo commandInfo = Processor.ProcessInput(input);
            Processor.ProcessCommand(commandInfo);
        }

        public override void StartCommandProcessing()
        {
            IsRunning = true;
            InputProcessingThread.Start();
        }
        public override void StopCommandProcessing()
        {
            IsRunning = false;
        }
        public IEnumerable<ICommand> GetCommands()
        {
            return Processor.GetAvailableCommands();
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
