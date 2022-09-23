using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UltimateCityBuildingSimulator.Commands.Manager
{
    internal interface ICommandManager
    {
        public void ProcessInput(string input);
        public void StartCommandProcessing();
        public void StopCommandProcessing();
    }
}
