using System;

namespace Goudkoorts.Views
{
    public class InputView
    {
        public bool ShowConfirm()
        {
            Console.WriteLine("Press any key to continue or s to cancel");
            var input = Console.ReadKey();
            var inputChar = input.KeyChar;
            return inputChar != 's';
        }
    }
}