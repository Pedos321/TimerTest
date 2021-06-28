using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimerTestApp.Model
{
    public interface ITimer
    {
        TimeSpan DefaultTimeValue { get; set; }
        TimeSpan Duration { get; set; }
        TimeSpan Interval { get; set; }
        bool IsEnabled { get; set; }//???
        TimerStatus Status { get; set; }
        DateTime CreatedTime { get; set; }

        string Name { get; set; }

        int Count { get; set; }

        void Start();
        void Stop();
        void Reset();

        event EventHandler<TimerModelEventArgs> Tick;
        event EventHandler<TimerModelEventArgs> Started;
        event EventHandler<TimerModelEventArgs> Stopped;
        event EventHandler<TimerModelEventArgs> TimerReset;
    }

    public enum TimerStatus
    {
        Default,
        Running,
        IsPaused
    }
}
