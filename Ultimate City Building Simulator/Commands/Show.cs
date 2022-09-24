using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UltimateCityBuildingSimulator.Game.Building;
using UltimateCityBuildingSimulator.Utility;
using UltimateCityBuildingSimulator.Commands.Manager;
using static UltimateCityBuildingSimulator.Game.City;

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
                    Output.WriteLine(balance.ToString());
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
                    CityStatistics stats = app.City.GetCityStatistics();
                    Output.WriteLine("\nStatistics:");
                    Output.WriteLine($"{"Population:",-15}{stats.Population}/{stats.Capacity}");
                    Output.WriteLine($"{"Happiness:",-15}{stats.Happiness,-15}");
                    Output.WriteLine($"\nCity Buildings:");
                    Output.WriteLine($"{"Total:",-15}{stats.BuildingsTotal,-15}");
                    Output.WriteLine($"{"Commercial:",-15}{stats.BuildingsCommercial,-15}");
                    Output.WriteLine($"{"Institutional:",-15}{stats.BuildingsInstitutional,-15}");
                    Output.WriteLine($"{"Residential:",-15}{stats.BuildingsResidential,-15}\n");
                    Output.WriteLine($"{"Income:",-15}{stats.Income}/s");

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
