using System;

namespace ConwaysGameOfLife.View
{
    public class ConsoleReader : IInputHandler
    {
        public string GetUserInput()
        {
            return Console.ReadLine();
        }
    }
}