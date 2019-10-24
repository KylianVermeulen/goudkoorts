using System;
using Goudkoorts.Models.ActionTiles;

namespace Goudkoorts.Models.Entities
{
    public class CartEntity : Entity
    {
        public override void Move()
        {
            switch (Tile.Direction)
            {
                case Direction.Up:
                    var nextUp = (ActionTile) Tile.PrevY;
                    if (nextUp.CanHaveEntity(this))
                    {
                        Tile.Entity = null;
                        nextUp.Entity = this;
                        Tile = nextUp;
                    }
                    break;
                case Direction.Right:
                    var nextRight = (ActionTile) Tile.NextX;
                    if (nextRight.CanHaveEntity(this))
                    {
                        Tile.Entity = null;
                        nextRight.Entity = this;
                        Tile = nextRight;
                    }
                    break;
                case Direction.Down:
                    var nextDown = (ActionTile) Tile.NextY;
                    if (nextDown.CanHaveEntity(this))
                    {
                        Tile.Entity = null;
                        nextDown.Entity = this;
                        Tile = nextDown;
                    }
                    break;
                case Direction.Left:
                    var nextLeft = (ActionTile) Tile.PrevX;
                    if (nextLeft.CanHaveEntity(this))
                    {
                        Tile.Entity = null;
                        nextLeft.Entity = this;
                        Tile = nextLeft;
                    }
                    break;
                case Direction.End:
                    Tile.Act();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public override char ToChar()
        {
            return 'C';
        }
    }
}