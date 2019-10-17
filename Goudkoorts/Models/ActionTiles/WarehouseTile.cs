using System;
using Goudkoorts.Models.Entities;
using Goudkoorts.Models.Exeptions;

namespace Goudkoorts.Models.ActionTiles
{
    public class WarehouseTile : ActionTile
    {
        public Map Map { get; set; }

        public override bool CanHaveEntity(Entity entity)
        {
            throw new CollisionException();
        }

        public override bool Act()
        {
            var cart = new CartEntity() {Tile = this};
            Entity = cart;
            Map.CartEntities.Add(cart);
            return true;
        }

        public override char ToChar()
        {
            return 'W';
        }
    }
}