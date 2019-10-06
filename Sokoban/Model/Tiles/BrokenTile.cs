using Sokoban.Model.Entities;

namespace Sokoban.Model.Tiles
{
    class BrokenTile : Tile
    {
        private int _amountStepped;

        public const char tileChar = '~';
        public const char tileCharHole = ' ';
        public override Entity EntityOnTile {
            get { return _entityOnTile; }
            set {
                if (_amountStepped < 3)
                {
                    _entityOnTile = value;
                    if(_entityOnTile!= null) _amountStepped++;
                }
                else if (_amountStepped >= 3)
                {
                    if (value != null && value is Crate) _entityOnTile = null;
                    else _entityOnTile = value;
                }
            }
        }

        public BrokenTile() : base(tileChar)
        {
            _amountStepped = 0;
        }

        public override char GetTileCharacter()
        {
            if (_entityOnTile != null) return _entityOnTile.GetCharacter();
            if (_amountStepped >= 3) return tileCharHole;
            return _type;
        }
    }
}
