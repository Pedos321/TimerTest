using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestWork.StopWatch.Module.Model
{
    public interface ISimpleStopWatch
    {
        double Interval
        {
            get;
            set;
        }






        void Start();
        void Stop();

        void Reset();

        void Pause();

        event EventHandler Elapsed;
    }
}
