using System.IO;
using System.Linq;
using ConwaysGameOfLife.Logic;

namespace ConwaysGameOfLife.Game_setup
{
    public class FileSeedGenerator : ISeedGenerator
    {
        private readonly string _filePath;
        public FileSeedGenerator(string filePath)
        {
            _filePath = filePath;
        }

        public string Generate()
        {
            var lines = File.ReadAllLines(_filePath);
            lines = RemoveEmptyLines(lines);
            var rows = lines.Length;
            InputValidator.ValidateDimension(rows);
            var columns = lines[0].Length;
            InputValidator.ValidateDimension(columns);
            var seed = ConvertToString(lines);
            InputValidator.ValidateSeed(seed, rows, columns);
            return seed;
        }

        private string[] RemoveEmptyLines(string[] lines)
        {
            return lines.Where(line => line.Length > 0).ToArray();
        }
        
        private string ConvertToString(string[] lines)
        {
            return string.Join(GameConstants.RowSeparator, lines).Replace(" ", "");
        }
    } 
}