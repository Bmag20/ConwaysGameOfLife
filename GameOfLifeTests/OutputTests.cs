using System;
using System.IO;
using ConwaysGameOfLife.Entities;
using ConwaysGameOfLife.View;
using Xunit;

namespace GameOfLifeTests
{
    public class OutputTests
    {
        private const string AliveSymbol = "😁";
        private const string DeadSymbol = "💀";

        [Fact]
        public void DisplayWorld_ShouldPrintCellsToConsole()
        {
            // Arrange
            var output = new StringWriter();
            Console.SetOut(output);
            var world = new World(2,2);
            world.SetAliveAt(new Coordinate(1, 1));
            world.SetAliveAt(new Coordinate(1, 2));
            var outputHandler = new ConsoleDisplay();
            var expectedOutput = $"{AliveSymbol}{AliveSymbol}\n{DeadSymbol}{DeadSymbol}\n";
            // Act
            outputHandler.DisplayWorld(world);
            // Assert
            Assert.Equal(expectedOutput, output.ToString());
        }
    }
}