using System;
using Goudkoorts.Controllers;

namespace Goudkoorts.Views
{
    public class InputView
    {
        private MainController MainController { get; set; }

        public InputView(MainController mainController)
        {
            MainController = mainController;
        }

        public void ShowConfirm()
        {
            Console.WriteLine("Press any key to continue");
            var confirm = Console.ReadKey();
        }

        public ConsoleKeyInfo ReadInput()
        {
            return Console.ReadKey();
        }
    }
}