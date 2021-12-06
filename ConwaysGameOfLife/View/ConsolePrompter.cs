using System;

namespace ConwaysGameOfLife.View
{
    public class ConsolePrompter : IPrompter
    {
        public void DisplayWelcomeMessage()
        {
            Console.WriteLine(GameInstructions.WelcomeMessage);
        }

        public void NumberOfRowsPrompt()
        {
            Console.WriteLine(GameInstructions.AskForRows);
        }

        public void NumberOfColumnsPrompt()
        {
            Console.WriteLine(GameInstructions.AskForColumns);
        }

        public void InitialStatePrompt()
        {
            Console.WriteLine(GameInstructions.AskForLivingCellCoordinates);
        }

        public void ReEnterPrompt()
        {
            Console.WriteLine(GameInstructions.AskToReEnter);
        }
    }
}