using ConwaysGameOfLife.Entities;
using ConwaysGameOfLife.View;

namespace ConwaysGameOfLife.Game_setup
{
    public class ConsoleGameInitializer : ISeedInitializer
    {
        private readonly IInputHandler _inputHandler;
        private readonly IOutputHandler _outputHandler;

        public ConsoleGameInitializer(IInputHandler inputObject, IOutputHandler outputObject)
        {
            _inputHandler = inputObject;
            _outputHandler = outputObject;
        }

        public string GenerateSeed()
        {
            _outputHandler.DisplayWelcomeMessage();
            var rows = GetRowsFromUser();
            var columns = GetColumnsFromUser();
            var world = new World(rows, columns);
            var seed = GetValidSeed(rows, columns);
            return seed;
        }
        
        private int GetRowsFromUser()
        {
            _outputHandler.NumberOfRowsPrompt();

            var rows = GetValidUserInput();
            return rows;
        }

        private int GetColumnsFromUser()
        {
            _outputHandler.NumberOfColumnsPrompt();

            var columns = GetValidUserInput();
            return columns;
        }

        private int GetValidUserInput()
        {
            while (true)
            {
                try
                {
                    var userInput = _inputHandler.GetUserInput();
                    InputValidator.ValidateDimension(userInput);
                    return int.Parse(userInput);
                }
                catch
                {
                    _outputHandler.ReEnterPrompt();
                }
            }
        }

        private string GetValidSeed(int rows, int columns)
        {
            _outputHandler.InitialStatePrompt();
            while (true)
            {
                try
                {
                    var initialState = _inputHandler.GetUserInput();
                    InputValidator.ValidateWorld(initialState, rows, columns);
                    return initialState;
                }
                catch
                {
                    // Display exception message here for better readability
                    _outputHandler.ReEnterPrompt();
                }
            }
        }
        
        // private void SetInitialState(World world, string seed, char aliveSymbol, char rowSeparator)
        // {
        //     var seedRows = seed.Split(rowSeparator);
        //     for (var i = 0; i < world.Rows; i++)
        //     {
        //         var rowCells = seedRows[i];
        //         for (var j = 0; j < world.Columns; j++)
        //         {
        //             var cell = world.GetCellAt(new Coordinate(i + 1, j + 1));
        //             cell.IsAlive = rowCells[j] == aliveSymbol;
        //         }
        //     }
        // }

    }
}