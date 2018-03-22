﻿using System.Collections.Generic;
using System.Linq;

namespace PokerHands
{
    public class HandRanker
    {
//        private IList<Card> _hand1;
        private PlayerHand _hand1;
        private List<OrderedCardList> _hand1ByValues;
        private bool _hand1Flush;
        private IList<Card> _hand2;
        private List<OrderedCardList> _hand2ByValues;
        private bool _hand2Flush;
        private bool _isHand1AStraight;
        private bool _isHand2AStraight;
        private PlayerHandFormatter _hand1Hand;
        private PlayerHandFormatter _hand2Hand;

        public int RankHands(IList<Card> hand1, IList<Card> hand2)
        {
            _hand1 = new PlayerHand(hand1);

            _hand2 = hand2;

            _hand1Hand = new PlayerHandFormatter(hand1);

            _hand2Hand = new PlayerHandFormatter(hand2);

            _hand1ByValues = GetHandByValues(_hand1.Cards);

            _hand2ByValues = GetHandByValues(_hand2);

            _isHand1AStraight = _hand1Hand.IsStraight;

            _isHand2AStraight = _hand2Hand.IsStraight;

            _hand1Flush = _hand1.Cards.All(i => i.Suit == _hand1.Cards.Select(j => j.Suit).FirstOrDefault());
            _hand2Flush = _hand2.All(i => i.Suit == _hand2.Select(j => j.Suit).FirstOrDefault());

            if ((_hand1Flush && _isHand1AStraight) || (_hand2Flush && _isHand2AStraight)) return IHandleSomeWierdKickerRule();

            if (APlayerHasSomeOfAKind(4)) return HandleFourOfAKind();

            if (IsFullHouse())
            {
                if ((_hand1ByValues.Any(i => i.Count == 3) && _hand1ByValues.Any(i => i.Count == 2)) &&  !(_hand2ByValues.Any(i => i.Count == 3) && _hand2ByValues.Any(i => i.Count == 2))) return 1;

                if (!(_hand1ByValues.Any(i => i.Count == 3) && _hand1ByValues.Any(i => i.Count == 2))) return 2;
            }

            if (_hand1Flush || _hand2Flush)
            {
                if (_hand1Flush && !_hand2Flush) return 1;

                if (!_hand1Flush) return 2;
            }

            if (APlayerHasAStraight()) return ProcessStraight();

            if (APlayerHasSomeOfAKind(3))
            {
                var hand1ThreeOfAKindValue = _hand1ByValues.Where(i => i.Count == 3).Select(i => i.Value).FirstOrDefault();
                var hand2ThreeOfAKindValue = _hand2ByValues.Where(i => i.Count == 3).Select(i => i.Value).FirstOrDefault();

                if (hand1ThreeOfAKindValue > hand2ThreeOfAKindValue) return 1;

                if (hand2ThreeOfAKindValue > hand1ThreeOfAKindValue) return 2;
            }

            // One of the hands have 2 pairs
            if (_hand1ByValues.Count(i => i.Count == 2) == 2 || _hand2ByValues.Count(i => i.Count == 2) == 2)
            {
                if (_hand1ByValues.Count(i => i.Count == 2) == 2 && _hand2ByValues.Count(i => i.Count == 2) != 2) return 1;

                if (_hand2ByValues.Count(i => i.Count == 2) == 2 && _hand1ByValues.Count(i => i.Count == 2) != 2) return 2;

                // Both Have 2 Pair find Highest Pair Value
                var hand1HighestPairValue = _hand1ByValues.Where(i => i.Count == 2).OrderByDescending(i => i.Value).Select(i => i.Value).FirstOrDefault();
                var hand2HighestPairValue = _hand2ByValues.Where(i => i.Count == 2).OrderByDescending(i => i.Value).Select(i => i.Value).FirstOrDefault();

                if (hand1HighestPairValue > hand2HighestPairValue) return 1;

                if (hand1HighestPairValue < hand2HighestPairValue) return 2;

                // Same Highest Pair must compare next
                _hand1ByValues = _hand1ByValues.Where(i => i.Value != hand1HighestPairValue).ToList();
                _hand2ByValues = _hand2ByValues.Where(i => i.Value != hand2HighestPairValue).ToList();
            }

            if (APlayerHasSomeOfAKind(2)) return HandlePairs();

            return HandleHighCard();
        }

        private int HandleHighCard()
        {
            // No Pairs high card wins
            if (_hand1.Cards.Max(i => (int)i.CardValue) > _hand2.Max(i => (int)i.CardValue)) return 1;

            if (_hand1.Cards.Max(i => (int)i.CardValue) < _hand2.Max(i => (int)i.CardValue)) return 2;

            // Have Same High Card Must remove the high card and compare  4 Cards Left
            var hand1MaxCard = _hand1.Cards.FirstOrDefault(j => (int)j.CardValue == _hand1.Cards.Max(i => (int)i.CardValue));

            _hand1.Cards.Remove(hand1MaxCard);

            var hand2MaxCard = _hand2.FirstOrDefault(j => (int)j.CardValue == _hand2.Max(i => (int)i.CardValue));

            _hand2.Remove(hand2MaxCard);

            if (_hand1.Cards.Max(i => (int)i.CardValue) > _hand2.Max(i => (int)i.CardValue)) return 1;

            if (_hand1.Cards.Max(i => (int)i.CardValue) < _hand2.Max(i => (int)i.CardValue)) return 2;

            // Have Same High Card Must remove the high card and compare 3 Cards Left
            hand1MaxCard = _hand1.Cards.FirstOrDefault(j => (int)j.CardValue == _hand1.Cards.Max(i => (int)i.CardValue));

            _hand1.Cards.Remove(hand1MaxCard);

            hand2MaxCard = _hand2.FirstOrDefault(j => (int)j.CardValue == _hand2.Max(i => (int)i.CardValue));

            _hand2.Remove(hand2MaxCard);

            if (_hand1.Cards.Max(i => (int)i.CardValue) > _hand2.Max(i => (int)i.CardValue)) return 1;

            if (_hand1.Cards.Max(i => (int)i.CardValue) < _hand2.Max(i => (int)i.CardValue)) return 2;

            // Have Same High Card Must remove the high card and compare 2 Cards Left
            hand1MaxCard = _hand1.Cards.FirstOrDefault(j => (int)j.CardValue == _hand1.Cards.Max(i => (int)i.CardValue));

            _hand1.Cards.Remove(hand1MaxCard);

            hand2MaxCard = _hand2.FirstOrDefault(j => (int)j.CardValue == _hand2.Max(i => (int)i.CardValue));

            _hand2.Remove(hand2MaxCard);

            if (_hand1.Cards.Max(i => (int)i.CardValue) > _hand2.Max(i => (int)i.CardValue)) return 1;

            if (_hand1.Cards.Max(i => (int)i.CardValue) < _hand2.Max(i => (int)i.CardValue)) return 2;

            // Have Same High Card Must remove the high card and compare 1 Cards Left
            hand1MaxCard = _hand1.Cards.FirstOrDefault(j => (int)j.CardValue == _hand1.Cards.Max(i => (int)i.CardValue));

            _hand1.Cards.Remove(hand1MaxCard);

            hand2MaxCard = _hand2.FirstOrDefault(j => (int)j.CardValue == _hand2.Max(i => (int)i.CardValue));

            _hand2.Remove(hand2MaxCard);

            if (_hand1.Cards.Max(i => (int)i.CardValue) > _hand2.Max(i => (int)i.CardValue)) return 1;

            if (_hand1.Cards.Max(i => (int)i.CardValue) < _hand2.Max(i => (int)i.CardValue)) return 2;

            return -1;
        }

        private int HandlePairs()
        {
            if (_hand1ByValues.Any(i => i.Count == 2) && _hand2ByValues.All(i => i.Count != 2)) return 1;

            if (_hand1ByValues.All(i => i.Count != 2) && _hand2ByValues.Any(i => i.Count == 2)) return 2;

            var hand1PairValue = _hand1ByValues.Where(i => i.Count == 2).Select(i => i.Value).FirstOrDefault();
            var hand2PairValue = _hand2ByValues.Where(i => i.Count == 2).Select(i => i.Value).FirstOrDefault();

            if (hand1PairValue > hand2PairValue) return 1;

            if (hand1PairValue < hand2PairValue) return 2;

            // Remove Pair Values 3 Cards Left
            _hand1 = new PlayerHand(_hand1.Cards.Where(i => i.CardValue != hand1PairValue).ToList());
            _hand2 = _hand2.Where(i => i.CardValue != hand1PairValue).ToList();

            // They have the same pair must compare kickers
            if (_hand1.Cards.Max(i => (int)i.CardValue) > _hand2.Max(i => (int)i.CardValue)) return 1;

            if (_hand1.Cards.Max(i => (int)i.CardValue) < _hand2.Max(i => (int)i.CardValue)) return 2;

            // They have the same kicker must remove max card 2 Cards Left
            var hand1MaxCardPair = _hand1.Cards.FirstOrDefault(j => (int)j.CardValue == _hand1.Cards.Max(i => (int)i.CardValue));

            _hand1.Cards.Remove(hand1MaxCardPair);

            var hand2MaxCardPair = _hand2.FirstOrDefault(j => (int)j.CardValue == _hand2.Max(i => (int)i.CardValue));

            _hand2.Remove(hand2MaxCardPair);

            if (_hand1.Cards.Max(i => (int)i.CardValue) > _hand2.Max(i => (int)i.CardValue)) return 1;

            if (_hand1.Cards.Max(i => (int)i.CardValue) < _hand2.Max(i => (int)i.CardValue)) return 2;

            // They have the same kicker must remove max card 1 Cards Left
            hand1MaxCardPair = _hand1.Cards.FirstOrDefault(j => (int)j.CardValue == _hand1.Cards.Max(i => (int)i.CardValue));

            _hand1.Cards.Remove(hand1MaxCardPair);

            hand2MaxCardPair = _hand2.FirstOrDefault(j => (int)j.CardValue == _hand2.Max(i => (int)i.CardValue));

            _hand2.Remove(hand2MaxCardPair);

            if (_hand1.Cards.Max(i => (int)i.CardValue) > _hand2.Max(i => (int)i.CardValue)) return 1;

            if (_hand1.Cards.Max(i => (int)i.CardValue) < _hand2.Max(i => (int)i.CardValue)) return 2;
            return -1;
        }

        private int ProcessStraight()
        {
            if (_isHand1AStraight && !_isHand2AStraight) return 1;

            if (!_isHand1AStraight) return 2;

            var hand1HighCard = GetHighestCard(_hand1.Cards);
            var hand2HighCard = GetHighestCard(_hand2);

            if (hand1HighCard == 12)
            {
                var lowCard = GetLowestCard(_hand1.Cards);

                if (lowCard == 0) hand1HighCard = 3;
            }

            if (hand2HighCard == 12)
            {
                var lowCard = _hand2ByValues.OrderBy(i => i.Value).Select(i => (int)i.Value).FirstOrDefault();

                if (lowCard == 0) hand2HighCard = 3;
            }

            if (hand1HighCard > hand2HighCard) return 1;

            if (hand1HighCard < hand2HighCard) return 2;

            return -1;
        }

        private bool APlayerHasAStraight()
        {
            return _isHand1AStraight || _isHand2AStraight;
        }

        private bool IsFullHouse()
        {
            return (HasNumberOfLikeSuits(_hand1ByValues, 3) && HasNumberOfLikeSuits(_hand1ByValues, 2) || (HasNumberOfLikeSuits(_hand2ByValues, 3) && HasNumberOfLikeSuits(_hand2ByValues, 2)));
        }

        private int IHandleSomeWierdKickerRule()
        {
            var hand1MaxValue = GetHighestCard(_hand1.Cards);
            var hand2MaxValue = GetHighestCard(_hand2);

            if (hand1MaxValue == GetValueFromCard(CardValue.Ace))
            {
                var lowCard = GetLowestCard(_hand1.Cards);

                if (lowCard == 0) hand1MaxValue = 3;
            }

            if (hand2MaxValue == GetValueFromCard(CardValue.Ace))
            {
                var lowCard = GetLowestCard(_hand2);

                if (lowCard == 0) hand2MaxValue = 3;
            }

            if (hand1MaxValue > hand2MaxValue) return 1;

            if (hand1MaxValue < hand2MaxValue) return 2;
            return 0;
        }

        private int HandleFourOfAKind()
        {
            if (_hand1ByValues.Any(i => i.Count == 4) && _hand2ByValues.All(i => i.Count != 4)) return 1;

            if (_hand2ByValues.Any(i => i.Count == 4) && _hand1ByValues.All(i => i.Count != 4)) return 2;

            var hand1FourOfAKindValue = _hand1ByValues.Where(i => i.Count == 4).Select(i => (int)i.Value).FirstOrDefault();
            var hand2FourOfAKindValue = _hand2ByValues.Where(i => i.Count == 4).Select(i => (int)i.Value).FirstOrDefault();

            if (hand1FourOfAKindValue > hand2FourOfAKindValue) return 1;

            if (hand2FourOfAKindValue > hand1FourOfAKindValue) return 2;
            return 0;
        }

        private bool APlayerHasSomeOfAKind(int i1)
        {
            return HasNumberOfLikeSuits(_hand1ByValues, i1) || _hand2ByValues.Any(i => i.Count == i1);
        }

        private static bool HasNumberOfLikeSuits(IEnumerable<OrderedCardList> hand1ByValues, int i1)
        {
            return hand1ByValues.Any(i => i.Count == i1);
        }

        private static int GetValueFromCard(CardValue cardValue)
        {
            return (int)cardValue;
        }

        private static int GetLowestCard(IEnumerable<Card> iList)
        {
            return iList.Min(x => GetValueFromCard(x.CardValue));
        }

        private static int GetHighestCard(IEnumerable<Card> iList)
        {
            return iList.Max(x => GetValueFromCard(x.CardValue));
        }

        private static List<OrderedCardList> GetHandByValues(IEnumerable<Card> hand1)
        {
            return hand1.GroupBy(i => i.CardValue).Select(g => new OrderedCardList()
                                                               {
                                                                       Value = g.Key,
                                                                       Count = g.Select(v => (int)v.CardValue).Count()
                                                               }).OrderBy(x => x.Value).ToList();
        }
    }
}