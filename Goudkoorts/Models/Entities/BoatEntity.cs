namespace Goudkoorts.Models.Entities
{
    public class BoatEntity : Entity
    {
        private int Load { get; set; }
        
        public override void Move()
        {
            throw new System.NotImplementedException();
        }

        public override char ToChar()
        {
            throw new System.NotImplementedException();
        }

        public void Dock()
        {
            Load += 1;
        }

        public bool IsFull()
        {
            return Load >= 4;
        }
    }
}