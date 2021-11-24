using ConwaysGameOfLife.Logic;

namespace ConwaysGameOfLife.View
{
    public interface IOutputHandler
    {
        void DisplayWelcomeMessage();
        void AskForNumberOfRows();
        void AskForNumberOfColumns();
        void AskForLivingCellCoordinates();
        void DisplayWorld(World world);
        void DisplayGeneration(int generation);
        void DisplayGameOver();
        void InvalidInput();
    }
}