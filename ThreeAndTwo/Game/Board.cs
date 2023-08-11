using ThreeAndTwo.Models;

namespace ThreeAndTwo.Game
{
    public class Board
    {
        private List<Player> players;
        private Deck deck;
        private Deck discardPile;

        public IReadOnlyList<Player> Players => players;
        public Deck Deck => deck;
        public Deck DiscardPile => discardPile;

        public Board(List<Player> players)
        {
            this.players = players;
            deck = new Deck();
            discardPile = new Deck();
            deck.Fill();
            deck.Shuffle();
        }

        public void DealCardsToAllPlayers(int numCards)
        {
            for (int i = 0; i < numCards; i++)
            {
                foreach (Player player in players)
                {
                    player.Draw(deck);
                }
            }
        }

        public void DealCardToPlayer(Player player)
        {
            ShuffleDeckIfEmpty();
            player.Draw(deck);
        }

        public void DiscardToSideDeck(Card card)
        {
            discardPile.Add(card);
        }

        //If the deck is empty, shuffle the discard pile and make it the new deck.
        private void ShuffleDeckIfEmpty()
        {
            if (deck.Cards.Count == 0)
            {
                deck = discardPile;
                discardPile = new Deck();
                deck.Shuffle();
            }
        }

        public void Reset()
        {
            deck = new Deck();
            discardPile = new Deck();
            players.Clear();
        }
    }
}
