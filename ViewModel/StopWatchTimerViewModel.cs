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

        private CustomTimer _StopWatchTimer;

      

        #endregion

        #region Properties

        public RelayCommand StartCommand { get; private set; }

        public RelayCommand StopCommand { get; private set; }

        public RelayCommand ResetCommand { get; private set; }



        public CustomTimer StopWatchTimer
        {
            get { return _StopWatchTimer; }
            set { _StopWatchTimer = value; }
        }
        #endregion

        #region Commands
        #endregion

        #region Methods
        public  void StartCommandExecute(object parameter)
        {
            StopWatchTimer.Start();
            OnPropertyChanged("StopWatchTimer");
        }

        public bool StartCommandCanExecute(object parameter)
        {
            return true;
        }


        public void StopCommandExecute(object parameter)
        {
            StopWatchTimer.Stop();
            OnPropertyChanged("StopWatchTimer");

        }

        public bool StopCommandCanExecute(object parameter)
        {
            return true;
        }

        public void ResetCommandExecute(object parameter)
        {
            StopWatchTimer.Reset();
            OnPropertyChanged("StopWatchTimer");
        }

        public bool ResetCommandCanExecute(object parameter)
        {
            if (StopWatchTimer.State != TimerStates.Running)
            {
                return true;
            }
            else return false;
        }
        #endregion

        #region Events



        #endregion

        #region Constructor
        public StopWatchTimerViewModel()
        {
            StopWatchTimer = new CustomTimer(0, 0, 0, 1000);
            StartCommand = new RelayCommand(StartCommandExecute,StartCommandCanExecute);
            StopCommand = new RelayCommand(StopCommandExecute, StopCommandCanExecute);
            ResetCommand = new RelayCommand(ResetCommandExecute, ResetCommandCanExecute);
        }
        #endregion


    }
}
