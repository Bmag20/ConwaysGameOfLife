using System;

namespace ConwaysGameOfLife.Exceptions
{
    public class InvalidRunArgumentsException : Exception
    {
        public InvalidRunArgumentsException()
        {
            Console.WriteLine("Invalid command line arguments");
        }
    }
}