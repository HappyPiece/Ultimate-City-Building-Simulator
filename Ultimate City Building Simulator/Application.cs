using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UltimateCityBuildingSimulator.Commands.Manager;
using UltimateCityBuildingSimulator.Game;

namespace UltimateCityBuildingSimulator
{
    public class Application
    {
        private bool IsRunning;
        private Thread UpdateThread;
        public Player Player { get; private set; }
        public City City { get; private set; }
        ICommandManager CommandManager;
        public Application()
        {
            CommandManager = new ConsoleCommandManager(this);
            Player = new Player();
            City = new City(Player);
            UpdateThread = new Thread(Update);
        }
        public void Start()
        {
            IsRunning = true;
            CommandManager.StartCommandProcessing();
            UpdateThread.Start();
        }

        public void Quit()
        {
            Console.WriteLine("Quitting");
            IsRunning = false;
            CommandManager.StopCommandProcessing();
            UpdateThread.Join();
        }
        private void Update()
        {
            while (IsRunning)
            {
                //City.Update();
                Thread.Sleep(500);
            }
        }
    }

}
