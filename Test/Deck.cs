using System;
using System.Collections.Generic;
using System.Text;

namespace Test
{
    public class Deck
    {
        private List<Card> cards;
        private Random random;

        public IReadOnlyList<Card> Cards => cards;

        public Deck()
        {
            cards = new List<Card>();
            random = new Random();
        }

        public void Shuffle()
        {
            for (int i = 0; i < cards.Count; i++)
            {
                int j = random.Next(cards.Count);
                Card temp = cards[i];
                cards[i] = cards[j];
                cards[j] = temp;
            }
        }

        public void Fill()
        {
            foreach (CardSuit suit in Enum.GetValues(typeof(CardSuit)))
            {
                foreach (CardRank rank in Enum.GetValues(typeof(CardRank)))
                {
                    cards.Add(new Card(rank, suit));
                }
            }
        }

        public void Add(Card card)
        {
            cards.Add(card);
        }

        public Card Deal()
        {
            if (cards.Count == 0)
            {
                throw new InvalidOperationException("The deck is empty. Cannot deal a card.");
            }

            Card card = cards[0];
            cards.RemoveAt(0);
            return card;
        }

        public Card ShowLastCard()
        {
            if (cards.Count == 0)
            {
                throw new InvalidOperationException("The deck is empty. There are no cards to show.");
            }

            return cards[cards.Count - 1];
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            foreach (Card card in cards)
            {
                sb.AppendLine(card.ToString());
            }
            return sb.ToString();
        }
    }
}
