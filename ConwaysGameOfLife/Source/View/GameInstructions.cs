namespace ConwaysGameOfLife.Source.View
{
    public static class GameInstructions
    {
        public const string WelcomeMessage = "Welcome to Conway's Game of Life game!";
        public const string RowsPrompt = "Please enter the number of rows of the world you would like to visualise";
        public const string ColumnsPrompt = "Please enter the number of columns of the world you would like to visualise";
        public const string SeedPrompt = "Please enter the initial state of the world using 'o' for living cells, " +
                                         "'.' for dead cells annd '|' as a row seperator";
        public const string ReenterPrompt = "Please enter a valid input!!";
        public const string GameEndedMessage = "The simulation is completed! Thank you for playing :)";

    }
}