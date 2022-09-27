using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UltimateCityBuildingSimulator.Utility
{
    public abstract class AmogusManager : IAmogusManager
    {
        public abstract string RetrieveAmogus(string seed);
        protected Dictionary<string, string> AmogusVariants;
        public AmogusManager()
        {
            AmogusVariants = new Dictionary<string,string>();
        }        
    }
}
