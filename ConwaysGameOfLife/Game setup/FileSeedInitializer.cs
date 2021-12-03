using System.IO;
using System.Linq;
using ConwaysGameOfLife.Logic;

namespace ConwaysGameOfLife.Game_setup
{
    public class FileSeedInitializer : ISeedInitializer
    {
        private readonly string _filePath;
        public FileSeedInitializer(string filePath)
        {
            _filePath = filePath;
        }

        public string GenerateSeed()
        {
            // make it more readable
            var lines = File.ReadAllLines(_filePath);
            var linesWithEmptyLinesRemoved = lines.Where(line => line.Length > 0).ToArray();
            var rows = linesWithEmptyLinesRemoved.Length;
            InputValidator.ValidateDimension(rows);
            var columns = linesWithEmptyLinesRemoved[0].Length;
            InputValidator.ValidateDimension(columns);
            var seed = string.Join(GameConstants.RowSeparator, linesWithEmptyLinesRemoved);
            var validSeed = seed.Replace(" ", "");
            InputValidator.ValidateWorld(validSeed, linesWithEmptyLinesRemoved.Length, linesWithEmptyLinesRemoved[0].Length);
            return validSeed;
        }
    } 
}