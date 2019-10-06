using Sokoban.Model.Tiles;

namespace Sokoban.Model.Entities
{
    class Truck : Entity
    {
        public const char entityChar = '@';
        public Truck()
        {
            _entityChar = entityChar;
        }

        public override bool Move(Direction dir)
        {
            Tile next = (dir == Direction.LEFT) ? TileOnPosition.Left : (dir == Direction.UP) ? TileOnPosition.Up : (dir == Direction.RIGHT) ? TileOnPosition.Right : TileOnPosition.Down;
            if (next == null || next is Wall) return false;

            if(next.EntityOnTile != null)
            {
                if(next.EntityOnTile is Employee)
                {
                    ((Employee)next.EntityOnTile).Sleeping = false;
                    return false;
                }

                if (!next.EntityOnTile.Move(dir)) return false;
            }

            _tileOnPosition.EntityOnTile = null;
            _tileOnPosition = next;
            _tileOnPosition.EntityOnTile = this;
            return true;
        }
    }
}
