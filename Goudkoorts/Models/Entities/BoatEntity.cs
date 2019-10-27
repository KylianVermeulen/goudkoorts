namespace Goudkoorts.Models.Entities
{
    public class BoatEntity : Entity
    {
        private int Load { get; set; }
        
        public override void Move()
        {
            Tile.Entity = null;
            Tile = null;
        }

        public override char ToChar()
        {
            return 'B';
        }

        public void Dock()
        {
            Load += 1;
        }

        public bool IsFull()
        {
            return Load >= 8;
        }
    }
}