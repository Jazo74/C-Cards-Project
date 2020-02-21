using System;
using Cardgame.UI;

namespace Cardgame.Core
{
    class Program
    {
        static void Main(string[] args)
        {
            Deck deck = new Deck("cards.csv");
            Dealer dealer = new Dealer(deck);
            DealerUI dealerUI = new DealerUI(dealer);
            dealerUI.start();
        }
    }
}
    
