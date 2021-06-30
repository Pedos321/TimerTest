using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimerTestApp.Model;

namespace TimerTestApp.ViewModel
{
    public class StopWatchTimerViewModel : ViewModelBase
    {

        #region Fields
        #endregion

        #region Properties
        #endregion

        #region Commands
        #endregion

        #region Methods
        private StopWatchTimer _StopWatch = new StopWatchTimer();

        private void Init()
        {
            _StopWatch.Elapsed += new
                EventHandler(_StopWatch_Elapsed);

            _StopWatch.StateChanged += new
                EventHandler(_StopWatch_StateChanged);
        }
        #endregion

        #region Events
        private void _StopWatch_Elapsed(
         object sender, EventArgs e)
        {
          
        }

        private void _StopWatch_StateChanged(object sender, EventArgs e)
        {
            
        }
        #endregion

        #region Constructor
        #endregion


    }
}
