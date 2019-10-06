using Sokoban.Model.Tiles;

namespace Sokoban.Model.Entities
{
    class Crate : Entity
    {
        public const char entityChar = 'O';
        public const char crateOnDestinationChar = '0';

        public Crate()
        {
            _entityChar = entityChar;
        }

        public override bool Move(Direction dir)
        {
            Tile next = (dir == Direction.LEFT) ? _tileOnPosition.Left : (dir == Direction.UP) ? _tileOnPosition.Up : (dir == Direction.RIGHT) ? _tileOnPosition.Right : _tileOnPosition.Down;
            if (next == null || next is Wall || next.EntityOnTile != null) return false;

            _tileOnPosition.EntityOnTile = null;
            _tileOnPosition = next;
            _tileOnPosition.EntityOnTile = this;
            return true;
        }

        public override char GetCharacter()
        {
            if (TileOnPosition is Destination) return crateOnDestinationChar;
            return base.GetCharacter();
        }
    }
}
