using ConwaysGameOfLife.Source.Exceptions;
using ConwaysGameOfLife.Source.Seed_Setup;
using Xunit;

namespace GameOfLifeTests.SetupTests
{
    public class SeedGeneratorFactoryTests
    {
        [Fact]
        public void CreateGameInitializer_ReturnsConsoleInitializer_WhenArgumentsAreEmpty()
        {
            // Arrange
            var factory = new SeedGeneratorFactory();
            var args = new string[] { };
            // Act
            var initializer = factory.CreateSeedGenerator(args);
            // Assert
            Assert.IsType<ConsoleSeedGenerator>(initializer);
        }
        
        [Fact]
        public void CreateGameInitializer_ReturnsFileInitializer_WhenArgumentsAreFileAndFileName()
        {
            // Arrange
            var factory = new SeedGeneratorFactory();
            var args = new[] {"file", "Glider.txt"};
            // Act
            var initializer = factory.CreateSeedGenerator(args);
            // Assert
            Assert.IsType<FileSeedGenerator>(initializer);
        }
        
        [Fact]
        public void CreateGameInitializer_ReturnsRandomInitializer_WhenArgumentsAreRowsAndColumns()
        {
            // Arrange
            var factory = new SeedGeneratorFactory();
            var args = new [] {"rows", "10", "columns", "10"};
            // Act
            var initializer = factory.CreateSeedGenerator(args);
            // Assert
            Assert.IsType<RandomSeedGenerator>(initializer);
        }
        
        [Theory]
        [InlineData("Glider.txt")]
        [InlineData("rows", "10", "columns", "10", "Glider.txt")]
        [InlineData("rows", "10", "10")]
        public void CreateGameInitializer_ThrowsArgumentException_WhenArgumentsAreNot2Or4(params string[] args)
        {
            // Arrange
            var factory = new SeedGeneratorFactory();
            // Act
            var exception = Record.Exception(() => factory.CreateSeedGenerator(args));
            // Assert
            Assert.IsType<InvalidRunArgumentsException>(exception);
        }
        
        // Valid argument formats:
        // file filename.txt
        // rows 10 columns 10
        [Theory]
        [InlineData("input", "Glider.txt")]
        [InlineData("file", "glider")]
        [InlineData("height", "10", "width", "10")]
        [InlineData("rows", "and", "columns", "10")]
        public void CreateGameInitializer_ThrowsArgumentException_WhenArgumentsAreNotInValidFormat(params string[] args)
        {
            // Arrange
            var factory = new SeedGeneratorFactory();
            // Act
            var exception = Record.Exception(() => factory.CreateSeedGenerator(args));
            // Assert
            Assert.IsType<InvalidRunArgumentsException>(exception);
        }

    }
}