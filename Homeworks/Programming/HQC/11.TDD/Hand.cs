using System;
using System.Collections.Generic;
using System.Text;

namespace Poker
{
    public class Hand : IHand
    {
        public IList<ICard> Cards { get; private set; }

        public Hand(IList<ICard> cards)
        {
            this.Cards = cards;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            foreach (Card card in this.Cards)
            {
                sb.Append(card.ToString());
                sb.Append(" ");
            }

            return sb.ToString().Trim();
        }
    }
}
