using System.Collections.Generic;

namespace ConwaysGameOfLife
{
    public class World
    {
        private readonly int _rows;
        private readonly int _columns;
        public List<Cell> Cells { get; private set; }

        public World(int rows, int columns)
        {
            _rows = rows;
            _columns = columns;
            InitialiseCells();
        }

        private void InitialiseCells()
        {
            Cells = new List<Cell>();
            for (int i = 1; i <= _rows; i++)
            {
                for (int j = 1; j <= _columns; j++)
                {
                    Cells.Add(new Cell(new Position(i, j)));
                }
            }
        }

        public void SetAliveAt(Position cellPosition)
        {
            var cell = GetCellAt(cellPosition);
            cell.IsAlive = true;
        }

        public Cell GetCellAt(Position cellPosition)
        {
            var cell = Cells.Find(cell => cell.Position == cellPosition);
            return cell ?? throw new InvalidCellException("Cell does not exist");
        }
        

        public void NextGeneration()
        {
            throw new System.NotImplementedException();
        }
    }
}

