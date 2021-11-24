using System.Collections.Generic;
using System.Threading;
using ConwaysGameOfLife.Entities;
using ConwaysGameOfLife.View;

namespace ConwaysGameOfLife.Logic
{
    public class GameController
    {
        private readonly IInputHandler _inputHandler;
        private readonly IOutputHandler _outputHandler;

        public GameController(IInputHandler inputObject, IOutputHandler outputObject)
        {
            _inputHandler = inputObject;
            _outputHandler = outputObject;
        }

        public World SetUpWorld()
        {
            _outputHandler.DisplayWelcomeMessage();
            var rows = GetRowsFromUser();
            var columns = GetColumnsFromUser();
            var world = new World(rows, columns);
            var liveCellCoordinates = GetLiveCellCoordinatesFromUser();
            // Move to world
            foreach (var cellCoordinate in liveCellCoordinates)
            {
                world.GetCellAt(cellCoordinate).IsAlive = true;
            }
            return world;
        }

        private List<Coordinate> GetLiveCellCoordinatesFromUser()
        {
            var coordinates = new List<Coordinate>();
            _outputHandler.AskForLivingCellCoordinates();
            var initialState = _inputHandler.GetUserInput();
            var initialStateArray = initialState.Split(' ');
            foreach (var t in initialStateArray)
            {
                var cell = t.Split(',');
                var row = int.Parse(cell[0]);
                var column = int.Parse(cell[1]);
                coordinates.Add(new Coordinate(row, column));
            }

            return coordinates;
        }

        private int GetRowsFromUser()
        {
            _outputHandler.AskForNumberOfRows();
            var rows = GetValidUserInput();
            return rows;
        }
        private int GetColumnsFromUser()
        {
            _outputHandler.AskForNumberOfColumns();
            var columns = GetValidUserInput();
            return columns;
        }

        private int GetValidUserInput()
        {
            var userInput = _inputHandler.GetUserInput();
            while (!InputValidator.IsValidNumber(userInput, 20)) // make it constant
            {
                _outputHandler.InvalidInput();
                userInput = _inputHandler.GetUserInput();
            }
            return int.Parse(userInput);
        }

        public void RunGame(World world)
        {
            _outputHandler.DisplayWorld(world);
            while (!world.IsEmpty())
            {
                world.Tick();
                Thread.Sleep(1000); // change to constant or argument
                _outputHandler.DisplayWorld(world);
            }
        }
    }
}