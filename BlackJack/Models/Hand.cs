using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.Models
{
    public class Hand
    {
        public List<Card> Cards { get; set; }

        public bool IsSoft { get; private set; }

        public Hand()
        {
            this.Cards = new List<Card>();
            IsSoft = false;
        }

        public void AddCard (Card card)
        {
            this.Cards.Add(card);
        }

        public int BestTotal()
        {
            Card[] calcCards = new Card[Cards.Count];
            Cards.CopyTo(calcCards);

            IsSoft = calcCards.Any(x => x.Value == 11);

            while(calcCards.Sum(x => x.Value) > 21 && calcCards.Any(x => x.Value == 11))
            {
                calcCards.First(x => x.Value == 11).Value = 1;
                IsSoft = false;
            }

            return calcCards.Sum(x => x.Value);
        }
    }
}
