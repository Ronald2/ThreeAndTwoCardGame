using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Test
{
    public class Player
    {
        public string Name { get; }
        private List<Card> hand { get; set;}

        public IEnumerable<Card> Hand => hand;

        public Player(string name)
        {
            Name = name;
            hand = new List<Card>();
        }

        public Card? Draw(Deck deck)
        {
            if (deck.Cards.Count > 0)
            {
                Card card = deck.Deal();
                hand.Add(card);
                return card;
            }
            return null;
        }

        public Card? Discard(int index)
        {
            if (index < 0 || index >= hand.Count)
            {
                return null;
            }
            else
            {
                Card card = hand[index];
                hand.RemoveAt(index);
                return card;
            }
        }

        public override string ToString()
        {
            return $"Player: {Name}, Hand: {string.Join(", ", hand)}";
        }

        
    }
}