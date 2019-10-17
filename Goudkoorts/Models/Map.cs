using System;
using System.Collections.Generic;
using System.Linq;
using Goudkoorts.Models.ActionTiles;
using Goudkoorts.Models.Entities;

namespace Goudkoorts.Models
{
    public class Map
    {
        public ITile Origin { get; set; }
        public List<SwitchRailTile> SwitchRailTiles { get; } = new List<SwitchRailTile>();
        public List<WarehouseTile> WarehouseTiles { get; } = new List<WarehouseTile>();
        public List<CartEntity> CartEntities { get; } = new List<CartEntity>();

        public void FlipSwitchDirection(int _switch)
        {
            if (_switch >= SwitchRailTiles.Count) throw new ArgumentOutOfRangeException();
            WarehouseTiles[_switch].Act();
        }

        public void SpawnNewCart()
        {
            var rand = new Random();
            var odds = rand.Next(0, WarehouseTiles.Count);
            WarehouseTiles[odds].Act();
            WarehouseTiles[odds].Entity.Move();
        }

        public void MoveAllCarts()
        {
            var list = CartEntities.ToArray().Reverse();
            var queue = new Queue<CartEntity>();
            foreach (var cartEntity in list)
            {
                queue.Enqueue(cartEntity);
            }

            while (queue.TryDequeue(out var result))
            {
                result.Move();
            }
        }
    }
}