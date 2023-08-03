using ThreeAndTwo;

internal class Program
{
    private static void Main(string[] args)
    {
        ConsoleUI.DisplayGameInstructions();

        int numofPlayers = ConsoleUI.GetNumberOfPlayers();
        var game = new ThreeAndTwoGame();

        for (int i = 0; i < numofPlayers; i++)
        {
            string playerName = ConsoleUI.GetPlayerName(i);
            game.AddPlayer(playerName);
        }

        game.Play();

        ConsoleUI.DisplayMessage("\nThank you for playing Three and Two Card Game!");
    }
}

