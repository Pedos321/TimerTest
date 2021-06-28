using Autofac.Features.Indexed;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;
using TimerTestApp.Commands;
using TimerTestApp.Model;


namespace TimerTestApp.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
      
        private IIndex<string, ITabViewModel> _detailViewModelCreator;
        public MainViewModel(
            IIndex<string, ITabViewModel> detailViewModelCreator)
        {
           
            _detailViewModelCreator = detailViewModelCreator;

            CreateNewTabCommand = new RelayCommand<Type>(CreateNewTabExecute,CreateNewTabCanExecute);
            
        }

        private ObservableCollection<ITabViewModel> _tabViewModels;
        public ObservableCollection<ITabViewModel> TabViewModels
        {
            get
            {
                if (_tabViewModels == null)
                {
                    _tabViewModels = new ObservableCollection<ITabViewModel>();
                    var itemsView = (IEditableCollectionView)CollectionViewSource.GetDefaultView(_tabViewModels);
                    itemsView.NewItemPlaceholderPosition = NewItemPlaceholderPosition.AtEnd;
                }

                return _tabViewModels;
            }
        }

        private int _selectedTabViewModel;
        public int SelectedTabViewModel
        {
            get { return _selectedTabViewModel; }
            set
            {
                _selectedTabViewModel = value;
                OnPropertyChanged();
            }
        }

        #region CreateNewTabCommand
        public ICommand CreateNewTabCommand { get; }

        private int nextNewItemId = 1;
        private void CreateNewTabExecute(Type viewModelType)
        {
            //if (TabViewModels.Count<10)
            //{
                OpenTabView(
              new OpenTabViewEventArgs
              {
                  Id = nextNewItemId++,
                  ViewModelName = viewModelType.Name
              });
            //}
        }
        public bool CreateNewTabCanExecute(Type type)
        {
            if (TabViewModels.Count < 10)
            {
                return true;
            }
            return false;
        }

        #endregion

        private  void OpenTabView(OpenTabViewEventArgs args)
        {
            
            var detailViewModel = TabViewModels.SingleOrDefault(x => x.Id == args.Id
            && x.GetType().Name == args.ViewModelName);

            if (detailViewModel == null)
            {
                detailViewModel = _detailViewModelCreator[args.ViewModelName];
                try
                {
                    detailViewModel.Load(args.Id);
                }
                catch
                {
                    return;
                }
                TabViewModels.Add(detailViewModel);
            }

            SelectedTabViewModel = TabViewModels.Count - 1;
        }

        private void AfterDetailClosed()
        {
            if (TabViewModels.Count > 1)
            {
                //RemoveDetailViewModel(args.Id, args.ViewModelName);
            }
           
        }

        private void RemoveDetailViewModel(int id, string viewModelName)
        {
            var detailViewModel = TabViewModels.SingleOrDefault(x => x.Id == id
            && x.GetType().Name == viewModelName);

            if (detailViewModel != null)
            {
                TabViewModels.Remove(detailViewModel);
            }
        }
    }
}
 