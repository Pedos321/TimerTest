using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace TimerTestApp.Services
{
    public class MessageDialogService : IMessageDialogService
    {
        private Window Window => Application.Current.MainWindow;

        public void ShowOkDialog(string text)
        {
         
        }

        public enum MessageDialogResult
        {
            OK
        }
    }
}
