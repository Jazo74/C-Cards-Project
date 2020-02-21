using System;

namespace Cardgame
{
    class Program
    {
        static void Main(string[] args)
        {
            Deck deck = new Deck("cards.csv");
            Dealer dealer = new Dealer(deck);
            dealer.start();
        }
    }
}
    
