using System.Collections.Generic;

namespace PokerHands
{
    internal class PlayerHand
    {
        public CardValue Value { get; set; }
        public int Count { get; set; }
        public List<Card> PlayerCards { get; set; }

        public static PlayerHand CreateHandFromCards(List<Card> playerHand)
        {
            return new PlayerHand
                   {
                           PlayerCards = playerHand
                   };
        }
    }
}