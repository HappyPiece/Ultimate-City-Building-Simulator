using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UltimateCityBuildingSimulator
{
    public class TimeManager
    {
        private Stopwatch stopwatch;
        public double elapsed { get { return stopwatch.Elapsed.TotalSeconds; } }
        public TimeManager()
        {
            stopwatch = new Stopwatch();
            stopwatch.Reset();
        }
        public void Start()
        {
            stopwatch.Start();
        }
        public void NewTick()
        {
            stopwatch.Restart();
        }
    }
}
