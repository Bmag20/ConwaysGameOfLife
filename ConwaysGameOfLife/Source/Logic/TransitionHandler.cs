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
            for (var i = -1; i <= 1; i++)
            {
                for (var j = -1; j <= 1; j++)
                {
                    var neighborCoordinate = WrapCoordinate(world, cellPosition.X + i, cellPosition.Y + j);
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