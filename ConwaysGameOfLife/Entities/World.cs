using System.Collections.Generic;
using System.Linq;
using ConwaysGameOfLife.Logic;

namespace ConwaysGameOfLife.Entities
{
    public class World
    {
        // todo : refactor this
        public int Rows { get; }
        public int Columns { get; }
        public List<Cell> Cells { get; set; }

        public World(int rows, int columns)
        {
            Rows = rows;
            Columns = columns;
            InitialiseCells();
        }

        public World(string seed)
        {
            Cells = new List<Cell>();
            var seedRows = seed.Split(GameConstants.RowSeparator);
            Rows = seedRows.Length;
            Columns = seedRows[0].Length;
            for (var i = 0; i < seedRows.Length; i++)
            {
                var rowCells = seedRows[i];
                for (var j = 0; j < rowCells.Length; j++)
                {
                    var isAlive = rowCells[j] == GameConstants.AliveSymbol;
                    var cell = new Cell(new Coordinate(i+1, j+1), isAlive);
                    Cells.Add(cell);
                }
            }
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
            return cell;
        }

        public bool IsEmpty()
        {
            return Cells.All(cell => !cell.IsAlive);
        }
        
        public List<Cell> GetNeighbours(Cell cell)
        {
            var neighbours = new List<Cell>();
            var cellPosition = cell.Position;
            for (var i = -1; i <= 1; i++)
            {
                for (var j = -1; j <= 1; j++)
                {
                    var neighborCoordinate = WrapCoordinate(cellPosition.X + i, cellPosition.Y + j);
                    if (cellPosition == neighborCoordinate) continue;
                    Cell neighbor = GetCellAt(neighborCoordinate);
                    neighbours.Add(neighbor);
                }
            }
            return neighbours;
        }

        private Coordinate WrapCoordinate(int x, int y)
        {
            var wrappedX = x == 0 ?  Rows : x > Rows ? x - Rows : x;
            var wrappedY = y == 0 ? Columns : y > Columns ? y - Columns : y;
            return new Coordinate(wrappedX, wrappedY);
        }

    }
}