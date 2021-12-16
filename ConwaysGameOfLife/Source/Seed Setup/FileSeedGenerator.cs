using System.IO;
using System.Linq;
using ConwaysGameOfLife.Source.Constants;

namespace ConwaysGameOfLife.Source.Seed_Setup
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
            var fileRows = File.ReadAllLines(_filePath);
            fileRows = RemoveEmptyLines(fileRows);
            var rows = fileRows.Length;
            InputValidator.ValidateDimension(rows);
            var columns = fileRows[0].Length;
            InputValidator.ValidateDimension(columns);
            var seed = ConvertToString(fileRows);
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