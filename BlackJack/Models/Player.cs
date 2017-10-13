using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.Models
{
    public class Player
    {
        public int Money { get; set; }
        public Hand Hand { get; set; }

        public Player(int startingMoney)
        {
            this.Money = startingMoney;
        }

        public void NewHand()
        {
            this.Hand = new Hand();
        }

        public void AddCard(Card card)
        {
            this.Hand.AddCard(card);
        }

    }
}
