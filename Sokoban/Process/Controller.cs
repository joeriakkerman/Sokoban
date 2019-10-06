using System;
using Sokoban.Model.Entities;
using Sokoban.Model;
using Sokoban.Presentation;

namespace Sokoban.Process
{
    class Controller
    {
        private InputView input;
        private OutputView output;

        private Maze _maze;

        public Controller()
        {
            input = new InputView();
            output = new OutputView();

            output.ShowWelcomeScreen();
            int mazeId = input.GetIntegerWithinRange("Kies een doolhof (1 - 6), s = stop", 1, 6);

            LoadMaze(mazeId);

            while (!_maze.HasFinished())
            {
                output.ShowMaze(_maze.MazeToString());
                ConsoleKey c = input.GetSingleKey("gebruik pijltjestoetsen (s = stop, r = reset)");
                switch (c)
                {
                    case ConsoleKey.S:
                        new Controller();
                        break;
                    case ConsoleKey.R:
                        LoadMaze(mazeId);
                        break;
                    case ConsoleKey.RightArrow:
                        _maze.Truck.Move(Entity.Direction.RIGHT);
                        if (_maze.Employee != null) _maze.Employee.action();
                        break;
                    case ConsoleKey.DownArrow:
                        _maze.Truck.Move(Entity.Direction.DOWN);
                        if (_maze.Employee != null) _maze.Employee.action();
                        break;
                    case ConsoleKey.LeftArrow:
                        _maze.Truck.Move(Entity.Direction.LEFT);
                        if (_maze.Employee != null) _maze.Employee.action();
                        break;
                    case ConsoleKey.UpArrow:
                        _maze.Truck.Move(Entity.Direction.UP);
                        if (_maze.Employee != null) _maze.Employee.action();
                        break;
                }

            }

            output.ShowMaze(_maze.MazeToString());
            output.ShowFinished();
            input.GetSingleKey("press any key to continue");
            new Controller();
        }

        private void LoadMaze(int mazeId)
        {
            try
            {
                _maze = Parser.ParseMazeFromFile(mazeId);
                if (_maze == null)
                {
                    output.ShowException("Er ging iets mis bij het inladen van het doolhofbestand", "");
                    new Controller();
                }

                _maze.Truck = _maze.Truck;
                if(_maze.Truck == null || _maze.Truck.TileOnPosition == null)
                {
                    output.ShowException("Er ging iets mis bij het inladen van het doolhofbestand", "Truck has not been initialized");
                    new Controller();
                }
            }
            catch (Exception e)
            {
                output.ShowException("Er ging iets mis bij het inladen van het doolhofbestand", e.StackTrace);
                new Controller();
            }
        }
    }
}
