using System.Collections.Generic;
using System.Linq;
using ConwaysGameOfLife;
using ConwaysGameOfLife.Entities;
using ConwaysGameOfLife.Logic;
using ConwaysGameOfLife.View;
using Moq;
using Xunit;

namespace GameOfLifeTests
{
    public class ControllerTests
    {
        [Fact]
        public void SetUpWorld_ShouldReturnNonNullWorldObject_WhenCalled()
        {
            // Arrange
            var inputMock = new Mock<IInputHandler>();
            var outputMock = new Mock<IOutputHandler>();
            var expectedRows = 10;
            var expectedColumns = 5;
            var liveCellCoordinate = "1,1";
            inputMock.SetupSequence(x => x.GetUserInput()).Returns($"{expectedRows}")
                .Returns($"{expectedColumns}").Returns(liveCellCoordinate);
            var controller = new GameController(inputMock.Object, outputMock.Object);
            // Act
            var world = controller.SetUpWorld();
            // Assert
            Assert.NotNull(world);
        }
        
        [Fact]
        public void SetUpWorld_ShouldReturnWorldWithUserGivenRows_WhenUserInputsRowsOntoTheConsole()
        {
            // Arrange
            var inputMock = new Mock<IInputHandler>();
            var expectedRows = 10;
            var expectedColumns = 5;
            var liveCellCoordinate = "1,1";
            inputMock.SetupSequence(x => x.GetUserInput()).Returns($"{expectedRows}")
                .Returns($"{expectedColumns}").Returns(liveCellCoordinate);
            var outputMock = new Mock<IOutputHandler>();
            var controller = new GameController(inputMock.Object, outputMock.Object);
            // Act
            var world = controller.SetUpWorld();
            // Assert
            Assert.Equal(world.Rows, expectedRows);
        }
        
        [Fact]
        public void SetUpWorld_ShouldReturnWorldWithUserGivenColumns_WhenUserInputsColumnsOntoTheConsole()
        {
            // Arrange
            var inputMock = new Mock<IInputHandler>();
            var expectedRows = 10;
            var expectedColumns = 5;
            inputMock.SetupSequence(x => x.GetUserInput()).Returns($"{expectedRows}")
                .Returns($"{expectedColumns}").Returns("1,1");
            var outputMock = new Mock<IOutputHandler>();
            var controller = new GameController(inputMock.Object, outputMock.Object);
            // Act
            var world = controller.SetUpWorld();
            // Assert
            Assert.Equal(world.Columns, expectedColumns);
        }
        
        [Fact]
        public void SetUpWorld_ShouldReturnWorldWithLiveCellsAtUserGivenCoordinates()
        {
            // Arrange
            var inputMock = new Mock<IInputHandler>();
            var expectedRows = 5;
            var expectedColumns = 5;
            var expectedLiveCellCoordinates = new List<Coordinate>
            {
                new(1, 1),
                new(3, 3),
                new(5, 5)
            };
            var expectedLiveCellsString = string.Join(" ", expectedLiveCellCoordinates.Select(c => $"{c.X},{c.Y}"));
            inputMock.SetupSequence(x => x.GetUserInput()).Returns($"{expectedRows}")
                .Returns($"{expectedColumns}")
                .Returns($"{expectedLiveCellsString}");
            var outputMock = new Mock<IOutputHandler>();
            var controller = new GameController(inputMock.Object, outputMock.Object);
            // Act
            var world = controller.SetUpWorld();
            // Assert
            Assert.True(AreCellsAliveAt(world, expectedLiveCellCoordinates));
        }
        
        private static bool AreCellsAliveAt(World world, List<Coordinate> coordinates)
        {
            return coordinates.All(c => world.GetCellAt(c).IsAlive);
        }
        
        [Fact]
        public void SetUpWorld_ShouldReturnWorldWithDeadCellsAtCoordinatesOtherThanUserGivenCoordinates()
        {
            // Arrange
            var inputMock = new Mock<IInputHandler>();
            var expectedRows = 5;
            var expectedColumns = 5;
            var expectedLiveCellCoordinates = new List<Coordinate>
            {
                new(1, 1),
                new(3, 3),
                new(5, 5)
            };
            var expectedLiveCellsString = string.Join(" ", expectedLiveCellCoordinates.Select(c => $"{c.X},{c.Y}"));
            inputMock.SetupSequence(x => x.GetUserInput()).Returns($"{expectedRows}")
                .Returns($"{expectedColumns}")
                .Returns($"{expectedLiveCellsString}");
            var outputMock = new Mock<IOutputHandler>();
            var controller = new GameController(inputMock.Object, outputMock.Object);
            // Act
            var world = controller.SetUpWorld();
            // Assert
            Assert.True(AreCellsDeadAt(world, expectedLiveCellCoordinates));
        }
        
        private static bool AreCellsDeadAt(World world, List<Coordinate> coordinates)
        {
            var cells = world.Cells;
            return cells.Where(c => !coordinates.Contains(c.Position)).All(c => !c.IsAlive);
        }

        [Fact]
        public void SetUpWorld_ShouldReAskForUserInput_WhenInvalidInputIsGiven()
        {
            // Arrange
            var inputMock = new Mock<IInputHandler>();
            var invalidRowsInput = "0";
            var validRowsInput = 5;
            var validColumnsInput = 5;
            var validCoordinateInput = "1,1";
            inputMock.SetupSequence(x => x.GetUserInput()).Returns($"{invalidRowsInput}")
                .Returns($"{validRowsInput}").Returns($"{validColumnsInput}").Returns(validCoordinateInput);
            
            var regularNumberOfCallsToGetUserInput = 3; // 3 times for rows, columns and live cell coordinates
            var invalidInput = 1;
            var expectedNumberOfCallsToGetUserInput = regularNumberOfCallsToGetUserInput + invalidInput;
            
            var outputMock = new Mock<IOutputHandler>();
            var controller = new GameController(inputMock.Object, outputMock.Object);
            // Act
            var world = controller.SetUpWorld();
            // Assert
            inputMock.Verify(iMock => iMock.GetUserInput(), Times.Exactly(expectedNumberOfCallsToGetUserInput));
        }


        // [Fact]
        // public void RunGame_ShouldDisplayGenerationsUntilThereAreLiveCellsInTheWorld()
        // {
        //     
        // }
    }
    
}