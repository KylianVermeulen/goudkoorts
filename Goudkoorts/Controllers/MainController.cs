using System;
using Goudkoorts.Models;
using Goudkoorts.Views;

namespace Goudkoorts.Controllers
{
    public class MainController
    {
        private InputView inputView;
        private OutputView outputView;
        private Parser parser;
        private Map map;

        public MainController()
        {
            inputView = new InputView();
            outputView = new OutputView();
            outputView.ShowStart();
            inputView.ShowConfirm();
            parser = new Parser();
            map = parser.ParseMap();
            GenerateMap();
        }

        private void GenerateMap()
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
            
            outputView.ViewMap(mapString);
            ActionInput();
        }

        private void ActionInput()
        {
            var keyInfo = inputView.ReadInput();
            
            var inputChar = keyInfo.KeyChar;
            switch (inputChar)
            {
                case 's':
                    return;
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
            GenerateMap();
        }
    }
}