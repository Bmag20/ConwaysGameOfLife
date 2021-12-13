using System;

namespace ConwaysGameOfLife.Exceptions
{
    public class InvalidDimensionException : Exception
    {
        public InvalidDimensionException(string exceptionMessage) : base($"Invalid input: {exceptionMessage}") 
        { }
    }
}