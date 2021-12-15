using System.Collections.Generic;
using System.Linq;
using ConwaysGameOfLife.Entities;
using Xunit;

namespace GameOfLifeTests.EntityTests
{
    public class WorldTests
    {

        [Fact]
        public void World_ShouldReturnNonNullObject_WhenASeedIsGiven()
        {
            // Arrange
            var seed = "o..|...|oo.";
            // Act
            var world = new World(seed);
            // Assert
            Assert.NotNull(world);
        }

        [Fact]
        public void IsEmpty_ShouldReturnTrue_WhenWorldHasNoLiveCells()
        {
            // Arrange
            var seed = "...|...|...";
            var world = new World(seed);
            // Act
            var result = world.IsEmpty();
            // Assert
            Assert.True(result);
        }

        [Fact]
        public void IsEmpty_ShouldReturnFalse_WhenWorldHasAtLeast1LiveCell()
        {
            // Assert
            var seed = "o..|...|...";
            var world = new World(seed);
            // Act
            var result = world.IsEmpty();
            // Assert
            Assert.False(result);
        }


        [Fact]
        public void Constructor_ShouldCreateAWorldAsPerTheSeed()
        {
            // Arrange
            var seed = "o...o|o...o|o...o";
            var expectedLiveCellCoordinates = new List<Coordinate>
            {
                new(1, 1), new(1, 5),
                new(2, 1), new(2, 5),
                new(3, 1), new(3, 5)
            };
            // Act
            var world = new World(seed);
            // Assert
            Assert.Equal(expectedLiveCellCoordinates, world.Cells.Where(c => c.IsAlive).Select(c => c.Position));
        }


        private bool SameNeighbours(List<Cell> expectedNeighbours, List<Cell> actualNeighbours)
        {
            return expectedNeighbours.Count == actualNeighbours.Count
                   && expectedNeighbours.All(actualNeighbours.Contains);
        }

        // o o o
        // o * o
        // o o o
        // * being the cell to be tested, and o being the neighbours
        [Fact]
        public void GetNeighbors_ShouldReturnItsSurrounding8Neighbours_WhenCellIsNotOnFringe()
        {
            // Arrange
            var seed = "o...o|o...o|o...o|o...o|o...o|o...o|o...o|o...o";
            var world = new World(seed);
            var cell = world.GetCellAt(new Coordinate(2, 2));
            var expectedNeighbours = new List<Cell>
            {
                world.GetCellAt(new Coordinate(1, 1)),
                world.GetCellAt(new Coordinate(1, 2)),
                world.GetCellAt(new Coordinate(1, 3)),
                world.GetCellAt(new Coordinate(2, 1)),
                world.GetCellAt(new Coordinate(2, 3)),
                world.GetCellAt(new Coordinate(3, 1)),
                world.GetCellAt(new Coordinate(3, 2)),
                world.GetCellAt(new Coordinate(3, 3))
            };
            // Act
            var actualNeighbours = world.GetNeighbours(cell);
            // Assert
            Assert.True(SameNeighbours(expectedNeighbours, actualNeighbours));
        }
        
        // . . . . .
        // o o . . o
        // * o . . o
        // o o . . o
        // . . . . .
        // * being the cell to be tested, and o being the neighbours
        [Fact]
        public void GetNeighbors_ShouldReturnItsSurrounding8Neighbours_WhenCellIsOnFringe()
        {
            // Arrange
            var seed = "o...o|o...o|o...o|o...o|o...o";
            var world = new World(seed);
            var cell = world.GetCellAt(new Coordinate(3, 1));
            var expectedNeighbours = new List<Cell>
            {
                world.GetCellAt(new Coordinate(2, 1)),
                world.GetCellAt(new Coordinate(2, 2)),
                world.GetCellAt(new Coordinate(2, 5)),
                world.GetCellAt(new Coordinate(3, 2)),
                world.GetCellAt(new Coordinate(3, 5)),
                world.GetCellAt(new Coordinate(4, 1)),
                world.GetCellAt(new Coordinate(4, 2)),
                world.GetCellAt(new Coordinate(4, 5)),
            };
            // Act
            var actualNeighbours = world.GetNeighbours(cell);
            // Assert
            Assert.True(SameNeighbours(expectedNeighbours, actualNeighbours));
        }
        
        // * o . . o
        // o o . . o
        // . . . . .
        // . . . . .
        // o o . . o
        // * being the cell to be tested, and o being the neighbours
        [Fact]
        public void GetNeighbors_ShouldReturnItsSurrounding8Neighbours_WhenCellIsOnTheCorner()
        {
            // Arrange
            var seed = "o...o|o...o|o...o|o...o|o...o";
            var world = new World(seed);
            var cell = world.GetCellAt(new Coordinate(1, 1));
            var expectedNeighbours = new List<Cell>
            {
                world.GetCellAt(new Coordinate(1, 2)),
                world.GetCellAt(new Coordinate(1, 5)),
                world.GetCellAt(new Coordinate(2, 1)),
                world.GetCellAt(new Coordinate(2, 2)),
                world.GetCellAt(new Coordinate(2, 5)),
                world.GetCellAt(new Coordinate(5, 1)),
                world.GetCellAt(new Coordinate(5, 2)),
                world.GetCellAt(new Coordinate(5, 5)),
            };
            // Act
            var actualNeighbours = world.GetNeighbours(cell);
            // Assert
            Assert.True(SameNeighbours(expectedNeighbours, actualNeighbours));
        }

       
    }
}