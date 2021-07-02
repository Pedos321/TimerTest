using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimerTestApp.Model
{
    public class CustomTimer
    {
        private int _Hour = 0;
        private int _Minute = 0;
        private int _Second = 0;
        private int _Interval = 1000;
        private int _TickCount = 0;
        private IPrimitiveTimer _Timer = null;
        private TimerStates _State = TimerStates.Stopped;

        
        #region Public properties

        public int TickCount
        {
            get { return _TickCount; }
            set { _TickCount = value; }
        }

        public int Hour
        {
            get { return _Hour; }
            set { _Hour = value; }
        }

        public int Minute
        {
            get { return _Minute; }
            set { _Minute = value; }
        }

        public int Second
        {
            get { return _Second; }
            set { _Second = value; }
        }

        public int Interval
        {
            get { return _Interval; }
            set
            {
                if (value < 1)
                {
                    throw new Exception(string.Format(
                        "Invalid CustomTimer interval {0}, must be positive",
                        value));
                }
                _Interval = value;
                UpdateTimerProperty();
            }
        }

        public TimerStates State
        {
            get { return _State; }
            set
            {
                _State = value;
                var e = new EventArgs();
                OnStateChanged(e);
            }
        }
        #endregion

        #region Private methods

        private void UpdateTimerProperty()
        {
            if (_Timer == null)
                return;
            _Timer.Interval = _Interval;
        }


        private IPrimitiveTimer CreateTimer()
        {
            return new MyTimer();
        }

        #endregion

        #region Public methods

        public virtual void Reset()
        {
            Hour = 0;
            Minute = 0;
            Second = 0;
            TickCount = 0;
        }

        public virtual void Start()
        {
            if (State != TimerStates.Running)
            {
                _Timer = CreateTimer();
                _Timer.Elapsed += TimerElapsed;

                UpdateTimerProperty();

                _Timer.Start();

             
                if (State != TimerStates.Paused)
                State = TimerStates.Running;
            }
        }

        public virtual void Pause()
        {
            if (_Timer != null)
                _Timer.Stop();
            State = TimerStates.Paused;
        }

        public virtual void Stop()
        {
            if (_Timer != null)
                _Timer.Stop();
            State = TimerStates.Stopped;
            Reset();
        }

        #endregion

        #region Events
        public event EventHandler Elapsed;
        protected virtual void OnElapsed(EventArgs e)
        {
            TickCount++;
        }


        public event EventHandler StateChanged;
        protected virtual void OnStateChanged(EventArgs e)
        {
           
        }
        #endregion

        #region Event Handler
        private void TimerElapsed(object sender, EventArgs e)
        {
            OnElapsed(new EventArgs());
        }
        #endregion

        #region Constructor
        public CustomTimer(int hour, int minute, int second, int interval)
        {
            Hour = hour;
            Minute = minute;
            Second = second;
            Interval = interval;
           
        }
        #endregion
    }

    public enum TimerStates : int { Stopped, Running, Paused };
}
