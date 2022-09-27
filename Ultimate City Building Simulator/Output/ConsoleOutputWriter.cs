using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UltimateCityBuildingSimulator.Utility;

namespace UltimateCityBuildingSimulator
{
    public class ConsoleOutputWriter : IOutputWriter
    {
        public ConsoleOutputWriter()
        {
            Console.OutputEncoding = Encoding.Unicode;
            SetFont("Cascadia Code", 25);
        }
        public void SetFont(string fontName, short fontSize)
        {
            ConsoleHelper.SetCurrentFont(fontName, fontSize);
        }
        public void Write<T>(T message)
        {
            Console.Write(message);
        }

        public void WriteLine<T>(T message)
        {
            Console.WriteLine(message);
        }
        public void ClearBuffer()
        {
            Console.Clear();
        }
    }
}
