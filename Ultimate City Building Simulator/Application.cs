using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UltimateCityBuildingSimulator.Commands.Manager;
using UltimateCityBuildingSimulator.Game;

namespace UltimateCityBuildingSimulator
{
    public class Application
    {
        public Player Player { get; private set; }
        public City City { get; private set; }
        private bool IsRunning;
        private Thread UpdateThread;
        private ICommandManager CommandManager;
        private TimeManager Timer;
        private IOutputWriter Output;
        public Application()
        {
            CommandManager = new ConsoleCommandManager(this);
            Output = new ConsoleOutputWriter();
            Player = new Player();
            City = new City(Player);
            UpdateThread = new Thread(Update);
            Timer = new TimeManager();
        }
        public void Start()
        {
            IsRunning = true;
            CommandManager.StartCommandProcessing();
            UpdateThread.Start();
            Timer.Start();
        }

        public void Quit()
        {            
            IsRunning = false;
            CommandManager.StopCommandProcessing();
            UpdateThread.Join();
        }
        private void Update()
        {
            while (IsRunning)
            {
                City.UpdateCity(Timer.elapsed);
                Thread.Sleep(500);
                Timer.NewTick();
            }
        }
    }

}
