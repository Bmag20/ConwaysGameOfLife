using System.Threading;
using ConwaysGameOfLife.Source.Constants;
using ConwaysGameOfLife.Source.Entities;
using ConwaysGameOfLife.Source.View;

namespace ConwaysGameOfLife.Source.Logic
{
    public class GameController
    {
        private readonly IWorldRenderer _renderer;
        private World World { get; }
        private int _currentGeneration;
        private readonly TransitionHandler _gameOfLifeCore;

        public GameController(World world, TransitionHandler gameOfLifeCore, IWorldRenderer outputHandler)
        {
            World = world;
            _gameOfLifeCore = gameOfLifeCore;
            _renderer = outputHandler;
        }

        public void RunGame()
        {
            _renderer.DisplayWorld(World);
            while (!World.HasAliveCells() && GameConstants.GenerationsToDisplay > _currentGeneration)
            {
                _gameOfLifeCore.ApplyTransition(World);
                _currentGeneration++;
                Thread.Sleep(GameConstants.TickDelayInMilliSeconds);
                _renderer.DisplayWorld(World);
                _renderer.DisplayGeneration(_currentGeneration);
            }
            _renderer.DisplayGameEnded();
        }
        
    }
}