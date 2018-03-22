using System.Collections.Generic;
using System.Linq;

namespace PokerHands
{
    internal class PlayerHandFormatter
    {
        private readonly List<OrderedCardList> _cardsByValues;
        private readonly IEnumerable<Card> _hand;

        public PlayerHandFormatter(IEnumerable<Card> hand1)
        {
            _hand = hand1;

            _cardsByValues = GetHandByValues(hand1);
        }

        public bool IsStraight
        {
            get { return CheckForStraight(); }
        }

        private int LowestCard
        {
            get { return _hand.Min(x => GetValueFromCard(x.CardValue)); }
        }

        private static List<OrderedCardList> GetHandByValues(IEnumerable<Card> hand1)
        {
            return hand1.GroupBy(i => i.CardValue).Select(g => new OrderedCardList()
                                                               {
                                                                       Value = g.Key,
                                                                       Count = g.Select(v => (int)v.CardValue).Count()
                                                               }).OrderBy(x => x.Value).ToList();
        }

        private bool CheckForStraight()
        {
            var lowestHand1Value = LowestCard;

            var isHand1AStraight = _cardsByValues.Count == 5;

            if (_cardsByValues.Count != 5) return isHand1AStraight;

            if (_cardsByValues.Any(i => i.Value == CardValue.Ace))
                for (var i = 0; i < 4; i++)
                    if (_cardsByValues.Any(v => (int)v.Value == (i))) ;
                    else isHand1AStraight = false;
            else
                for (var i = 0; i < 4; i++)
                    if (_cardsByValues.Any(v => (int)v.Value == (lowestHand1Value))) lowestHand1Value = lowestHand1Value + 1;
                    else
                    {
                        isHand1AStraight = false;

                        break;
                    }

            return isHand1AStraight;
        }

        private static int GetValueFromCard(CardValue cardValue)
        {
            return (int)cardValue;
        }
    }
}