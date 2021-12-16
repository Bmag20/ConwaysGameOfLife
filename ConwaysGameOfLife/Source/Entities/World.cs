using System.Collections.Generic;
using System.Linq;
using ConwaysGameOfLife.Source.Constants;

namespace ConwaysGameOfLife.Source.Entities
{
    public class World
    {
        public int Rows { get; }
        public int Columns { get; }
        public List<Cell> Cells { get; set; }
        
        public World(string seed)
        {
            var seedRows = seed.Split(GameConstants.RowSeparator);
            Rows = seedRows.Length;
            Columns = seedRows[0].Length;
            Cells = new List<Cell>();
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
        
        public Cell GetCellAt(Coordinate cellPosition)
        {
            var cell = Cells.Find(cell => cell.Position.Equals(cellPosition));
            return cell;
        }

        public bool HasAliveCells()
        {
            return Cells.All(cell => !cell.IsAlive);
        }
        


    }
}