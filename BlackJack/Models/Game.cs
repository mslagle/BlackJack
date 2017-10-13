using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.Models
{
    public class Game
    {
        public Player Dealer { get; set; }
        public Player Player { get; set; }

        public Game()
        {
            this.Dealer = new Player(100000000);
            this.Player = new Player(1000);
        }

        public void Play()
        {
            while (true)
            {
                NewGame();
            }
        }

        public int PlayerBet()
        {
            Console.WriteLine("Player - Place your bet in increments of 10!");

            while (true)
            {
                Console.Write("Bet Amount: ");

                string bet = Console.ReadLine();
                int betAmount = 0;

                if (!int.TryParse(bet, out betAmount))
                {
                    Console.Error.WriteLine("Please enter in only numeric entries!!!!!");
                }
                else if (betAmount % 10 != 0)
                {
                    Console.Error.WriteLine("Bets are only allowed in increments of 10!!!!!");
                }
                else if (betAmount > Player.Money)
                {
                    Console.Error.WriteLine("You can not bet more money than you have!!!!!");
                }
                else
                {
                    return betAmount;
                }
            }
        }

        public void NewGame()
        {
            Deck deck = new Deck();
            deck.Initalize(1);

            Dealer.NewHand();
            Player.NewHand();

            Console.Clear();
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine(GetLogo());
            Console.WriteLine();
            Console.WriteLine($"Player Money: ${Player.Money}.00");
            Console.WriteLine();

            int bet = PlayerBet();
            Console.WriteLine();

            Dealer.AddCard(deck.DrawCard());
            Dealer.AddCard(deck.DrawCard());

            Player.AddCard(deck.DrawCard());
            Player.AddCard(deck.DrawCard());

            bool playerWon = false;
            bool playerDone = false;

            // Player action!
            while(!playerDone)
            {
                Console.WriteLine("************************************************************************************");
                Console.WriteLine("== Dealer Cards ==");
                Console.WriteLine(PrintCards(Dealer.Hand, true));

                Console.WriteLine();
                Console.WriteLine("== Player Cards ==");
                Console.WriteLine(PrintCards(Player.Hand, false));
                Console.WriteLine();

                if (Player.Hand.BestTotal() == 21)
                {
                    Console.WriteLine("You got blackjack, you won!");

                    bet = (int)((double)bet * 1.5);
                    playerWon = true;
                    playerDone = true;
                    break;
                }

                if (Player.Hand.BestTotal() > 21)
                {
                    Console.WriteLine("You busted, you lost!");

                    playerWon = false;
                    playerDone = true;
                    break;
                }

                // H = false
                // S = true
                playerDone = PlayerAction(Player, deck);
            }

            bool dealerDone = false;
            while(playerWon == false && dealerDone == false && Player.Hand.BestTotal() < 21)
            {
                Console.WriteLine("Dealer's Turn!");

                Console.WriteLine("************************************************************************************");
                Console.WriteLine("== Dealer Cards ==");
                Console.WriteLine(PrintCards(Dealer.Hand, false));

                Console.WriteLine();
                Console.WriteLine("== Player Cards ==");
                Console.WriteLine(PrintCards(Player.Hand, false));
                Console.WriteLine();

                if (Dealer.Hand.BestTotal() > 21)
                {
                    Console.WriteLine("The dealer has busted, the player won!");

                    dealerDone = true;
                    playerWon = true;
                }
                else if ((Dealer.Hand.BestTotal() == 17 && Dealer.Hand.IsSoft) || Dealer.Hand.BestTotal() < 17)
                {
                    Console.WriteLine("Dealer must hit on 16 and less or soft 17!");
                    Dealer.Hand.AddCard(deck.DrawCard());
                    dealerDone = false;

                    Console.WriteLine("Press any button for the Dealer to draw!");
                    Console.ReadLine();
                }
                else
                {
                    dealerDone = true;

                    Console.WriteLine();
                    if (Dealer.Hand.BestTotal() > Player.Hand.BestTotal())
                    {
                        Console.WriteLine("The dealer won!");
                    }
                    else if (Dealer.Hand.BestTotal() < Player.Hand.BestTotal())
                    {
                        Console.WriteLine("The player won!");
                    }
                    else
                    {
                        Console.WriteLine("Push - there is no winner!");
                    }
                }
            }

            if (playerWon)
            {
                Player.Money += bet;
            }
            if (!playerWon && Dealer.Hand.BestTotal() != Player.Hand.BestTotal())
            {
                Player.Money -= bet;
            }

            Console.WriteLine($"Player Money: ${Player.Money}.00");
            Console.WriteLine();

            Console.WriteLine("The hand is over, press any button to play again!");
            Console.ReadLine();
        }

        public bool PlayerAction(Player player, Deck deck)
        {
            Console.WriteLine("Enter [S] to stand or [H] to hit!");
            bool validAction = false;
            while (validAction == false)
            {
                Console.Write("Action: ");

                string action = Console.ReadLine();

                if (string.Compare(action, "H", true) == 0)
                {
                    Console.WriteLine("Drawing a new card.....");
                    Console.WriteLine();
                    player.Hand.AddCard(deck.DrawCard());

                    return false;
                }
                else if (string.Compare(action, "S", true) == 0)
                {
                    Console.WriteLine("You are standing.....");
                    Console.WriteLine();
                    return true;
                }
                else
                {
                    Console.WriteLine("You can only enter S or H for an action!!!!");
                }
            }

            return false;
        }

        public string PrintCards(Hand hand, bool hide = false)
        {
            StringBuilder sb = new StringBuilder();

            if (hide)
            {
                for (int line = 1; line <= 5; line++)
                {
                    sb.Append(hand.Cards.First().PrintCard(line, false) + " ");
                    sb.AppendLine(string.Join(" ", hand.Cards.Skip(1).Select(x => x.PrintCard(line))));
                }
            }
            else
            {
                for (int line = 1; line <= 5; line++)
                {
                    sb.AppendLine(string.Join(" ", hand.Cards.Select(x => x.PrintCard(line))));
                }
            }

            if (hide)
            {
                sb.AppendLine($"Hand = {hand.Cards.Last().Value}?");
            }
            else
            {
                sb.AppendLine($"Hand = {hand.BestTotal()}");
            }
            
            return sb.ToString();           
        }

        public string GetLogo()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(@"______ _            _      ___            _    ");
            sb.AppendLine(@"| ___ \ |          | |    |_  |          | |   ");
            sb.AppendLine(@"| |_/ / | __ _  ___| | __   | | __ _  ___| | __");
            sb.AppendLine(@"| ___ \ |/ _` |/ __| |/ /   | |/ _` |/ __| |/ /");
            sb.AppendLine(@"| |_/ / | (_| | (__|   </\__/ / (_| | (__|   < ");
            sb.AppendLine(@"\____/|_|\__,_|\___|_|\_\____/ \__,_|\___|_|\_\");

            return sb.ToString();
        }
    }
}
