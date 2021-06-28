
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using TimerTestApp.Commands;
using TimerTestApp.Model;

namespace TimerTestApp.ViewModel
{
    public class TabItemViewModel : ViewModelBase, ITabViewModel
    {  
      
        private readonly ITimer _timer;
        public TabItemViewModel() 
        {

            StartStopCommand = new RelayCommand<>(OnStartStop, CanStartStop);
            ResetCommand = new RelayCommand<>(OnReset, CanReset);
            UpdateTimerValues();
            AddEventHandlers();
        }

        public int Id => throw new NotImplementedException();

        public bool IsEnable => throw new NotImplementedException();

        private bool _IsRunning;
        public bool IsRunning
        {
            get => _IsRunning;
            set
            {
                _IsRunning = value;
                OnPropertyChanged();
            }
        }

        public int Count;
        public string Title;

        private bool _IsPaused;
        public bool IsPaused
        {
            get => _IsPaused;
            set
            {
                _IsPaused = value;
                OnPropertyChanged();
            }
        }

        private string timerValue;
        public string TimerValue
        {
            get
            {
                return timerValue;
            }

            set
            {
                if (timerValue != value)
                {
                    timerValue = value;
                    OnPropertyChanged();
                }
            }
        }

        #region StartStopCommand

        private ICommand startStopCommand;
        public ICommand StartStopCommand
        {
            get { return startStopCommand; }
            set { startStopCommand = value; }
        }
        private bool CanStartStop()
        {
            return true;
        }
        public void OnStartStop()
        {
            if (_timer.Status == TimerStatus.Default)
            {
                IsRunning = true;
                IsPaused = false;
                _timer.Start();
            }
            else if (_timer.Status == TimerStatus.IsPaused)
            {
                IsRunning = true;
                IsPaused = false;
                _timer.Start();
            }
            else
            {
                IsRunning = false;
                IsPaused = true;
                _timer.Stop();
            }
        }

        #endregion

        #region ResetCommand

        private ICommand resetCommand;
        public ICommand ResetCommand
        {
            get{ return resetCommand; }
            set{ resetCommand = value; }
        }


        private void OnReset()
        {
            _timer.Reset();
            IsPaused = false;
            UpdateTimerValues();
        }
        private bool CanReset()
        {
            return IsPaused;
        }

        #endregion

        private void UpdateTimer(TimerModelEventArgs e)
        {
            UpdateTimerValues();
        }
        private void UpdateTimerValues()
        {
            TimeSpan t = _timer.Duration;
            TimerValue = string.Format("{0}:{1}:{2}", t.Hours.ToString("D2"),
                t.Minutes.ToString("D2"), t.Seconds.ToString("D2"));
        }
        public  void Load(int tabItemId)
        {
            var tabitem = CreateTabItem();

            Id = tabItemId;

            tabitem.Id = tabItemId;
            InitTabItem(tabitem);
        }
        private Model.TabItem CreateTabItem()
        {
            var tabitem = new Model.TabItem();
            return tabitem;
        }
        private void InitTabItem(Model.TabItem tabItem)
        {
            SetTitle();
        }
        private void SetTitle()
        {
            Title = string.Format("{0} {1} {2:HH:mm}", _timer.Name, Id, _timer.CreatedTime);
        }
        private void AddEventHandlers()
        {
            _timer.Tick += (sender, e) => UpdateTimer(e);
            _timer.Started += (sender, e) => UpdateTimer(e);
            _timer.Stopped += (sender, e) => UpdateTimer(e);
            _timer.TimerReset += (sender, e) => UpdateTimer(e);
        }
    }
}
