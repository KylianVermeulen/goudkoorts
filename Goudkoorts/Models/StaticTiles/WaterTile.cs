using System;

namespace Goudkoorts.Models.StaticTiles
{
    public class WaterTile : StaticTile
    {
        public override char ToChar()
        {
            return '~';
        }
    }
}