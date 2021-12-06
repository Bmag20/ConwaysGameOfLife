using System.Linq;
using ConwaysGameOfLife.Exceptions;
using ConwaysGameOfLife.Logic;

namespace ConwaysGameOfLife.Game_setup
{
    public static class InputValidator
    {
        public static void ValidateDimension(string input)
        {
            if (IsEmpty(input)) throw new EmptyInputException();
            if (!input.IsNaturalNumber())
                throw new InvalidDimensionException("Input is not a natural number!");
            var number = int.Parse(input);
            ValidateDimension(number);
        }

        public static void ValidateDimension(int number)
        {
            switch (number)
            {
                case 0:
                    throw new InvalidDimensionException("Input is zero!");
                case > GameConstants.MaximumGridSize:
                    throw new InvalidDimensionException(
                        $"Input is greater than the permitted grid size - {GameConstants.MaximumGridSize}!");
            }
        }

        public static void ValidateWorld(string worldRepresentation, int rows, int columns)
        {
            if (IsEmpty(worldRepresentation)) throw new EmptyInputException();
            var worldRows = worldRepresentation.Trim().Split(GameConstants.RowSeparator);
            if (worldRows.Any(w=>w.Any(c => c != GameConstants.AliveSymbol && c != GameConstants.DeadSymbol)))
                throw new InvalidSeedException($"Input contains characters other than Alive symbol " +
                                                $"[{GameConstants.AliveSymbol}] and Dead symbol [{GameConstants.DeadSymbol}]");
            if (worldRows.Length != rows)
                throw new InvalidSeedException($"Input has {worldRows.Length} rows, but expected {rows}!");
            if (worldRows.Any(row => row.Length != columns))
                throw new InvalidSeedException($"Input has rows with different lengths!");
        }
        
        private static bool IsEmpty(string input)
        {
            return input is null || input.Length == 0;
        }
        
    }
}