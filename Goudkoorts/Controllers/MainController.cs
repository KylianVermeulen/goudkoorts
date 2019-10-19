using System;
using System.Threading;
using Goudkoorts.Models;
using Goudkoorts.Models.Exeptions;
using Goudkoorts.Views;
using Timer = Goudkoorts.Models.Timer;

namespace Goudkoorts.Controllers
{
    public class MainController
    {
        private InputView inputView;
        private OutputView outputView;
        private Parser parser;
        private Map map;
        private Timer timer;

        public MainController()
        {
            inputView = new InputView(this);
            outputView = new OutputView();
            timer = new Timer(this);
            outputView.ShowStart();
            inputView.ShowConfirm();
            parser = new Parser();
            map = parser.ParseMap();
            timer.Start();
            GameLoop();
        }

        private void GameLoop()
        {
            while (timer.Running)
            {
                inputView.ReadInput();
            }
        }

        public void Run()
        {
            try
            {
                map.MoveAllCarts();
                map.SpawnNewCart();
                UpdateView();
            }
            catch (CollisionException e)
            {
                Console.WriteLine(e.StackTrace);
                Environment.Exit(0);
            }
        }

        public void UpdateView()
        {
            outputView.ViewMap(GenerateMap());
            outputView.ViewControls();
            outputView.ViewScore(map.Score);
            outputView.ViewCounter(timer.CurrentCounter);
        }

        private string GenerateMap()
        {
            var mapString = "";
            var tile = map.Origin;
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

        public void ActionInput(ConsoleKeyInfo consoleKeyInfo)
        {
            var keyInfo = consoleKeyInfo;

            var inputChar = keyInfo.KeyChar;
            switch (inputChar)
            {
                case 's':
                    Environment.Exit(0);
                    break;
                default:
                {
                    switch (keyInfo.Key)
                    {
                        case ConsoleKey.D1:
                            map.FlipSwitchDirection(0);
                            break;
                        case ConsoleKey.D2:
                            map.FlipSwitchDirection(1);
                            break;
                        case ConsoleKey.D3:
                            map.FlipSwitchDirection(2);
                            break;
                        case ConsoleKey.D4:
                            map.FlipSwitchDirection(3);
                            break;
                        case ConsoleKey.D5:
                            map.FlipSwitchDirection(4);
                            break;
                    }

                    break;
                }
            }
            
            UpdateView();
        }
    }
}