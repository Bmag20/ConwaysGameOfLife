using System;

namespace ConwaysGameOfLife.Exceptions
{
    public class InvalidRunArgumentsException : Exception
    {
        public InvalidRunArgumentsException() : base("Invalid command line arguments") {}
    }
}