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
                    Output.WriteLine(balance);
                    break;
                case "map":
                    if (app.City.GetBuildings().Count() > 0)
                    {
                        foreach (var building in app.City.GetBuildings())
                            Output.WriteLine(building.GetType().Name.ToString().ToLower());
                    }
                    else
                    {
                        Output.WriteLine("There are no building in the City");
                    }
                    break;
                case "stats":
                    Output.WriteLine("Stats");
                    break;
                case "catalogue":
                    var catalogue = app.City.GetAvailableBuildings();
                    Output.WriteLine(ParentManager.CatalogueParser.Parse(catalogue));
                    break;
                default: return false;
            }
            return true;
        }
    }
}
