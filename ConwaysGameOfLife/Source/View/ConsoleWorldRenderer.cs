using System;
using ConwaysGameOfLife.Source.Entities;

namespace ConwaysGameOfLife.Source.View
{
    public class ConsoleWorldRenderer : IWorldRenderer
    {
        private readonly string _aliveCellDisplayCharacter = "😁";
        private readonly string _deadCellDisplayCharacter = "💀";
        public void DisplayWorld(World world)
        {
            Console.Clear();
            for (var i = 1; i <= world.Rows; i++)
            {
                for (var j = 1; j <= world.Columns; j++)
                {
                    Console.Write(world.GetCellAt(new Coordinate(i, j)).IsAlive ? _aliveCellDisplayCharacter 
                        : _deadCellDisplayCharacter);
                }

                Console.WriteLine();
            }
        }

        public void DisplayGeneration(int generation)
        {
            Console.WriteLine($"Generation: {generation}");
        }

        public void DisplayGameEnded()
        {
            Console.WriteLine(GameInstructions.GameOver);
        }
    }
}