using ThreeAndTwo.Models;

namespace ThreeAndTwo.Game
{
    public class Player
    {
        public string Name { get; }
        private List<Card> hand { get; set; }

        public IEnumerable<Card> Hand => hand;

        public Player(string name)
        {
            Name = name;
            hand = new List<Card>();
        }

        public Card Draw(Deck deck)
        {
            if (deck.Cards.Count > 0)
            {
                Card card = deck.Deal();
                hand.Add(card);
                hand.Sort((c1, c2) => c1.Rank.CompareTo(c2.Rank));
                return card;
            }
            return null;
        }

        public Card Discard(int index)
        {
            if (index < 1 || index > hand.Count)
            {
                return null;
            }
            else
            {
                Card card = hand[index - 1];
                hand.Remove(card);
                return card;
            }
        }

        public string ShowHand()
        {
            var playerHand = hand.Select((card, index) => $"{index + 1}-{card}");
            return $"Hand: {string.Join(", ", playerHand)}";
        }
    }
}