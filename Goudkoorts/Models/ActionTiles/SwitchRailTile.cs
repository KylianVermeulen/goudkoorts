using System;
using Goudkoorts.Models.Entities;
using Goudkoorts.Models.Exeptions;

namespace Goudkoorts.Models.ActionTiles
{
    public class SwitchRailTile : ActionTile
    {
        private Direction Entry { get; set; }
        private Direction Exit { get; set; }
        private string Type { get; set; }
        private Direction SwitchDirection => Type.Equals("entry") ? Entry : Exit;

        public SwitchRailTile(Direction entry, Direction exit, string type)
        {
            Entry = entry;
            Exit = exit;
            Type = type;
            Direction = Exit;
        }

        public override bool CanHaveEntity(Entity entity)
        {
            switch (Entry)
            {
                case Direction.Up:
                    if (!entity.Tile.Equals(PrevY)) return false;
                    if (Entity != null) throw new CollisionException();
                    return true;
                case Direction.Down:
                    if (!entity.Tile.Equals(NextY)) return false;
                    if (Entity != null) throw new CollisionException();
                    return true;
                case Direction.Right:
                    if (!entity.Tile.Equals(NextX)) return false;
                    if (Entity != null) throw new CollisionException();
                    return true;
                case Direction.Left:
                    if (!entity.Tile.Equals(PrevX)) return false;
                    if (Entity != null) throw new CollisionException();
                    return true;
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
                    if (Type.Equals("entry")) Entry = Direction.Down;
                    else Exit = Direction.Down;
                    Direction = Exit;
                    return true;
                case Direction.Down:
                    if (Type.Equals("entry")) Entry = Direction.Up;
                    else Exit = Direction.Up;
                    Direction = Exit;
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