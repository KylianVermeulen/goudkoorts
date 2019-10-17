using System;

namespace Goudkoorts.Views
{
    public class InputView
    {
        public void ShowConfirm()
        {
            Console.WriteLine("Press any key to continue");
            var input = Console.ReadKey();
            var inputChar = input.KeyChar;
        }

        public ConsoleKeyInfo ReadInput()
        {
            return Console.ReadKey();
        }
    }
}