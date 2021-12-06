using ConwaysGameOfLife.Exceptions;
using ConwaysGameOfLife.View;

namespace ConwaysGameOfLife.Game_setup
{
    public class GameInitializerFactory
    {
        private readonly string FileDirectory =
            "/Users/Bhuvana.Maganti/Documents/Projects/ConwaysGameOfLife/ConwaysGameOfLife/Data/";
        public ISeedInitializer CreateGameInitializer(string[] args)
        {
            switch (args.Length)
            {
                case 0 :
                {
                    var consoleReader = new ConsoleReader();
                    var consolePrompter = new ConsolePrompter();
                    return new ConsoleGameInitializer(consoleReader, consolePrompter);
                }
                case 2 when IsFileArgs(args):
                {
                    var fileName = args[1];
                    var filePath = FileDirectory + fileName;
                    return new FileSeedInitializer(filePath);
                }
                case 4 when IsRandomSeedArgs(args):
                {
                    var rows = int.Parse(args[1]);
                    var columns = int.Parse(args[3]);
                    return new RandomSeedInitializer(rows, columns);
                }
                default:
                    throw new InvalidRunArgumentsException();
            }
        }
        private bool IsFileArgs(string[] args)
        {
            return args.Length == 2 && args[0].ToLower() == "file" && args[1].Contains(".txt");
        }
        
        private bool IsRandomSeedArgs(string[] args)
        {
            return args.Length == 4 && args[0].ToLower() == "rows" && args[2].ToLower() == "columns" 
                   && args[1].IsNaturalNumber() && args[3].IsNaturalNumber();
        }
    }
}