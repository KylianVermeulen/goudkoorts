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
        public int Score => 0;

        public void FlipSwitchDirection(int _switch)
        {
            if (_switch >= SwitchRailTiles.Count) throw new ArgumentOutOfRangeException();
            SwitchRailTiles[_switch].Act();
        }

        public void SpawnNewCart()
        {
            var rand = new Random();
            var change = rand.Next(0, 1);
            if (change != 0) return;
            var odds = rand.Next(0, 4);
            WarehouseTiles[odds].Act();
            WarehouseTiles[odds].Entity.Move();
        }

        public void MoveAllCarts()
        {
            var queue = new Queue<CartEntity>();
            foreach (var cartEntity in CartEntities)
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