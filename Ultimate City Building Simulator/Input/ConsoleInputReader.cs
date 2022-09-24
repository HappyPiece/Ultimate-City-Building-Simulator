using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UltimateCityBuildingSimulator
{
    internal class ConsoleInputReader : IInputReader
    {
        private string Input = String.Empty;
        //private bool IsRead = false;
        //private bool IsRunning;

        //~ConsoleInputReader()
        //{
        //    IsRunning = false;
        //}
        public string GetInput()
        {
            return Console.ReadLine() ?? "";
        }

        //public string GetInputIfNotRead()
        //{
        //    if (IsRead) return String.Empty;

        //    IsRead = true;
        //    return Input;
        //}

        //private void ConsoleInputUpdate()
        //{
        //    while (IsRunning)
        //    {
        //        if (!IsRead) continue;
        //        Input = Console.ReadLine() ?? "";
        //        IsRead = false;
        //    }
        //}
    }
}
