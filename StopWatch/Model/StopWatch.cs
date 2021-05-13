using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestWork.StopWatch.Module.Model
{
    public class StopWatch : ISimpleStopWatch
    {
        public enum StopWatchStates { Stopped, Running, Paused };

        #region Fields
        private int _Hour = 0;
        private int _Minute = 0;
        private int _Second = 0;
        private int _Millisecond = 0;
        private int _Interval = 1000;

        public double Interval { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        #endregion

        #region Properties
        #endregion

        #region Constructors
        public StopWatch()
        {
            
        }
        #endregion



        #region Methods

        public virtual void Reset()
        {
          
        }

        public  void Start()
        {
           
        }

        public  void Pause()
        {
           
        }

        public void Stop()
        {
        
        }

        public void FireAsync(Delegate dlg, params object[] pList)
        {
          
        }

        public  void FindEffectivTime()
        {

        }

        

        #endregion

        #region Events
        public event EventHandler Elapsed;
        public void OnElapsed(EventArgs e)
        {
            
        }

        public event EventHandler Completed;
        public void OnCompleted(EventArgs e)
        {
         
        }

        public event EventHandler StateChanged;
        public void OnStateChanged(EventArgs e)
        {
         
        }

        private void TimerElapsed(object sender, EventArgs e)
        {

        }
        #endregion


    }







}
