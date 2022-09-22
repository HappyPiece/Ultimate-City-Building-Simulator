using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UltimateCityBuildingSimulator.Commands.Manager;
using UltimateCityBuildingSimulator.Game;

namespace UltimateCityBuildingSimulator
{
    internal class Application
    {
        private bool IsRunning;
        public Player Player { get; private set; }
        public City City { get; private set; }
        ConsoleCommandManager ConsoleManager;
        public Application()
        {
            ConsoleManager = new ConsoleCommandManager(this);
            Player = new Player();
            City = new City(Player);
        }
        public void Start()
        {
            IsRunning = true;
            ConsoleManager.StartCommandProcessing();
            Update();
        }

        public void Quit()
        {
            Console.WriteLine("Quitting");
            IsRunning = false;
            ConsoleManager.StopCommandProcessing();
        }
        private void Update()
        {
            while (IsRunning)
            {
                //City.Update();
                Thread.Sleep(1000);
            }
        }
    }

}
