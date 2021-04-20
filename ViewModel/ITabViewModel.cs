using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimerTestApp.ViewModel
{
    public interface ITabViewModel
    {
        void Load(int id);
        int Id { get; }
        bool IsEnable { get; }

    }
}
