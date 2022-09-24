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
            Help = "print [text] - prints text to console";
        }
        public override bool Process(string[] args)
        {
            if (args.Length <= 0) return false;
            if (args.Length == 1 && args[0] == "amogus")
            {
                Output.WriteLine(AmogusManager.bigMogus);
                return true;
            }
            else if (args.Length == 2 && args[0] == "amogus" && args[1] == "sus")
            {
                Output.WriteLine(AmogusManager.susMogus);
                return true;
            }
            Output.WriteLine(String.Join(' ', args));
            return true;
        }
    }
}
