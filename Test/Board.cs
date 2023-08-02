using System.Collections.Generic;

namespace Test
{
    public class Board
    {
        private List<Player> players;
        private Deck deck;
        private Deck discardPile;

        public IReadOnlyList<Player> Players => players;
        public Deck Deck => deck;
        public Deck DiscardPile => discardPile;

        public Board()
        {
            players = new List<Player>();
            deck = new Deck();
            discardPile = new Deck();
            deck.Fill();
        }

        public void AddPlayer(string name)
        {
            Player player = new Player(name);
            players.Add(player);
        }

        public void DealCardsToPlayers(int numCards)
        {
            for (int i = 0; i < numCards; i++)
            {
                foreach (Player player in players)
                {
                    player.Draw(deck);
                }
            }
        }

        public void Discard(Card card)
        {
            discardPile.Add(card);
        }

        // if deck is empty, shuffle discard pile and make it the deck
        public void ShuffleDeckIfEmpty()
        {
            if (deck.Cards.Count == 0)
            {
                deck = discardPile;
                discardPile = new Deck();
                deck.Shuffle();
            }
        }

        public bool HasThreeOfAKindAndPair(Player player)
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
            deck = new Deck();
            discardPile = new Deck();
            players.Clear();
        }
    }
}
