using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimerTestApp.Model
{
    public abstract class CustomTimer
    {
        
        public enum TimerStates : byte {Stopped,Running,Paused };

        protected int _Hour = 0;
        protected int _Minute = 0;
        protected int _Second = 0;
        protected int _Interval = 1000;
        protected IPrimitiveTimer _Timer = null;
        protected TimerStates _State = TimerStates.Stopped;
        

        #region Public properties
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
}
