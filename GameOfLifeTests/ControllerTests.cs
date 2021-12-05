using System;
using System.IO;
using ConwaysGameOfLife.Entities;
using ConwaysGameOfLife.Logic;
using ConwaysGameOfLife.View;
using Xunit;

namespace GameOfLifeTests
{
    public class ControllerTests
    {
        private const string AliveSymbol = "😁";
        private const string DeadSymbol = "💀";
        
        [Fact]
         public void RunGame_ShouldDisplayGenerationsUntilThereAreLiveCellsInTheWorld()
         {
             // Arrange
             var output = new StringWriter();
             //Console.Clear();
             Console.SetOut(output);
             output.Flush();
             var consoleDisplay = new ConsoleDisplay();
             var seed = "oo.|o..|...";
             var seedDisplay = $"{AliveSymbol}{AliveSymbol}{DeadSymbol}\n{AliveSymbol}{DeadSymbol}{DeadSymbol}\n{DeadSymbol}{DeadSymbol}{DeadSymbol}";
             var world = new World(seed);
             var controller = new GameController(world, consoleDisplay);
             // next generations will be all alive followed by all dead
             // ooo|ooo|ooo
             var firstGenDisplay = $"{AliveSymbol}{AliveSymbol}{AliveSymbol}\n{AliveSymbol}{AliveSymbol}{AliveSymbol}\n{AliveSymbol}{AliveSymbol}{AliveSymbol}";
             // ...|...|...
             var secondGenDisplay = $"{DeadSymbol}{DeadSymbol}{DeadSymbol}\n{DeadSymbol}{DeadSymbol}{DeadSymbol}\n{DeadSymbol}{DeadSymbol}{DeadSymbol}";
             var expectedOutput = seedDisplay + "\n"+ firstGenDisplay +"\n" + secondGenDisplay + "\n";
             // Act
             controller.RunGame();
             // Assert
             Assert.Equal(expectedOutput, output.ToString());
         }
     }
    
}