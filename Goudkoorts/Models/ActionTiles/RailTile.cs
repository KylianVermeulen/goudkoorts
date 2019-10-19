using System;
using Goudkoorts.Models.Entities;
using Goudkoorts.Models.Exeptions;

namespace Goudkoorts.Models.ActionTiles
{
    public class RailTile : ActionTile
    {

        public RailTile(Direction direction)
        {
            Direction = direction;
        }

        public override bool CanHaveEntity(Entity entity)
        {
            if (Entity == null) return true;
            throw new CollisionException();
        }

        public override bool Act()
        {
            return true;
        }

        public override char ToChar()
        {
            switch (Direction)
            {
                case Direction.Up:
                case Direction.Down:
                    return base.ToChar('|');
                case Direction.Right:
                case Direction.Left:
                    return base.ToChar('-');
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}