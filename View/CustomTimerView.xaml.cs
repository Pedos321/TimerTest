using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TimerTestApp.ViewModel;

namespace TimerTestApp.View
{
    /// <summary>
    /// Логика взаимодействия для CustomTimerView.xaml
    /// </summary>
    public partial class CustomTimerView : UserControl
    {
        
        public CustomTimerView()
        {
            InitializeComponent();
            DataContext = new StopWatchTimerViewModel();
        }
    }
}
