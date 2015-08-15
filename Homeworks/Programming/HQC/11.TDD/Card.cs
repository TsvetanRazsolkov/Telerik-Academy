using System;
using System.Text;

namespace Poker
{
    public class Card : ICard
    {
        public CardFace Face { get; private set; }
        public CardSuit Suit { get; private set; }

        public Card(CardFace face, CardSuit suit)
        {
            this.Face = face;
            this.Suit = suit;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            string cardFaceString = GetCardFaceString();
            char cardSuitSymbol = GetCardSuitSymbol();

            sb.Append(cardFaceString);
            sb.Append(cardSuitSymbol);

            return sb.ToString();

        }

        private char GetCardSuitSymbol()
        {
            switch (this.Suit)
            {
                case CardSuit.Clubs:
                    return '♣';
                case CardSuit.Diamonds:
                    return '♦';
                case CardSuit.Hearts:
                    return '♥';
                case CardSuit.Spades:
                    return '♠';
                default:
                    return ' ';
            }
        }

        private string GetCardFaceString()
        {
            switch (this.Face)
            {
                case CardFace.Two:
                    return "2";
                case CardFace.Three:
                    return "3";
                case CardFace.Four:
                    return "4";
                case CardFace.Five:
                    return "5";
                case CardFace.Six:
                    return "6";
                case CardFace.Seven:
                    return "7";
                case CardFace.Eight:
                    return "8";
                case CardFace.Nine:
                    return "9";
                case CardFace.Ten:
                    return "10";
                case CardFace.Jack:
                    return "J";
                case CardFace.Queen:
                    return "Q";
                case CardFace.King:
                    return "K";
                case CardFace.Ace:
                    return "A";
                default:
                    return string.Empty;
            }
        }
    }
}
