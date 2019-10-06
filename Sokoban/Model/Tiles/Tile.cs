using Sokoban.Model.Tiles;
using Sokoban.Model.Entities;

namespace Sokoban.Model
{
    class Tile
    {
        //█ = wall
        //. = floor
        //O = crate
        //x = desination
        //0 = crate on destination
        //@ = truck
        //~ = broken tile
        //[space] = hole

        protected char _type;
        protected Entity _entityOnTile;
        private Tile _left, _up, _right, _down;

        public char Type { get { return _type; } set { _type = value; } }

        public virtual Entity EntityOnTile { get { return _entityOnTile; } set { _entityOnTile = value; } }

        public Tile Left { get { return _left; } set { _left = value; } }
        public Tile Up { get { return _up; } set { _up = value; } }
        public Tile Right { get { return _right; } set { _right = value; } }
        public Tile Down { get { return _down; } set { _down = value; } }

        public Tile(char type)
        {
            this._type = type;
        }

        public virtual char GetTileCharacter()
        {
            if (_entityOnTile != null) return _entityOnTile.GetCharacter();
            return _type;
        }

        public static Tile CreateTile(char type, Entity entity)
        {
            Tile tile;
            switch (type)
            {
                case Floor.tileChar:
                    tile = new Floor();
                    break;
                case Destination.tileChar:
                    tile = new Destination();
                    break;
                case Wall.tileChar:
                    tile = new Wall();
                    break;
                case BrokenTile.tileChar:
                    tile = new BrokenTile();
                    break;
                default:
                    tile = null;
                    break;
            }
            if(entity != null && tile != null) tile.EntityOnTile = entity;
            return tile;
        }
    }
}
