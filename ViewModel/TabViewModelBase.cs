using Prism.Commands;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TimerTestApp.Events;
using TimerTestApp.Services;

namespace TimerTestApp.ViewModel
{
    public abstract class TabViewModelBase : ViewModelBase, ITabViewModel
    {

        private readonly IEventAggregator EventAggregator;
        protected readonly IMessageDialogService MessageDialogService;

        public TabViewModelBase(IEventAggregator eventAggregator, IMessageDialogService messageDialogService)
        {
            EventAggregator = eventAggregator;
            MessageDialogService = messageDialogService;
            CloseTabViewCommand = new DelegateCommand(OnCloseTabViewExecute, OnCloseTabViewCanExecute);
            IsEnable = true;
        }
        public ICommand CloseTabViewCommand { get; }

        private int _id;
        public int Id
        {
            get { return _id; }
            protected set { _id = value; }
        }

        private string _title;
        public string Title
        {
            get { return _title; }
            set { _title = value; OnPropertyChanged(); }
        }

        private DateTime _createTab;
        public DateTime CreateTab
        {
            get { return _createTab; }
            set { _createTab = value;OnPropertyChanged(); }
        }

        private bool _isEnable;
        public bool IsEnable
        {
            get { return _isEnable; }
            set
            {
                if (_isEnable != value)
                {
                    _isEnable = value;
                    OnPropertyChanged();
                    ((DelegateCommand)CloseTabViewCommand).RaiseCanExecuteChanged();
                }
            }
        }
        protected virtual void OnCloseTabViewExecute()
        {
            EventAggregator.GetEvent<TabViewClosedEvent>()
                .Publish(new TabViewClosedEventArgs
                {
                    Id = this.Id,
                    ViewModelName = this.GetType().Name
                }
                );
        }

        private bool OnCloseTabViewCanExecute()
        {
            return IsEnable;
        }

        public virtual void Load(int tabiD)
        {
        }
    }
}
