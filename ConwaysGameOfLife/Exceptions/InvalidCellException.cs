using System;

namespace ConwaysGameOfLife.Exceptions
{
    public class InvalidCellException : Exception
    {
        public InvalidCellException()
        {
            Console.WriteLine("Cell does not exist in the current world");
        }
    }
}