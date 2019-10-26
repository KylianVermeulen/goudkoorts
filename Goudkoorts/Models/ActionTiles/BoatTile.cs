using Goudkoorts.Models.Entities;
using Goudkoorts.Models.Exeptions;

namespace Goudkoorts.Models.ActionTiles
{
    public class BoatTile : ActionTile
    {
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
            return base.ToChar('~');
        }
    }
}