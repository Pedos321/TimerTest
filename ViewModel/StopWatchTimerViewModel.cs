using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using TimerTestApp.Commands;
using TimerTestApp.Model;
using static TimerTestApp.Model.CustomTimer;

namespace TimerTestApp.ViewModel
{
    public class StopWatchTimerViewModel : ViewModelBase
    {

        #region Fields

        private CustomTimer StopWatchTimer = new CustomTimer(0, 0, 0, 1000);

        private TimerStates _CurTimerState;

        #endregion

        #region Properties

        public RelayCommand StartCommand { get; private set; }

        public RelayCommand StopCommand { get; private set; }

        public RelayCommand ResetCommand { get; private set; }


        public TimerStates CurrentTimerState
        {
            get { return StopWatchTimer.State; }
        }

        #endregion

        #region Commands
        #endregion

        #region Methods
        private void StartCommandExecute(object parameter)
        { }

        private bool StartCommandCanExecute(object parameter)
        {
            return true;
        }


        private void StopCommandExecute()
        { }

        private void ResetCommandExecute()
        { }
        #endregion

        #region Events



        #endregion

        #region Constructor
        public StopWatchTimerViewModel()
        {
            StartCommand = new RelayCommand(StartCommandExecute,StartCommandCanExecute);
        }
        #endregion


    }
}
