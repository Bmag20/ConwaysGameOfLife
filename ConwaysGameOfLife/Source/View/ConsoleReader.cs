using System;

namespace ConwaysGameOfLife.Source.View
{
    public class ConsoleReader : IInputHandler
    {
        public string GetUserInput()
        {
            return Console.ReadLine();
        }

    }
}