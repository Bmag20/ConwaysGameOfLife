using System.Linq;
using ConwaysGameOfLife;
using Xunit;

namespace GameOfLifeTests
{
    public class UnitTest1
    {
        private const int Rows = 10;
        private const int Columns = 10;
        private readonly Position _validPosition = new(1, 1);

        [Fact]
        public void World_ShouldContain100Cells_WhenInitialisedWith10RowsAnd10Columns()
        {
            // Arrange
            var rows = 10;
            var columns = 10;
            var world = new World(rows, columns);
            var expectedCellCount = rows * columns;
            // Act
            var result = world.Cells.Count;
            // Assert
            Assert.Equal(expectedCellCount, result);
        }

        [Fact]
        public void NewWorld_ShouldHaveNoLiveCells()
        {
            // Arrange
            var world = new World(Rows, Columns);
            // Act
            var result = world.Cells.All(c => c.IsAlive == false);
            // Assert
            Assert.True(result);
        }
        
        [Fact]
        public void World_ShouldHaveLiveCell_WhenCellIsSetToAlive()
        {
            // Arrange
            var world = new World(Rows, Columns);
            var position = _validPosition;
            // Act
            world.SetAliveAt(position);
            // Assert
            //Assert.True(world.Cells.First(c => c.X == 1 && c.Y == 1).IsAlive);
            Assert.True(world.GetCellAt(position).IsAlive);
        }
        
        
        
        [Fact]
        public void World_ShouldThrowException_WhenCellIsSetToAliveUsingIncorrectCoordinates()
        {
            // Arrange
            var world = new World(10, 10);
            // Act
            var exception = Record.Exception(() => world.SetAliveAt(new Position(11, 11)));
            // Assert
            Assert.IsType<InvalidCellException>(exception);
        }

    }
}