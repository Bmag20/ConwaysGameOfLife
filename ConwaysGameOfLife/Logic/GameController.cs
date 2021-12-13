using System.Collections.Generic;
using System.Linq;
using System.Threading;
using ConwaysGameOfLife.Entities;
using ConwaysGameOfLife.View;

namespace ConwaysGameOfLife.Logic
{
    public class GameController
    {
        private readonly IWorldRenderer _renderer;
        private World World { get; }
        private int _generation;

        public GameController(World world, IWorldRenderer outputHandler)
        {
            World = world;
            _renderer = outputHandler;
        }

        public void RunGame()
        {
            _renderer.DisplayWorld(World);
            while (!World.IsEmpty() && GameConstants.GenerationsToDisplay > _generation)
            {
                Tick();
                _generation++;
                Thread.Sleep(GameConstants.TickDelayInMilliSeconds);
                _renderer.DisplayWorld(World);
                _renderer.DisplayGeneration(_generation);
            }
            _renderer.DisplayGameOver();
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