using System;

namespace ConwaysGameOfLife.Source.Exceptions
{
    public class InvalidDimensionException : Exception
    {
        public InvalidDimensionException(string exceptionMessage) : base($"Invalid input: {exceptionMessage}") 
        { }
    }
}