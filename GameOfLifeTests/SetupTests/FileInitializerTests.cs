using System.IO;
using ConwaysGameOfLife.Source.Constants;
using ConwaysGameOfLife.Source.Exceptions;
using ConwaysGameOfLife.Source.Seed_Setup;
using Xunit;

namespace GameOfLifeTests.SetupTests
{
    public class FileInitializerTests
    {
        private readonly string testFilePath = "../../../TestData/";
        
        [Fact]
        public void GenerateSeed_ShouldThrowDirectoryNotFoundException_WhenDirectoryDoesNotExist()
        {
            // Arrange
            var file = "NonExistentFile.txt";
            var fakeDirectory = "NonExistentDirectory/";
            var fileInitializer = new FileSeedGenerator(fakeDirectory+file);

            // Act
            var exception = Record.Exception(() => fileInitializer.Generate());

            // Assert
            Assert.IsType<DirectoryNotFoundException>(exception);
        }
        
        [Fact]
        public void GenerateSeed_ShouldThrowFileNotFoundException_WhenFileDoesNotExist()
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
        public void GenerateSeed_ShouldThrowInvalidDimensionException_WhenFileIsEmpty()
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
        public void GenerateSeed_ShouldThrowInvalidSeedException_WhenFileHasInvalidSymbols()
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
        public void GenerateSeed_ShouldThrowInvalidSeedException_WhenFileHasVariedLengthRows()
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