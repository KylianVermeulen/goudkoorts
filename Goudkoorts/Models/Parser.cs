using System;
using System.Collections.Generic;
using System.Text;
using Goudkoorts.Models.ActionTiles;
using Goudkoorts.Models.StaticTiles;

namespace Goudkoorts.Models
{
    public class Parser
    {
        private string mapString = "~~~~~~~~~~~~\n" +
                                   "~~~~~~~~~~~~\n" +
                                   "---------D-5\n" +
                                   "<        < |\n" +
                                   "W--1 3---1 |\n" +
                                   "  >↓-↑   ↑-2\n" +
                                   "W--2 41 32> \n" +
                                   "  >   ↓-↓ > \n" +
                                   "W-----2 4--1\n" +
                                   " YYYYYYYY__6\n" +
                                   "         <  ";

        public Map ParseMap()
        {
            var lines = mapString.Split("\n");
            var map = new Map();
            ITile origin = null;
            ITile prevTileY = null;
            ITile currentTileY = null;

            foreach (var line in lines)
            {
                var chars = line.ToCharArray();
                ITile prevTileX = null;
                foreach (var c in chars)
                {
                    var tile = CharToITileObject(c, map);
                    if (origin == null) origin = tile;

                    if (prevTileX != null)
                    {
                        if (currentTileY != null)
                        {
                            currentTileY.NextY = tile;
                            tile.PrevY = currentTileY;
                            currentTileY = currentTileY.NextX;
                        }

                        prevTileX.NextX = tile;
                        tile.PrevX = prevTileX;
                        prevTileX = tile;
                    }
                    else
                    {
                        if (prevTileY != null)
                        {
                            currentTileY = prevTileY;
                            currentTileY.NextY = tile;
                            tile.PrevY = currentTileY;
                            currentTileY = currentTileY.NextX;
                        }

                        prevTileX = tile;
                        prevTileY = tile;
                    }
                }
            }

            map.Origin = origin;
            return map;
        }

        private ITile CharToITileObject(char c, Map map)
        {
            switch (c)
            {
                case '-':
                {
                    return new RailTile(Direction.Right);
                }
                case '_':
                {
                    return new RailTile(Direction.Left);
                }
                case '|':
                {
                    return new RailTile(Direction.Up);
                }
                case '1':
                {
                    return new CornerRailTile(Direction.Down, Direction.Left, '1');
                }
                case '2':
                {
                    return new CornerRailTile(Direction.Up, Direction.Left, '2');
                }
                case '3':
                {
                    return new CornerRailTile(Direction.Right, Direction.Down, '3');
                }
                case '4':
                {
                    return new CornerRailTile(Direction.Right, Direction.Up, '4');
                }
                case '5':
                {
                    return new CornerRailTile(Direction.Left, Direction.Down, '5');
                }
                case '6':
                {
                    return new CornerRailTile(Direction.Left, Direction.Up, '6');
                }
                case '↓':
                {
                    var _switch = new SwitchRailTile(Direction.Right, Direction.Down);
                    map.SwitchRailTiles.Add(_switch);
                    return _switch;
                }
                case '↑':
                {
                    var _switch = new SwitchRailTile(Direction.Right, Direction.Up);
                    map.SwitchRailTiles.Add(_switch);
                    return _switch;
                }
                case 'W':
                {
                    var warehouse = new WarehouseTile {Map = map};
                    map.WarehouseTiles.Add(warehouse);
                    return warehouse;
                }
                case '>':
                {
                    return new ArrowTile(Direction.Right);
                }
                case '<':
                {
                    return new ArrowTile(Direction.Left);
                }
                case 'D':
                {
                    //TODO: Add Dock
                    return new RailTile(Direction.Left);
                }
                case 'Y':
                {
                    return new YardTile(Direction.Left);
                }
                case '~':
                {
                    return new WaterTile();
                }
                default:
                {
                    return new EmptyTile();
                }
            }
        }
    }
}