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
    public class MainwindowViewModelTests
    {
        [Test]
        public void MainModelItemPageCount()
        {
            MainViewModel mainVM = new MainViewModel(null, null);

            Assert.IsTrue(mainVM.TabViewModels.Count==1);

        }
    }
}
