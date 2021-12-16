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
        private readonly TransitionHandler _transitionHandler;

        public GameController(World world, TransitionHandler transitionHandler, IWorldRenderer outputHandler)
        {
            World = world;
            _transitionHandler = transitionHandler;
            _renderer = outputHandler;
        }

        public void RunGame()
        {
            _renderer.DisplayWorld(World);
            while (!World.HasAliveCells() && GameConstants.GenerationsToDisplay > _currentGeneration)
            {
                _transitionHandler.ApplyTransition(World);
                _currentGeneration++;
                Thread.Sleep(GameConstants.TickDelayInMilliSeconds);
                _renderer.DisplayWorld(World);
                _renderer.DisplayGeneration(_currentGeneration);
            }
            _renderer.DisplayGameEnded();
        }
        
    }
}