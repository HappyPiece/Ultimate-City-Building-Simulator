using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UltimateCityBuildingSimulator.Commands.Manager;

namespace UltimateCityBuildingSimulator
{
    internal class Application
    {
        private bool IsRunning;
        ConsoleCommandManager ConsoleManager;
        public Application()
        {
            ConsoleManager = new ConsoleCommandManager(this);
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
