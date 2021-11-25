using System;

namespace ConwaysGameOfLife.Exceptions
{
    public class InvalidInputException : Exception
    {
        public InvalidInputException(string exceptionMessage)
        {
            Console.WriteLine($"Invalid input!: {exceptionMessage}");
        }
    }
}