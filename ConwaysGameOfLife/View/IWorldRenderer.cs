using ConwaysGameOfLife.Entities;

namespace ConwaysGameOfLife.View
{
    public interface IWorldRenderer
    {
        void DisplayWorld(World world);
        void DisplayGeneration(int generation);
        void DisplayGameOver();
    }
}