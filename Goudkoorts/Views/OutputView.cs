using System;

namespace Goudkoorts.Views
{
    public class OutputView
    {
        public void ShowStart()
        {
            Console.Clear();
            Console.WriteLine("┌────────────────────────────────────────────────────┐");
            Console.WriteLine("| Welkom bij goudkoorts                              |");
            Console.WriteLine("|                                                    |");
            Console.WriteLine("| betekenis van de symbolen   |   doel van het spel  |");
            Console.WriteLine("|                             |                      |");
            Console.WriteLine("|                             |   zet de schakelaars |");
            Console.WriteLine("|      ~ : water              |   om, om zoveel      |");
            Console.WriteLine("|      - : rail horizontaal   |   mogelijk lading    |");
            Console.WriteLine("|      | : rail verticaal     |   naar de boot       |");
            Console.WriteLine("|      ╗ : bocht naar beneden |   te brengen         |");
            Console.WriteLine("|      ╝ : bocht omhoog       |   maar pas op        |");
            Console.WriteLine("|      ╔ : bocht naar rechts  |   dat je karretjes   |");
            Console.WriteLine("|      ╚ : bocht naar links   |   niet botsen!       |");
            Console.WriteLine("|        : leeg veld          |                      |");
            Console.WriteLine("|      ↑ : switch naar boven  |                      |");
            Console.WriteLine("|      ↓ : switch naar onder  |                      |");
            Console.WriteLine("|      Y : rangeerterrein     |                      |");
            Console.WriteLine("|      D : kade               |                      |");
            Console.WriteLine("|      W : loods              |                      |");
            Console.WriteLine("|      > : pijl naar rechts   |                      |");
            Console.WriteLine("|      < : pijl naar links    |                      |");
            Console.WriteLine("|      _ : water route        |                      |");
            Console.WriteLine("└────────────────────────────────────────────────────┘");
            Console.WriteLine("");
        }

        public void ViewMap(string map)
        {
            Console.Clear();
            Console.WriteLine(map);
        }

        public void ViewControls()
        {
            Console.WriteLine("----------------------");
            Console.WriteLine("  1,  2,  3,  4,  5");
            Console.WriteLine("----------------------");
        }

        public void ViewScore(int score)
        {
            Console.WriteLine("Score: " + score);
        }

        public void ViewCounter(int counter)
        {
            Console.WriteLine(counter + " seconds left!");
        }
    }
}