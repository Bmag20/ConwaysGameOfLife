using System.Collections.Generic;
using System.Linq;
using ConwaysGameOfLife.Exceptions;
using ConwaysGameOfLife.Game_setup;
using ConwaysGameOfLife.Logic;
using Xunit;

namespace GameOfLifeTests
{
    public class RandomSeedGeneratorTests
    {
        [Fact]
        public void Generate_ReturnsRandomSeedWithGivenNumberOfRows_WhenInitialisedWithValidRowsAndColumns()
        {
            // Arrange
            var rows = 3;
            var columns = 3;
            var randomSeedGenerator = new RandomSeedInitializer(rows, columns);
            // Act
            var seed = randomSeedGenerator.GenerateSeed();
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
            var randomSeedGenerator = new RandomSeedInitializer(rows, columns);
            // Act
            var seed = randomSeedGenerator.GenerateSeed();
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
            var randomSeedGenerator = new RandomSeedInitializer(rows, columns);
            // Act
            var seed = randomSeedGenerator.GenerateSeed();
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
        public void Generate_ThrowsInvalidSeedException_WhenInitialisedWithInvalidRowsAndColumns(int rows, int columns)
        {
            // Arrange
            var randomSeedGenerator = new RandomSeedInitializer(rows, columns);
            // Act and Assert
            Assert.Throws<InvalidDimensionException>(() => randomSeedGenerator.GenerateSeed());
        }
    }
}