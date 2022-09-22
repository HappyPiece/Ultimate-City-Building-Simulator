using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UltimateCityBuildingSimulator.Commands
{
    internal class Print : ConsoleCommand
    {
        public Print()
        {
            commandWord = "print";
            help = "print [text] - prints text to console";
        }
        public override bool Process(string[] args)
        {
            if (args.Length <= 0) return false;
            Console.WriteLine(String.Join(' ', args));
            return true;
        }
    }
}
