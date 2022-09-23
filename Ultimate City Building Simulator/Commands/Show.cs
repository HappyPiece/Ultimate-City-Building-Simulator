using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UltimateCityBuildingSimulator.Game.Building;
using UltimateCityBuildingSimulator.Utility;
using UltimateCityBuildingSimulator.Commands.Manager;

namespace UltimateCityBuildingSimulator.Commands.Manager
{
    internal class Show : ConsoleCommand
    {
        public Show(ConsoleCommandManager manager) : base(manager)
        {
            CommandWord = "show";
            Help = "Use: show [balance|map|stats|catalogue]";
        }
        public override bool Process(string[] args)
        {
            if (args.Length <= 0) return false;

            Application app = ParentManager.ParentApplication;
            switch (args[0])
            {
                case "balance":
                    var playerTerminal = app.Player.GetTransactionProcessor().GetTransactionProcessorTerminal();
                    var balance = playerTerminal.GetTransaction();
                    Console.WriteLine(balance);
                    break;
                case "map":
                    Console.WriteLine("Map Showcase Not Implemented Yet");
                    break;
                case "stats":
                    Console.WriteLine("Stats");
                    break;
                case "catalogue":
                    var catalogue = app.City.GetAvailableBuildings();
                    Console.WriteLine(ParentManager.CatalogueParser.Parse(catalogue));
                    break;
                default: return false;
            }
            return true;
        }
    }
}
