using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.Models
{
    public class Card
    {
        public int Value { get; set; }
        public string ValueName { get; set; }
        public Suit Suit { get; set; }

        public Card(int value, string valueName, Suit suit)
        {
            this.Value = value;
            this.ValueName = valueName;
            this.Suit = suit;
        }

        public string PrintCard()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("-----");
            sb.AppendLine($"|{SuitToString(this.Suit)}  |");
            sb.AppendLine($"| {this.ValueName.PadRight(2)}|");
            sb.AppendLine($"|  {SuitToString(this.Suit)}|");
            sb.AppendLine("-----");

            return sb.ToString();
        }

        public string PrintCard(int line, bool show = true)
        {

            if (line == 2)
            {
                if (show)
                    return $"|{SuitToString(this.Suit)}  |";
                else
                    return "|*  |";
            }

            if (line == 3)
            {
                if (show)
                    return $"| {this.ValueName.PadRight(2)}|";
                else
                    return "| * |";
            }

            if (line == 4)
            {
                if (show)
                    return $"|  {SuitToString(this.Suit)}|";
                else
                    return "|  *|";
            }

            return "-----";
        }

        public string SuitToString(Suit suit)
        {
            if (suit == Suit.Clubs)
            {
                return "\u2663";
            }
            if (suit == Suit.Diamonds)
            {
                return "\u2666";
            }
            if (suit == Suit.Hearts)
            {
                return "\u2665";
            }
            if (suit == Suit.Spades)
            {
                return "\u2660";
            }

            return null;
        }
    }

    public enum Suit
    {
        Hearts,
        Diamonds,
        Clubs,
        Spades
    }
}
