using System;
using System.IO;
using ConwaysGameOfLife.Entities;
using ConwaysGameOfLife.View;
using Xunit;

namespace GameOfLifeTests.ViewTests
{
    public class RendererTests
    {
        private const string AliveSymbol = "😁";
        private const string DeadSymbol = "💀";
        
        [Fact]
        public void DisplayWorld_ShouldPrintCellsToConsole()
        {
            // Arrange
            var output = new StringWriter();
            Console.SetOut(output);
            var seed = "oo|..";
            var world = new World(seed);
            var outputHandler = new ConsoleWorldRenderer();
            var expectedOutput = $"{AliveSymbol}{AliveSymbol}\n{DeadSymbol}{DeadSymbol}\n";
            // Act
            outputHandler.DisplayWorld(world);
            // Assert
            Assert.Equal(expectedOutput, output.ToString());
        }
    }
}