using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban.Model.Tiles
{
    class Floor : Tile
    {
        public const char tileChar = '.';

        public Floor() : base(tileChar)
        {
        }

    }
}
