using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BlackJack.Models;

namespace BlackJack.Tests
{
    [TestClass]
    public class DeckTests
    {
        [TestMethod]
        public void DeckInitalizeTest()
        {
            Deck deck = new Deck();

            deck.Initalize(1);
            Assert.AreEqual(52, deck.Cards.Count);

            deck.Initalize(3);
            Assert.AreEqual(3*52, deck.Cards.Count);
        }
    }
}
