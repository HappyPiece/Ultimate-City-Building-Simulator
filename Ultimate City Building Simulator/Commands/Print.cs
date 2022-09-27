using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UltimateCityBuildingSimulator.Commands.Manager;
using UltimateCityBuildingSimulator.Utility;

namespace UltimateCityBuildingSimulator.Commands
{
    internal class Print : ConsoleCommand
    {
        public Print(ConsoleCommandManager manager) : base(manager)
        {
            CommandWord = "print";
            Help = "Use: print [text] - prints text to console";
        }
        public override bool Process(string[] args)
        {
            if (args.Length <= 0) return false;
            if (args[0] == "amogus")
            {
                var seed = String.Join(" ", args.Skip(1));
                var mogus = ParentManager.AmogusManager.RetrieveAmogus(seed);
                Output.WriteLine(mogus);
                return true;
            }
            Output.WriteLine(String.Join(' ', args));
            return true;
        }
    }
}
