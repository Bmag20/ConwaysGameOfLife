using System;
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
            try
            {
                var factory = new SeedGeneratorFactory();
                var gameInitializer = factory.CreateGameInitializer(args);
                var seed = gameInitializer.Generate();
                var world = new World(seed);
                var worldRenderer = new ConsoleWorldRenderer();
                var gameController = new GameController(world, worldRenderer);
                gameController.RunGame();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}