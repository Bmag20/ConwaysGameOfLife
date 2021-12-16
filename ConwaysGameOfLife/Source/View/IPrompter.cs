namespace ConwaysGameOfLife.Source.View
{
    public interface IPrompter
    {
        void DisplayWelcomeMessage();
        void NumberOfRowsPrompt();
        void NumberOfColumnsPrompt();
        void SeedPrompt();
        void ReEnterPrompt();
        void DisplayErrorMessage(string errorMessage);
    }
}