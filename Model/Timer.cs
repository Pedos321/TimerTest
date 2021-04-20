using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace TimerTestApp.Model
{
    public class Timer : ITimer
    {
        private readonly DispatcherTimer internalTimer = new DispatcherTimer();

        public event EventHandler<TimerModelEventArgs> Tick;
        public event EventHandler<TimerModelEventArgs> Started;
        public event EventHandler<TimerModelEventArgs> Stopped;
        public event EventHandler<TimerModelEventArgs> TimerReset;

        public Timer()
        {
            internalTimer.Interval = TimeSpan.FromSeconds(1);
            DefaultTimeValue = new TimeSpan(0, 0, 0);
            CreatedTime = DateTime.Now;
            Name = "Секундомер";
            Status = TimerStatus.Default;
            internalTimer.Tick += (sender, e) => OnDispatcherTimerTick();
        }

        public bool IsEnabled
        {
            get => internalTimer.IsEnabled;
            set => internalTimer.IsEnabled = value;
        }
        public TimeSpan Interval
        {
            get => internalTimer.Interval;
            set => internalTimer.Interval = value;
        }
        public TimerStatus Status { get; set; }

        public TimeSpan DefaultTimeValue { get; set; }
        public TimeSpan Duration { get; set; }
        public DateTime CreatedTime { get; set; }
        public string Name { get; set; }

        public void Start()
        {
            internalTimer.Start();
            OnStarted();
        }
        public void Stop()
        {
            internalTimer.Stop();
            OnStopped();
        }
        public void Reset()
        {
            Stop();
            Duration = DefaultTimeValue;
            OnReset();
        }
        private void OnDispatcherTimerTick()
        {
            Duration = Duration + Interval;
            OnTick();
        }
        private void OnTick()
        {
            Status = TimerStatus.Running;

            if (Tick != null)
            {
                Tick(this, new TimerModelEventArgs(Duration, DefaultTimeValue, TimerModelEventArgs.Status.Running));//ДЕРГАЕМ ВМ ДЛЯ ОБНОВЛЕНИЯ ДАННЫХ
            }
        }
        private void OnReset()
        {
            Status = TimerStatus.Default;
            if (TimerReset!=null)
            {
                TimerReset(this, new TimerModelEventArgs(Duration, DefaultTimeValue, TimerModelEventArgs.Status.Reset));
            }
        }
        private void OnStopped()
        {
            Status = TimerStatus.IsPaused;
            if (Stopped != null)
            {
                Stopped(this, new TimerModelEventArgs(Duration, DefaultTimeValue, TimerModelEventArgs.Status.Stopped));
            }
        }
        private void OnStarted()
        {
            Status = TimerStatus.Running;
            if (Started !=null)
            {
                Started(this, new TimerModelEventArgs(Duration, DefaultTimeValue, TimerModelEventArgs.Status.Started));
            }
        }
    }
}

