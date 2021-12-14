using ConwaysGameOfLife.Exceptions;
using ConwaysGameOfLife.Logic;
using ConwaysGameOfLife.View;

namespace ConwaysGameOfLife.Game_setup
{
    public class SeedGeneratorFactory
    {
        public ISeedGenerator CreateSeedGenerator(string[] args)
        {
            switch (args.Length)
            {
                case 0 :
                {
                    var consoleReader = new ConsoleReader();
                    var consolePrompter = new ConsolePrompter();
                    return new ConsoleSeedGenerator(consoleReader, consolePrompter);
                }
                case 2 when IsFileArgs(args):
                {
                    var fileName = args[1];
                    var filePath = GameConstants.FileDirectory + fileName;
                    return new FileSeedGenerator(filePath);
                }
                case 4 when IsRandomSeedArgs(args):
                {
                    var rows = int.Parse(args[1]);
                    var columns = int.Parse(args[3]);
                    return new RandomSeedGenerator(rows, columns);
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