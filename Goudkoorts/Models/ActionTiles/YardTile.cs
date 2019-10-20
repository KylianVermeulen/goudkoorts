using Goudkoorts.Models.Entities;
using Goudkoorts.Models.Exeptions;

namespace Goudkoorts.Models.ActionTiles
{
    public class YardTile : ActionTile
    {
        public YardTile(Direction direction)
        {
            Direction = direction;
        }

        public override bool CanHaveEntity(Entity entity)
        {
            if (Entity == null) return true;
            if (entity.Tile is RailTile) throw new CollisionException();
            return false;
        }

        public override bool Act()
        {
            return true;
        }

        public override char ToChar()
        {
            return base.ToChar('Y');
        }
    }
}