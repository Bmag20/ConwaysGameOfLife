namespace ConwaysGameOfLife.Source.Entities
{
    public class Cell
    {
        public Coordinate Position { get; }
        public bool IsAlive { get; }

        public Cell(Coordinate coordinate, bool isAlive)
        {
            Position = coordinate;
            IsAlive = isAlive;
        }
    }
}