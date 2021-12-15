using ConwaysGameOfLife.Entities;
using ConwaysGameOfLife.Logic;
using Xunit;

namespace GameOfLifeTests.LogicTests
{
    public class RulesTests
    {
        private readonly Coordinate _validPosition = new(1, 1);

        [Fact]
        public void LiveCellCheck_ShouldBeFalse_WhenLessThanTwoOrThreeLiveNeighbours()
        {
            // Arrange
            var cell = new Cell(_validPosition);
            var liveNeighborCount = 1;
            var rules = new Rules();
            // Act
            var result = rules.LiveCellCheck(liveNeighborCount);
            // Assert
            Assert.False(result);
        }

        [Theory]
        [InlineData(2)]
        [InlineData(3)]
        public void LiveCellCheck_ShouldBeTrue_WhenTwoOrThreeLiveNeighbours(int liveNeighborCount)
        {
            // Arrange
            var cell = new Cell(_validPosition);
            var rules = new Rules();
            // Act
            var result = rules.LiveCellCheck(liveNeighborCount);
            // Assert
            Assert.True(result);
        }

        [Fact]
        public void LiveCellCheck_ShouldBeFalse_WhenMoreThanThreeLiveNeighbours()
        {
            // Arrange
            var cell = new Cell(_validPosition);
            var liveNeighborCount = 4;
            var rules = new Rules();
            // Act
            var result = rules.LiveCellCheck(liveNeighborCount);
            // Assert
            Assert.False(result);
        }

        [Fact]
        public void DeadCellCheck_ShouldBeTrue_WhenExactlyThreeLiveNeighbours()
        {
            // Arrange
            var cell = new Cell(_validPosition);
            var liveNeighborCount = 3;
            var rules = new Rules();
            // Act
            var result = rules.DeadCellCheck(liveNeighborCount);
            // Assert
            Assert.True(result);
        }

        [Theory]
        [InlineData(2)]
        [InlineData(4)]
        public void DeadCellCheck_ShouldBeFalse_WhenTwoOrFourLiveNeighbours(int liveNeighborCount)
        {
            // Arrange
            var cell = new Cell(_validPosition);
            var rules = new Rules();
            // Act
            var result = rules.DeadCellCheck(liveNeighborCount);
            // Assert
            Assert.False(result);
        }
    }
}