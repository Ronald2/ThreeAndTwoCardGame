using ThreeAndTwo.Models;
using ThreeAndTwo.UI;

namespace ThreeAndTwo.Game
{
    public class ThreeAndTwoGame
    {
        private const int NumCardsToDeal = 5;
        private readonly Board board;
        private readonly List<Player> players;
        public IReadOnlyList<Player> Players => players;

        public ThreeAndTwoGame()
        {
            players = new List<Player>();
            board = new Board(players);
        }

        // Add a player to the game, with the given name
        public void AddPlayer(string name)
        {
            var player = new Player(name);
            players.Add(player);
        }

        public void Play()
        {
            Deal();

            while (true)
            {
                foreach (var player in players)
                {
                    ConsoleUI.ClearScreen();
                    TakeTurn(player);
                    if (CheckIsWinner(player))
                    {
                        ConsoleUI.DisplayMessage($"\n {player.Name} wins!");
                        return;
                    }
                }
            }

        }

        // Deal 5 cards to each player
        private void Deal()
        {
            board.DealCardsToAllPlayers(NumCardsToDeal);
        }

        private void TakeTurn(Player player)
        {
            board.DealCardToPlayer(player);

            ConsoleUI.DisplayMessage($"\n{player.Name} has taken a card. \n");
            ConsoleUI.DisplayPlayer(player);

            int index;
            string input;
            do
            {
                ConsoleUI.DisplayMessage("\nEnter the index of the card you want to discard:");
                input = Console.ReadLine() ?? "";
            } while (!ConsoleInputParser.TryParseCardIndex(input, player.Hand.Count(), out index));

            Card card = player.Discard(index);
            if (card != null)
            {
                board.DiscardToSideDeck(card);
            }
        }

        private bool CheckIsWinner(Player player)
        {
            var isWinner = (HasThreeOfAKindAndPair(player));
            return isWinner;
        }

        private bool HasThreeOfAKindAndPair(Player player)
        {
            var rankCount = new Dictionary<CardRank, int>();
            foreach (var card in player.Hand)
            {
                if (rankCount.ContainsKey(card.Rank))
                {
                    rankCount[card.Rank]++;
                }
                else
                {
                    rankCount.Add(card.Rank, 1);
                }
            }

            return rankCount.ContainsValue(3) && rankCount.ContainsValue(2);
        }

        public void Reset()
        {
            board.Reset();
            players.Clear();
        }
    }
}
