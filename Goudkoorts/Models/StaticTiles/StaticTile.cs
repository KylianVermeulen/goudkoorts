using System;

namespace Goudkoorts.Models.StaticTiles
{
    public abstract class StaticTile : ITile
    {
        public ITile PrevY { get; set; }
        public ITile NextX { get; set; }
        public ITile NextY { get; set; }
        public ITile PrevX { get; set; }

        public virtual ConsoleColor GetColor()
        {
            return ConsoleColor.White;
        }

        public abstract char ToChar();
    }
}