using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimerTestApp.Model
{
    public class StopWatchTimer : CustomTimer
    {

        #region Fields
        #endregion

        #region Properties
        #endregion

        #region Methods
        private void UpdateInternalTime()
        {

            long totalMilliseconds = Convert.ToInt64(timeElapsed.TotalMilliseconds);

            long totalTime = Convert.ToInt64(
                   (double)totalMilliseconds / (double)1000)
                   * 1000;



            _Second = (int)(totalTime % 60);
            totalTime = totalTime / 60;

            _Minute = (int)(totalTime % 60);
            totalTime = totalTime / 60;

            _Hour = (int)totalTime;
        }
        #endregion

        #region Events
        protected override void OnElapsed(EventArgs e)
        {
            UpdateInternalTime();
            base.OnElapsed(e);
        }
        #endregion

        #region Constructor

        public StopWatchTimer()
        {
            
        }
        #endregion
    }
}
