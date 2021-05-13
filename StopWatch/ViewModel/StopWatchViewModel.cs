

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TestWork.StopWatch.Module.Model;
using TimerTestApp.ViewModel;

namespace TestWork.StopWatch.Module.ViewModel
{
    public class StopWatchViewModel : ViewModelBase
    {
        private readonly ISimpleStopWatch _simpleStopWatch;

        #region Constructors
        public StopWatchViewModel(ISimpleStopWatch simpleStopWatch)
        {
            _simpleStopWatch = simpleStopWatch;

         




        }

        #endregion
        #region StartStopCommand
      
        #endregion

        #region Commands

        #region StartStopCommand

        public ICommand StartStopCommand { get; }

        private void OnStartStop()
        {
           
        }

        private bool CanStartStop()
        {
            return true;
        }

        #endregion

        #region ResetCommand

        public ICommand ResetCommand { get; }

        private void OnReset()
        { }

        private bool CanReset()
        { 
            return true;
        }

        #endregion



        #endregion
    }
}
