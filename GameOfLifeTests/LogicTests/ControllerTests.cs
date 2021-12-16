using System.Collections.Generic;
using System.Linq;
using ConwaysGameOfLife.Source.Entities;
using ConwaysGameOfLife.Source.Logic;
using ConwaysGameOfLife.Source.View;
using Moq;
using Xunit;

namespace GameOfLifeTests.LogicTests
{
    public class ControllerTests
    {
        [Fact]
        public void RunGame_ShouldDisplayWorldWithInitialState()
        {
            // Arrange
            var mockDisplay = new MockRenderer();
            var world = new World("...|ooo|...");
            var initialState = world.Cells;
            var transitionHandler = new TransitionHandler();
            var controller = new GameController(world, transitionHandler, mockDisplay);
            // Act
            controller.RunGame();
            // Assert
            Assert.True(IsSameWorldState(mockDisplay.WorldStatesToDisplay[0], initialState));
        }
        
        private bool IsSameWorldState(List<Cell> world1, List<Cell> world2)
        {
            return !world1.Where((t, i) => t.IsAlive != world2[i].IsAlive).Any();
        }

        [Fact]
        public void RunGame_ShouldDisplayWorldWithNextState()
        {
            // Arrange
            var mockDisplay = new MockRenderer();
            var world = new World("...|ooo|...");
            var transitionHandler = new TransitionHandler();
            var controller = new GameController(world, transitionHandler, mockDisplay);
            var expectedWorld = new World("...|ooo|...");
            transitionHandler.ApplyTransition(expectedWorld);
            // Act
            controller.RunGame();
            // Assert
            Assert.True(IsSameWorldState(mockDisplay.WorldStatesToDisplay[1], expectedWorld.Cells));
        }

        [Fact]
        public void RunGame_ShouldDisplayWorldTillThereAreNoLiveCellsInTheWorld()
        {
            // Arrange
            var mockRenderer = new Mock<IWorldRenderer>();
            var seed = "oo.|o..|...";
            var world = new World(seed);
            var transition = new TransitionHandler();
            var controller = new GameController(world, transition, mockRenderer.Object);
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