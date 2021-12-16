using System.Collections.Generic;
using System.Linq;
using ConwaysGameOfLife.Source.Entities;

namespace ConwaysGameOfLife.Source.Logic
{
    public class TransitionHandler
    {
        public void ApplyTransition(World world)
        {
            var nextGenCells = new List<Cell>();
            var rules = new Rules();    
            foreach (var cell in world.Cells)
            {
                var neighbours = GetNeighbours(cell, world);
                var aliveNeighbours = neighbours.Count(neighbour => neighbour.IsAlive);
                var nextGenCellState = cell.IsAlive
                    ? rules.LiveCellCheck(aliveNeighbours)
                    : rules.DeadCellCheck(aliveNeighbours);
                nextGenCells.Add(new Cell(cell.Position, nextGenCellState));
            }

            world.Cells = nextGenCells;
        }

        private List<Cell> GetNeighbours(Cell cell, World world)
        {
            var neighbours = new List<Cell>();
            var cellPosition = cell.Position;
            for (var x = -1; x <= 1; x++)
            {
                for (var y = -1; y <= 1; y++)
                {
                    var neighborCoordinate = WrapCoordinate(world, cellPosition.X + x, cellPosition.Y + y);
                    if (cellPosition.Equals(neighborCoordinate)) continue;
                    var neighbor = world.GetCellAt(neighborCoordinate);
                    neighbours.Add(neighbor);
                }
            }
            return neighbours;
        }

        private Coordinate WrapCoordinate(World world, int x, int y)
        {
            var wrappedX = x == 0 ?  world.Rows : x > world.Rows ? x - world.Rows : x;
            var wrappedY = y == 0 ? world.Columns : y > world.Columns ? y - world.Columns : y;
            return new Coordinate(wrappedX, wrappedY);
        }
    }
}