using ConwaysGameOfLife.Entities;
using ConwaysGameOfLife.Game_setup;
using ConwaysGameOfLife.Logic;
using ConwaysGameOfLife.View;

namespace ConwaysGameOfLife
{
    class Program
    {
        static void Main(string[] args)
        {
            var factory = new GameInitializerFactory();
            var gameInitializer = factory.CreateGameInitializer(args);
            var outputHandler = new ConsoleDisplay();
            var seed = gameInitializer.GenerateSeed();
            var world = new World(seed);
            var gameController = new GameController(world, outputHandler);
            gameController.RunGame(world);
        }
    }
}