using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerHands
{
    class PlayerHand
    {
        public PlayerHand(IList<Card> cardList)
        {
            Cards = cardList;
        }

        public IList<Card> Cards { get; set; }

        public bool IsFlush
        {
            get { return Cards.All(i => i.Suit == Cards.Select(j => j.Suit).FirstOrDefault()); }
        }
    }
}
