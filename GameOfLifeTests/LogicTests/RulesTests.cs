using ConwaysGameOfLife.Source.Entities;
using ConwaysGameOfLife.Source.Logic;
using Xunit;

namespace GameOfLifeTests.LogicTests
{
    public class RulesTests
    {
        [Fact]
        public void LiveCellCheck_ShouldBeFalse_WhenLessThanTwoOrThreeLiveNeighbours()
        {
            // Arrange
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
            var rules = new Rules();
            // Act
            var result = rules.DeadCellCheck(liveNeighborCount);
            // Assert
            Assert.False(result);
        }
    }
}