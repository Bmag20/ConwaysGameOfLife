namespace ConwaysGameOfLife.Entities
{
    public class Cell
    {
        public Coordinate Position { get; set; }
        public bool IsAlive { get; set; }
        

        public Cell(Coordinate position)
        {
            Position = position;
        }        
        public Cell(Coordinate position, bool isAlive)
        {
            Position = position;
            IsAlive = isAlive;
        }

    }
}