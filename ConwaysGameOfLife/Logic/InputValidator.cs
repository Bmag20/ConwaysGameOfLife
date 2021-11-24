using System.Linq;
using ConwaysGameOfLife.Exceptions;

namespace ConwaysGameOfLife.Logic
{
    public static class InputValidator
    {
        public static bool IsValidNumber(string input, int maximumLimit)
        {
            if (input is null || input.Length == 0 || !input.All(char.IsDigit))
                throw new InvalidInputException();
            var number = int.Parse(input);
            return number > 0 && number <= maximumLimit;
        }
    }
}