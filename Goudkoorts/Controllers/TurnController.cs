using System;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using Goudkoorts.Controllers;

namespace Goudkoorts.Controllers
{
    public class TurnController
    {
        private MainController MainController { get; set; }
        private System.Timers.Timer GameTimer { get; set; }
        public bool Running { get; set; }
        public int CurrentCounter { get; private set; }
        private int Counter { get; set; }
        public bool IsCooldown { get; private set; }

        public TurnController(MainController mainController)
        {
            MainController = mainController;
        }

        public void Start()
        {
            GameTimer = new System.Timers.Timer(1000);
            GameTimer.Elapsed += OnTimedEvent;
            GameTimer.AutoReset = true;
            CurrentCounter = 3;
            Counter = 3;
            Running = true;
            IsCooldown = false;
            GameTimer.Enabled = true;
        }

        private void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            if (CurrentCounter <= 0)
            {
                MainController.Run();
                Thread.Sleep(500);
                CurrentCounter = Counter;
            }
            else
            {
                MainController.UpdateView();
                CurrentCounter--;
            }
        }
    }
}