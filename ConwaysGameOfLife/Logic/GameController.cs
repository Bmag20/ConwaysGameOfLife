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
            var seed = GetValidSeed(rows, columns);
            world.SetInitialState(seed, GameConstants.AliveSymbol, GameConstants.rowSeparator);
            return world;
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
                    InputValidator.ValidateDimension(userInput, GameConstants.MaximumGridSize);
                    return int.Parse(userInput);
                }
                catch
                {
                    _outputHandler.InvalidInput();
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
                    InputValidator.ValidateWorld(initialState, rows, columns, GameConstants.AliveSymbol,
                        GameConstants.DeadSymbol, GameConstants.rowSeparator);
                    return initialState;
                }
                catch
                {
                    _outputHandler.InvalidInput();
                }
            }
        }

        public void RunGame(World world)
        {
            _outputHandler.DisplayWorld(world);
            while (!world.IsEmpty())
            {
                world.Tick();
                Thread.Sleep(GameConstants.TickDelayInMilliSeconds);
                _outputHandler.DisplayWorld(world);
            }
        }
    }
}