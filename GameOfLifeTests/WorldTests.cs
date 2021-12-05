// using System.Collections.Generic;
// using System.Linq;
// using ConwaysGameOfLife.Entities;
// using Xunit;
//
// namespace GameOfLifeTests
// {
//     public class WorldTests
//     {
//         private const int Rows = 3;
//         private const int Columns = 3;
//         private readonly Coordinate _validPosition = new(1, 1);
//
//         [Fact]
//         public void World_ShouldReturnNonNullObject_WhenASeedIsGiven()
//         {
//             // Arrange
//             var seed = "o..|...|oo.";
//             // Act
//             var world = new World(seed);
//             // Assert
//             Assert.NotNull(world);
//         }
//
//         [Fact]
//         public void IsEmpty_ShouldReturnTrue_WhenWorldHasNoLiveCells()
//         {
//             // Arrange
//             var rows = 2;
//             var columns = 2;
//             var world = new World(rows, columns);
//             world.GetCellAt(new Coordinate(1, 1)).IsAlive = false;
//             world.GetCellAt(new Coordinate(1, 2)).IsAlive = false;
//             world.GetCellAt(new Coordinate(2, 1)).IsAlive = false;
//             world.GetCellAt(new Coordinate(2, 2)).IsAlive = false;
//             // Act
//             var result = world.IsEmpty();
//             // Assert
//             Assert.True(result);
//         }
//
//         [Fact]
//         public void IsEmpty_ShouldReturnFalse_WhenWorldHasAtLeast1LiveCell()
//         {
//             // Assert
//             var rows = 2;
//             var columns = 2;
//             var world = new World(rows, columns);
//             world.GetCellAt(new Coordinate(1, 1)).IsAlive = true;
//             // Act
//             var result = world.IsEmpty();
//             // Assert
//             Assert.False(result);
//         }
//
//         [Fact]
//         public void NewWorld_ShouldBeEmpty()
//         {
//             // Arrange
//             var world = new World(Rows, Columns);
//             // Act
//             var result = world.IsEmpty();
//             // Assert
//             Assert.True(result);
//         }
//
//         [Fact]
//         public void World_ShouldHaveLiveCell_WhenCellIsSetToAlive()
//         {
//             // Arrange
//             var world = new World(Rows, Columns);
//             var position = _validPosition;
//             // Act
//             world.SetAliveAt(position);
//             // Assert
//             Assert.True(world.GetCellAt(position).IsAlive);
//         }
//
//         // [Fact]
//         // public void SetInitialState_ShouldSetTheInitialStateOfTheWorld()
//         // {
//         //     // Arrange
//         //     var rows = 3;
//         //     var columns = 5;
//         //     var world = new World(rows, columns);
//         //     var aliveSymbol = 'o';
//         //     var rowSeparator = '\n';
//         //     var seed = "o...o\no...o\no...o";
//         //     var expectedLiveCellCoordinates = new List<Coordinate>
//         //     {
//         //         new(1, 1), new(1, 5),
//         //         new(2, 1), new(2, 5),
//         //         new(3, 1), new(3, 5)
//         //     };
//         //     // Act
//         //     world.SetInitialState(seed, aliveSymbol, rowSeparator);
//         //     // Assert
//         //     Assert.Equal(expectedLiveCellCoordinates, world.Cells.Where(c => c.IsAlive).Select(c => c.Position));
//         // }
//
//
//         private bool SameNeighbours(List<Cell> expectedNeighbours, List<Cell> actualNeighbours)
//         {
//             return expectedNeighbours.Count == actualNeighbours.Count
//                    && expectedNeighbours.All(actualNeighbours.Contains);
//         }
//
//         // o o o
//         // o * o
//         // o o o
//         // * being the cell to be tested, and o being the neighbours
//         [Fact]
//         public void GetNeighbors_ShouldReturnItsSurrounding8Neighbours_WhenCellIsNotOnFringe()
//         {
//             // Arrange
//             var world = new World(10, 10);
//             var cell = world.GetCellAt(new Coordinate(2, 2));
//             var expectedNeighbours = new List<Cell>
//             {
//                 world.GetCellAt(new Coordinate(1, 1)),
//                 world.GetCellAt(new Coordinate(1, 2)),
//                 world.GetCellAt(new Coordinate(1, 3)),
//                 world.GetCellAt(new Coordinate(2, 1)),
//                 world.GetCellAt(new Coordinate(2, 3)),
//                 world.GetCellAt(new Coordinate(3, 1)),
//                 world.GetCellAt(new Coordinate(3, 2)),
//                 world.GetCellAt(new Coordinate(3, 3))
//             };
//             // Act
//             var actualNeighbours = world.GetNeighbours(cell);
//             // Assert
//             Assert.True(SameNeighbours(expectedNeighbours, actualNeighbours));
//         }
//
//         // . . . . .
//         // o o . . o
//         // * o . . o
//         // o o . . o
//         // . . . . .
//         // * being the cell to be tested, and o being the neighbours
//         [Fact]
//         public void GetNeighbors_ShouldReturnItsSurrounding8Neighbours_WhenCellIsOnFringe()
//         {
//             // Arrange
//             var world = new World(5, 5);
//             var cell = world.GetCellAt(new Coordinate(3, 1));
//             var expectedNeighbours = new List<Cell>
//             {
//                 world.GetCellAt(new Coordinate(2, 1)),
//                 world.GetCellAt(new Coordinate(2, 2)),
//                 world.GetCellAt(new Coordinate(2, 5)),
//                 world.GetCellAt(new Coordinate(3, 2)),
//                 world.GetCellAt(new Coordinate(3, 5)),
//                 world.GetCellAt(new Coordinate(4, 1)),
//                 world.GetCellAt(new Coordinate(4, 2)),
//                 world.GetCellAt(new Coordinate(4, 5)),
//             };
//             // Act
//             var actualNeighbours = world.GetNeighbours(cell);
//             // Assert
//             Assert.True(SameNeighbours(expectedNeighbours, actualNeighbours));
//         }
//
//         // * o . . o
//         // o o . . o
//         // . . . . .
//         // . . . . .
//         // o o . . o
//         // * being the cell to be tested, and o being the neighbours
//         [Fact]
//         public void GetNeighbors_ShouldReturnItsSurrounding8Neighbours_WhenCellIsOnTheCorner()
//         {
//             // Arrange
//             var world = new World(5, 5);
//             var cell = world.GetCellAt(new Coordinate(1, 1));
//             var expectedNeighbours = new List<Cell>
//             {
//                 world.GetCellAt(new Coordinate(1, 2)),
//                 world.GetCellAt(new Coordinate(1, 5)),
//                 world.GetCellAt(new Coordinate(2, 1)),
//                 world.GetCellAt(new Coordinate(2, 2)),
//                 world.GetCellAt(new Coordinate(2, 5)),
//                 world.GetCellAt(new Coordinate(5, 1)),
//                 world.GetCellAt(new Coordinate(5, 2)),
//                 world.GetCellAt(new Coordinate(5, 5)),
//             };
//             // Act
//             var actualNeighbours = world.GetNeighbours(cell);
//             // Assert
//             Assert.True(SameNeighbours(expectedNeighbours, actualNeighbours));
//         }
//
//         // [Fact]
//         // public void WorldAfterTick_ShouldContainSameNumberOfCells()
//         // {
//         //     // Arrange
//         //     var world = new World(5, 5);
//         //     var expectedNumberOfCells = world.Cells.Count;
//         //     // Act
//         //     world.Tick();
//         //     // Assert
//         //     Assert.Equal(expectedNumberOfCells, world.Cells.Count);
//         // }
//         //
//         // [Fact]
//         // public void WorldAfterTick_ShouldContainAllDeadCells_WhenWorldIsEmpty()
//         // {
//         //     // Arrange
//         //     var world = new World(Rows, Columns);
//         //     // Act
//         //     world.Tick();
//         //     // Assert
//         //     Assert.True(world.Cells.All(cell => !cell.IsAlive));
//         // }
//         //
//         // // Previous state: (o being alive, . being dead)
//         // // o . o . .
//         // // o o o . .
//         // // o o . . .
//         // // . . . . o
//         // // . . o . o
//         //
//         // // Expected state:
//         // // o . o . o
//         // // . . o . o
//         // // . . o . o
//         // // . o . o o
//         // // o o . . o
//         // [Fact]
//         // public void WorldAfterTick_ShouldContainCellsWithTransformationsApplied_WhenWorldIsNotEmpty()
//         // {
//         //     // Arrange
//         //     var world = new World(5, 5);
//         //     SetInputPattern(world);
//         //     // Act
//         //     world.Tick();
//         //     // Assert
//         //     Assert.True(ExpectedCellsAlive(world));
//         //     Assert.True(ExpectedCellsDead(world));
//         // }
//         //
//         // private static void SetInputPattern(World world)
//         // {
//         //     world.SetAliveAt(new Coordinate(1, 1));
//         //     world.SetAliveAt(new Coordinate(1, 3));
//         //     world.SetAliveAt(new Coordinate(2, 1));
//         //     world.SetAliveAt(new Coordinate(2, 2));
//         //     world.SetAliveAt(new Coordinate(2, 3));
//         //     world.SetAliveAt(new Coordinate(3, 1));
//         //     world.SetAliveAt(new Coordinate(3, 2));
//         //     world.SetAliveAt(new Coordinate(4, 5));
//         //     world.SetAliveAt(new Coordinate(5, 3));
//         //     world.SetAliveAt(new Coordinate(5, 5));
//         // }
//         // private static bool ExpectedCellsAlive(World world)
//         // {
//         //     return world.GetCellAt(new Coordinate(1, 1)).IsAlive &
//         //            world.GetCellAt(new Coordinate(1, 3)).IsAlive &
//         //            world.GetCellAt(new Coordinate(1, 5)).IsAlive &
//         //            world.GetCellAt(new Coordinate(2, 3)).IsAlive &
//         //            world.GetCellAt(new Coordinate(2, 5)).IsAlive &
//         //            world.GetCellAt(new Coordinate(3, 3)).IsAlive &
//         //            world.GetCellAt(new Coordinate(3, 5)).IsAlive &
//         //            world.GetCellAt(new Coordinate(4, 2)).IsAlive &
//         //            world.GetCellAt(new Coordinate(4, 4)).IsAlive &
//         //            world.GetCellAt(new Coordinate(4, 5)).IsAlive &
//         //            world.GetCellAt(new Coordinate(5, 1)).IsAlive &
//         //            world.GetCellAt(new Coordinate(5, 2)).IsAlive &
//         //            world.GetCellAt(new Coordinate(5, 5)).IsAlive;
//         // }
//         //
//         // private static bool ExpectedCellsDead(World world)
//         // {
//         //     return !world.GetCellAt(new Coordinate(1, 2)).IsAlive &
//         //            !world.GetCellAt(new Coordinate(1, 4)).IsAlive &
//         //            !world.GetCellAt(new Coordinate(2, 1)).IsAlive &
//         //            !world.GetCellAt(new Coordinate(2, 2)).IsAlive &
//         //            !world.GetCellAt(new Coordinate(2, 4)).IsAlive &
//         //            !world.GetCellAt(new Coordinate(3, 1)).IsAlive &
//         //            !world.GetCellAt(new Coordinate(3, 2)).IsAlive &
//         //            !world.GetCellAt(new Coordinate(3, 4)).IsAlive &
//         //            !world.GetCellAt(new Coordinate(4, 1)).IsAlive &
//         //            !world.GetCellAt(new Coordinate(4, 3)).IsAlive &
//         //            !world.GetCellAt(new Coordinate(5, 3)).IsAlive &
//         //            !world.GetCellAt(new Coordinate(5, 4)).IsAlive;
//         // }
//     }
// }