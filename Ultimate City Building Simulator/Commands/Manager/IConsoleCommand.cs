using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UltimateCityBuildingSimulator
{
    internal interface IConsoleCommand
    {
        string GetCommandName();
        string GetCommandHelp();
        bool Process(string[] args);
    }
}
