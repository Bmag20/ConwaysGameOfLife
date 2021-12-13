using System;

namespace ConwaysGameOfLife.Exceptions
{
    public class InvalidSeedException : Exception
    {
        public InvalidSeedException(string exceptionMessage) : base($"Invalid seed: {exceptionMessage}") {}
    }
}