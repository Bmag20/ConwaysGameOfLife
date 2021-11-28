using System.Collections.Generic;
using System.Linq;
using ConwaysGameOfLife.Exceptions;
using ConwaysGameOfLife.Logic;

namespace ConwaysGameOfLife.Entities
{
    public class World
    {
        public int Rows { get; }
        public int Columns { get; }
        public List<Cell> Cells { get; private set; }

        public World(int rows, int columns)
        {
            Rows = rows;
            Columns = columns;
            InitialiseCells();
        }

        private void InitialiseCells()
        {
            Cells = new List<Cell>();
            for (var i = 1; i <= Rows; i++)
            {
                for (var j = 1; j <= Columns; j++)
                {
                    Cells.Add(new Cell(new Coordinate(i, j)));
                }
            }
        }

        public void SetAliveAt(Coordinate cellPosition)
        {
            var cell = GetCellAt(cellPosition);
            cell.IsAlive = true;
        }

        public Cell GetCellAt(Coordinate cellPosition)
        {
            var cell = Cells.Find(cell => cell.Position.Equals(cellPosition));
            return cell ?? throw new InvalidCellException();
        }

        public bool IsEmpty()
        {
            return Cells.All(cell => !cell.IsAlive);
        }

        public void SetInitialState(string seed, char aliveSymbol, char rowSeparator)
        {
            var seedRows = seed.Split(rowSeparator);
            for (var i = 0; i < Rows; i++)
            {
                var rowCells = seedRows[i];
                for (var j = 0; j < Columns; j++)
                {
                    var cell = GetCellAt(new Coordinate(i + 1, j + 1));
                    cell.IsAlive = rowCells[j] == aliveSymbol;
                }
            }
        }

        public List<Cell> GetNeighbours(Cell cell)
        {
            var neighbours = new List<Cell>();
            var cellPosition = cell.Position;
            for (var i = -1; i <= 1; i++)
            {
                for (var j = -1; j <= 1; j++)
                {
                    var x = AdjustXCoordinate(cellPosition.X + i);
                    var y = AdjustYCoordinate(cellPosition.Y + j);
                    var neighbourPosition = new Coordinate(x, y);
                    if (cellPosition != neighbourPosition)
                        neighbours.Add(GetCellAt(neighbourPosition));
                }
            }

            return neighbours;
        }

        
        private int AdjustYCoordinate(int y)
        {
            return y < 1 ? y + Columns : y > Columns ? y - Columns : y;
        }

        private int AdjustXCoordinate(int x)
        {
            return x < 1 ? x + Rows : x > Rows ? x - Rows : x;
            ;
        }

        public void Tick()
        {
            var nextGenCells = new List<Cell>();
            var rules = new Rules();
            foreach (var cell in Cells)
            {
                var neighbours = GetNeighbours(cell);
                var aliveNeighbours = neighbours.Count(neighbour => neighbour.IsAlive);
                var nextGenCellState = cell.IsAlive
                    ? rules.LiveCellCheck(aliveNeighbours)
                    : rules.DeadCellCheck(aliveNeighbours);
                nextGenCells.Add(new Cell(cell.Position, nextGenCellState));
            }

            Cells = nextGenCells;
        }
    }
}