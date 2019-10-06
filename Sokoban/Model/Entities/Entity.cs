
namespace Sokoban.Model.Entities
{
    abstract class Entity
    {
        protected char _entityChar;
        protected Tile _tileOnPosition;
        public char EntityChar { get { return _entityChar; } }
        public Tile TileOnPosition { get { return _tileOnPosition; } set { _tileOnPosition = value; } }

        public enum Direction { LEFT, UP, RIGHT, DOWN }

        public abstract bool Move(Direction dir);

        public virtual char GetCharacter()
        {
            return _entityChar;
        }

        public static Entity CreateEntity(char type)
        {
            Entity entity;
            switch (type)
            {
                case Crate.entityChar:
                    entity = new Crate();
                    break;
                case Truck.entityChar:
                    entity = new Truck();
                    break;
                case Employee.entityChar:
                    entity = new Employee();
                    break;
                default:
                    entity = null;
                    break;
            }
            return entity;
        }
    }
}
