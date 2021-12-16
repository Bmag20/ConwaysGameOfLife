using System;

namespace ConwaysGameOfLife.Source.View
{
    public class ConsolePrompter : IPrompter
    {
        public void DisplayWelcomeMessage()
        {
            Console.WriteLine(GameInstructions.WelcomeMessage);
        }

        public void NumberOfRowsPrompt()
        {
            Console.WriteLine(GameInstructions.RowsPrompt);
        }

        public void NumberOfColumnsPrompt()
        {
            Console.WriteLine(GameInstructions.ColumnsPrompt);
        }

        public void SeedPrompt()
        {
            Console.WriteLine(GameInstructions.SeedPrompt);
        }

        public void ReEnterPrompt()
        {
            Console.WriteLine(GameInstructions.ReenterPrompt);
        }

        public void DisplayErrorMessage(string errorMessage)
        {
            Console.WriteLine($"{errorMessage}!!");
        }
    }
}