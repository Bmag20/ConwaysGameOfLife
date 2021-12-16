using ConwaysGameOfLife.Source.Entities;
using Xunit;

namespace GameOfLifeTests.EntityTests
{
    public class CoordinateTests
    {
        [Fact]
        public void Equality_ShouldBeTrue_WhenTwoPositionsHaveSameCoordinates()
        {
            // Arrange
            var coordinate1 = new Coordinate(1, 1);
            var coordinate2 = new Coordinate(1, 1);
            // Act
            var result = coordinate1.Equals(coordinate2);
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
            var coordinate1 = new Coordinate(1, 1);
            var coordinate2 = new Coordinate(x, y);
            // Act
            var result = coordinate1.Equals(coordinate2);
            // Assert
            Assert.False(result);
        }

        [Fact]
        public void Equality_ShouldBeFalse_WhenComparedToANullObject()
        {
            // Arrange
            var coordinate = new Coordinate(1, 1);
            // Act
            var result = coordinate.Equals(null);
            // Assert
            Assert.False(result);
        }
    }
}