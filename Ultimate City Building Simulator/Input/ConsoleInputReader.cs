using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UltimateCityBuildingSimulator
{
    internal class ConsoleInputReader: IInputReader
    {
        public string GetInput()
        {
            return Console.ReadLine() ?? "";
        }
    }
}
