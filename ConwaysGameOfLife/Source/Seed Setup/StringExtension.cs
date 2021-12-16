namespace ConwaysGameOfLife.Source.Seed_Setup
{
    public static class StringExtension
    {
        public static bool IsEmpty(this string value)
        {
            return string.IsNullOrEmpty(value);
        }
        
        public static bool IsNaturalNumber(this string inputValue)
        {
            return int.TryParse(inputValue, out var result) && result > 0;
        }
    }
}