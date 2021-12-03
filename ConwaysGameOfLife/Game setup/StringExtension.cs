namespace ConwaysGameOfLife.Game_setup
{
    public static class StringExtension
    {
        public static bool IsNaturalNumber(this string inputValue)
        {
            return int.TryParse(inputValue, out var result) && result > 0;
        }
    }
}