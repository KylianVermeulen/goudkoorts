using System;
using System.Threading;
using System.Timers;
using Goudkoorts.Controllers;

namespace Goudkoorts.Models
{
    public class Timer
    {
        public MainController MainController { get; set; }

        public System.Timers.Timer GameTimer { get; set; }
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