using System;
using Goudkoorts.Models.Entities;
using Goudkoorts.Models.Exeptions;

namespace Goudkoorts.Models.ActionTiles
{
    public class CornerRailTile : ActionTile
    {
        private Direction OriginDirection { get; set; }
        private char Id { get; set; }

        public CornerRailTile(Direction direction, Direction originDirection, char id)
        {
            Direction = direction;
            OriginDirection = originDirection;
            Id = id;
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
            switch (Id)
            {
                case '1':
                    return base.ToChar('╗');
                case '2':
                    return base.ToChar('╝');
                case '3':
                    return base.ToChar('╔');
                case '4':
                    return base.ToChar('╚');
                case '5':
                    return base.ToChar('╗');
                case '6':
                    return base.ToChar('╝');
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}