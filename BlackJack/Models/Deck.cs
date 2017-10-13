using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.Models
{
    public class Deck
    {
        public List<Card> Cards { get; set; }

        public void Initalize(int deckCount)
        {
            this.Cards = new List<Card>();

            while (deckCount-- > 0)
            {
                foreach (Suit suit in Enum.GetValues(typeof(Suit)))
                {
                    for (int cardNum = 2; cardNum <= 10; cardNum++)
                    {
                        Cards.Add(new Card(cardNum, cardNum.ToString(), suit));
                    }

                    Cards.Add(new Card(10, "J", suit));
                    Cards.Add(new Card(10, "Q", suit));
                    Cards.Add(new Card(10, "K", suit));
                    Cards.Add(new Card(11, "A", suit));
                }
            }

            Cards.Shuffle();
        }

        public Card DrawCard()
        {
            if (!Cards.Any())
            {
                return null;
            }

            Card card = Cards.Last();
            Cards.Remove(card);
            return card;
        }
    }
}
