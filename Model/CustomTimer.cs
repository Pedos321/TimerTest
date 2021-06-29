using System;
using System.Collections.Generic;
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
        #endregion

        #region Private methods
        #endregion

        #region Public methods
        #endregion





        #region Constructor
        public CustomTimer()
        {
            int hour,int minute, int second, 
        }
        #endregion
    }
}
