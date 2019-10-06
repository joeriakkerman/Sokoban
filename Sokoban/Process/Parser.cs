using Sokoban.Model;
using System;
using System.IO;
using Sokoban.Model.Tiles;
using Sokoban.Model.Entities;

namespace Sokoban.Process
{
    class Parser
    {

        public static Maze ParseMazeFromFile(int mazeId)
        {
            string file = @"./Resources/doolhof" + mazeId + ".txt";
            if (!File.Exists(file)) throw new Exception("Could not find file: '" + Path.GetFullPath(file) + "'");
            string[] lines = File.ReadAllLines(file);

            int columns = lines[0].Length, rows = lines.Length;
            Tile firstTile = null;
            Tile[] tiles = new Tile[columns * rows];
            Truck truck = null;
            Employee employee = null;

            //parse file to maze tiles + entities
            for(int y = 0; y < lines.Length; y++)
            {
                for (int x = 0; x < lines[y].Length; x++)
                {
                    Entity entity = null;
                    char c = lines[y][x];
                    if (c == '#') c = Wall.tileChar;
                    else if (c == 'o') 
                    {
                        c = Floor.tileChar;
                        entity = Entity.CreateEntity(Crate.entityChar);
                    }
                    else if (c == '@')
                    {
                        c = Floor.tileChar;
                        entity = Entity.CreateEntity(Truck.entityChar);
                        truck = ((Truck)entity);
                    }
                    else if (c == '$')
                    {
                        c = Floor.tileChar;
                        entity = Entity.CreateEntity(Employee.entityChar);
                        employee = ((Employee)entity);
                    }
                    tiles[y * columns + x] = Tile.CreateTile(c, entity);
                    if (entity != null) tiles[y * columns + x].EntityOnTile.TileOnPosition = tiles[y * columns + x];
                }
            }

            //create double linked list
            for (int y = 0; y < rows; y++)
            {
                for (int x = 0; x < columns; x++)
                {
                    if (tiles[y * columns + x] == null) continue;
                    tiles[y * columns + x].Left = (x > 0) ? tiles[y * columns + x - 1] : null;
                    tiles[y * columns + x].Up = (y > 0) ? tiles[(y-1) * columns + x] : null;
                    tiles[y * columns + x].Right = (x < columns-1) ? tiles[y * columns + x + 1] : null;
                    tiles[y * columns + x].Down = (y < rows-1) ? tiles[(y + 1) * columns + x] : null;
                }
            }
            firstTile = tiles[0];

            if (columns == 0 || rows == 0 || firstTile == null) throw new Exception("File is corrupt");
            Maze maze = new Maze(firstTile, columns, rows);
            maze.Truck = truck;
            maze.Employee = employee;
            return maze;
        }
    }
}
