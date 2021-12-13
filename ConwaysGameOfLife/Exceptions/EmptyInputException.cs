using System;

namespace ConwaysGameOfLife.Exceptions
{
    public class EmptyInputException : Exception
    {
        public EmptyInputException() : base("Empty input") {}
    }
}