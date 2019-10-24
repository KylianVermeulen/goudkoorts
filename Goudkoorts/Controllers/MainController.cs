using System;
using System.Threading;
using System.Threading.Tasks;
using Goudkoorts.Models;
using Goudkoorts.Models.Exeptions;
using Goudkoorts.Views;

namespace Goudkoorts.Controllers
{
    public class MainController
    {
        private readonly InputView _inputView;
        private readonly OutputView _outputView;
        private readonly Map _map;
        private readonly TurnController _turnController;
        private readonly CancellationTokenSource _ctx;

        public MainController()
        {
            _inputView = new InputView(this);
            _outputView = new OutputView();
            _turnController = new TurnController(this);
            _outputView.ShowStart();
            _inputView.ShowConfirm();
            var parser = new Parser();
            _map = parser.ParseMap();
            _turnController.Start();

            _ctx = new CancellationTokenSource();
            var kbTask = Task.Run(() =>
            {
                while (true)
                {
                    var input = _inputView.ReadInput();
                    if (input.KeyChar.Equals('s'))
                    {
                        _ctx.Cancel();
                        break;
                    }

                    ActionInput(input);
                }
            });
            kbTask.Wait();
        }

        public void Run()
        {
            try
            {
                _map.MoveAllCarts();
                _map.SpawnNewCart();
                UpdateView();
            }
            catch (Exception e)
            {
                _ctx.Cancel();
                Console.WriteLine(e.StackTrace);
                Environment.Exit(0);
            }
        }

        public void UpdateView()
        {
            _outputView.ViewMap(GenerateMap());
            _outputView.ViewControls();
            _outputView.ViewScore(_map.Score);
            _outputView.ViewCounter(_turnController.CurrentCounter);
        }

        private string GenerateMap()
        {
            var mapString = "";
            var tile = _map.Origin;

            var currentY = tile;
            while (currentY != null)
            {
                mapString += "\n";

                var currentX = currentY;
                while (currentX != null)
                {
                    mapString += currentX.ToChar();
                    currentX = currentX.NextX;
                }

                currentY = currentY.NextY;
            }

            return mapString;
        }

        private void ActionInput(ConsoleKeyInfo consoleKeyInfo)
        {
            var keyInfo = consoleKeyInfo;

            var inputChar = keyInfo.KeyChar;
            switch (keyInfo.Key)
            {
                case ConsoleKey.D1:
                    _map.FlipSwitchDirection(0);
                    break;
                case ConsoleKey.D2:
                    _map.FlipSwitchDirection(1);
                    break;
                case ConsoleKey.D3:
                    _map.FlipSwitchDirection(2);
                    break;
                case ConsoleKey.D4:
                    _map.FlipSwitchDirection(3);
                    break;
                case ConsoleKey.D5:
                    _map.FlipSwitchDirection(4);
                    break;
            }

            UpdateView();
        }
    }
}