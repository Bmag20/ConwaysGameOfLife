using System;

namespace ConwaysGameOfLife.Exceptions
{
    public class EmptyInputException : Exception
    {
        public EmptyInputException()
        {
            Console.WriteLine("Empty input!!");
        }
    }
}