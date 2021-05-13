
using Prism.Unity;
using Prism.Modularity;
using Prism.Ioc;

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.ComponentModel;
using TestWork.StopWatch.Module;

namespace StopWatchApp
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : PrismApplication
    {
        protected override Window CreateShell()
        {
            var view = Container.Resolve<Shell>();
            var datacontext = Container.Resolve<ShellViewModel>();
            view.DataContext = datacontext;
            return view;
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {

        }

        //protected override void InitializeShell(System.Windows.Window shell)
        //{
        //    shell.Show();
        //}

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            base.ConfigureModuleCatalog(moduleCatalog);
            Type moduleCType = typeof(StopWatchModule);
            moduleCatalog.AddModule(new ModuleInfo()
            {
                ModuleName = moduleCType.Name,
                ModuleType = moduleCType.AssemblyQualifiedName,
            });
        }


    }




}
