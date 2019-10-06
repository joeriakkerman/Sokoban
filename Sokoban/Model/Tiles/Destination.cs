using Sokoban.Model.Entities;

namespace Sokoban.Model.Tiles
{
    class Destination : Tile
    {
        public const char tileChar = 'x';

        public Destination() : base(tileChar)
        {
        }
    }
}
