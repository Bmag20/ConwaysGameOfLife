using System.IO;
using ConwaysGameOfLife.Exceptions;
using ConwaysGameOfLife.Game_setup;
using ConwaysGameOfLife.Logic;
using Xunit;

namespace GameOfLifeTests.SetupTests
{
    public class FileInitializerTests
    {
        private readonly string testFilePath = "/Users/Bhuvana.Maganti/Documents/Projects/ConwaysGameOfLife/GameOfLifeTests/TestFiles/";
        
        [Fact]
        public void GenerateSeed_ShouldThrowException_WhenFileDoesNotExist()
        {
            // Arrange
            var file = "NonExistentFile.txt";
            var fileInitializer = new FileSeedGenerator(testFilePath+file);

            // Act
            var exception = Record.Exception(() => fileInitializer.Generate());

            // Assert
            Assert.IsType<FileNotFoundException>(exception);
        }
        
        [Fact]
        public void GenerateSeed_ShouldThrowException_WhenFileIsEmpty()
        {
            // Arrange
            var file = "EmptyFile.txt";
            var fileInitializer = new FileSeedGenerator(testFilePath+file);

            // Act
            var exception = Record.Exception(() => fileInitializer.Generate());

            // Assert
            Assert.IsType<InvalidDimensionException>(exception);
        }
        
        [Fact]
        public void GenerateSeed_ShouldThrowException_WhenFileHasInvalidSymbols()
        {
            // Arrange
            var file = "InvalidSymbols.txt";
            var fileInitializer = new FileSeedGenerator(testFilePath+file);

            // Act
            var exception = Record.Exception(() => fileInitializer.Generate());

            // Assert
            Assert.IsType<InvalidSeedException>(exception);
        }
        
        [Fact]
        public void GenerateSeed_ShouldThrowException_WhenFileHasVariedLengthRows()
        {
            // Arrange
            var file = "VariedLengthRows.txt";
            var fileInitializer = new FileSeedGenerator(testFilePath+file);

            // Act
            var exception = Record.Exception(() => fileInitializer.Generate());

            // Assert
            Assert.IsType<InvalidSeedException>(exception);
        }
        
        [Fact]
        public void GenerateSeed_ShouldReturnSeedWithDataInTheFile_GivenAValidFilePath()
        {
            // Arrange
            const string file = "TestPattern.txt";
            var filePath = testFilePath+file;
            var fileInitializer = new FileSeedGenerator(filePath);
            // Act
            var seed = fileInitializer.Generate();
            // Assert
            Assert.True(IsExpectedInitialState(seed, filePath));
        }

        private bool IsExpectedInitialState(string seed, string file)
        {
            var lines = File.ReadAllLines(file);
            var seedFromFile = "";
            foreach (var line in lines)
            {
                seedFromFile += line.Trim() + GameConstants.RowSeparator;
            }
            seedFromFile = seedFromFile.TrimEnd(GameConstants.RowSeparator);
            return seedFromFile.Equals(seed);
        }
    }
}