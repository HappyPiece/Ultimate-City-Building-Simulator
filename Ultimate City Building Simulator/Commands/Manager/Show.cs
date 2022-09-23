using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UltimateCityBuildingSimulator.Commands.Manager
{
    internal class Show : ConsoleCommand
    {
        public Show()
        {
            commandWord = "show";
            help = "Use: show [balance|map|stats]";            
        }
        public override bool Process(string[] args)
        {
            if (args.Length <= 0) return false;
            switch (args[0])
            {
                case "balance":
                    Console.WriteLine("Balance");
                    break;
                case "map":
                    Console.WriteLine("Map Showcase Not Implemented Yet");
                    break;
                case "stats":
                    Console.WriteLine("Stats");
                    break;
                default: return false;
            }
            return true;
        }
    }
}
