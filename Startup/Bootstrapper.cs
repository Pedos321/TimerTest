using Autofac;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimerTestApp.Services;
using TimerTestApp.ViewModel;

namespace TimerTestApp.Startup
{
    public class Bootstrapper
    {
        public IContainer Bootstrap()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<EventAggregator>().As<IEventAggregator>().SingleInstance();


            builder.RegisterType<MainWindow>().AsSelf();

            builder.RegisterType<MainViewModel>().AsSelf();

            builder.RegisterType<MessageDialogService>().As<IMessageDialogService>();

            builder.RegisterType<TimerFactory>().As<ITimerFactory>();

            builder.RegisterType<TabItemViewModel>()
                .Keyed<ITabViewModel>(nameof(TabItemViewModel));

            return builder.Build();
        }
    }
}

