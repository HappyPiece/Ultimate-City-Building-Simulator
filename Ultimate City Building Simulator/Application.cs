using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UltimateCityBuildingSimulator.Game;
using static UltimateCityBuildingSimulator.ConsoleCommandProcessor;

namespace UltimateCityBuildingSimulator
{
    internal class Application
    {
        private bool IsRunning;
        private Thread Thread;
        private ConsoleCommandProcessor Processor;
        private IInputReader InputReader;
        private City City;
        private Player Player;
        public Application()
        {
            Thread = new Thread(Update);
            Processor = new ConsoleCommandProcessor();
            InputReader = new ConsoleInputReader();
            Player = new Player();
            City = new City(Player);
        }
        private void Update()
        {
            while (IsRunning)
            {
                var input = InputReader.GetInput();
                CommandInfo commandInfo = Processor.ProcessInput(input);
                Processor.ProcessCommand(commandInfo);
            }
        }

        public void Start()
        {
            IsRunning = true;
            Thread.Start();
        }
    }

}
