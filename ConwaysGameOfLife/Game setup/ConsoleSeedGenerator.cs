using System;
using ConwaysGameOfLife.View;

namespace ConwaysGameOfLife.Game_setup
{
    public class ConsoleSeedGenerator : ISeedGenerator
    {
        private readonly IInputHandler _inputHandler;
        private readonly IPrompter _prompter;

        public ConsoleSeedGenerator(IInputHandler inputObject, IPrompter outputObject)
        {
            _inputHandler = inputObject;
            _prompter = outputObject;
        }

        public string Generate()
        {
            _prompter.DisplayWelcomeMessage();
            var rows = GetRowsFromUser();
            var columns = GetColumnsFromUser();
            var seed = GetValidSeed(rows, columns);
            return seed;
        }
        
        private int GetRowsFromUser()
        {
            _prompter.NumberOfRowsPrompt();

            var rows = GetValidUserInput();
            return rows;
        }

        private int GetColumnsFromUser()
        {
            _prompter.NumberOfColumnsPrompt();

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
                catch(Exception e)
                {
                    _prompter.DisplayErrorMessage(e.Message);
                    _prompter.ReEnterPrompt();
                }
            }
        }

        private string GetValidSeed(int rows, int columns)
        {
            _prompter.InitialStatePrompt();
            while (true)
            {
                try
                {
                    var initialState = _inputHandler.GetUserInput();
                    InputValidator.ValidateSeed(initialState, rows, columns);
                    return initialState;
                }
                catch(Exception e)
                {
                    _prompter.DisplayErrorMessage(e.Message);
                    _prompter.ReEnterPrompt();
                }
            }
        }
        

    }
}