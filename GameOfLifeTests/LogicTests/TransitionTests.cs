using System.Linq;
using ConwaysGameOfLife.Source.Entities;
using ConwaysGameOfLife.Source.Logic;
using Xunit;

namespace GameOfLifeTests.LogicTests
{
    public class TransitionTests
    {
        [Fact]
        public void WorldAfterTransition_ShouldContainSameNumberOfCells()
        {
            // Arrange
            var seed = "o...o|o...o|o...o|o...o|o...o";
            var world = new World(seed);
            var expectedNumberOfCells = world.Cells.Count;
            var transition = new TransitionHandler();
            // Act
            transition.ApplyTransition(world);
            // Assert
            Assert.Equal(expectedNumberOfCells, world.Cells.Count);
        }

        [Fact]
        public void WorldAfterTransition_ShouldContainAllDeadCells_WhenWorldIsEmpty()
        {
            // Arrange
            var seed = "........|........|........|........|........";
            var world = new World(seed);
            var transition = new TransitionHandler();
            // Act
            transition.ApplyTransition(world);
            // Assert
            Assert.True(world.Cells.All(cell => !cell.IsAlive));
        }

        // Previous state: (o being alive, . being dead)
        // o . o . .
        // o o o . .
        // o o . . .
        // . . . . o
        // . . o . o

        // Expected state:
        // o . o . o
        // . . o . o
        // . . o . o
        // . o . o o
        // o o . . o
        [Fact]
        public void WorldAfterTransition_ShouldContainCellsWithTransformationsApplied_WhenWorldIsNotEmpty()
        {
            // Arrange
            var seed = "o.o..|ooo..|oo...|....o|..o.o";
            var world = new World(seed);
            var transition = new TransitionHandler();
            // Act
            transition.ApplyTransition(world);
            // Assert
            Assert.True(ExpectedCellsAlive(world));
            Assert.True(ExpectedCellsDead(world));
        }
        private static bool ExpectedCellsAlive(World world)
        {
            return world.GetCellAt(new Coordinate(1, 1)).IsAlive &
                   world.GetCellAt(new Coordinate(1, 3)).IsAlive &
                   world.GetCellAt(new Coordinate(1, 5)).IsAlive &
                   world.GetCellAt(new Coordinate(2, 3)).IsAlive &
                   world.GetCellAt(new Coordinate(2, 5)).IsAlive &
                   world.GetCellAt(new Coordinate(3, 3)).IsAlive &
                   world.GetCellAt(new Coordinate(3, 5)).IsAlive &
                   world.GetCellAt(new Coordinate(4, 2)).IsAlive &
                   world.GetCellAt(new Coordinate(4, 4)).IsAlive &
                   world.GetCellAt(new Coordinate(4, 5)).IsAlive &
                   world.GetCellAt(new Coordinate(5, 1)).IsAlive &
                   world.GetCellAt(new Coordinate(5, 2)).IsAlive &
                   world.GetCellAt(new Coordinate(5, 5)).IsAlive;
        }
        private static bool ExpectedCellsDead(World world)
        {
            return !world.GetCellAt(new Coordinate(1, 2)).IsAlive &
                   !world.GetCellAt(new Coordinate(1, 4)).IsAlive &
                   !world.GetCellAt(new Coordinate(2, 1)).IsAlive &
                   !world.GetCellAt(new Coordinate(2, 2)).IsAlive &
                   !world.GetCellAt(new Coordinate(2, 4)).IsAlive &
                   !world.GetCellAt(new Coordinate(3, 1)).IsAlive &
                   !world.GetCellAt(new Coordinate(3, 2)).IsAlive &
                   !world.GetCellAt(new Coordinate(3, 4)).IsAlive &
                   !world.GetCellAt(new Coordinate(4, 1)).IsAlive &
                   !world.GetCellAt(new Coordinate(4, 3)).IsAlive &
                   !world.GetCellAt(new Coordinate(5, 3)).IsAlive &
                   !world.GetCellAt(new Coordinate(5, 4)).IsAlive;
        }
    }
}