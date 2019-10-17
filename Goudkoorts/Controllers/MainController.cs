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

        public void GenerateMap()
        {
            var mapString = "";
            var tile = map.Origin;
            var currentY = tile;
            while (currentY != null)
            {
                if (!currentY.Equals(tile))
                {
                    mapString += "\n";
                }
                
                var currentX = currentY;
                while (currentX != null)
                {
                    mapString += currentX.ToChar();
                    currentX = currentX.NextX;
                }

                currentY = currentY.NextY;
            }
            
            outputView.ViewMap(mapString);
        }
    }
}