using System;
using System.Threading;

namespace Cardgame.UI
{
    public class DealerUI
    {
        Dealer dealer;
        public DealerUI(Dealer dealer)
        {
            this.dealer = dealer;
        }
        public void start()
        {
            while (true)
            {
                showMenu(menupoints);
                Console.WriteLine();
                Console.Write("Type in your choice: ");
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "0":
                        {
                            Environment.Exit(0);
                            break;
                        }
                    case "1":
                        {
                            dealer.myDeck.Shuffle();
                            dealer.AddPlayers();
                            dealer.param = dealer.myDeck.GetParameters();
                            dealer.Dealing();
                            dealer.Play(dealer.ChooseFirtsPlayer());
                            dealer.myDeck.ResetDeck();
                            break;
                        }
                    case "2":
                        {
                            if (dealer.CheckPlayersExist())
                            {
                                dealer.myDeck.Shuffle();
                                dealer.Dealing();
                                dealer.Play(dealer.ChooseFirtsPlayer());
                                dealer.myDeck.ResetDeck();
                            }
                            else
                            {
                                Console.WriteLine("There are no current players. Start a new game.");
                                Thread.Sleep(2000);
                            }
                            break;
                        }
                }
            }
        }
        private void showMenu(string[] menupoints)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Game of Torque!");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
            foreach (string point in menupoints)
            {
                Console.WriteLine(point);
            }
        }
        string[] menupoints = new string[]
            {
                "(1) New Play",
                "(2) Another game with current players",
                "(0) End Program"
            };
    }
}
