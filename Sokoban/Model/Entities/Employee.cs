using System;
using Sokoban.Model.Tiles;

namespace Sokoban.Model.Entities
{
    class Employee : Entity
    {

        public const char entityChar = '$';
        private const char sleepingChar = 'Z';
        private bool _sleeping = false;

        public bool Sleeping { get { return _sleeping; } set { _sleeping = value; } }

        public Employee()
        {
            _entityChar = entityChar;
        }

        public override bool Move(Direction dir)
        {
            Tile next = (dir == Direction.LEFT) ? TileOnPosition.Left : (dir == Direction.UP) ? TileOnPosition.Up : (dir == Direction.RIGHT) ? TileOnPosition.Right : TileOnPosition.Down;
            if (next == null || next is Wall) return false;

            if (next.EntityOnTile != null && !next.EntityOnTile.Move(dir)) return false;

            _tileOnPosition.EntityOnTile = null;
            _tileOnPosition = next;
            _tileOnPosition.EntityOnTile = this;
            return true;
        }

        public override char GetCharacter()
        {
            if (_sleeping) return sleepingChar;
            return base.GetCharacter();
        }

        public void action()
        {
            Random random = new Random();
            if(_sleeping)
            {
                int ran = random.Next(10);
                if (ran == 3)
                {
                    _sleeping = false;
                }
            }
            else
            {
                int ran = random.Next(4);
                if(ran == 1)
                {
                    _sleeping = true;
                }
                else
                {
                    Direction[] dirs = new Direction[] { Direction.LEFT, Direction.UP, Direction.RIGHT, Direction.DOWN };
                    Move(dirs[random.Next(4)]);
                }
            }
        }
    }
}
