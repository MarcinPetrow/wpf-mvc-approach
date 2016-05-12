using MVCinWPF.Core;
using MVCinWPF.Core.Navigation;
using MVCinWPF.Core.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Samples.Controllers
{
    public class TimerController : Controller
    {
        private bool isTimerRunning;
        private bool isTimerLoopAlive;

        public void Index()
        {
            ClearData();
            Data.StartCommand = new DelegateCommand(StartCommandExecute);
            Data.StopCommand = new DelegateCommand(StopCommandExecute);
            Data.PauseCommand = new DelegateCommand(PauseCommandExecute);
            Data.CurrentTime = new DateTime(2000, 1, 1, 0, 0, 0);

            TimerView view = new TimerView();
            Navigator.Navigate(this, null, view);

            isTimerLoopAlive = true;
            Thread thread = new Thread(new ThreadStart(this.TimeUpdater));
            thread.Start();
        }

        private void StartCommandExecute(object obj)
        {
            isTimerRunning = true;
        }

        private void StopCommandExecute(object obj)
        {
            Data.CurrentTime = new DateTime(2000, 1, 1, 0,0,0);
            isTimerRunning = false;
        }

        private void PauseCommandExecute(object obj)
        {
            isTimerRunning = false;
        }

        private void TimeUpdater()
        {
            while (isTimerLoopAlive)
            {
                while (
                    isTimerRunning)
                {
                    Data.CurrentTime = Data.CurrentTime.AddSeconds(1);
                    Thread.Sleep(10);
                }
                Thread.Sleep(500);
            }
        }

        public override void Cleanup()
        {
            base.Cleanup();
            isTimerRunning = false;
            isTimerLoopAlive = false;
        }

    }
}
