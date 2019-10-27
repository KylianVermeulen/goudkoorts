using Goudkoorts.Models.ActionTiles;

namespace Goudkoorts.Models.Entities
{
    public abstract class Entity
    {
        public ActionTile Tile { get; set; }

        public abstract void Move();

        public abstract char ToChar();
    }
}