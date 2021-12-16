using System.Linq;
using ConwaysGameOfLife.Source.Constants;
using ConwaysGameOfLife.Source.Exceptions;
using ConwaysGameOfLife.Source.Seed_Setup;
using Xunit;

namespace GameOfLifeTests.SetupTests
{
    public class RandomSeedGeneratorTests
    {
        [Fact]
        public void Generate_ReturnsRandomSeedWithGivenNumberOfRows_WhenInitialisedWithValidRowsAndColumns()
        {
            // Arrange
            var rows = 3;
            var columns = 3;
            var randomSeedGenerator = new RandomSeedGenerator(rows, columns);
            // Act
            var seed = randomSeedGenerator.Generate();
            // Assert
            Assert.Equal(rows, GetRows(seed));
        }

        private int GetRows(string seed)
        {
            return seed.Count(c => c == GameConstants.RowSeparator) + 1; // +1 for the last row
        }
        
        [Fact]
        public void Generate_ReturnsRandomSeedWithGivenNumberOfColumns_WhenInitialisedWithValidRowsAndColumns()
        {
            // Arrange
            var rows = 3;
            var columns = 3;
            var randomSeedGenerator = new RandomSeedGenerator(rows, columns);
            // Act
            var seed = randomSeedGenerator.Generate();
            // Assert
            Assert.True(HasCorrectColumns(seed, columns));
        }

        private bool HasCorrectColumns(string seed, int columns)
        {
            return seed.Split(GameConstants.RowSeparator).All(row => row.Length == columns);
        }
        
        [Fact]
        public void Generate_ReturnsSeedWithAliveSymbolsAndDeadSymbols_WhenInitialisedWithValidRowsAndColumns()
        {
            // Arrange
            var rows = 3;
            var columns = 3;
            var randomSeedGenerator = new RandomSeedGenerator(rows, columns);
            // Act
            var seed = randomSeedGenerator.Generate();
            // Assert
            Assert.True(HasCorrectSymbols(seed));
        }

        private bool HasCorrectSymbols(string seed)
        {
            return seed.All(c => c is GameConstants.AliveSymbol or GameConstants.DeadSymbol or GameConstants.RowSeparator);
        }
        
        [Theory]
        [InlineData(0, 0)]
        [InlineData(0, 1)]
        [InlineData(1, 0)]
        [InlineData(100, 5)]
        [InlineData(5, 100)]
        public void Generate_ThrowsInvalidDimensionException_WhenInitialisedWithInvalidRowsOrColumns(int rows, int columns)
        {
            // Arrange
            var randomSeedGenerator = new RandomSeedGenerator(rows, columns);
            // Act and Assert
            Assert.Throws<InvalidDimensionException>(() => randomSeedGenerator.Generate());
        }
    }
}