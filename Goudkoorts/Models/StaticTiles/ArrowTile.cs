using System;

namespace Goudkoorts.Models.StaticTiles
{
    public class ArrowTile : StaticTile
    {
        private Direction Direction { get; set; }

        public ArrowTile(Direction direction)
        {
            Direction = direction;
        }

        public override char ToChar()
        {
            switch (Direction)
            {
                case Direction.Right:
                    return '>';
                case Direction.Left:
                    return '<';
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}