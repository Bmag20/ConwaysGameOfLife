using System.Collections.Generic;
using System.Linq;
using ConwaysGameOfLife.Source.Entities;
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
        public void HasAliveCells_ShouldReturnTrue_WhenWorldHasNoLiveCells()
        {
            // Arrange
            var seed = "...|...|...";
            var world = new World(seed);
            // Act
            var result = world.HasAliveCells();
            // Assert
            Assert.True(result);
        }

        [Fact]
        public void HasAliveCells_ShouldReturnFalse_WhenWorldHasAtLeast1LiveCell()
        {
            // Assert
            var seed = "o..|...|...";
            var world = new World(seed);
            // Act
            var result = world.HasAliveCells();
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
    }
}