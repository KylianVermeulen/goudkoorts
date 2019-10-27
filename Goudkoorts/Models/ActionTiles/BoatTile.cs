using Goudkoorts.Models.Entities;

namespace Goudkoorts.Models.ActionTiles
{
    public class BoatTile : ActionTile
    {
        public override bool CanHaveEntity(Entity entity)
        {
            if (Entity == null) return true;
            return false;
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