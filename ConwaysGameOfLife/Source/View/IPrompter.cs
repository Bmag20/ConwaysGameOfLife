namespace ConwaysGameOfLife.Source.View
{
    public interface IPrompter
    {
        void DisplayWelcomeMessage();
        void NumberOfRowsPrompt();
        void NumberOfColumnsPrompt();
        void InitialStatePrompt();
        void ReEnterPrompt();
        void DisplayErrorMessage(string errorMessage);
    }
}