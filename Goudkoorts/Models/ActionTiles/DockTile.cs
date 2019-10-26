namespace Goudkoorts.Models.ActionTiles
{
    public class DockTile : RailTile
    {
        public DockTile(Direction direction) : base(direction)
        {
        }

        public override bool Act()
        {
            return true;
        }

        public override char ToChar()
        {
            return base.ToChar('D');
        }
    }
}