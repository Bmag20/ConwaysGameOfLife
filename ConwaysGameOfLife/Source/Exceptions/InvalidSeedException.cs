using System;

namespace ConwaysGameOfLife.Source.Exceptions
{
    public class InvalidSeedException : Exception
    {
        public InvalidSeedException(string exceptionMessage) : base($"Invalid seed: {exceptionMessage}") {}
    }
}