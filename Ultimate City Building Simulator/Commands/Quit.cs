using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UltimateCityBuildingSimulator.Commands
{
    internal class Quit : ConsoleCommand
    {
        Application application;
        public Quit(Application app)
        {
            commandWord = "quit";
            help = "Use: quit - quits the application";
            application = app;
        }
        public override bool Process(string[] args)
        {
            if (args.Length != 0) return false;
            application.Quit();
            return true;
        }
    }
}
