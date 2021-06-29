using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;

namespace TimerTestApp.Model
{
   public  class MyTimer : IPrimitiveTimer
    {
        private System.Timers.Timer _timer = new System.Timers.Timer();

        public double Interval
        {
            get
            {
                return _timer.Interval;
            }
            set
            {
                _timer.Interval = value;
            }
        }

        public virtual void Start()
        {
            _timer.Start();
        }

        public virtual void Stop()
        {
            _timer.Stop();
        }

        #region EventHandler

        private int _Timer_ElapsedRunning = 0;
        public event EventHandler Elapsed;
        protected virtual void OnElapsed(EventArgs e)
        {
            Elapsed(this, e);
        }

        public void _Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (Interlocked.Exchange(ref _Timer_ElapsedRunning, 1) == 0)
            {
                OnElapsed(new EventArgs());
                Interlocked.Exchange(ref _Timer_ElapsedRunning, 0);
            }
        }

        #endregion

        public MyTimer()
        {
            _timer.Elapsed += new ElapsedEventHandler(_Timer_Elapsed);
        }
    }
}
