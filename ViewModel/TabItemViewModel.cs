using Prism.Commands;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using TimerTestApp.Model;
using TimerTestApp.Services;

namespace TimerTestApp.ViewModel
{
    public class TabItemViewModel : TabViewModelBase, ITabViewModel
    {  
        private readonly ITimerFactory _timerFactory;
        private readonly ITimer _timer;
        public TabItemViewModel(IEventAggregator eventAggregator, ITimerFactory timerFactory) : base(eventAggregator)
        {
            _timerFactory = timerFactory;
            _timer = timerFactory.CreateTimer();

            UpdateTimerValues();
            AddEventHandlers();
           
            StartStopCommand = new DelegateCommand(OnStartStop, CanStartStop);
            ResetCommand = new DelegateCommand(OnReset, CanReset);
        }

        private bool _IsRunning;
        public bool IsRunning
        {
            get => _IsRunning;
            set
            {
                _IsRunning = value;
                OnPropertyChanged();
                ((DelegateCommand)ResetCommand).RaiseCanExecuteChanged();
            }
        }

        private bool _IsPaused;
        public bool IsPaused
        {
            get => _IsPaused;
            set
            {
                _IsPaused = value;
                OnPropertyChanged();
                ((DelegateCommand)ResetCommand).RaiseCanExecuteChanged();
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
        public ICommand StartStopCommand { get; }
        private bool CanStartStop()
        {
            return true;
        }
        private void OnStartStop()
        {
            if (_timer.Status == TimerStatus.Default)
            {
                IsRunning = true;
                IsPaused = false;
                _timer.Start();
                base.IsEnable = false;
            }
            else if (_timer.Status == TimerStatus.IsPaused)
            {
                IsRunning = true;
                IsPaused = false;
                _timer.Start();
                base.IsEnable = false;
            }
            else
            {
                IsRunning = false;
                IsPaused = true;
                _timer.Stop();
                base.IsEnable = true;
            }
        }

        #endregion

        #region ResetCommand
        public ICommand ResetCommand { get; }

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
        public override void Load(int tabItemId)
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
            _timer.Tick += (sender, e) => OnTick(sender, e);
            _timer.Started += (sender, e) => OnStarted(sender, e);
            _timer.Stopped += (sender, e) => OnStopped(sender, e);
            _timer.TimerReset += (sender, e) => OnReset(sender, e);
        }
        private void OnReset(object sender, TimerModelEventArgs e)
        {
            UpdateTimer(e);
        }
        private void OnStopped(object sender, TimerModelEventArgs e)
        {
            UpdateTimer(e);
        }
        private void OnStarted(object sender, TimerModelEventArgs e)
        {
            UpdateTimer(e);
        }
        private void OnTick(object sender, TimerModelEventArgs e)
        {
            UpdateTimer(e);
        }
    }
}
