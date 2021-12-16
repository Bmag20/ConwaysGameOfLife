using System;
using ConwaysGameOfLife.Source.Constants;

namespace ConwaysGameOfLife.Source.Seed_Setup
{
    public class RandomSeedGenerator : ISeedGenerator
    {
        private readonly int _rows;
        private readonly int _columns;

        public RandomSeedGenerator(int rows, int columns)
        {
            _rows = rows;
            _columns = columns;
        }

        public string Generate()
        {
            InputValidator.ValidateDimension(_rows);
            InputValidator.ValidateDimension(_columns);
            var seed = "";
            var random = new Random(); 
            for (var i = 0; i < _rows; i++)
            {
                for (var j = 0; j < _columns; j++)
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