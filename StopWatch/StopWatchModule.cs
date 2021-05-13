using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestWork.StopWatch.Module.View;
using TestWork.StopWatch.Module.ViewModel;
using Unity;

namespace TestWork.StopWatch.Module
{
    public class StopWatchModule : IModule 
    {
        private readonly IUnityContainer _container;
        private readonly IRegionManager _regionManager;


        public StopWatchModule(IUnityContainer container, IRegionManager regionManager)
        {
            _container = container;
            _regionManager = regionManager;
        }

        public void OnInitialized(IContainerProvider containerProvider)
        {
            _container.RegisterType<StopWatchViewModel, StopWatchViewModel>();
            _regionManager.RegisterViewWithRegion("MainRegion", typeof(StopWatchView));
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            
        }

    }
}
