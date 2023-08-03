using ThreeAndTwo;
using ThreeAndTwo.Models;

namespace ThreeAndTwo
{
    public class CardDesigns
    {
        private Dictionary<CardRank, string> rankDesigns;
        private Dictionary<CardSuit, string> suitDesigns;

        public CardDesigns()
        {

            rankDesigns = new Dictionary<CardRank, string>
            {
                { CardRank.Two, "2" },
                { CardRank.Three, "3" },
                { CardRank.Four, "4" },
                { CardRank.Five, "5" },
                { CardRank.Six, "6" },
                { CardRank.Seven, "7" },
                { CardRank.Eight, "8" },
                { CardRank.Nine, "9" },
                { CardRank.Ten, "10" },
                { CardRank.Jack, "J" },
                { CardRank.Queen, "Q" },
                { CardRank.King, "K" },
                { CardRank.Ace, "A" },  
            };

            suitDesigns = new Dictionary<CardSuit, string>
            {
                { CardSuit.Hearts, "♥" },
                { CardSuit.Diamonds, "♦" },
                { CardSuit.Clubs, "♣" },
                { CardSuit.Spades, "♠" },
            };
        }

        public string GetCardDesign(CardRank rank, CardSuit suit)
        {
            return $"|{rankDesigns[rank]}{suitDesigns[suit]}|";
        }
    }
}

