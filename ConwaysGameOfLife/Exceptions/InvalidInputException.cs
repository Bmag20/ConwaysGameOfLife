using System;

namespace ConwaysGameOfLife.Exceptions
{
    public class InvalidDimensionException : Exception
    {
        public InvalidDimensionException(string exceptionMessage)
        {
            Console.WriteLine($"Invalid input!: {exceptionMessage}");
        }
    }
}