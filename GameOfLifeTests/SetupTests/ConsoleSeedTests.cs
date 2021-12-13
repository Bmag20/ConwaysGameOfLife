using ConwaysGameOfLife.Game_setup;
using ConwaysGameOfLife.View;
using Moq;
using Xunit;

namespace GameOfLifeTests.SetupTests
{
    public class ConsoleSeedTests
    {
        [Fact]
        public void SetUpWorld_ShouldReturnNonNullWorldObject_WhenCalled()
        {
            // Arrange
            var inputMock = new Mock<IInputHandler>();
            var outputMock = new Mock<IPrompter>();
            var inputRows = 3;
            var inputColumns = 5;
            var inputSeed = "o.o.o|o.o.o|o.o.o";
            inputMock.SetupSequence(x => x.GetUserInput()).Returns($"{inputRows}")
                .Returns($"{inputColumns}").Returns(inputSeed);
            var controller = new ConsoleSeedGenerator(inputMock.Object, outputMock.Object);
            // Act
            var world = controller.Generate();
            // Assert
            Assert.NotNull(world);
        }

        [Fact] public void SetUpWorld_ShouldReturnSeed_WhenUserInputsValidSeed()
         {
             // Arrange
             var inputMock = new Mock<IInputHandler>();
             var inputRows = 3;
             var inputColumns = 5;
             var inputSeed = "o.o.o|o.o.o|o.o.o";
             inputMock.SetupSequence(x => x.GetUserInput()).Returns($"{inputRows}")
                 .Returns($"{inputColumns}").Returns(inputSeed);
             var outputMock = new Mock<IPrompter>();
             var controller = new ConsoleSeedGenerator(inputMock.Object, outputMock.Object);
             // Act
             var world = controller.Generate();
             // Assert
             Assert.Equal(world, inputSeed);
         }
    
//         [Fact]
//         public void SetUpWorld_ShouldReturnWorldWithLiveCellsAtUserGivenCoordinates()
//         {
//             // Arrange
//             var inputMock = new Mock<IInputHandler>();
//             var inputRows = 3;
//             var inputColumns = 5;
//             var inputSeed = "o...o|o...o|o...o";
//             inputMock.SetupSequence(x => x.GetUserInput()).Returns($"{inputRows}")
//                 .Returns($"{inputColumns}").Returns(inputSeed);
//             var expectedLiveCellCoordinates = new List<Coordinate>
//             {
//                 new(1, 1), new(1, 5),
//                 new(2, 1), new(2, 5),
//                 new(3, 1), new(3, 5)
//             };
//             var outputMock = new Mock<IOutputHandler>();
//             var controller = new GameController(inputMock.Object, outputMock.Object);
//             // Act
//             var world = controller.SetUpWorld();
//             // Assert
//             Assert.True(AreCellsAliveAt(world, expectedLiveCellCoordinates));
//         }
//         
//         private static bool AreCellsAliveAt(World world, List<Coordinate> coordinates)
//         {
//             return coordinates.All(c => world.GetCellAt(c).IsAlive);
//         }
//         
//         [Fact]
//         public void SetUpWorld_ShouldReturnWorldWithDeadCellsAtCoordinatesOtherThanUserGivenCoordinates()
//         {
//             // Arrange
//             var inputMock = new Mock<IInputHandler>();
//             var inputRows = 3;
//             var inputColumns = 5;
//             var inputSeed = "o.o.o|o.o.o|o.o.o";
//             inputMock.SetupSequence(x => x.GetUserInput()).Returns($"{inputRows}")
//                 .Returns($"{inputColumns}").Returns(inputSeed);
//             var expectedDeadCellCoordinates = new List<Coordinate>
//             {
//                 new(1, 2), new(1, 4),
//                 new(2, 2), new(2, 4),
//                 new(3, 2), new(3, 4)
//             };
//             var outputMock = new Mock<IOutputHandler>();
//             var controller = new GameController(inputMock.Object, outputMock.Object);
//             // Act
//             var world = controller.SetUpWorld();
//             // Assert
//             Assert.True(AreCellsDeadAt(world, expectedDeadCellCoordinates));
//         }
//         
//         private static bool AreCellsDeadAt(World world, List<Coordinate> coordinates)
//         {
//             return coordinates.All(c => !world.GetCellAt(c).IsAlive);
//         }
//
        [Fact]
        public void SetUpWorld_ShouldReAskForUserInput_WhenInvalidRowsIsGiven()
        {
            // Arrange
            var inputMock = new Mock<IInputHandler>();
            var invalidRowsInput = "0";
            var inputRows = 3;
            var inputColumns = 5;
            var inputSeed = "o.o.o|o.o.o|o.o.o";
            inputMock.SetupSequence(x => x.GetUserInput()).Returns(invalidRowsInput)
                .Returns($"{inputRows}").Returns($"{inputColumns}").Returns(inputSeed);
             
            var regularNumberOfCallsToGetUserInput = 3; // 1 for rows, 1 for columns and 1 for initial state of world
            var invalidInput = 1;
            var expectedNumberOfCallsToGetUserInput = regularNumberOfCallsToGetUserInput + invalidInput;
             
            var outputMock = new Mock<IPrompter>();
            var controller = new ConsoleSeedGenerator(inputMock.Object, outputMock.Object);
            // Act
            var world = controller.Generate();
            // Assert
            inputMock.Verify(iMock => iMock.GetUserInput(), Times.Exactly(expectedNumberOfCallsToGetUserInput));
        }
        
        [Fact]
        public void SetUpWorld_ShouldReAskForUserInput_WhenInvalidColumnsIsGiven()
        {
            // Arrange
            var inputMock = new Mock<IInputHandler>();
            var inputRows = 3;
            var invalidColumnsInput = "";
            var inputColumns = 5;
            var inputSeed = "o.o.o|o.o.o|o.o.o";
            inputMock.SetupSequence(x => x.GetUserInput()).Returns($"{inputRows}")
                .Returns(invalidColumnsInput).Returns($"{inputColumns}").Returns(inputSeed);
             
            var regularNumberOfCallsToGetUserInput = 3; // 1 for rows, 1 for columns and 1 for initial state of world
            var invalidInput = 1;
            var expectedNumberOfCallsToGetUserInput = regularNumberOfCallsToGetUserInput + invalidInput;
             
            var outputMock = new Mock<IPrompter>();
            var controller = new ConsoleSeedGenerator(inputMock.Object, outputMock.Object);
            // Act
            var world = controller.Generate();
            // Assert
            inputMock.Verify(iMock => iMock.GetUserInput(), Times.Exactly(expectedNumberOfCallsToGetUserInput));
        }
        
        [Fact]
        public void SetUpWorld_ShouldReAskForUserInput_WhenInvalidSeedIsGiven()
        {
            // Arrange
            var inputMock = new Mock<IInputHandler>();
            var inputRows = 3;
            var inputColumns = 5;
            var emptySeed = "";
            var invalidSeed = "o.o.o";
            var inputSeed = "o.o.o|o.o.o|o.o.o";
            inputMock.SetupSequence(x => x.GetUserInput())
                .Returns($"{inputRows}").Returns($"{inputColumns}")
                .Returns(emptySeed).Returns(invalidSeed).Returns(inputSeed);
             
            var regularNumberOfCallsToGetUserInput = 3; // 1 for rows, 1 for columns and 1 for initial state of world
            var invalidInput = 2;
            var expectedNumberOfCallsToGetUserInput = regularNumberOfCallsToGetUserInput + invalidInput;
             
            var outputMock = new Mock<IPrompter>();
            var controller = new ConsoleSeedGenerator(inputMock.Object, outputMock.Object);
            // Act
            var world = controller.Generate();
            // Assert
            inputMock.Verify(iMock => iMock.GetUserInput(), Times.Exactly(expectedNumberOfCallsToGetUserInput));
        }

//
//         // [Fact]
//         // public void RunGame_ShouldDisplayGenerationsUntilThereAreLiveCellsInTheWorld()
//         // {
//         //     
//         // }
     }
    
}