using System;
using ConwaysGameOfLife.Logic;
using ConwaysGameOfLife.View;

namespace ConwaysGameOfLife
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputHandler = new ConsoleReader();
            var outputHandler = new ConsoleDisplay();
            var gameController = new GameController(inputHandler, outputHandler);
            var world = gameController.SetUpWorld();
            gameController.RunGame(world);
        }
    }
}