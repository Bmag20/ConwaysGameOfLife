using System;
using ConwaysGameOfLife.Entities;

namespace ConwaysGameOfLife.View
{
    public class ConsoleWorldRenderer : IWorldRenderer
    {
        public void DisplayWorld(World world)
        {
            Console.Clear();
            for (var i = 1; i <= world.Rows; i++)
            {
                for (var j = 1; j <= world.Columns; j++)
                {
                    Console.Write(world.GetCellAt(new Coordinate(i, j)).IsAlive ? "😁" : "💀");
                }

                Console.WriteLine();
            }
        }

        public void DisplayGeneration(int generation)
        {
            Console.WriteLine($"Generation: {generation}");
        }

        public void DisplayGameOver()
        {
            Console.WriteLine(GameInstructions.GameOver);
        }
    }
}