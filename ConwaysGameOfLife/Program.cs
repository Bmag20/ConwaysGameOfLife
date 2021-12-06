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
            var factory = new GameInitializerFactory();
            try
            {
                var gameInitializer = factory.CreateGameInitializer(args);
                var seed = gameInitializer.GenerateSeed();
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