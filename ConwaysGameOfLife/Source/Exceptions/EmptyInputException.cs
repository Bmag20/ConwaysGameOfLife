using System;

namespace ConwaysGameOfLife.Source.Exceptions
{
    public class EmptyInputException : Exception
    {
        public EmptyInputException() : base("Empty input") {}
    }
}