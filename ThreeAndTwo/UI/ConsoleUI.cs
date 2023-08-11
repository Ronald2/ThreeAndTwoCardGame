using ThreeAndTwo.Game;
namespace ThreeAndTwo.UI
{
    public static class ConsoleUI
    {
        public static int GetNumberOfPlayers()
        {
            int numOfPlayers = 0;
            DisplayMessage("How many players? ");
            while (!int.TryParse(Console.ReadLine(), out numOfPlayers) || numOfPlayers <= 0 || numOfPlayers > 5)
            {
                DisplayMessage("Please enter a valid number of players (max 5 players): ");
            }
            return numOfPlayers;
        }

        public static string GetPlayerName(int index)
        {
            DisplayMessage($"Enter player - {index + 1} name: ");
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
            DisplayMessage("Welcome to Three and Two Card Game!\n");
            DisplayMessage("Objective: The goal of the game is to collect a hand with three cards of the same rank (three-of-a-kind) and two cards of another rank (a pair).");
            DisplayMessage("           The first player to achieve this combination wins the game.");
            DisplayMessage("\nHow to Play:");
            DisplayMessage("1. Enter the number of players participating in the game (should be greater than 0), max 5 players.");
            DisplayMessage("2. Enter the name of each player when prompted (Default name: Player).");
            DisplayMessage("3. The game will automatically deal cards to each player.");
            DisplayMessage("4. During each player's turn, they will draw a card from the deck and can choose to discard a card from their hand.");
            DisplayMessage("5. The game will continue until a player forms a winning hand or until the deck is empty.");
            DisplayMessage("6. The winning player will be announced, and the game will end.\n");
            DisplayMessage("Enjoy playing the Three and Two Card Game!");
            DisplayMessage("----------------------------------------\n");
        }

        public static void ClearScreen()
        {
            Console.Clear();
        }


    }
}
