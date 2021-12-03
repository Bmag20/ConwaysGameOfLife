using ConwaysGameOfLife.Entities;

namespace ConwaysGameOfLife.View
{
    public interface IOutputHandler
    {
        void DisplayWelcomeMessage();
        void NumberOfRowsPrompt();
        void NumberOfColumnsPrompt();
        void InitialStatePrompt();
        void ReEnterPrompt();
        void DisplayWorld(World world);
        void DisplayGeneration(int generation);
        void DisplayGameOver();
    }
}