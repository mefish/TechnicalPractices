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
        public List<OrderedCardList> GetHandByValues()
        {
            return Cards.GroupBy(i => i.CardValue).Select(g => new OrderedCardList()
                                                               {
                                                                   Value = g.Key,
                                                                   Count = g.Select(v => (int)v.CardValue).Count()
                                                               }).OrderBy(x => x.Value).ToList();
        }
    }
}
