using System;
using ConwaysGameOfLife.Entities;
using ConwaysGameOfLife.Logic;

namespace ConwaysGameOfLife.View
{
    public class ConsoleDisplay : IOutputHandler
    {
        public void DisplayWelcomeMessage()
        {
            Console.WriteLine(GameInstructions.WelcomeMessage);
        }

        public void AskForNumberOfRows()
        {
            Console.WriteLine(GameInstructions.AskForRows);
        }

        public void AskForNumberOfColumns()
        {
            Console.WriteLine(GameInstructions.AskForColumns);
        }

        public void AskForLivingCellCoordinates()
        {
            Console.WriteLine(GameInstructions.AskForLivingCellCoordinates);
        }

        public void DisplayWorld(World world)
        {
            Console.Clear();
            for (int i = 1; i <= world.Rows; i++)
            {
                for (int j = 1; j <= world.Columns; j++)
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

        public void InvalidInput()
        {
            Console.WriteLine(GameInstructions.InvalidInput);
        }
    }
}