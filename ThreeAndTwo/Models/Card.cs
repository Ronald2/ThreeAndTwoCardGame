using ThreeAndTwo.UI;

namespace ThreeAndTwo.Models
{
    public class Card
    {
        public CardRank Rank { get; }
        public CardSuit Suit { get; }
        private static CardDesign cardDesign = new CardDesign();
        public bool IsFaceUp { get; private set; }

        public Card(CardRank rank, CardSuit suit)
        {
            Rank = rank;
            Suit = suit;
            IsFaceUp = true;
        }

        public void Flip()
        {
            IsFaceUp = !IsFaceUp;
        }

        public override string ToString()
        {
            if (IsFaceUp)
            {
                return cardDesign.GetCardDesign(Rank, Suit);
            }
            else
            {
                return "Face Down";
            }
        }

        public override bool Equals(object? obj)
        {
            if (obj == null || !(obj is Card))
            {
                return false;
            }

            Card otherCard = (Card)obj;
            return Rank == otherCard.Rank && Suit == otherCard.Suit;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
                hash = hash * 23 + Rank.GetHashCode();
                hash = hash * 23 + Suit.GetHashCode();
                return hash;
            }
        }
    }
}
