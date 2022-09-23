using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UltimateCityBuildingSimulator.Commands.Manager;

namespace UltimateCityBuildingSimulator.Commands
{
    internal class Quit : ConsoleCommand
    {
        public Quit(ConsoleCommandManager manager) : base(manager)
        {
            CommandWord = "quit";
            Help = "Use: quit - quits the application";
        }
        public override bool Process(string[] args)
        {
            if (args.Length != 0) return false;
            ParentManager.ParentApplication.Quit();
            return true;
        }
    }
}
