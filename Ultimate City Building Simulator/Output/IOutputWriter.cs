using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UltimateCityBuildingSimulator
{
    public interface IOutputWriter
    {
        void Write<T>(T message);
        void WriteLine<T>(T message);
        void ClearBuffer();
        //void Start();
        //void Stop();
    }
}
