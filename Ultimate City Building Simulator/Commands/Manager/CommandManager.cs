using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UltimateCityBuildingSimulator.Utility;

namespace UltimateCityBuildingSimulator.Commands.Manager
{
    public abstract class CommandManager : ICommandManager
    {
        public IBuildingCatalogueParser CatalogueParser { get; protected set; }
        public Application ParentApplication { get; protected set; }
        public IOutputWriter Output { get; protected set; }
        public abstract void ProcessInput(string input);
        public abstract void StartCommandProcessing();
        public abstract void StopCommandProcessing();
    }
}
