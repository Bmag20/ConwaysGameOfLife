using System.Collections.Generic;
using System.Linq;
using System.Threading;
using ConwaysGameOfLife.Entities;
using ConwaysGameOfLife.View;

namespace ConwaysGameOfLife.Logic
{
    public class GameController
    {
        private readonly IOutputHandler _outputHandler;
        private World World { get; }

        public GameController(World world, IOutputHandler outputHandler)
        {
            World = world;
            _outputHandler = outputHandler;
        }

        public void RunGame()
        {
            _outputHandler.DisplayWorld(World);
            while (!World.IsEmpty())
            {
                Tick();
                Thread.Sleep(GameConstants.TickDelayInMilliSeconds);
                _outputHandler.DisplayWorld(World);
            }
        }
        

        private void Tick()
        {
            var nextGenCells = new List<Cell>();
            var rules = new Rules();
            foreach (var cell in World.Cells)
            {
                var neighbours = World.GetNeighbours(cell);
                var aliveNeighbours = neighbours.Count(neighbour => neighbour.IsAlive);
                var nextGenCellState = cell.IsAlive
                    ? rules.LiveCellCheck(aliveNeighbours)
                    : rules.DeadCellCheck(aliveNeighbours);
                nextGenCells.Add(new Cell(cell.Position, nextGenCellState));
            }

            World.Cells = nextGenCells;
        }
    }
}