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
    }
}
