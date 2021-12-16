using System;

namespace ConwaysGameOfLife.Source.Exceptions
{
    public class InvalidRunArgumentsException : Exception
    {
        public InvalidRunArgumentsException() : base("Invalid command line arguments") {}
    }
}