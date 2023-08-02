using System;
using System.Collections.Generic;

namespace TestClass
{
    public class ThreeAndTwoGame
    {
        private const int NumCardsToDeal = 5;
        private readonly Board board;
        private readonly List<Player> players;
        private Player? winner;

        public ThreeAndTwoGame()
        {
            players = new List<Player>();
            board = new Board();
        }

        // Properties for encapsulation
        public Player? Winner => winner;
        public IReadOnlyList<Player> Players => players;

        // Add a player to the game, with the given name
        public void AddPlayer(string name)
        {
            var player = new Player(name);
            players.Add(player);
            board.AddPlayer(player);
        }

        // Deal 5 cards to each player
        public void Deal()
        {
            board.DealCardsToPlayers(NumCardsToDeal);
        }

        public void TakeTurn(Player player)
        {
            board.DealCardToPlayer(player);

            ConsoleUI.DisplayMessage($"\n {player.Name} has taken a card. \n");
            ConsoleUI.DisplayPlayer(player);

            int index;
            string input;
            do
            {
                ConsoleUI.DisplayMessage("Enter the index of the card you want to discard:");
                input = Console.ReadLine() ?? "";
            } while (!ConsoleInputParser.TryParseCardIndex(input, player.Hand.Count(), out index));

            Card? card = player.Discard(index);
            if (card != null)
            {
                board.Discard(card);
            }
        }


        // Check for a winner among the players
        public bool CheckForWinner()
        {
            foreach (var player in players)
            {
                if (board.HasThreeOfAKindAndPair(player))
                {
                    winner = player;
                    return true;
                }
            }
            return false;
        }

        // Reset the game
        public void Reset()
        {
            board.Reset();
            players.Clear();
            winner = null;
        }

        // Play the game
        public void Play()
        {
            Deal();

            while (winner == null)
            {
                foreach (var player in players)
                {
                    ConsoleUI.ClearScreen();
                    TakeTurn(player);
                    if (CheckForWinner())
                        break;
                }
            }
            ConsoleUI.DisplayMessage($"\n {winner.Name} wins!");
        }
    }
}
