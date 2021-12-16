using System;
using ConwaysGameOfLife.Source.Entities;
using ConwaysGameOfLife.Source.Logic;
using ConwaysGameOfLife.Source.Seed_Setup;
using ConwaysGameOfLife.Source.View;

namespace ConwaysGameOfLife.Source
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var factory = new SeedGeneratorFactory();
                var seedGenerator = factory.CreateSeedGenerator(args);
                var seed = seedGenerator.Generate();
                var world = new World(seed);
                var worldRenderer = new ConsoleWorldRenderer();
                var transitionHandler = new TransitionHandler();
                var gameController = new GameController(world, transitionHandler, worldRenderer);
                gameController.RunGame();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}