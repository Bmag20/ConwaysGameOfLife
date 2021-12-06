using System;

namespace ConwaysGameOfLife.Exceptions
{
    public class InvalidSeedException : Exception
    {
        public InvalidSeedException(string exceptionMessage)
        {
            Console.WriteLine($"Invalid seed!: {exceptionMessage}");
        }
    }
}