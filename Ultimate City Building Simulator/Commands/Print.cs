using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UltimateCityBuildingSimulator.Commands.Manager;

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
            Output.WriteLine(String.Join(' ', args));
            return true;
        }
    }
}
