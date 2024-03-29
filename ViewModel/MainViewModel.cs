﻿using Autofac.Features.Indexed;
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
       
        public MainViewModel()
        {
           
          

            CreateNewTabCommand = new RelayCommand<Type>(CreateNewTabExecute,CreateNewTabCanExecute);
            
        }

        //private ObservableCollection<Items> _tabViewModels;
        //public ObservableCollection<ITabViewModel> TabViewModels
        //{
        //    get
        //    {
        //        if (_tabViewModels == null)
        //        {
        //            _tabViewModels = new ObservableCollection<ITabViewModel>();
        //            var itemsView = (IEditableCollectionView)CollectionViewSource.GetDefaultView(_tabViewModels);
        //            itemsView.NewItemPlaceholderPosition = NewItemPlaceholderPosition.AtEnd;
        //        }

        //        return _tabViewModels;
        //    }
        //}

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

        private ICommand createNewTabCommand;
        public ICommand CreateNewTabCommand
        {
            get { return createNewTabCommand; }
            set { createNewTabCommand = value; }
        }

        private int nextNewItemId = 1;

        public void CreateNewTabExecute(Type type)
        {
            
        }

        public bool CreateNewTabCanExecute(Type type)
        {
            return true;
        }

        #endregion

        private  void OpenTabView()
        {
            
            //var detailViewModel = TabViewModels.SingleOrDefault(x => x.Id == args.Id
            //&& x.GetType().Name == args.ViewModelName);

            //if (detailViewModel == null)
            //{
            //    detailViewModel = _detailViewModelCreator[args.ViewModelName];
            //    try
            //    {
            //        detailViewModel.Load(args.Id);
            //    }
            //    catch
            //    {
            //        return;
            //    }
            //    TabViewModels.Add(detailViewModel);
            //}

            //SelectedTabViewModel = TabViewModels.Count - 1;
        }

        private void AfterDetailClosed()
        {
      
           
        }

        private void RemoveDetailViewModel(int id, string viewModelName)
        {
           
        }
    }
}
 