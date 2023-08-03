using ThreeAndTwo.Game;

public static class ConsoleUI
{
    public static int GetNumberOfPlayers()
    {
        int numOfPlayers = 0;
        Console.Write("How many players? ");
        while (!int.TryParse(Console.ReadLine(), out numOfPlayers) || numOfPlayers <= 0 || numOfPlayers > 5)
        {
            Console.Write("Please enter a valid number of players (max 5 players): ");
        }
        return numOfPlayers;
    }

    public static string GetPlayerName(int index)
    {
        Console.Write($"Enter player - {index + 1} name: ");
        string playerName = Console.ReadLine();
        return string.IsNullOrWhiteSpace(playerName) ? $"Player {index + 1}" : playerName;
    }

    public static void DisplayMessage(string message)
    {
        Console.WriteLine(message);
    }

    public static void DisplayPlayer(Player player)
    {
        Console.WriteLine($"Player: {player.Name}");
        Console.WriteLine(player.ShowHand());
    }

    public static void DisplayGameInstructions()
    {
        Console.WriteLine("Welcome to Three and Two Card Game!\n");
        Console.WriteLine("Objective: The goal of the game is to collect a hand with three cards of the same rank (three-of-a-kind) and two cards of another rank (a pair).");
        Console.WriteLine("           The first player to achieve this combination wins the game.");
        Console.WriteLine("\nHow to Play:");
        Console.WriteLine("1. Enter the number of players participating in the game (should be greater than 0), max 5 players.");
        Console.WriteLine("2. Enter the name of each player when prompted (Default name: Player).");
        Console.WriteLine("3. The game will automatically deal cards to each player.");
        Console.WriteLine("4. During each player's turn, they will draw a card from the deck and can choose to discard a card from their hand.");
        Console.WriteLine("5. The game will continue until a player forms a winning hand or until the deck is empty.");
        Console.WriteLine("6. The winning player will be announced, and the game will end.\n");
        Console.WriteLine("Enjoy playing the Three and Two Card Game!");
        Console.WriteLine("----------------------------------------\n");
    }

    public static void ClearScreen()
    {
        Console.Clear();
    }
}
