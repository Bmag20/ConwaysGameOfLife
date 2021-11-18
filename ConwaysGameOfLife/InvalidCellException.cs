using System;

namespace ConwaysGameOfLife
{
    public class InvalidCellException : Exception
    {
        public InvalidCellException(string message) : base(message)
        {
        }
    }
}