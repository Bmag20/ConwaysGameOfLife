using System.Collections.Generic;
using System.Linq;
using ConwaysGameOfLife.Entities;
using ConwaysGameOfLife.Logic;
using ConwaysGameOfLife.View;
using Moq;
using Xunit;

namespace GameOfLifeTests.LogicTests
{
    public class ControllerTests
    {

        [Fact]
        public void RunGame_ShouldTickTheWorldAsPerTheRules()
        {
            // Arrange
            var mockDisplay = new MockRenderer();
            var seed = "oo.|o..|...";
            var world = new World(seed);
            var initialState = world.Cells;
            var controller = new GameController(world, mockDisplay);
            // Next generations with the given seed will have all live cells followed by the generation with no live cells
            // ooo|ooo|ooo
            var firstGenWorld = new World("ooo|ooo|ooo");
            // ...|...|...
            var secondGenWorld = new World("...|...|...");
            
            // Act
            controller.RunGame();
            // Assert
            Assert.True(IsSameWorldState(mockDisplay.WorldStatesToDisplay[0], initialState));
            Assert.True(IsSameWorldState(mockDisplay.WorldStatesToDisplay[1], firstGenWorld.Cells));
            Assert.True(IsSameWorldState(mockDisplay.WorldStatesToDisplay[2], secondGenWorld.Cells));
        }

        private bool IsSameWorldState(List<Cell> world1, List<Cell> world2)
        {
            return !world1.Where((t, i) => t.IsAlive != world2[i].IsAlive).Any();
        }

        [Fact]
        public void RunGame_ShouldDisplayWorldTillThereAreNoLiveCellsInTheWorld()
        {
            // Arrange
            var mockRenderer = new Mock<IWorldRenderer>();
            var seed = "oo.|o..|...";
            var world = new World(seed);
            var controller = new GameController(world, mockRenderer.Object);
            // Next generations with the given seed will have all live cells followed by the generation with no live cells
            var totalGenerations = 3; // Including seed
            
            // Act
            controller.RunGame();
            // Assert
            mockRenderer.Verify(r => r.DisplayWorld(world), Times.Exactly(totalGenerations));
        }
        
        private class MockRenderer : IWorldRenderer
         {
             public readonly List<List<Cell>> WorldStatesToDisplay = new();

             public void DisplayWorld(World world)
             {
                 var cells = world.Cells;
                 WorldStatesToDisplay.Add(cells);
             }

             public void DisplayGeneration(int generation)
             {
             }

             public void DisplayGameEnded()
             {
             }
         }

    }
    
}