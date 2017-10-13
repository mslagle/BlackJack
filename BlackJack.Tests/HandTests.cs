using BlackJack.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.Tests
{
    [TestClass]
    public class HandTests
    {
        [TestMethod]
        public void HandTotal_Normal()
        {
            Hand hand = new Hand();
            hand.AddCard(new Card(5, "5", Suit.Clubs));
            hand.AddCard(new Card(7, "7", Suit.Clubs));

            Assert.AreEqual(12, hand.BestTotal());
        }

        [TestMethod]
        public void HandTotal_OneAce_NotOver()
        {
            Hand hand = new Hand();
            hand.AddCard(new Card(5, "5", Suit.Clubs));
            hand.AddCard(new Card(11, "A", Suit.Clubs));

            Assert.AreEqual(16, hand.BestTotal());
        }

        [TestMethod]
        public void HandTotal_OneAce_Over()
        {
            Hand hand = new Hand();
            hand.AddCard(new Card(10, "10", Suit.Clubs));
            hand.AddCard(new Card(10, "10", Suit.Clubs));
            hand.AddCard(new Card(11, "A", Suit.Clubs));

            Assert.AreEqual(21, hand.BestTotal());
        }

        [TestMethod]
        public void HandTotal_TwoAce_Over()
        {
            Hand hand = new Hand();
            hand.AddCard(new Card(10, "10", Suit.Clubs));
            hand.AddCard(new Card(11, "A", Suit.Clubs));
            hand.AddCard(new Card(11, "A", Suit.Clubs));

            Assert.AreEqual(12, hand.BestTotal());
        }

        [TestMethod]
        public void HandTotal_ThreeAce_Over()
        {
            Hand hand = new Hand();
            hand.AddCard(new Card(10, "10", Suit.Clubs));
            hand.AddCard(new Card(11, "A", Suit.Clubs));
            hand.AddCard(new Card(11, "A", Suit.Clubs));
            hand.AddCard(new Card(11, "A", Suit.Clubs));

            Assert.AreEqual(13, hand.BestTotal());
        }

        [TestMethod]
        public void HandTotal_FourAce_Over()
        {
            Hand hand = new Hand();
            hand.AddCard(new Card(10, "10", Suit.Clubs));
            hand.AddCard(new Card(11, "A", Suit.Clubs));
            hand.AddCard(new Card(11, "A", Suit.Clubs));
            hand.AddCard(new Card(11, "A", Suit.Clubs));
            hand.AddCard(new Card(11, "A", Suit.Clubs));

            Assert.AreEqual(14, hand.BestTotal());
        }
    }
}
