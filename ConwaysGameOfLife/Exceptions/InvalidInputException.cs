using System;

namespace ConwaysGameOfLife.Exceptions
{
    public class InvalidInputException : Exception
    {
        public InvalidInputException()
        {
            Console.WriteLine("Empty input!!");
        }
    }
}