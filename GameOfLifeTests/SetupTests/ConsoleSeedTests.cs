using ConwaysGameOfLife.Source.Seed_Setup;
using ConwaysGameOfLife.Source.View;
using Moq;
using Xunit;

namespace GameOfLifeTests.SetupTests
{
    public class ConsoleSeedTests
    {
        [Fact]
        public void SetUpWorld_ShouldReturnNonNullSeed_WhenCalled()
        {
            // Arrange
            var inputMock = new Mock<IInputHandler>();
            var outputMock = new Mock<IPrompter>();
            var inputRows = 3;
            var inputColumns = 5;
            var inputSeed = "o.o.o|o.o.o|o.o.o";
            inputMock.SetupSequence(x => x.GetUserInput()).Returns($"{inputRows}")
                .Returns($"{inputColumns}").Returns(inputSeed);
            var consoleSeedGenerator = new ConsoleSeedGenerator(inputMock.Object, outputMock.Object);
            // Act
            var seed = consoleSeedGenerator.Generate();
            // Assert
            Assert.NotNull(seed);
        }

        [Fact]
        public void SetUpWorld_ShouldReturnSeedGivenByUser_WhenUserInputsValidSeed()
        {
            // Arrange
            var inputMock = new Mock<IInputHandler>();
            var inputRows = 3;
            var inputColumns = 5;
            var inputSeed = "o.o.o|o.o.o|o.o.o";
            inputMock.SetupSequence(x => x.GetUserInput()).Returns($"{inputRows}")
                .Returns($"{inputColumns}").Returns(inputSeed);
            var outputMock = new Mock<IPrompter>();
            var consoleSeedGenerator = new ConsoleSeedGenerator(inputMock.Object, outputMock.Object);
            // Act
            var world = consoleSeedGenerator.Generate();
            // Assert
            Assert.Equal(world, inputSeed);
        }

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
            var consoleSeedGenerator = new ConsoleSeedGenerator(inputMock.Object, outputMock.Object);
            // Act
            consoleSeedGenerator.Generate();
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
            var consoleSeedGenerator = new ConsoleSeedGenerator(inputMock.Object, outputMock.Object);
            // Act
            consoleSeedGenerator.Generate();
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
            var consoleSeedGenerator = new ConsoleSeedGenerator(inputMock.Object, outputMock.Object);
            // Act
            consoleSeedGenerator.Generate();
            // Assert
            inputMock.Verify(iMock => iMock.GetUserInput(), Times.Exactly(expectedNumberOfCallsToGetUserInput));
        }
    }
}