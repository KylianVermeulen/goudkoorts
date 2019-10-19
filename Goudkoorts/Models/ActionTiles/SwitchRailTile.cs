using System;
using Goudkoorts.Models.Entities;
using Goudkoorts.Models.Exeptions;

namespace Goudkoorts.Models.ActionTiles
{
    public class SwitchRailTile : ActionTile
    {
        private Direction SwitchDirection { get; set; }

        public SwitchRailTile(Direction direction, Direction switchDirection)
        {
            Direction = direction;
            SwitchDirection = switchDirection;
        }

        public override bool CanHaveEntity(Entity entity)
        {
            if (Entity != null) throw new CollisionException();
            if (entity.Tile.Equals(PrevX)) return true;
            switch (SwitchDirection)
            {
                case Direction.Up:
                    return entity.Tile.Equals(PrevY);
                case Direction.Down:
                    return entity.Tile.Equals(NextY);
                case Direction.Right:
                case Direction.Left:
                    throw new ArgumentOutOfRangeException();
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public override bool Act()
        {
            if (Entity != null) return false;
            switch (SwitchDirection)
            {
                case Direction.Up:
                    SwitchDirection = Direction.Down;
                    return true;
                case Direction.Down:
                    SwitchDirection = Direction.Up;
                    return true;
                case Direction.Right:
                case Direction.Left:
                    throw new ArgumentOutOfRangeException();
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public override char ToChar()
        {
            switch (SwitchDirection)
            {
                case Direction.Up:
                    return base.ToChar('↑');
                case Direction.Down:
                    return base.ToChar('↓');
                case Direction.Right:
                case Direction.Left:
                    throw new ArgumentOutOfRangeException();
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}