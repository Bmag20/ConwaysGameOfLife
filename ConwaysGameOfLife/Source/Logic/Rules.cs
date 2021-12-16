namespace ConwaysGameOfLife.Source.Logic
{
    public class Rules
    {
        private const int UnderPopulationThreshold = 2;
        private const int OverCrowdingThreshold = 3;
        private const int ReproductionThreshold = 3;
        public bool LiveCellCheck(int liveNeighbours)
        {
            return liveNeighbours >= UnderPopulationThreshold & liveNeighbours <= OverCrowdingThreshold;
        }

        public bool DeadCellCheck(int liveNeighborCount)
        {
            return liveNeighborCount == ReproductionThreshold;
        }
    }
}