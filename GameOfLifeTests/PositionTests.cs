using ConwaysGameOfLife;
using Xunit;

namespace GameOfLifeTests
{
    public class PositionTests
    {
        [Fact]
        public void Equality_ShouldBeTrue_WhenTwoPositionsHaveSameCoordinates()
        {
            // Arrange
            var position1 = new Position(1, 1);
            var position2 = new Position(1, 1);
            // Act
            var result = position1 == position2;
            // Assert
            Assert.True(result);
        }

        [Theory]
        [InlineData(1, 2)]
        [InlineData(2, 1)]
        [InlineData(2, 2)]
        public void Equality_ShouldBeFalse_WhenTwoPositionsHaveDifferentCoordinates(int x, int y)
        {
            // Arrange
            var position1 = new Position(1, 1);
            var position2 = new Position(x, y);
            // Act
            var result = position1 == position2;
            // Assert
            Assert.False(result);
        }

        [Fact]
        public void Equality_ShouldBeFalse_WhenComparedToANullObject()
        {
            // Arrange
            var position = new Position(1, 1);
            // Act
            var result = position.Equals(null);
            // Assert
            Assert.False(result);
        }
    }
}