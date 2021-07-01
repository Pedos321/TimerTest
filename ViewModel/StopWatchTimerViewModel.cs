using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TimerTestApp.Model;

namespace TimerTestApp.ViewModel
{
    public class StopWatchTimerViewModel : ViewModelBase
    {

        #region Fields

        private CustomTimer StopWatchTimer = new CustomTimer(0, 0, 0, 1000);

        private ICommand StartCommand;

        private ICommand StopCommand;

        private ICommand ResetCommand;

        #endregion

        #region Properties


        #endregion

        #region Commands
        #endregion

        #region Methods

        #endregion

        #region Events



        #endregion

        #region Constructor
        public StopWatchTimerViewModel()
        {
            
        }
        #endregion


    }
}
