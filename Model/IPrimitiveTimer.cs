using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimerTestApp.Model
{
    public interface IPrimitiveTimer
    {
        double Interval
        {
            get;
            set;
        }

        void Start();
        void Stop();

        event EventHandler Elapsed;
    }
}
