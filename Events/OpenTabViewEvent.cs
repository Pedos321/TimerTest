using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimerTestApp.Events
{
    public class OpenTabViewEvent : PubSubEvent<OpenTabViewEventArgs>
    {
    }

    public class OpenTabViewEventArgs
    {
        public int Id { get; set; }
        public string ViewModelName { get; set; }
    }
}
