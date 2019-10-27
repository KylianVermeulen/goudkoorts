using Goudkoorts.Models.Entities;

namespace Goudkoorts.Models.ActionTiles
{
    public abstract class ActionTile : ITile
    {
        public ITile PrevY { get; set; }
        public ITile NextX { get; set; }
        public ITile NextY { get; set; }
        public ITile PrevX { get; set; }
        public Entity Entity { get; set; }
        public Direction Direction { get; set; }

        public abstract bool CanHaveEntity(Entity entity);

        public abstract bool Act();

        public abstract char ToChar();

        public char ToChar(char c)
        {
            return Entity?.ToChar() ?? c ;
        }
    }
}