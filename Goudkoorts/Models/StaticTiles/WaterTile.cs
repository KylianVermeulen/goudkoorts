using System;

namespace Goudkoorts.Models.StaticTiles
{
    public class WaterTile : StaticTile
    {
        public override ConsoleColor GetColor()
        {
            return ConsoleColor.Blue;
        }

        public override char ToChar()
        {
            return '~';
        }
    }
}