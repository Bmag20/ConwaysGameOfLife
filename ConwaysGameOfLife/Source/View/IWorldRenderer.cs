using ConwaysGameOfLife.Source.Entities;

namespace ConwaysGameOfLife.Source.View
{
    public interface IWorldRenderer
    {
        void DisplayWorld(World world);
        void DisplayGeneration(int generation);
        void DisplayGameEnded();
    }
}