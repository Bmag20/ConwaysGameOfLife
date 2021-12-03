using System;
using ConwaysGameOfLife.Logic;

namespace ConwaysGameOfLife.Game_setup
{
    public class RandomSeedInitializer : ISeedInitializer
    {
        private readonly int _rows;
        private readonly int _columns;

        public RandomSeedInitializer(int rows, int columns)
        {
            _rows = rows;
            _columns = columns;
        }

        public string GenerateSeed()
        {
            InputValidator.ValidateDimension(_rows);
            InputValidator.ValidateDimension(_columns);
            var seed = "";
            var random = new Random(); // pass as parameter?
            for (int i = 0; i < _rows; i++)
            {
                for (int j = 0; j < _columns; j++)
                {
                    var alive = random.Next(0, 2);
                    seed += alive == 1 ? GameConstants.AliveSymbol : GameConstants.DeadSymbol;
                }
                
                seed += GameConstants.RowSeparator;
            }
            seed = seed.TrimEnd(GameConstants.RowSeparator);
            return seed;
        }
    }
}