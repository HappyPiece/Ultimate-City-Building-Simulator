using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UltimateCityBuildingSimulator
{
    public class ConsoleOutputWriter : IOutputWriter
    {
        public void Write<T>(T message)
        {
            Console.Write(message);
        }

        public void WriteLine<T>(T message)
        {
            Console.WriteLine(message);
        }
    }
}
