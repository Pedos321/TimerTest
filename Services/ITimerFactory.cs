using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimerTestApp.Model;

namespace TimerTestApp.Services
{
    public interface ITimerFactory
    {
        ITimer CreateTimer();

    }

    public class TimerFactory : ITimerFactory
    {
        public ITimer CreateTimer() => new Timer();
    }
}
