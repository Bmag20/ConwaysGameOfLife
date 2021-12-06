using ConwaysGameOfLife.View;

namespace ConwaysGameOfLife.Game_setup
{
    public class ConsoleGameInitializer : ISeedInitializer
    {
        private readonly IInputHandler _inputHandler;
        private readonly IPrompter _outputHandler;

        public ConsoleGameInitializer(IInputHandler inputObject, IPrompter outputObject)
        {
            _inputHandler = inputObject;
            _outputHandler = outputObject;
        }

        public string GenerateSeed()
        {
            _outputHandler.DisplayWelcomeMessage();
            var rows = GetRowsFromUser();
            var columns = GetColumnsFromUser();
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
        

    }
}