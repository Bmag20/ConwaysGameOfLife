using ConwaysGameOfLife.Entities;
using ConwaysGameOfLife.Logic;

namespace ConwaysGameOfLife.View
{
    public interface IOutputHandler
    {
        void DisplayWelcomeMessage();
        void NumberOfRowsPrompt();
        void NumberOfColumnsPrompt();
        void InitialStatePrompt();
        void DisplayWorld(World world);
        void DisplayGeneration(int generation);
        void DisplayGameOver();
        void InvalidInput();
    }
}