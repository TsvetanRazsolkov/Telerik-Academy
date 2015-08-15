using System;
using System.Linq;

namespace Poker
{
    public class PokerHandsChecker : IPokerHandsChecker
    {
        public const int ValidHandCardCount = 5;

        public bool IsValidHand(IHand hand)
        {
            if (hand == null)
            {
                throw new ArgumentNullException("Hand cannot be null.");
            }

            if (hand.Cards.Count != ValidHandCardCount)
            {
                return false;
            }

            for (int i = 0; i < ValidHandCardCount; i++)
            {
                var currentCard = hand.Cards[i];
                for (int j = i + 1; j < hand.Cards.Count; j++)
                {
                    if (hand.Cards[j].Face == currentCard.Face
                        && hand.Cards[j].Suit == currentCard.Suit)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public bool IsStraightFlush(IHand hand)
        {
            if (!this.IsValidHand(hand))
            {
                throw new ArgumentException("Invalid hand");
            }

            bool isStraight = true; ;

            var sortedCardFaces = hand.Cards.Select(c => (int)c.Face)
                                              .OrderBy(faceValue => faceValue)
                                              .ToArray();

            if (sortedCardFaces.Contains((int)CardFace.Ace)
                && sortedCardFaces.Contains((int)CardFace.Two))
            {
                var indexOfAce = Array.IndexOf(sortedCardFaces, (int)CardFace.Ace);
                sortedCardFaces[indexOfAce] = 1;

                sortedCardFaces = sortedCardFaces.OrderBy(faceValue => faceValue)
                                                           .ToArray();
            }

            for (int i = 0; i < sortedCardFaces.Length - 1; i++)
            {
                if ((sortedCardFaces[i] + 1) != sortedCardFaces[i + 1])
                {
                    isStraight = false;
                }
            }

            bool isFlush = hand.Cards.GroupBy(c => c.Suit).Count() == 1;

            return isStraight && isFlush;
        }

        public bool IsFourOfAKind(IHand hand)
        {
            if (!this.IsValidHand(hand))
            {
                throw new ArgumentException("Invalid hand");
            }

            var groups = hand.Cards.GroupBy(c => c.Face);

            return groups.Any(gr => gr.Count() == 4);
        }

        public bool IsFullHouse(IHand hand)
        {
            if (!this.IsValidHand(hand))
            {
                throw new ArgumentException("Invalid hand");
            }

            var groups = hand.Cards.GroupBy(c => c.Face);

            return groups.Any(gr => gr.Count() == 3) && groups.Any(gr => gr.Count() == 2);
        }

        public bool IsFlush(IHand hand)
        {
            if (!this.IsValidHand(hand))
            {
                throw new ArgumentException("Invalid hand");
            }

            bool isFlush = hand.Cards.GroupBy(c => c.Suit).Count() == 1;

            return isFlush && !this.IsStraightFlush(hand);
        }

        public bool IsStraight(IHand hand)
        {
            if (!this.IsValidHand(hand))
            {
                throw new ArgumentException("Invalid hand");
            }

            if (hand.Cards.GroupBy(c => c.Suit).Count() == 1)
            {
                return false;
            }

            var sortedCardFaces = hand.Cards.Select(c => (int)c.Face)
                                              .OrderBy(faceValue => faceValue)
                                              .ToArray();

            if (sortedCardFaces.Contains((int)CardFace.Ace)
                && sortedCardFaces.Contains((int)CardFace.Two))
            {
                var indexOfAce = Array.IndexOf(sortedCardFaces, (int)CardFace.Ace);
                sortedCardFaces[indexOfAce] = 1;

                sortedCardFaces = sortedCardFaces.OrderBy(faceValue => faceValue)
                                                           .ToArray();
            }

            for (int i = 0; i < sortedCardFaces.Length - 1; i++)
            {
                if ((sortedCardFaces[i] + 1) != sortedCardFaces[i + 1])
                {
                    return false;
                }
            }

            return true;
        }

        public bool IsThreeOfAKind(IHand hand)
        {
            if (!this.IsValidHand(hand))
            {
                throw new ArgumentException("Invalid hand");
            }

            var groups = hand.Cards.GroupBy(c => c.Face);

            return groups.Any(gr => gr.Count() == 3)
                   && !groups.Any(gr => gr.Count() == 2);
        }

        public bool IsTwoPair(IHand hand)
        {
            if (!this.IsValidHand(hand))
            {
                throw new ArgumentException("Invalid hand");
            }

            var groups = hand.Cards.GroupBy(c => c.Face)
                                   .Where(gr => gr.Count() == 2);

            return groups.Count() == 2;
        }

        public bool IsOnePair(IHand hand)
        {
            if (!this.IsValidHand(hand))
            {
                throw new ArgumentException("Invalid hand");
            }

            var groups = hand.Cards.GroupBy(c => c.Face);

            return groups.Count(gr => gr.Count() == 2) == 1
                   && !groups.Any(gr => gr.Count() == 3);
        }

        public bool IsHighCard(IHand hand)
        {
            if (!this.IsValidHand(hand))
            {
                throw new ArgumentException("Invalid hand");
            }

            var groups = hand.Cards.GroupBy(c => c.Face);

            return groups.Count() == 5
                  && !this.IsFlush(hand)
                  && !this.IsStraight(hand)
                  && !this.IsStraightFlush(hand);
        }

        public int CompareHands(IHand firstHand, IHand secondHand)
        {
            if (firstHand == null || secondHand == null)
	        {
                throw new ArgumentNullException("Cannot compare null hands");
	        }

            // One check to see if there are same cards in both hands
            // Should be resolved in the dealing logic, eventually;)
            foreach (var card in firstHand.Cards)
            {
                if (secondHand.Cards.Any(x => x.Face == card.Face && x.Suit == card.Suit))
                {
                    throw new InvalidOperationException("Cannot compare hands with same cards.");
                }
            }

            var firstHandType = this.GetHandType(firstHand);
            var secondHandType = this.GetHandType(secondHand);

            if (firstHandType != secondHandType)
            {
                return firstHandType.CompareTo(secondHandType);
            }
            else
            {
                switch (firstHandType)
                {
                    case HandType.HighCard:
                        return this.CompareHighCardHands(firstHand, secondHand);
                    case HandType.OnePair:
                        return this.CompareOnePairHands(firstHand, secondHand);
                    case HandType.TwoPair:
                        return this.CompareTwoPairHands(firstHand, secondHand);
                    case HandType.ThreeOfAKind:
                        return this.CompareThreeOfAKindHands(firstHand, secondHand);
                    case HandType.Straight:
                        return this.CompareStraightHands(firstHand, secondHand);
                    case HandType.Flush:
                    case HandType.StraightFlush:
                        return this.CompareFlushHands(firstHand, secondHand);
                    case HandType.FullHouse:
                        return this.CompareFullHouseHands(firstHand, secondHand);
                    case HandType.FourOfAKind:
                        return this.CompareFourOfAKindHands(firstHand, secondHand);
                    default:
                        throw new InvalidOperationException("Cannot compare invalid hands");
                }
            }
        }

        private int CompareTwoPairHands(IHand firstHand, IHand secondHand)
        {
            var firstHandCards = firstHand.Cards.Select(c => (int)c.Face)
                                                .ToArray();
            int firstHandTopPairValue = firstHandCards.Where(faceValue => firstHandCards.Count(x => x == faceValue) == 2)
                                                      .Max();

            var secondHandCards = secondHand.Cards.Select(c => (int)c.Face)
                                                .ToArray();
            int secondHandTopPairValue = secondHandCards.Where(faceValue => secondHandCards.Count(x => x == faceValue) == 2)
                                                      .Max();

            if (firstHandTopPairValue.CompareTo(secondHandTopPairValue) != 0)
            {
                return firstHandTopPairValue.CompareTo(secondHandTopPairValue);
            }
            else
            {
                int firstHandLowPairValue = firstHandCards.Where(faceValue => firstHandCards.Count(x => x == faceValue) == 2)
                                                      .Min();
                int secondHandLowPairValue = secondHandCards.Where(faceValue => secondHandCards.Count(x => x == faceValue) == 2)
                                                      .Min();

                if (firstHandLowPairValue.CompareTo(secondHandLowPairValue) != 0)
                {
                    return firstHandLowPairValue.CompareTo(secondHandLowPairValue);
                }
                else
                {
                    int firstHandKicker = firstHandCards.Where(faceValue => firstHandCards.Count(x => x == faceValue) == 1)
                                                      .ToArray()[0];
                    int secondHandKicker = secondHandCards.Where(faceValue => secondHandCards.Count(x => x == faceValue) == 1)
                                                      .ToArray()[0];

                    return firstHandKicker.CompareTo(secondHandKicker);
                }
            }
        }

        private int CompareOnePairHands(IHand firstHand, IHand secondHand)
        {
            int firstHandPairValue = this.GetValueOfGroupOfSameCards(firstHand, 2);
            int secondHandPairValue = this.GetValueOfGroupOfSameCards(secondHand, 2);

            if (firstHandPairValue.CompareTo(secondHandPairValue) != 0)
            {
                return firstHandPairValue.CompareTo(secondHandPairValue);
            }
            else
            {
                return this.CompareSingleCards(firstHand, secondHand);
            }
        }

        private int CompareThreeOfAKindHands(IHand firstHand, IHand secondHand)
        {
            var firstHandValue = this.GetValueOfGroupOfSameCards(firstHand, 3);
            var secondHandValue = this.GetValueOfGroupOfSameCards(secondHand, 3);

            return firstHandValue.CompareTo(secondHandValue);
        }

        private int CompareStraightHands(IHand firstHand, IHand secondHand)
        {
            var firstHandHighCard = firstHand.Cards.Select(c => (int)c.Face)
                                                 .OrderByDescending(faceValue => faceValue)
                                                 .ToArray()[0];
            var secondHandHighCard = secondHand.Cards.Select(c => (int)c.Face)
                                                 .OrderByDescending(faceValue => faceValue)
                                                 .ToArray()[0];

            return firstHandHighCard.CompareTo(secondHandHighCard);
        }

        private int CompareFullHouseHands(IHand firstHand, IHand secondHand)
        {
            int firstHandThreeValue = this.GetValueOfGroupOfSameCards(firstHand, 3);
            int secondHandThreeValue = this.GetValueOfGroupOfSameCards(secondHand, 3);

            if (firstHandThreeValue.CompareTo(secondHandThreeValue) != 0)
            {
                return firstHandThreeValue.CompareTo(secondHandThreeValue);
            }
            else
            {
                var firstHandPairValue = this.GetValueOfGroupOfSameCards(firstHand, 2);
                var secondHandPairValue = this.GetValueOfGroupOfSameCards(secondHand, 2);

                return firstHandPairValue.CompareTo(secondHandPairValue);
            }            
        }        

        private int CompareFourOfAKindHands(IHand firstHand, IHand secondHand)
        {
            int firstHandValue = this.GetValueOfGroupOfSameCards(firstHand, 4);
            int secondHandValue = this.GetValueOfGroupOfSameCards(secondHand, 4);

            return firstHandValue.CompareTo(secondHandValue);
        }

        private int CompareHighCardHands(IHand firstHand, IHand secondHand)
        {
            var result = this.CompareSingleCards(firstHand, secondHand);

            return result;
        }

        private int CompareFlushHands(IHand firstHand, IHand secondHand)
        {
            var result = this.CompareSingleCards(firstHand, secondHand);

            return result;
        }

        private int CompareSingleCards(IHand firstHand, IHand secondHand)
        {
            var firstHandCards = firstHand.Cards.Select(c => (int)c.Face);
            var firstHandSingleCards = firstHandCards.Where(faceValue => firstHandCards.Count(x => x == faceValue) == 1)
                                                     .OrderByDescending(faceValue => faceValue)
                                                     .ToArray();

            var secondHandCards = secondHand.Cards.Select(c => (int)c.Face);
            var secondHandSingleCards = secondHandCards.Where(faceValue => secondHandCards.Count(x => x == faceValue) == 1)
                                                     .OrderByDescending(faceValue => faceValue)
                                                     .ToArray();

            for (int i = 0; i < firstHandSingleCards.Length; i++)
            {
                if (firstHandSingleCards[i].CompareTo(secondHandSingleCards[i]) != 0)
                {
                    return firstHandSingleCards[i].CompareTo(secondHandSingleCards[i]);
                }
            }

            return 0;
        }

        private int GetValueOfGroupOfSameCards(IHand hand, int countOfSameCards)
        {
            var handCards = hand.Cards.Select(c => (int)c.Face);
            int value = handCards.Where(faceValue => handCards.Count(x => x == faceValue) == countOfSameCards)
                                 .ToArray()[0];

            return value;
        }

        private HandType GetHandType(IHand hand)
        {
            if (this.IsHighCard(hand))
            {
                return HandType.HighCard;
            }
            else if (this.IsOnePair(hand))
            {
                return HandType.OnePair;
            }
            else if (this.IsTwoPair(hand))
            {
                return HandType.TwoPair;
            }
            else if (this.IsThreeOfAKind(hand))
            {
                return HandType.ThreeOfAKind;
            }
            else if (this.IsStraight(hand))
            {
                return HandType.Straight;
            }
            else if (this.IsFlush(hand))
            {
                return HandType.Flush;
            }
            else if (this.IsFullHouse(hand))
            {
                return HandType.FullHouse;
            }
            else if (this.IsFourOfAKind(hand))
            {
                return HandType.FourOfAKind;
            }
            else
            {
                return HandType.StraightFlush;
            }
        }
    }
}
