using System;
using Sokoban.Model.Tiles;
using Sokoban.Model.Entities;

namespace Sokoban.Model
{
    class Maze
    {
        private int _columns, _rows;
        private Tile _firstTile;
        private Truck _truck;
        private Employee _employee;

        public int Columns { get { return _columns; } set { _columns = value; } }
        public int Rows { get { return _rows; } set { _rows = value; } }
        public Truck Truck { get { return _truck; } set { _truck = value; } }
        public Employee Employee { get { return _employee; } set { _employee = value; } }
        public Tile FirstTile { get { return _firstTile; } set { _firstTile = value; } }

        public Maze(Tile firstTile, int columns, int rows)
        {
            this._firstTile = firstTile;
            this._columns = columns;
            this._rows = rows;
        }

        public bool HasFinished()
        {
            Tile t = _firstTile;
            while(t != null)
            {
                Tile tt = t;
                while(tt != null)
                {
                    if (tt is Destination && (tt.EntityOnTile == null || !(tt.EntityOnTile is Crate))) return false;
                    tt = tt.Right;
                }
                t = t.Down;
            }

            return true;
        }

        public String MazeToString()
        {
            String s = "";
            Tile currentTile = _firstTile;
            while (currentTile != null)
            {
                Tile tile = currentTile;
                while (tile != null)
                {
                    s += tile.GetTileCharacter();
                    tile = tile.Right;
                }
                s += Environment.NewLine;
                currentTile = currentTile.Down;
            }
            return s;
        }
    }
}
