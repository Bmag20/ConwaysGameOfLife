using System.Linq;
using ConwaysGameOfLife.Exceptions;

namespace ConwaysGameOfLife.Logic
{
    public static class InputValidator
    {
        public static void ValidateDimension(string input, int maximumLimit)
        {
            if (IsEmpty(input)) throw new EmptyInputException();
            if (!input.All(char.IsDigit))
                throw new InvalidInputException("Input contains non numeric characters!");
            var number = int.Parse(input);
            if (number <= 0)
                throw new InvalidInputException("Input is not a natural number!");
            if (number > maximumLimit)
                throw new InvalidInputException($"Input is greater than the permitted grid size - {maximumLimit}!");
        }

        public static void ValidateWorld(string worldRepresentation, int rows, int columns, char aliveSymbol, char deadSymbol, char rowSeparator)
        {
            if (IsEmpty(worldRepresentation)) throw new EmptyInputException();
            var worldRows = worldRepresentation.Trim().Split(rowSeparator);
            if (worldRows.Any(w=>w.Any(c => c != aliveSymbol && c != deadSymbol)))
                throw new InvalidInputException($"Input contains characters other than Alive symbol [{aliveSymbol}] and Dead symbol [{deadSymbol}]");
            if (worldRows.Length != rows)
                throw new InvalidInputException($"Input has {worldRows.Length} rows, but expected {rows}!");
            if (worldRows.Any(row => row.Length != columns))
                throw new InvalidInputException($"Input has rows with different lengths!");
        }

        private static bool IsEmpty(string input)
        {
            return input is null || input.Length == 0;
        }
    }
}