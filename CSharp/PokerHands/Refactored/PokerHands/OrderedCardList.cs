using System.Collections.Generic;

namespace PokerHands
{
    internal class OrderedCardList
    {
        public CardValue Value { get; set; }
        public int Count { get; set; }
        public List<Card> PlayerCards { get; set; }

        public static OrderedCardList CreateHandFromCards(List<Card> playerHand)
        {
            return new OrderedCardList
                   {
                           PlayerCards = playerHand
                   };
        }
    }
}