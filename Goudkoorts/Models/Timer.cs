using System;
using System.Timers;
using Goudkoorts.Controllers;

namespace Goudkoorts.Models
{
    public class Timer
    {
        private MainController MainController { get; set; }
        private System.Timers.Timer GameTimer { get; set; }
        public bool Running { get; set; }
        public int CurrentCounter { get; set; }
        private int Counter { get; set; }

        public Timer(MainController mainController)
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
            GameTimer.Enabled = true;
        }

        private void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            Running = false;
            if (CurrentCounter <= 0)
            {
                GameTimer.Enabled = false;
                MainController.Run();
                CurrentCounter = Counter;
                GameTimer.Enabled = true;
            }
            else
            {
                MainController.UpdateView();
                CurrentCounter--;
            }

            Running = true;
        }
    }
}