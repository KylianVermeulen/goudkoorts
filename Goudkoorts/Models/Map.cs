using System;
using System.Collections.Generic;
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
        public DockTile DockTile { get; set; }
        public int Score { get; set; }
        public BoatEntity BoatEntity { get; set; }

        public void FlipSwitchDirection(int _switch)
        {
            if (_switch >= SwitchRailTiles.Count) throw new ArgumentOutOfRangeException();
            SwitchRailTiles[_switch].Act();
        }

        public void SpawnNewCart()
        {
            var rand = new Random();
            var change = rand.Next(0, 5);
            if (change != 0) return;
            var odds = rand.Next(0, 3);
            WarehouseTiles[odds].Act();
            WarehouseTiles[odds].Entity.Move();
        }

        public void MoveAllCarts()
        {
            foreach (var cartEntity in CartEntities)
            {
                cartEntity.Move();
            }
        }

        public void CheckDock()
        {
            if (DockTile.Entity == null) return;
            if (BoatEntity == null) return;
            Score += 1;
            BoatEntity.Dock();
        }

        public void CheckBoat()
        {
            if (BoatEntity?.IsFull() != true) return;
            BoatEntity.Move();
            BoatEntity = null;
            Score += 10;
        }

        public void SpawnNewBoat()
        {
            var rand = new Random();
            var change = rand.Next(0, 11);
            if (change != 0) return;
            var prevY = (ActionTile) DockTile.PrevY;
            var boatEntity = new BoatEntity();
            if (!prevY.CanHaveEntity(null)) return;
            BoatEntity = boatEntity;
            BoatEntity.Tile = prevY;
            prevY.Entity = BoatEntity;
        }
    }
}