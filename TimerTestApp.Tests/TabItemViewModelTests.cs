using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimerTestApp.ViewModel;

namespace TimerTestApp.Tests
{
    [TestFixture]
    public class TabItemViewModelTests
    {
        [Test]
        public void StartStopCommand()
        {
            TabItemViewModel TabItemVM = new TabItemViewModel(null, null);
            
        }

        [Test]
        public void ResetCommand()
        {

        }
    }
}
